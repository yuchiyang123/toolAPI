using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using blog.Common.Enum;
using blog.Common.Helper;
using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using blog.Dtos.Page;
using blog.Entities;
using blog.Entities.Judge;
using blog.Repository;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;

namespace blog.Services
{
    public class JudgeService(
        IMapper mapper,
        IDistributedCache cache,
        JudgeRepository repository,
        JuageHelper helper,
        BlogContext context
    )
    {
        private readonly DockerClient _docker = new DockerClientConfiguration(
            new Uri("npipe://./pipe/docker_engine")
        ).CreateClient();

        private async Task<JudgeResult> RunAsync(
            JudgeLanguageEnum languageEnum,
            string code,
            CancellationToken ct = default
        )
        {
            return await RunAsync(new JudgeDto { Code = code, Language = languageEnum }, ct);
        }

        public async Task<JudgeResult> RunAsync(JudgeDto dto, CancellationToken ct = default)
        {
            var (image, fileName, cmd) = JudgeConfig.Config[dto.Language];

            var jobId = Guid.NewGuid().ToString();
            var tempDir = Path.Combine(@"C:\PushAPI\judgeTemp", jobId);
            Directory.CreateDirectory(tempDir);
            await File.WriteAllTextAsync(Path.Combine(tempDir, fileName), dto.Code, ct);

            try
            {
                var localImages = JudgeConfig.LocalImages;

                if (!localImages.Contains(image))
                {
                    var (fromImage, tag) = image.Split(':') is [var f, var t]
                        ? (f, t)
                        : (image, "latest");
                    await _docker.Images.CreateImageAsync(
                        new ImagesCreateParameters { FromImage = fromImage, Tag = tag },
                        null,
                        new Progress<JSONMessage>(),
                        ct
                    );
                }

                var pidsLimit = dto.Language switch
                {
                    JudgeLanguageEnum.csharp => 200L,
                    _ => 50L,
                };

                var container = await _docker.Containers.CreateContainerAsync(
                    new CreateContainerParameters
                    {
                        Image = image,
                        Cmd = ["sh", "-c", cmd],
                        HostConfig = new HostConfig
                        {
                            Binds = [$"{tempDir}:/code"],
                            NetworkMode = "none",
                            Memory = 128 * 1024 * 1024,
                            PidsLimit = pidsLimit,
                            AutoRemove = false,
                        },
                    }
                );

                await _docker.Containers.StartContainerAsync(container.ID, null, ct);

                var waitTimeout = dto.Language switch
                {
                    JudgeLanguageEnum.csharp => TimeSpan.FromSeconds(15),
                    JudgeLanguageEnum.python => TimeSpan.FromSeconds(15),
                    _ => TimeSpan.FromSeconds(15),
                };

                ContainerWaitResponse? waitResult = null;
                try
                {
                    using var cts = new CancellationTokenSource(waitTimeout);
                    waitResult = await _docker.Containers.WaitContainerAsync(
                        container.ID,
                        cts.Token
                    );
                }
                catch (OperationCanceledException)
                {
                    await _docker.Containers.RemoveContainerAsync(
                        container.ID,
                        new ContainerRemoveParameters { Force = true },
                        ct
                    );
                    return new JudgeResult
                    {
                        Stdout = string.Empty,
                        Stderr = JudgeErrorMsg.Time_Limit_Exceeded.ToString(),
                    };
                }

                var logs = await _docker.Containers.GetContainerLogsAsync(
                    container.ID,
                    false,
                    new ContainerLogsParameters { ShowStdout = true, ShowStderr = true },
                    ct
                );

                var (stdout, stderr) = await logs.ReadOutputToEndAsync(default);

                await _docker.Containers.RemoveContainerAsync(
                    container.ID,
                    new ContainerRemoveParameters { Force = true },
                    ct
                );

                if (waitResult.StatusCode == (int)JudgeStatusCodeEnum.Timeout)
                {
                    return new JudgeResult
                    {
                        Stdout = string.Empty,
                        Stderr = JudgeErrorMsg.Time_Limit_Exceeded.ToString(),
                    };
                }

                return new JudgeResult { Stdout = stdout, Stderr = stderr };
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        public async Task<PageResponseDto<ProblemsList>> GetProblemListAsync(
            ProblemsListQuery query,
            CancellationToken ct = default
        )
        {
            var filterSHA = PageHelper.ComputeFilterHash(query);
            return await repository
                .GetProblemList()
                .ProjectTo<ProblemsList>(mapper.ConfigurationProvider)
                .ToPageResponseDtoWithCache(
                    query.PageIndex,
                    query.PageSize,
                    PageEnums.ProblemsList,
                    filterSHA,
                    cache,
                    ct: ct
                );
        }

        public async Task<ProblemDetail> GetProblemDetailAsync(int id)
        {
            var needCombleData = await repository
                .GetComieDataAsQueryable()
                .Where(x => x.ProblemId == id)
                .ProjectTo<ParameterTypeDto>(mapper.ConfigurationProvider)
                .ToListAsync();
            var combinStartCodes = helper.CombinStratCode(needCombleData);
            var dto =
                await repository
                    .GetProblemDetail()
                    .Where(x => x.Id == id)
                    .ProjectTo<ProblemDetail>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException();

            var jsonValueInput = GetJsonValueByCases(dto.TestCases);
            dto.StartCodes = combinStartCodes;
            dto.TestCases = jsonValueInput;
            return dto;
        }

        private static List<TestCases>? GetJsonValueByCases(List<TestCases>? cases)
        {
            if (cases == null)
                return null;
            foreach (var item in cases)
            {
                var jsonObjcets = Newtonsoft.Json.JsonConvert.DeserializeObject<
                    Dictionary<string, object>
                >(item.Input);
                if (jsonObjcets == null)
                    continue;
                string inputStr = BuildTestCaseInputArgs(jsonObjcets);
                item.Input = inputStr;
            }
            return cases;
        }

        private static string BuildTestCaseInputArgs(Dictionary<string, object> jsonObjectDic)
        {
            bool isNeedComma = false;
            var inputStr = string.Empty;
            foreach (var json in jsonObjectDic)
            {
                if (json.Value == null)
                    continue;

                string valueStr;
                if (json.Value is Newtonsoft.Json.Linq.JToken token)
                {
                    valueStr = token.ToString(Newtonsoft.Json.Formatting.None);
                }
                else
                {
                    valueStr = json.Value.ToString()!;
                }

                inputStr += isNeedComma ? "," + valueStr : valueStr;
                isNeedComma = true;
            }
            return inputStr;
        }

        public async Task<SubmissionResponse> GetJudgeResultById(
            JudgeRequestDto dto,
            CancellationToken ct = default
        )
        {
            var entity =
                await repository
                    .GetProblemsFeature(dto.Language)
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException();

            var functionName = entity.ProblemSignatures.First().FunctionName;
            var testList = entity
                .Functions.Select(x => new TestCode { Id = x.Id, Input = x.Input })
                .ToList();
            foreach (var code in testList)
            {
                var jsonObjcets = Newtonsoft.Json.JsonConvert.DeserializeObject<
                    Dictionary<string, object>
                >(code.Input);
                if (jsonObjcets == null)
                    continue;
                var testStr = string.Empty;
                bool isNeedComma = false;
                foreach (var json in jsonObjcets)
                {
                    string valueStr;
                    var token = json.Value as JToken ?? JToken.FromObject(json.Value);

                    valueStr = token.Type switch
                    {
                        JTokenType.String => $"\"{token.Value<string>()}\"",
                        JTokenType.Array => token.ToString(Newtonsoft.Json.Formatting.None),
                        JTokenType.Object => token.ToString(Newtonsoft.Json.Formatting.None),
                        _ => token.ToString(), // int, bool, float 直接輸出
                    };

                    testStr += isNeedComma ? "," + valueStr : valueStr;
                    isNeedComma = true;
                }
                code.Input = functionName + "(" + testStr + ")";
            }
            var testCode = testList.ToDictionary(x => x.Id, x => x.Input);
            var expectedResult = entity.Functions.ToDictionary(x => x.Id, x => x.Expected);
            var splicingCode = helper.SplicingTestAndCode(dto.Language, dto.Code, testCode);
            var resultDto = await RunAsync(dto.Language, splicingCode, ct);
            var results = resultDto.Stdout?.Split(JuageHelper.SplitSpecialSymbols);
            if (results == null)
            {
                SubmissionStatus status =
                    resultDto.Stderr == JudgeErrorMsg.Time_Limit_Exceeded.ToString()
                        ? SubmissionStatus.TLE
                        : SubmissionStatus.RE;
                context.Submissions.Add(CombinationSubmission(dto, status, null));
                await context.SaveChangesAsync(ct);
                var testResultDtoForNull = await GetTestResultDto(dto.Id, dto.Language, ct);
                testResultDtoForNull.ErrorMessage = resultDto.Stderr;
                return testResultDtoForNull;
            }
            List<JudgeResultReponse> testResultCase = [];
            string pattern = @"===(.+?)_(.+?)===(.+)";
            foreach (var result in results)
            {
                var match = Regex.Match(result, pattern);
                if (match.Success)
                {
                    int id = int.Parse(match.Groups[2].Value);
                    string testResultSymbol = match.Groups[1].Value;
                    string testResult = JsonSerializer.Serialize(match.Groups[3].Value);
                    testResultCase.Add(
                        new JudgeResultReponse
                        {
                            Id = id,
                            Output = JsonSerializer.Deserialize<string>(testResult) ?? string.Empty,
                            IsPassed = ComparisonResult(
                                expectedResult,
                                id,
                                testResult,
                                testResultSymbol
                            ),
                        }
                    );
                }
            }

            SubmissionStatus nobuildErrorStatus = testResultCase.Any(x => !x.IsPassed)
                ? SubmissionStatus.WA
                : SubmissionStatus.AC;

            var addEntity = CombinationSubmission(dto, nobuildErrorStatus, testResultCase);
            context.Submissions.Add(addEntity);
            await context.SaveChangesAsync(ct);
            var testResultDto = await GetTestResultDto(dto.Id, dto.Language, ct);
            testResultDto.ErrorMessage = resultDto.Stderr;
            testResultDto.Results = GetJsonValueByResultCases(testResultDto.Results);
            return testResultDto;
        }

        private static List<SubmissionResultDto>? GetJsonValueByResultCases(
            List<SubmissionResultDto>? cases
        )
        {
            if (cases == null)
                return null;
            foreach (var item in cases)
            {
                if (item.Input == null)
                    continue;
                var jsonObjcets = Newtonsoft.Json.JsonConvert.DeserializeObject<
                    Dictionary<string, object>
                >(item.Input);
                if (jsonObjcets == null)
                    continue;
                string inputStr = BuildTestCaseInputArgs(jsonObjcets);

                item.Input = inputStr;
            }

            return cases;
        }

        private async Task<SubmissionResponse> GetTestResultDto(
            int id,
            JudgeLanguageEnum judgeLanguage,
            CancellationToken ct
        )
        {
            var testResponseEntity = await repository
                .GetTestResultAsQueryable(id, judgeLanguage)
                .FirstOrDefaultAsync(x => x.Id == id, ct);
            return mapper.Map<SubmissionResponse>(testResponseEntity);
        }

        private static bool ComparisonResult(
            Dictionary<int, string> expectedResult,
            int id,
            string testValue,
            string testSymbol
        )
        {
            if (
                !expectedResult.TryGetValue(id, out var expected)
                || testSymbol == TestResultSymbolEnum.ERROR.ToString()
            )
                return false;
            var jsonStrForExpected = JsonSerializer.Serialize(expected);
            if (jsonStrForExpected.Replace(" ", "") != testValue.Replace(" ", ""))
                return false;
            return true;
        }

        private static Submission CombinationSubmission(
            JudgeRequestDto dto,
            SubmissionStatus status,
            List<JudgeResultReponse>? result,
            int userId = 2
        )
        {
            return new Submission
            {
                ProblemId = dto.Id,
                Language = dto.Language,
                Code = dto.Code,
                Status = status,
                PassedCount = result?.Count(x => x.IsPassed) ?? 0,
                TotalCount = result?.Count ?? 0,
                UserId = userId, // 先寫hard code 之後放上 Auth
                SubmissionResults =
                    result == null
                        ? new List<SubmissionResult>()
                        :
                        [
                            .. result.Select(x => new SubmissionResult
                            {
                                FunctionId = x.Id,
                                ActualOutput = x.Output,
                                IsPassed = x.IsPassed,
                            }),
                        ],
            };
        }
    }
}

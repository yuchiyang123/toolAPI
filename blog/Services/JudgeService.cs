using blog.Common.Enum;
using blog.Common.Helper.Key;
using blog.Dtos.Judge;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace blog.Services
{
    public class JudgeService
    {
        private readonly DockerClient _docker = new DockerClientConfiguration(
            new Uri("npipe://./pipe/docker_engine")
        ).CreateClient();

        public async Task<JudgeResult> RunAsync(JudgeDto dto)
        {
            var (image, fileName, cmd) = JudgeConfig.Config[dto.Language];

            var jobId = Guid.NewGuid().ToString();
            var tempDir = Path.Combine(@"C:\PushAPI\judgeTemp", jobId);
            Directory.CreateDirectory(tempDir);
            await File.WriteAllTextAsync(Path.Combine(tempDir, fileName), dto.Code);

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
                        new Progress<JSONMessage>()
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

                await _docker.Containers.StartContainerAsync(container.ID, null);

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
                        new ContainerRemoveParameters { Force = true }
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
                    new ContainerLogsParameters { ShowStdout = true, ShowStderr = true }
                );

                var (stdout, stderr) = await logs.ReadOutputToEndAsync(default);

                await _docker.Containers.RemoveContainerAsync(
                    container.ID,
                    new ContainerRemoveParameters { Force = true }
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
    }
}

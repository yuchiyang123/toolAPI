using System.ComponentModel;
using blog.Dtos.Judge;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.CodeAnalysis.Emit;

namespace blog.Services
{
    public class JudgeService
    {
        private readonly DockerClient _docker = new DockerClientConfiguration(
            new Uri("npipe://./pipe/docker_engine")
        ).CreateClient();

        public async Task<JudgeResult> RunAsync(JudgeDto dto)
        {
            var (image, fileName, cmd) = dto.Language switch
            {
                "python" => ("python:3.12-alpine", "main.py", "timeout 10 python /code/main.py"),
                "csharp" => ("judge-csharp:latest", "main.cs", "timeout 60 sh -c 'cp /template/template.csproj /code/ && cp /code/main.cs /code/Program.cs && rm /code/main.cs && cd /code && dotnet restore --source /root/.nuget/packages -v q 2>/dev/null && dotnet run --no-restore -v q'"),
                _ => throw new ArgumentException("Unsupported language")
            };

            var jobId = Guid.NewGuid().ToString();
            var tempDir = Path.Combine(@"C:\PushAPI\judgeTemp", jobId);
            Directory.CreateDirectory(tempDir);
            await File.WriteAllTextAsync(Path.Combine(tempDir, fileName), dto.Code);

            try
            {
                var localImages = new HashSet<string> { "judge-csharp:latest" };

                if (!localImages.Contains(image))
                {
                    var (fromImage, tag) = image.Split(':') is [var f, var t] ? (f, t) : (image, "latest");
                    await _docker.Images.CreateImageAsync(
                        new ImagesCreateParameters { FromImage = fromImage, Tag = tag },
                        null,
                        new Progress<JSONMessage>()
                    );
                }

                var pidsLimit = dto.Language switch
                {
                    "csharp" => 200L,
                    _ => 50L
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
                    "csharp" => TimeSpan.FromSeconds(75),
                    _ => TimeSpan.FromSeconds(15)
                };

                ContainerWaitResponse? waitResult = null;
                try
                {
                    using var cts = new CancellationTokenSource(waitTimeout);
                    waitResult  = await _docker.Containers.WaitContainerAsync(container.ID, cts.Token);
                }
                catch (OperationCanceledException)
                {
                    await _docker.Containers.RemoveContainerAsync(container.ID, new ContainerRemoveParameters { Force = true });
                    return new JudgeResult { Stdout = "", Stderr = "Time Limit Exceeded" };
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

                if (waitResult.StatusCode == 124)
                {
                    return new JudgeResult { Stdout = "", Stderr = "Time Limit Exceeded" };
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

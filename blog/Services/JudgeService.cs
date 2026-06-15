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

        public async Task<JudgeResult> RunAsync(string code)
        {
            var jobId = Guid.NewGuid().ToString();
            var tempDir = Path.Combine(Path.GetTempPath(), jobId);
            Directory.CreateDirectory(tempDir);
            await File.WriteAllTextAsync(Path.Combine(tempDir, "main.py"), code);

            try
            {
                await _docker.Images.CreateImageAsync(
                    new ImagesCreateParameters { FromImage = "python", Tag = "3.12-alpine" },
                    null,
                    new Progress<JSONMessage>()
                );

                var container = await _docker.Containers.CreateContainerAsync(
                    new CreateContainerParameters
                    {
                        Image = "python:3.12-alpine",
                        Cmd = ["sh", "-c", "timeout 10 python /code/main.py"],
                        HostConfig = new HostConfig
                        {
                            Binds = [$"{tempDir}:/code"],
                            NetworkMode = "none",
                            Memory = 128 * 1024 * 1024,
                            PidsLimit = 50,
                            AutoRemove = false,
                        },
                    }
                );

                await _docker.Containers.StartContainerAsync(container.ID, null);
                await _docker.Containers.WaitContainerAsync(container.ID);

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

                return new JudgeResult { Stdout = stdout, Stderr = stderr };
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }
    }
}

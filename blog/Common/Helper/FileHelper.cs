using blog.Entities;

namespace blog.Common.Helper
{
    public class FileHelper(BlogContext context, IConfiguration configuration)
    {
        private const long MaxFileSizeBytes = 5 * 1024 * 1024;

        private static readonly HashSet<string> AllowedExtensions = new(
            StringComparer.OrdinalIgnoreCase
        )
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".webp",
            ".gif",
        };

        private readonly string _filePath =
            configuration["File:BasePath"]
            ?? (
                OperatingSystem.IsWindows()
                    ? @"C:\PushAPI\files"
                    : Path.Combine(AppContext.BaseDirectory, "files")
            );

        public async Task<int> SaveFileAsync(IFormFile file)
        {
            if (file.Length <= 0)
                throw new ArgumentException("檔案為空");
            if (file.Length > MaxFileSizeBytes)
                throw new ArgumentException(
                    $"檔案大小超過上限 {MaxFileSizeBytes / 1024 / 1024} MB"
                );

            var ext = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(ext) || !AllowedExtensions.Contains(ext))
                throw new ArgumentException(
                    $"不支援的檔案格式，僅允許：{string.Join(", ", AllowedExtensions)}"
                );

            var fileName = $"{Guid.NewGuid()}{ext.ToLowerInvariant()}";
            var path = Path.Combine(_filePath, fileName);

            // 確保目錄存在
            Directory.CreateDirectory(_filePath);

            using (var fileStream = File.Create(path))
            {
                await file.CopyToAsync(fileStream);
            }

            var fileEntity = new Files { Path = $"/files/{fileName}", FileName = fileName };

            context.Files.Add(fileEntity);

            await context.SaveChangesAsync();
            return fileEntity.Id;
        }

        public async Task DeleteFileAsync(int id)
        {
            var file =
                await context.Files.FindAsync(id)
                ?? throw new KeyNotFoundException($"找不到檔案 {id}");

            // 刪除檔案
            var filePath = Path.Combine(_filePath, file.FileName);
            if (File.Exists(filePath))
                File.Delete(filePath);

            context.Files.Remove(file);
            await context.SaveChangesAsync();
        }
    }
}

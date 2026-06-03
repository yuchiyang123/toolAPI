using blog.Entities;

namespace blog.Common.Helper
{
    public class FileHelper(BlogContext context, IConfiguration configuration)
    {
        private readonly string _filePath = configuration["File:BasePath"]!;

        public async Task<int> SaveFileAsync(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{ext}";
            var path = Path.Combine(_filePath, fileName);

            // 確保目錄存在
            Directory.CreateDirectory(_filePath);

            using (var fileStream = System.IO.File.Create(path))
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
            var file = await context.Files.FindAsync(id) ?? throw new NotImplementedException();

            // 刪除檔案
            var filePath = Path.Combine(_filePath, file.FileName);
            if (File.Exists(filePath))
                File.Delete(filePath);

            context.Files.Remove(file);
        }
    }
}

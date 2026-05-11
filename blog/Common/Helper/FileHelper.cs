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

            context.Files.Add(new Files
            {
                Path = path,
                FileName = fileName,
            });

            return await context.SaveChangesAsync();
        }
    }
}

using Microsoft.AspNetCore.Http;

namespace Uplay.Application.Extensions
{
    public static class FileExtensions
    {
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
        public static string GetFileExtension(this IFormFile file)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            return Path.GetExtension(file.FileName);
        }

        public static double GetFileSize(this IFormFile file)
        {
            return file?.Length / 1024.0 ?? 0;
        }
    }
}

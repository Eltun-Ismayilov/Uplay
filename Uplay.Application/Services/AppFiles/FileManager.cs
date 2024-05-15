using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Domain.Entities.Models.Miscs;
using Uplay.Persistence.Data;

namespace Uplay.Application.Services.AppFiles
{
    public class FileManager : IFileService
    {
        private readonly AppDbContext _dbContext;
        private const string _tempFolder = "uploads";
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), _tempFolder);
        public FileManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<FileStream> GetPhoto(string cyrptedPhoto)
        {
            var photoId = GetIdFromEncryptedString(cyrptedPhoto);
            var file = await _dbContext.Files.FirstOrDefaultAsync(x => x.Id == photoId);

            if (file == null)
                throw new NotFoundException("File tapilmadi");

            var photofullPath = Path.Combine(_filePath, file.Path);
            var str = File.OpenRead(photofullPath);
            return str;
        }
        public async Task<AppFile> UploadPhoto(IFormFile file)
        {
            AppFile photo = new()
            {
                Name = file.FileName,
                Path = file.SaveFileToFolderAndGetPath(),
                CreatedDate = DateTime.UtcNow,
            };

            return photo;
        }
        private int GetIdFromEncryptedString(string cyrpted) => int.Parse(CryptHelper.Decrypt(HttpUtility.UrlDecode(cyrpted)).Split('-')[0]);
    }
}

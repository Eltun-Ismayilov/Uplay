using Microsoft.AspNetCore.Http;
using Uplay.Domain.Entities.Models;

namespace Uplay.Application.Services.File
{
    public interface IFileService : IBaseService
    {
        Task<AppFile> UploadPhoto(IFormFile file);
        Task<FileStream> GetPhoto(string cyrptedPhoto);
    }
}

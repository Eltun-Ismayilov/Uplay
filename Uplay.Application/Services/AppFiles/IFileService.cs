using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Application.Services.AppFiles
{
    public interface IFileService : IBaseService
    {
        Task<AppFile> UploadPhoto(IFormFile file);
        Task<FileStream> GetPhoto(string cyrptedPhoto);
    }
}

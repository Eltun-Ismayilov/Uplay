using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Models.Minio;

namespace Uplay.Application.Services.MinioFile
{
    public interface IMinioService : IBaseService
    {
        string GenerateFileUrl(string token);
        Task<GetFileResponse> GetObject(string token);
        Task<string> PutObject(UploadFileDto request);
        Task<string> PutObject(string base64, string contentType);
    }
}

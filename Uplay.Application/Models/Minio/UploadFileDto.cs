using Microsoft.AspNetCore.Http;

namespace Uplay.Application.Models.Minio
{
    public class UploadFileDto
    {
        public UploadFileDto(IFormFile? file)
        {
            File = file;
        }

        public IFormFile? File { get; set; }
    }
}

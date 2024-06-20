using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Services.AppFiles;
using static System.Net.Mime.MediaTypeNames;

namespace Uplay.Api.Controllers.v1
{
    public class FileController : BaseController
    {
        private readonly IFileService _imageService;
        public FileController(IFileService imageService)
        {
            _imageService = imageService;
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.FileRoute.Create)]
        public async Task<IActionResult> Create(IFormFile file)
        {
            await _imageService.UploadPhoto(file);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.FileRoute.GetAll)]
        public async Task<object> GetAll(string cyrptedPhoto)
        {
            var data = await _imageService.GetPhoto(cyrptedPhoto);
            return File(data, Image.Jpeg);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Uplay.Application.Extensions;
using Uplay.Application.Services.MinioFile;
using Uplay.Domain.Entities.Models;
using Uplay.Persistence.Repository.Concrete;

namespace Uplay.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IMinioService _minioService;
        private readonly AppFileRepository _appFileRepository;
        public FileController(IMinioService minioService,
            AppFileRepository appFileRepository)
        {
            _minioService = minioService;
            _appFileRepository = appFileRepository;
        }

        [HttpGet("{token}")]

        public async Task<ActionResult> GetFile([FromRoute] string token)
        {
            var response = await _minioService.GetObject(token);

            //var url =  _minioService.GenerateFileUrl(token);

            //return Ok(url);
            return File(response.Bytes, response.ContentType);
        }

        [HttpPost]
        [Route("download")]
        public async Task<ActionResult> DownloadFile(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("Invalid file");
            }

            try
            {
                var token = await _minioService.PutObject(new(file));

                var appFile = new AppFile
                {
                    Token = token,
                    Name = file.FileName,
                    Size = file.Length
                };

                await _appFileRepository.InsertAsync(appFile,true);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

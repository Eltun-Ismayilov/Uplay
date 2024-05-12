using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uplay.Application.Extensions
{
    public static class FileHelperExtension
    {
        private const string _tempFolder = "wwwroot";
        private const string _folderPhoto = "uploads";
        private const string _tempFolderVideo = "Video";
        private const string _tempFolderResume = "Resume";
        private const string _tempFolderFile = "File";

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        private static string baseUrl = string.Empty;
        public const string Getphoto = Base + "/file/GetPhoto/{cyrptedPhoto}";
        public static string SaveFileToFolderAndGetPath(this IFormFile file, FileType fileType = FileType.Photo)
        {
            string directory = fileType switch
            {
                FileType.Photo => Path.Combine(Directory.GetCurrentDirectory(), _tempFolder, _folderPhoto),
                FileType.Video => Path.Combine(Directory.GetCurrentDirectory(), _tempFolder, _tempFolderVideo),
                FileType.Resume => Path.Combine(Directory.GetCurrentDirectory(), _tempFolder, _tempFolderResume),
                FileType.File => Path.Combine(Directory.GetCurrentDirectory(), _tempFolder, _tempFolderFile),
                _ => throw new NotSupportedException()
            };
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            return SaveFileAndGetPath(file, directory);
        }
        public static bool IsPhoto(this IFormFile file) => file.ContentType != null && (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png" || file.ContentType == "image/gif");
        private static string SaveFileAndGetPath(IFormFile file, string directory)
        {
            string filePath = string.Empty;
            if (file != null)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                filePath = Path.Combine(directory, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return filePath;
        }


        public enum FileType : byte
        {
            Photo = 10,
            Video = 20,
            Resume = 30,
            File = 40,
        }
    }
}

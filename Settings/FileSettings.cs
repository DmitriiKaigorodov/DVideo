using System.Collections.Generic;
using System.IO;
using System.Linq;
using DVideo.Core;
using DVideo.Core.FileStorage;
using Microsoft.AspNetCore.Http;

namespace DVideo.Settings
{
    public abstract class FileSettings
    {
        public readonly Dictionary<FileValidationResult, string> ErrorsDescriptions = new Dictionary <FileValidationResult, string>() 
        {
            [FileValidationResult.FileTooBig] = "File is too big",
            [FileValidationResult.UnsupportedFileExtention] = "Invalid file extention"
        };
        public long MaxBytes { get; set; }
        public string[] AllowedExtentions { get; set; }

        public virtual FileValidationResult Validate(IFormFile formFile)
        {
            if(formFile.Length >= MaxBytes)
                return FileValidationResult.FileTooBig;

            string fileExtention = Path.GetExtension(formFile.FileName).ToLowerInvariant();
            if(!AllowedExtentions.Any( ext => ext == fileExtention))
                return FileValidationResult.UnsupportedFileExtention;

            return FileValidationResult.Ok;
        }
    }
}
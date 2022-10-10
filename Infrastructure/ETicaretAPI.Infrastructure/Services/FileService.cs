using ETicaretAPI.Application.Operations;
using ETicaretAPI.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<bool> FileCreateAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo loglama mekanizmasını ekle
                throw ex;
            }

        }

        async Task<string> FileNameCreatorAsync(string fileName, string path)
        {
            string newName = await Task.Run<string>(async () =>
            {
                //jpg,png
                string extension = Path.GetExtension(fileName);
                //oldName
                string oldName = Path.GetFileNameWithoutExtension(fileName);

                string newFilename = $"{NameChanger.ChangeName(oldName)}_{DateTime.UtcNow.ToString("ddMMyyyyHHmmsss")}{extension}";

                return newFilename;
            });

            return newName;
        }

        public async Task<IList<(string fileName, string path)>> UploadFileAsync(string path, IFormFileCollection formFiles)
        {
            //wwwroot/resources/images
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }


            IList<(string fileName, string path)> a = new List<(string fileName, string path)>();
            List<bool> uploadedFiles = new();

            foreach (IFormFile file in formFiles)
            {

                var newName =await FileNameCreatorAsync(file.FileName, path);
                bool result = await FileCreateAsync($"{filePath}//{newName}", file);
                uploadedFiles.Add(result);
                a.Add(new(newName, $"{path}//{newName}"));

            }
            if (uploadedFiles.TrueForAll(u => u.Equals(true)))
                return a;
            return null;

        }
    }
}

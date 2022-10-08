using ETicaretAPI.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        public Task<string> FileNameCreatorAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<(string fileName, string path)>> UploadFileAsync(string path, IFormFileCollection formFiles)
        {
            //wwwroot ve gelen path
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }


            IList<(string fileName, string path)> a = new List<(string fileName, string path)>();
            List<bool> uploadedFiles = new();
            foreach (IFormFile file in formFiles)
            {
                
                var newName = await FileNameCreatorAsync(file.FileName);
                await FileCreateAsync($"{path}//{newName}", file);
                uploadedFiles.Add(true);
                if (uploadedFiles.TrueForAll(u => u.Equals(true)))
                a.Add(new(newName, $"{path}//{newName}"));

            }

            return a;
        }
    }
}

using ETicaretAPI.Application.Services.Storages.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Infrastructure.Services.Storages.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteFile(string path, string fileName)
        {
            await Task.Run(() => File.Delete($"{path}\\{fileName}"));
        }

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName) => File.Exists($"{path}\\{fileName}");

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

        public async Task<List<(string path, string fileName)>> UploadAsync(string path, IFormFileCollection formFiles)
        {
            //wwwroot/resources/images
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            List<(string fileName, string path)> datas = new();

            foreach (IFormFile file in formFiles)
            {
                //var newName = await FileNameCreatorAsync(file.FileName, path);
                bool result = await FileCreateAsync($"{filePath}/{file.Name}", file);
                datas.Add(new(file.Name, $"{path}//{file.Name}"));

            }
            return datas;
        }
    }
}

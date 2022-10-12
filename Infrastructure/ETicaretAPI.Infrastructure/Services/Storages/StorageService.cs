using ETicaretAPI.Application.Services.Storages;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Infrastructure.Services.Storages
{
    public class StorageService : IStorageService,IStorage
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName => _storage.GetType().Name;

        public async Task DeleteFile(string path, string fileName)
        {
            await _storage.DeleteFile(path, fileName);
        }



        public List<string> GetFiles(string path)
        {
          return _storage.GetFiles(path);
        }

        public bool HasFile(string path, string fileName)
        {
            return _storage.HasFile(path, fileName);
        }

        public async Task<List<(string path, string fileName)>> UploadAsync(string path, IFormFileCollection formFiles)
        {
            return await _storage.UploadAsync(path, formFiles);
        }
    }
}

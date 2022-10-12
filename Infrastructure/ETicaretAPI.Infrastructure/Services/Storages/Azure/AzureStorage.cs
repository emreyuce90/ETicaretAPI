using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ETicaretAPI.Application.Services.Storages.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Infrastructure.Services.Storages.Azure
{
    public class AzureStorage : Storage,IAzureStorage
    {

        private readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }
        public async Task DeleteFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient =_blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(b=>b.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);

        }

        public async Task<List<(string path, string fileName)>> UploadAsync(string containerName, IFormFileCollection formFiles)
        {
            //blobServiceClient ın içerisine verilen container get edilip containerClienta atanır
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            List<(string path, string fileName)> datas = new();

            foreach (IFormFile? file in formFiles)
            {
                //dosyaya yeni isim ver
                string newName = await FileNameCreatorAsync(file.FileName, containerName);
                BlobClient blobClient =_blobContainerClient.GetBlobClient(newName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add(($"{containerName}/{newName}", newName));
            }
            return datas;
        }
    }
}

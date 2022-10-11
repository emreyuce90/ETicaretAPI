using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Services.Storages
{
    public interface IStorage
    {
        /// <summary>
        /// Bir dosya yolu ve IFormFileCollection tipinde bir file alır geriye dosya yolunu ve dosya adını döner
        /// </summary>
        /// <param name="path">dosya yolunu belirtir Örn. resources/productImages</param>
        /// <param name="formFiles">dosyanın kendisidir </param>
        /// <returns></returns>
        Task<List<(string path, string fileName)>> UploadAsync(string path, IFormFileCollection formFiles);
        /// <summary>
        /// Kendisine verilen dosya yolundaki dosyaları geriye return eder
        /// </summary>
        /// <param name="path">Dosya yolu alır ,gelen dosya yolunda arama yapar</param>
        /// <returns></returns>
        List<string> GetFiles(string path);
        /// <summary>
        /// Dosya yolu ve dosya adını parametre olarak alır ve eğer bu bağlamda bir dosya var ise bool olarak sonucu geriye döner
        /// </summary>
        /// <param name="path">dosya yolu</param>
        /// <param name="fileName">dosya adı</param>
        /// <returns></returns>
        bool HasFile(string path, string fileName);
        /// <summary>
        /// Parametre olarak aldığı dosya yolundan parametre olarak aldığı dosya adını siler
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task DeleteFile(string path, string fileName);
    }
}

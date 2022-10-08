using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services
{
    public interface IFileService
    {
        /// <summary>
        /// Upload işlemini yapar ve geriye upload ettiği dosyaların adlarını ve yollarını liste olarak geriye döndürür
        /// </summary>
        /// <param name="path">Upload edilecek dosyanın yolu</param>
        /// <param name="formFiles">Upload edilecek dosya</param>
        /// <returns></returns>
        Task<IList<(string fileName, string path)>> UploadFileAsync(string path, IFormFileCollection formFiles);
        Task<string> FileNameCreatorAsync(string fileName);
        Task<bool> FileCreateAsync(string path, IFormFile file);

    }
}

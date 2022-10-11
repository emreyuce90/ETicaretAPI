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
    public class FileService
    {     
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
    }
}

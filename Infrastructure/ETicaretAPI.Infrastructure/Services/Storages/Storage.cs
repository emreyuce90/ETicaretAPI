using ETicaretAPI.Application.Operations;

namespace ETicaretAPI.Infrastructure.Services.Storages
{
    public class Storage
    {
        protected async Task<string> FileNameCreatorAsync(string fileName, string path)
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

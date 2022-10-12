namespace ETicaretAPI.Application.Services.Storages
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}

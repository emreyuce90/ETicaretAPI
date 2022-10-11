using ETicaretAPI.Application.Repositories.FileRepo;
using ETicaretAPI.Persistence.Context;
using File = ETicaretAPI.Domain.Entities.File;
namespace ETicaretAPI.Persistence.Repositories.FileRepo
{
    public class FileWriteRepository : WriteRepository<File>,IFileWriteRepository
    {
        public FileWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}

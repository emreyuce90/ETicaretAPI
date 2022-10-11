using ETicaretAPI.Application.Repositories.FileRepo;
using ETicaretAPI.Persistence.Context;
using File = ETicaretAPI.Domain.Entities.File;
namespace ETicaretAPI.Persistence.Repositories.FileRepo
{
    public class FileReadRepository : ReadRepository<File>,IFileReadReadRepository
    {
        public FileReadRepository(ETicaretAPIDbContext context) : base(context)
        {

        }
    }
}

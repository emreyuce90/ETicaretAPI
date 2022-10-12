using ETicaretAPI.Domain.Entities.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretAPI.Domain.Entities
{
    public class File:BaseEntity
    {
        [NotMapped]
        public override DateTime ModifiedDate { get => base.ModifiedDate; set => base.ModifiedDate = value; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string StorageName { get; set; }
    }
}

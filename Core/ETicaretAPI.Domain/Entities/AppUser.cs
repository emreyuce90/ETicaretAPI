using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Domain.Entities
{
    public class AppUser:IdentityUser<string>
    {
        public string NameSurname { get; set; }
    }
}

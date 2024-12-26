using Microsoft.AspNetCore.Identity;

namespace IdenApp.Models
{
    public class AppUser:IdentityUser
    {
        public int Age { get; set; }
    }
}

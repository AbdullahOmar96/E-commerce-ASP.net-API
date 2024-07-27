using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User : IdentityUser
    {
         
        public ICollection<Order> Orders { get; set; } 

    }
}

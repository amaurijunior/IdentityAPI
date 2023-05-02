using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Models
{
    public class User : IdentityUser
    {

        public DateTime BirthDate { get; set; }

        public User() : base() { }

    }   
}

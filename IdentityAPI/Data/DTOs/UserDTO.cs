using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace IdentityAPI.Data.DTOs
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }

    }
}

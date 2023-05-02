using System.ComponentModel.DataAnnotations;

namespace IdentityAPI.Data.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

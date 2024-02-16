using System.ComponentModel.DataAnnotations;

namespace IdentityAndAuth.Models
{
    public class SignUp
    {
        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage="Email is missing")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password,ErrorMessage ="Incorrect or missing password")]
        public string Password { get; set; }
    }
}

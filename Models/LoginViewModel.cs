using System.ComponentModel.DataAnnotations;

namespace MvcWebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(30, ErrorMessage = "Username must be 30 characters!")]
        public String? UserName { get; set; }


        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required!")]
        [MinLength(6, ErrorMessage = "Password must be minimum 6 charaters!")]
        [MaxLength(16, ErrorMessage = "Password must be max 16 charaters!")]
        public String? Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace MvcWebApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(30, ErrorMessage = "Username must be 30 characters!")]
        public String? UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [MinLength(6, ErrorMessage = "Password must be minimum 6 charaters!")]
        [MaxLength(16, ErrorMessage = "Password must be max 16 charaters!")]
        public String? Password { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "RePassword is required!")]
        [MinLength(6, ErrorMessage = "RePassword must be minimum 6 charaters!")]
        [MaxLength(16, ErrorMessage = "RePassword must be max 16 charaters!")]
        [Compare(nameof(Password))]//hatayı direkt bulmak için
        public string? RePassword { get; set; }
    }
}
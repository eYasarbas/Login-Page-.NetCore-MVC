using System.ComponentModel.DataAnnotations;

namespace MvcWebApp.Models
{
    public class LoginViewModel
    {
        //[Display(Name ="Kullanıcı Adı", Prompt ="johndoe")]
        [Required(ErrorMessage = "Username must be required!")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters!")]
        public string? Username { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Password must be required!")]
        [MinLength(6, ErrorMessage = "Password can be min 6 characters.")]
        [MaxLength(16, ErrorMessage = "Password can be max 16 characters.")]
        public string? Password { get; set; }
    }
}
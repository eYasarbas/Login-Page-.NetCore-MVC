using System.ComponentModel.DataAnnotations;

namespace MvcWebApp.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]

        public String? Fullname { get; set; }
        [Required]
        [StringLength(30)]

        public String? Username { get; set; }
        [Required]
        [StringLength(100)]
        public String? Password { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;


    }
}

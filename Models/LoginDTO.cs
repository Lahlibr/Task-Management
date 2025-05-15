using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

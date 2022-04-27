using System.ComponentModel.DataAnnotations;

namespace MicroService_Auth.Models
{
    public class AuthUser
    {
        public int Id { get; set; }
        [Required] public string Username { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
    }
}

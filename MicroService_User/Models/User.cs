using System.ComponentModel.DataAnnotations;

namespace MicroService_User.Models
{
    public class User
    {
        public int Id  { get; set; }

        [Required] public string Name { get; set; } = null!;
        public string? Address  { get; set; }
        public string? ProfileImage  { get; set; }
        
    }
}

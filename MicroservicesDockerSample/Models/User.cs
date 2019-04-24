using System.ComponentModel.DataAnnotations;

namespace MicroservicesDockerSample.Models
{
    public class User
    {
        public string UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}

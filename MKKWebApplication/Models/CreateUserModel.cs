using System.ComponentModel.DataAnnotations;

namespace MKKWebApplication.Models
{
    public class CreateUserModel
    {
        [Required]
        public string id { get; set; } = null!;
        [Required]
        public string username { get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;

        [Required]
        public string role { get; set; } = null!;
    }
}

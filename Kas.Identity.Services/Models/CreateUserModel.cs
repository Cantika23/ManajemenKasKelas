using System.ComponentModel.DataAnnotations;

namespace Kas.Identity.Services.Models
{
    public class CreateUserModel
    {
        [Required]
        public string id { get; set; } = null!;
        [Required]
        public string username { get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;

        public string role { get; set; } = null!;
    }
}

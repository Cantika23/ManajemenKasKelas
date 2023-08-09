using System.ComponentModel.DataAnnotations;

namespace Kas.Identity.Services.Models
{
    public class UpdateUserModel
    {
        public string id { get; set; }
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
        public string role { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Kas.Identity.Services.Models
{
    public class ReadUserModel
    {
        public string id { get; set; } = null!;
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
        public string role { get; set; } = null!;
    }
}

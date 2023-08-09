using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Identity.Domain.Entities
{
    public class User
    {
        public string? id { get; set; }
        public string username { get; set; } = null!;
        public string password { get; set; } = null!;
        public string roleId { get; set; }
        public Role? Role { get; set; }
    }
}

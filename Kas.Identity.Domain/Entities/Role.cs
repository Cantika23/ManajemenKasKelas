using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Identity.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string? Id { get; set; }
        public string role { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}

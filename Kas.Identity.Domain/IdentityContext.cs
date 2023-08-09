using Microsoft.EntityFrameworkCore;

namespace Kas.Identity.Domain
{
    public partial class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.User> Users { get; set; }
        public virtual DbSet<Entities.Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Mappings.UserMap());
            modelBuilder.ApplyConfiguration(new Mappings.RoleMap());

        }
    }
}
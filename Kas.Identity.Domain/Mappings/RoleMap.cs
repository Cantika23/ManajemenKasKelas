using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Identity.Domain.Mappings
{
    public partial class RoleMap : IEntityTypeConfiguration<Kas.Identity.Domain.Entities.Role>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kas.Identity.Domain.Entities.Role> builder)
        {
            builder.ToTable("TBL_ROLE", "dbo");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.role)
                .HasColumnName("ROLE_NAME")
                .HasColumnType("varchar(36)")
                .HasMaxLength(10);


            builder.HasMany(t => t.Users)
                .WithOne(t => t.Role)
                .HasForeignKey(d => d.roleId);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Identity.Domain.Mappings
{
    public partial class UserMap : IEntityTypeConfiguration<Kas.Identity.Domain.Entities.User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kas.Identity.Domain.Entities.User> builder)
        {
            builder.ToTable("TBL_USER", "dbo");
            builder.HasKey(t => t.id);

            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.username)
                .IsRequired()
                .HasColumnName("USERNAME")
                .HasColumnType("varchar(36)")
                .HasMaxLength(20);

            builder.Property(t => t.password)
                .IsRequired()
                .HasColumnName("PASSWORD")
                .HasColumnType("varchar(36)")
                .HasMaxLength(20);

            builder.Property(t => t.roleId)
                .HasColumnName("ROLE_ID")
                .HasColumnType("varchar(36)");

            builder.HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.roleId);

        }
    }
}

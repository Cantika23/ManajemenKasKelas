using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Transaksi.Domain.Mappings
{
    public partial class SiswaMap : IEntityTypeConfiguration<Kas.Transaksi.Domain.Entities.Siswa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kas.Transaksi.Domain.Entities.Siswa> builder)
        {
            builder.ToTable("TBL_SISWA", "dbo");
            builder.HasKey(t => t.id);

            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.nama_lengkap)
                .IsRequired()
                .HasColumnName("NAMA_LENGKAP")
                .HasColumnType("varchar(36)")
                .HasMaxLength(150);

            builder.Property(t => t.nama_lengkap)
                .IsRequired()
                .HasColumnName("NISN")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36);

            builder.Property(t => t.kelasId)
                .IsRequired()
                .HasColumnName("KELAS_ID")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36);

            builder.Property(t => t.tanggalLahir)
                .IsRequired()
                .HasColumnName("TANGGAL_LAHIR")
                .HasColumnType("datetime")
                .HasMaxLength(20);

            builder.HasOne(t => t.Kelas)
                .WithMany(t => t.Siswa)
                .HasForeignKey(d => d.kelasId);


        }
    }

}

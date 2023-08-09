using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Transaksi.Domain.Mappings
{
    public partial class PemasukanKasMap : IEntityTypeConfiguration<Kas.Transaksi.Domain.Entities.PemasukanKas>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kas.Transaksi.Domain.Entities.PemasukanKas> builder)
        {
            builder.ToTable("TBL_PEMASUKAN_KAS", "dbo");
            builder.HasKey(t => t.id);

            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.tanggalMasukKas)
                .IsRequired()
                .HasColumnName("TANGGAL")
                .HasColumnType("datetime");

            builder.Property(t => t.kelasId)
                .IsRequired()
                .HasColumnName("KELAS_ID")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36);

            builder.Property(t => t.nominalKas)
                .HasColumnName("JUMLAH")
                .HasColumnType("float");

            builder.Property(t => t.keterangan)
                .IsRequired()
                .HasColumnName("KETERANGAN")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.HasOne(t => t.Kelas)
                .WithMany(t => t.PemasukanKas)
                .HasForeignKey(d => d.kelasId);
        }
    }

}

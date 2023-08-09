using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Transaksi.Domain.Mappings
{
    public partial class PelaporanTransaksiMap : IEntityTypeConfiguration<Kas.Transaksi.Domain.Entities.PelaporanTransaksi>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kas.Transaksi.Domain.Entities.PelaporanTransaksi> builder)
        {
            builder.ToTable("TBL_PELAPORAN_TRANSAKSI", "dbo");
            builder.HasKey(t => t.id);

            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.tanggal)
                .IsRequired()
                .HasColumnName("TANGGAL")
                .HasColumnType("datetime");

            builder.Property(t => t.jumlahPemasukan)
                .HasColumnName("JUMLAH_PEMASUKAN")
                .HasColumnType("float");

            builder.Property(t => t.jumlahPengeluaran)
                .HasColumnName("JUMLAH_PENGELUARAN")
                .HasColumnType("float");

            builder.Property(t => t.jenisTransaksi)
                .HasColumnName("JENIS_TRANSAKSI")
                .HasColumnType("varchar(36)");

            builder.Property(t => t.keterangan)
                .HasColumnName("KETERANGAN")
                .HasColumnType("varchar(36)");

            builder.Property(t => t.kelasId)
                .IsRequired()
                .HasColumnName("KELAS_ID")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36);

            builder.HasOne(t => t.Kelas)
                .WithMany(t => t.PelaporanTransaksi)
                .HasForeignKey(d => d.kelasId);


        }
    }

}

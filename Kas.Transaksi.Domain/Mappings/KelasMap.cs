using Kas.Transaksi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Transaksi.Domain.Mappings
{
    public partial class KelasMap : IEntityTypeConfiguration<Kas.Transaksi.Domain.Entities.Kelas>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kas.Transaksi.Domain.Entities.Kelas> builder)
        {
            builder.ToTable("TBL_KELAS", "dbo");
            builder.HasKey(t => t.id);

            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("ID")
                .HasColumnType("varchar(36)")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.kelas)
                .IsRequired()
                .HasColumnName("KELAS")
                .HasColumnType("varchar(36)")
                .HasMaxLength(20);


            builder.HasMany(pemasukan => pemasukan.PemasukanKas)
                .WithOne(kelas => kelas.Kelas)
                .HasForeignKey(kelas => kelas.kelasId);

            builder.HasMany(pengeluaran => pengeluaran.PengeluaranKas)
                .WithOne(kelas => kelas.Kelas)
                .HasForeignKey(kelas => kelas.kelasId);

            builder.HasMany(pelaporanTransaksi => pelaporanTransaksi.PelaporanTransaksi)
                .WithOne(kelas => kelas.Kelas)
                .HasForeignKey(kelas => kelas.kelasId);


        }
    }

}

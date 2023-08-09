using Microsoft.EntityFrameworkCore;

namespace Kas.Transaksi.Domain
{
    public partial class TransaksiContext : DbContext
    {
        public TransaksiContext(DbContextOptions<TransaksiContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Entities.PengeluaranKas> PengeluaranKas { get; set; }
        public virtual DbSet<Entities.PemasukanKas>  PemasukanKas{ get; set; }
        public virtual DbSet<Entities.PelaporanTransaksi> PelaporanTransaksis { get; set; }
        public virtual DbSet<Entities.Kelas> Kelass { get; set; }
        public virtual DbSet<Entities.Siswa> Siswas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Mappings.PemasukanKasMap());
            modelBuilder.ApplyConfiguration(new Mappings.PengeluaranKasMap());
            modelBuilder.ApplyConfiguration(new Mappings.PelaporanTransaksiMap());
            modelBuilder.ApplyConfiguration(new Mappings.KelasMap());
            modelBuilder.ApplyConfiguration(new Mappings.SiswaMap());
        }
    }
}
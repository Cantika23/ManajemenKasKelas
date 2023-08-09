using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Transaksi.Domain.Entities
{
    public class Kelas
    {
        public Kelas()
        {
            PemasukanKas = new HashSet<PemasukanKas>();
            PengeluaranKas = new HashSet<PengeluaranKas>();
            PelaporanTransaksi = new HashSet<PelaporanTransaksi>();
            Siswa = new HashSet<Siswa>();
        }
        public string? id { get; set; }
        public string kelas  { get; set; } = null!;

        public ICollection<PemasukanKas> PemasukanKas { get; set; }
        public ICollection<PengeluaranKas> PengeluaranKas { get; set; }
        public ICollection<PelaporanTransaksi> PelaporanTransaksi { get; set; }
        public ICollection<Siswa> Siswa { get; set; }
    }
}

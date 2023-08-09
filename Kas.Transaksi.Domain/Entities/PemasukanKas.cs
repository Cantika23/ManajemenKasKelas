using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Transaksi.Domain.Entities
{
    public class PemasukanKas
    {
        public string? id { get; set; }
        public DateTime? tanggalMasukKas { get; set; }
        public double nominalKas { get; set; }
        public string keterangan { get; set; } = null!;
        public string kelasId { get; set; } // ForeignKey
        public Kelas Kelas { get; set; } // Navigation Property
    }
}

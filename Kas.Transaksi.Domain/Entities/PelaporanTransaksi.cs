using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Transaksi.Domain.Entities
{
    public class PelaporanTransaksi
    {

        public string? id { get; set; }
        public DateTime? tanggal { get; set; }
        public double jumlahPemasukan { get; set; }
        public double jumlahPengeluaran { get; set; }
        public string? jenisTransaksi { get; set; }
        public string? keterangan { get; set; }
        public string kelasId { get; set; } // ForeignKey
        public Kelas Kelas { get; set; } // Navigation Property

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kas.Transaksi.Domain.Entities
{
    public class Siswa
    {
        public string? id { get; set; }
        public string nama_lengkap { get; set; } = null!;
        public string kelasId { get; set; } = null!;
        public Kelas Kelas { get; set; } = null!;
        public string nisn { get; set; } = null!;
        public DateTime tanggalLahir { get; set; } 
    }
}

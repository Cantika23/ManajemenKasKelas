using Kas.Transaksi.Domain.Entities;

namespace Kas.Transaksi.Services.Models
{
    public class UpdateSiswaModel
    {
        public string? id { get; set; }
        public string nama_lengkap { get; set; } = null!;
        public string kelasId { get; set; } = null!;
        public Kelas Kelas { get; set; } = null!;
        public string nisn { get; set; } = null!;
        public DateTime tanggalLahir { get; set; }
    }
}

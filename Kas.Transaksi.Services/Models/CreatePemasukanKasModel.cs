namespace Kas.Transaksi.Services.Models
{
    public class CreatePemasukanKasModel
    {
        public string? id { get; set; }
        public DateTime? tanggalMasukKas { get; set; }
        public string kelasId { get; set; } = null!;
        public double nominalKas { get; set; }
        public string keterangan { get; set; } = null!;
    }
}

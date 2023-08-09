namespace Kas.Transaksi.Services.Models
{
    public class CreatePengeluaranModel
    {
        public string? id { get; set; }
        public DateTime? tanggalKasKeluar { get; set; }
        public double nominalKas { get; set; }
        public string keterangan { get; set; } = null!;
        public string kelasId { get; set; } = null!;
    }
}

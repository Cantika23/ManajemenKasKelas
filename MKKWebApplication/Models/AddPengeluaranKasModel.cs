namespace MKKWebApplication.Models
{
    public class AddPengeluaranKasModel
    {
        public string? id { get; set; }
        public DateTime? tanggalKasKeluar { get; set; }
        public string kelasId { get; set; } = null!;
        public double nominalKas { get; set; }
        public string keterangan { get; set; } = null!;
    }
}

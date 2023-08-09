namespace MKKWebApplication.Models
{
    public class AddPemasukanKasModel
    {
        public string? id { get; set; }
        public DateTime? tanggalMasukKas { get; set; }
        public string kelasId { get; set; } = null!;
        public double nominalKas { get; set; }
        public string keterangan { get; set; } = null!;
    }
}

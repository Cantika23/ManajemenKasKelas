namespace Kas.Transaksi.Services.Models
{
    public class ReadPengeluaranKasModel
    {
        public string? id { get; set; }
        public DateTime? tanggalKeluarKas { get; set; }
        public double nominalKas { get; set; }
        public string keterangan { get; set; } = null!;
        public string kelasId { get; set; } = null!;
    }
}

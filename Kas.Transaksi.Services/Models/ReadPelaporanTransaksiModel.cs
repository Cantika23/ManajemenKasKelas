namespace Kas.Transaksi.Services.Models
{
    public class ReadPelaporanTransaksiModel
    {
        public string? id { get; set; }
        public string? kelas { get; set; }
        public DateTime? tanggal { get; set; }
        public double jumlahPemasukan { get; set; }
        public double jumlahPengeluaran { get; set; }
        public string? jenisTransaksi { get; set; }
        public string? keterangan { get; set; }
    }
}

namespace Kas.Transaksi.Services.Models
{
    public class ResponseRincianKasModel
    {
        public List<ReadPemasukanKasModel> pemasukanKas { get; set; }
        public List<ReadPengeluaranKasModel> pengeluaranKas { get; set; }
    }
}

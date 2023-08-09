using Kas.Transaksi.Services.Models;

namespace Kas.Transaksi.Services.Repositories
{
    public interface IPelaporanTransaksiRepository
    {
        Task<List<ReadPelaporanTransaksiModel>> ReadPelaporanTransaksiAsync(DateTime startDate, DateTime endDate, string kelasId);
        Task<ResponseRincianKasModel> ReadRincianKasAsync();

    }
}

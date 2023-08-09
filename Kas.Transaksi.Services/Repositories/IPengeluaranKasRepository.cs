using Kas.Transaksi.Services.Models;

namespace Kas.Transaksi.Services.Repositories
{
    public interface IPengeluaranKasRepository
    {
        Task<string> CreatePengeluaranKasAsync(CreatePengeluaranModel model);

    }
}

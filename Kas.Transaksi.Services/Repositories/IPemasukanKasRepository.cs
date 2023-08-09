using Kas.Transaksi.Services.Models;

namespace Kas.Transaksi.Services.Repositories
{
    public interface IPemasukanKasRepository
    {
        Task<string> CreatePemasukanKasAsync(CreatePemasukanKasModel model);

    }
}

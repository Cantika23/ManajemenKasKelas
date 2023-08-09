using Kas.Transaksi.Services.Models;

namespace Kas.Transaksi.Services.Repositories
{
    public interface IKelasRepository
    {
        Task<string> CreateKelasAsync(CreateKelasModel model);
        Task<List<ReadKelasModel>> ReadKelasAsync();
        Task<string> UpdateKelasAsync(UpdateKelasModel model);
        Task<string> DeleteKelasAsync(string id);



    }
}

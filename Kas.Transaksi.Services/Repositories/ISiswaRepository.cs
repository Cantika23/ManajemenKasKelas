using Kas.Transaksi.Services.Models;

namespace Kas.Transaksi.Services.Repositories
{
    public interface ISiswaRepository
    {
        Task<string> CreateSiswaAsync(CreateSiswaModel model);
        Task<List<ReadSiswaModel>> ReadSiswaAsync();
        Task<string> UpdateSiswaAsync(UpdateSiswaModel model);
        Task<string> DeleteSiswaAsync(string id);


    }
}

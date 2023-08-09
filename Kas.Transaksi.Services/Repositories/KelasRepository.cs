using Kas.Transaksi.Domain;
using Kas.Transaksi.Domain.Entities;
using Kas.Transaksi.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace Kas.Transaksi.Services.Repositories
{
    public class KelasRepository : IKelasRepository
    {
        private readonly ILogger<KelasRepository> _logger;
        private readonly TransaksiContext _context;

        public KelasRepository(ILogger<KelasRepository> logger, TransaksiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<string> CreateKelasAsync(CreateKelasModel model)
        {
            try
            {
                var kelas = new Kelas()
                {
                    id = Guid.NewGuid().ToString(),
                    kelas = model.kelas
                };


                this._context.Add(kelas);
                await _context.SaveChangesAsync();

                return kelas.id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<string> DeleteKelasAsync(string id)
        {
            try
            {
                var agunan = await _context.Kelass.Where(x => x.id == id).ExecuteDeleteAsync();

                await _context.SaveChangesAsync();

                return "0";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<List<ReadKelasModel>> ReadKelasAsync()
        {
            try
            {
                var kelas = await _context.Kelass
                    .Select(x => new ReadKelasModel()
                    {
                        id = x.id,
                        kelas = x.kelas,
                    })
                    .ToListAsync();

                return kelas;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public async Task<string> UpdateKelasAsync(UpdateKelasModel model)
        {
            try
            {
                var dataKelas = await _context.Kelass.Where(x => x.id == model.id)
                   .FirstOrDefaultAsync();

                if (dataKelas == null)
                    throw new GlobalException("902", "Data Not Found");

                var kelas = new Kelas()
                {
                    kelas = model.kelas
                };


                this._context.Update(kelas);
                await _context.SaveChangesAsync();

                return kelas.id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}

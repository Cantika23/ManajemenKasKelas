using Kas.Transaksi.Domain;
using Kas.Transaksi.Domain.Entities;
using Kas.Transaksi.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Kas.Transaksi.Services.Repositories
{
    public class SiswaRepository : ISiswaRepository
    {
        private readonly ILogger<SiswaRepository> _logger;
        private readonly TransaksiContext _context;

        public SiswaRepository(ILogger<SiswaRepository> logger, TransaksiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<string> CreateSiswaAsync(CreateSiswaModel model)
        {
            try
            {
                var kelas = await _context.Kelass.FirstOrDefaultAsync(x => x.id == model.kelasId);

                if (kelas != null)
                {
                    var siswa = new Siswa()
                    {
                        id = Guid.NewGuid().ToString(),
                        nama_lengkap = model.nama_lengkap,
                        kelasId = kelas.id,
                        nisn = model.nisn,
                        tanggalLahir = model.tanggalLahir
                    };

                    this._context.Add(siswa);
                    await _context.SaveChangesAsync();
                }


                return kelas.id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public async Task<string> DeleteSiswaAsync(string id)
        {
            try
            {
                var agunan = await _context.Siswas.Where(x => x.id == id).ExecuteDeleteAsync();

                await _context.SaveChangesAsync();

                return "0";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<List<ReadSiswaModel>> ReadSiswaAsync()
        {
            try
            {
                var siswa = await _context.Siswas
                    .Select(x => new ReadSiswaModel()
                    {
                        id = x.id,
                        nama_lengkap = x.nama_lengkap,
                        nisn = x.nisn,
                        tanggalLahir = x.tanggalLahir,
                        kelasId= x.Kelas.kelas,
                    })
                    .ToListAsync();

                return siswa;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }

        public async Task<string> UpdateSiswaAsync(UpdateSiswaModel model)
        {
            try
            {
                var dataSiswa = await _context.Siswas.Where(x => x.id == model.id)
                   .FirstOrDefaultAsync();

                if (dataSiswa == null)
                    throw new GlobalException("902", "Data Not Found");

                var siswa = new Siswa()
                {
                    id = Guid.NewGuid().ToString(),
                    nama_lengkap = model.nama_lengkap,
                    kelasId = model.kelasId,
                    nisn = model.nisn,
                    tanggalLahir = model.tanggalLahir
                };


                this._context.Update(siswa);
                await _context.SaveChangesAsync();

                return siswa.id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }
    }
}

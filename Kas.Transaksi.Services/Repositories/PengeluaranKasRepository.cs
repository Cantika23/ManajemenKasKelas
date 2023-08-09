using Kas.Transaksi.Domain;
using Kas.Transaksi.Domain.Entities;
using Kas.Transaksi.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Kas.Transaksi.Services.Repositories
{
    public class PengeluaranKasRepository : IPengeluaranKasRepository
    {
        private readonly ILogger<PengeluaranKasRepository> _logger;
        private readonly TransaksiContext _context;

        public PengeluaranKasRepository(ILogger<PengeluaranKasRepository> logger, TransaksiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<string> CreatePengeluaranKasAsync(CreatePengeluaranModel model)
        {
            try
            {

                var pengeluaran = new PengeluaranKas()
                {
                    id = Guid.NewGuid().ToString(),
                    tanggalKeluarKas = model.tanggalKasKeluar,
                    nominalPengeluaran = model.nominalKas,
                    keterangan = model.keterangan,
                    kelasId = model.kelasId

                };

                var transaksi = new PelaporanTransaksi()
                {
                    id = Guid.NewGuid().ToString(),
                    tanggal = model.tanggalKasKeluar,
                    jumlahPengeluaran = model.nominalKas,
                    kelasId = model.kelasId,
                    jenisTransaksi = "Kas Keluar",
                    keterangan = model.keterangan

                };

                this._context.Add(transaksi);
                this._context.Add(pengeluaran);
                await _context.SaveChangesAsync();

                return pengeluaran.id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }
    }
}

using Kas.Transaksi.Domain;
using Kas.Transaksi.Domain.Entities;
using Kas.Transaksi.Services.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Kas.Transaksi.Services.Repositories
{
    public class PemasukanKasRepository : IPemasukanKasRepository
    {

        private readonly ILogger<PemasukanKasRepository> _logger;
        private readonly TransaksiContext _context;

        public PemasukanKasRepository(ILogger<PemasukanKasRepository> logger, TransaksiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<string> CreatePemasukanKasAsync(CreatePemasukanKasModel model)
        {
            try
            {

                var pemasukan = new PemasukanKas()
                {
                    id = Guid.NewGuid().ToString(),
                    tanggalMasukKas = model.tanggalMasukKas,
                    nominalKas = model.nominalKas,
                    kelasId = model.kelasId,
                    keterangan = model.keterangan
                    
                };

                var transaksi = new PelaporanTransaksi()
                {
                    id = Guid.NewGuid().ToString(),
                    tanggal = model.tanggalMasukKas,
                    jumlahPemasukan = model.nominalKas,
                    kelasId = model.kelasId,
                    jenisTransaksi = "Kas Masuk",
                    keterangan = model.keterangan

                };

                this._context.Add(transaksi);
                this._context.Add(pemasukan);
                await _context.SaveChangesAsync();

                return pemasukan.id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }
    }
}

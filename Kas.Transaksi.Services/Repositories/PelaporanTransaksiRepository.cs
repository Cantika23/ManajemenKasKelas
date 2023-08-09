using Azure.Core;
using Kas.Transaksi.Domain;
using Kas.Transaksi.Domain.Entities;
using Kas.Transaksi.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Kas.Transaksi.Services.Repositories
{
    public class PelaporanTransaksiRepository : IPelaporanTransaksiRepository
    {
        private readonly ILogger<PelaporanTransaksiRepository> _logger;
        private readonly TransaksiContext _context;

        public PelaporanTransaksiRepository(ILogger<PelaporanTransaksiRepository> logger, TransaksiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<ReadPelaporanTransaksiModel>> ReadPelaporanTransaksiAsync(DateTime startDate, DateTime endDate, string kelasId)
        {
            try
            {
                var pelaporanTransaksi = await _context.PelaporanTransaksis
                    .Include(x => x.Kelas)
                    .Where(x => x.tanggal >= startDate && x.tanggal <= endDate && x.kelasId == kelasId)
                    .Select(x => new ReadPelaporanTransaksiModel()
                    {
                        id = x.id,
                        tanggal = x.tanggal,
                        jumlahPemasukan = x.jumlahPemasukan,
                        jumlahPengeluaran = x.jumlahPengeluaran,
                        jenisTransaksi = x.jenisTransaksi,
                        keterangan = x.keterangan,
                        kelas = x.Kelas.kelas,
                    })
                    .ToListAsync();


                return pelaporanTransaksi;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<ResponseRincianKasModel> ReadRincianKasAsync()
        {
            try
            {

                var pemasukan = await _context.PemasukanKas
                    .Include(x => x.Kelas)
                    .Select(x => new ReadPemasukanKasModel()
                    {
                        id = x.id,
                        tanggalMasukKas = x.tanggalMasukKas,
                        nominalKas = x.nominalKas,
                        keterangan = x.keterangan,
                        kelasId = x.Kelas.kelas,
                    })
                    .ToListAsync();

                var pengeluaran = await _context.PengeluaranKas
                    .Include(x => x.Kelas)
                    .Select(x => new ReadPengeluaranKasModel()
                    {
                        id = x.id,
                        tanggalKeluarKas = x.tanggalKeluarKas,
                        nominalKas = x.nominalPengeluaran,
                        keterangan = x.keterangan,
                        kelasId = x.Kelas.kelas
                    })
                    .ToListAsync();

                return new ResponseRincianKasModel()
                {
                    pemasukanKas = pemasukan,
                    pengeluaranKas = pengeluaran
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}

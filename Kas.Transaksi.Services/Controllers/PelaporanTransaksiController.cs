using Kas.Transaksi.Services.Models;
using Kas.Transaksi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Kas.Transaksi.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PelaporanTransaksiController : ControllerBase
    {
        private readonly ILogger<PelaporanTransaksiController> _logger;
        private readonly IPelaporanTransaksiRepository _pelaporanTransaksiRepository;

        public PelaporanTransaksiController(ILogger<PelaporanTransaksiController> logger, IPelaporanTransaksiRepository pelaporanTransaksiRepository)
        {
            _logger = logger;
            _pelaporanTransaksiRepository = pelaporanTransaksiRepository;
        }

        [HttpGet("readPelaporanTransaksi")]
        public async Task<ActionResult<ResponseBase<List<ReadPelaporanTransaksiModel>>>> 
            ReadPelaporanTransaksi(DateTime startDate, DateTime endDate, string kelasId)
        {
            try
            {
                var res = await _pelaporanTransaksiRepository.ReadPelaporanTransaksiAsync(startDate,endDate, kelasId);
                return Ok(new ResponseBase<List<ReadPelaporanTransaksiModel>>
                {
                    Code = "000",
                    Message = "Successfully",
                    Data = res
                });
            }
            catch (GlobalException ex)
            {
                return BadRequest(new ResponseBase<string>
                {
                    Code = ex.ErrorCode,
                    Message = ex.ErrorMessage,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseBase<string>
                {
                    Code = "999",
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("readRincianKas")]
        public async Task<ActionResult<ResponseBase<ResponseRincianKasModel>>> ReadRincianKas()
        {
            try
            {
                var res = await _pelaporanTransaksiRepository.ReadRincianKasAsync();
                return Ok(new ResponseBase<ResponseRincianKasModel>
                {
                    Code = "000",
                    Message = "Successfully",
                    Data = res
                });
            }
            catch (GlobalException ex)
            {
                return BadRequest(new ResponseBase<string>
                {
                    Code = ex.ErrorCode,
                    Message = ex.ErrorMessage,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseBase<string>
                {
                    Code = "999",
                    Message = ex.Message,
                    Data = null
                });
            }
        }


    }
}

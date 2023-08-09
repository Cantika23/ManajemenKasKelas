using Kas.Transaksi.Services.Models;
using Kas.Transaksi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Kas.Transaksi.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PengeluaranKasController : ControllerBase
    {
        private readonly ILogger<PengeluaranKasController> _logger;
        private readonly IPengeluaranKasRepository _pengeluaranKasRepository;

        public PengeluaranKasController(ILogger<PengeluaranKasController> logger, IPengeluaranKasRepository pengeluaranKasRepository)
        {
            _logger = logger;
            _pengeluaranKasRepository = pengeluaranKasRepository;
        }


        [HttpPost]
        public async Task<ActionResult<ResponseBase<string>>> CreatePemohon(CreatePengeluaranModel model)
        {
            try
            {
                var res = await _pengeluaranKasRepository.CreatePengeluaranKasAsync(model);
                return Ok(new ResponseBase<string>
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

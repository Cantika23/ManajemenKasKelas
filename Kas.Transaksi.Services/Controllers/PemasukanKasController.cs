using Kas.Transaksi.Services.Models;
using Kas.Transaksi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Kas.Transaksi.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PemasukanKasController : ControllerBase
    {
        private readonly ILogger<PemasukanKasController> _logger;
        private readonly IPemasukanKasRepository _pemasukanKasRepository;

        public PemasukanKasController(ILogger<PemasukanKasController> logger, IPemasukanKasRepository pemasukanKasRepository)
        {
            _logger = logger;
            _pemasukanKasRepository = pemasukanKasRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseBase<string>>> CreatePemohon(CreatePemasukanKasModel model)
        {
            try
            {
                var res = await _pemasukanKasRepository.CreatePemasukanKasAsync(model);
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

using Kas.Transaksi.Services.Models;
using Kas.Transaksi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Kas.Transaksi.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class SiswaController : ControllerBase
    {
        private readonly ILogger<SiswaController> _logger;
        private readonly ISiswaRepository _siswaRepository;

        public SiswaController(ILogger<SiswaController> logger, ISiswaRepository siswaRepository)
        {
            _logger = logger;
            _siswaRepository = siswaRepository;
        }

        [HttpGet("readSiswa")]
        public async Task<ActionResult<ResponseBase<List<ReadSiswaModel>>>> ReadSiswa()
        {
            try
            {
                var res = await _siswaRepository.ReadSiswaAsync();
                return Ok(new ResponseBase<List<ReadSiswaModel>>
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

        [HttpPost("createSiswa")]
        public async Task<ActionResult<ResponseBase<string>>> CreateSiswa(CreateSiswaModel model)
        {
            try
            {
                var res = await _siswaRepository.CreateSiswaAsync(model);
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

        [HttpPost("deleteSiswa")]
        public async Task<ActionResult<ResponseBase<string>>> DeleteSiswa(DeleteSiswaModel model)
        {
            try
            {
                var res = await _siswaRepository.DeleteSiswaAsync(model.id);
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

        [HttpPost("updateSiswa")]
        public async Task<ActionResult<ResponseBase<string>>> UpdateSiswa(UpdateSiswaModel model)
        {
            try
            {
                var res = await _siswaRepository.UpdateSiswaAsync(model);
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

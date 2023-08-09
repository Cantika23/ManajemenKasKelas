using Kas.Transaksi.Services.Models;
using Kas.Transaksi.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Kas.Transaksi.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class KelasController : ControllerBase
    {
        private readonly ILogger<KelasController> _logger;
        private readonly IKelasRepository _kelasRepository;

        public KelasController(ILogger<KelasController> logger, IKelasRepository kelasRepository)
        {
            _logger = logger;
            _kelasRepository = kelasRepository;
        }

        [HttpGet("readKelas")]
        public async Task<ActionResult<ResponseBase<List<ReadKelasModel>>>> ReadKelas()
        {
            try
            {
                var res = await _kelasRepository.ReadKelasAsync();
                return Ok(new ResponseBase<List<ReadKelasModel>>
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

        [HttpPost("createKelas")]
        public async Task<ActionResult<ResponseBase<string>>> CreateSiswa(CreateKelasModel model)
        {
            try
            {
                var res = await _kelasRepository.CreateKelasAsync(model);
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


        [HttpPost("deleteKelas")]
        public async Task<ActionResult<ResponseBase<string>>> DeleteKelas(DeleteKelasModel model)
        {
            try
            {
                var res = await _kelasRepository.DeleteKelasAsync(model.id);
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

        [HttpPost("updateKelas")]
        public async Task<ActionResult<ResponseBase<string>>> UpdateKelas (UpdateKelasModel model)
        {
            try
            {
                var res = await _kelasRepository.UpdateKelasAsync(model);
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

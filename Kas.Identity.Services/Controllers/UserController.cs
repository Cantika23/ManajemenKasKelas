using Kas.Identity.Services.Models;
using Kas.Identity.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Kas.Identity.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost("createUser")]
        public async Task<ActionResult<ResponseBase<string>>> CreateUser(CreateUserModel model)
        {
            try
            {
                var res = await _userRepository.CreateUserAsync(model);
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

        [HttpGet("auth")]
        public async Task<ActionResult<ResponseBase<bool>>> AuthenticateAsync(string username, string password)
        {
            try
            {
                var res = await _userRepository.AuthenticateAsync(username,password);
                return Ok(new ResponseBase<bool>
                {
                    Code = "000",
                    Message = "Successfully",
                    Data = true
                });
            }
            catch (GlobalException ex)
            {
                return BadRequest(new ResponseBase<bool>
                {
                    Code = ex.ErrorCode,
                    Message = ex.ErrorMessage,
                    Data = false
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseBase<bool>
                {
                    Code = "999",
                    Message = ex.Message,
                    Data = false
                });
            }
        }

        [HttpGet("readUser")]
        public async Task<ActionResult<ResponseBase<List<ReadUserModel>>>> ReadUser()
        {
            try
            {
                var res = await _userRepository.ReadUserAsync();
                return Ok(new ResponseBase<List<ReadUserModel>>
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

        [HttpPost("updateUser")]
        public async Task<ActionResult<ResponseBase<string>>> UpdateUser(UpdateUserModel model)
        {
            try
            {
                var res = await _userRepository.UpdateUserAsync(model);
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

        [HttpPost("deleteUser")]
        public async Task<ActionResult<ResponseBase<string>>> DeleteUser(DeleteUserModel model)
        {
            try
            {
                var res = await _userRepository.DeleteUserAsync(model.id);
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

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using MKKWebApplication.Models;

namespace MKKWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult ListPengguna()
        {
            return View();
        }

        [HttpPost("[controller]/CreateUserAsync")]
        public async Task<string> CreateUserAsync([FromBody] CreateUserModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7037/api/User/createUser", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }

        [HttpGet("[controller]/ReadUserAsync")]
        public async Task<IActionResult> ReadUserAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7037/api/User/readUser");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "Data Not Found" });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("[controller]/DeleteUserAsync")]
        public async Task<string> DeleteUserAsync([FromBody] DeleteUserModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7037/api/User/deleteUser", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }

        [HttpPost("[controller]/UpdateUserAsync")]
        public async Task<string> UpdateUserAsync([FromBody] UpdateUserModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7037/api/User/updateUser", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }


    }
}

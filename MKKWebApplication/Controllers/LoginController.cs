using Microsoft.AspNetCore.Mvc;
using MKKWebApplication.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MKKWebApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("[controller]/Auth")]
        public async Task<string> Auth([FromBody] AuthModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
            "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7037/api/User/auth", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }
    }
}

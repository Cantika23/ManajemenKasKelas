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
        public async Task<IActionResult> Auth([FromBody] AuthModel model)
        {
			try
			{
                var password = model.password;
                var username = model.username;
				HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7037/api/User/auth?username={username}&password={password}");
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					return Ok(result);
				}
				else
				{
					return NotFound(new { message = "Login Failed" });
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
    }
}

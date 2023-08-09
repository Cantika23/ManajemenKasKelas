using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using MKKWebApplication.Models;

namespace MKKWebApplication.Controllers
{
    public class PemasukanKasController : Controller
    {
        private readonly HttpClient _httpClient;

        public PemasukanKasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult AddKasMasuk()
        {
            return View();
        }


        [HttpPost("[controller]/PemasukanKasAsync")]
        public async Task<string> PemasukanKasAsync([FromBody] AddPemasukanKasModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7249/api/PemasukanKas", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }
    }
}

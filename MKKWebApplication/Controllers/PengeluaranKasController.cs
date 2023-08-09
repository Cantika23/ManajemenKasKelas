using Microsoft.AspNetCore.Mvc;
using MKKWebApplication.Models;
using System.Text.Json;
using System.Text;

namespace MKKWebApplication.Controllers
{
    public class PengeluaranKasController : Controller
    {
        private readonly HttpClient _httpClient;

        public PengeluaranKasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult AddKasKeluar()
        {
            return View();
        }


        [HttpPost("[controller]/PengeluaranKasAsync")]
        public async Task<string> PengeluaranKasAsync([FromBody] AddPengeluaranKasModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7249/api/PengeluaranKas", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }
    }
}

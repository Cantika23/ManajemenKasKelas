using Microsoft.AspNetCore.Mvc;
using MKKWebApplication.Models;
using System.Text.Json;
using System.Text;

namespace MKKWebApplication.Controllers
{
    public class KelasController : Controller
    {
        private readonly HttpClient _httpClient;

        public KelasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult AddKelas()
        {
            return View();
        }

        public IActionResult ListKelas()
        {
            return View();
        }

        [HttpPost("[controller]/CreateKelasAsync")]
        public async Task<string> CreateKelasAsync([FromBody] CreateKelasModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7249/api/Kelas/createKelas", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }

        [HttpGet("[controller]/ReadKelasAsync")]
        public async Task<IActionResult> ReadKelasAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7249/api/Kelas/readKelas");

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
                // handle or log exception as necessary
                throw;
            }
        }


        [HttpPost("[controller]/DeleteKelasAsync")]
        public async Task<string> DeleteKelasAsync([FromBody] DeleteKelasModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7249/api/Kelas/deleteKelas", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }

        [HttpPost("[controller]/UpdateKelasAsync")]
        public async Task<string> UpdateKelasAsync([FromBody] UpdateKelasModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7249/api/Kelas/updateKelas", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }



    }
}

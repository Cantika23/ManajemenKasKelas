using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using MKKWebApplication.Models;

namespace MKKWebApplication.Controllers
{
    public class SiswaController : Controller
    {
        private readonly HttpClient _httpClient;

        public SiswaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult AddSiswa()
        {
            return View();
        }

        public IActionResult ListSiswa()
        {
            return View();
        }

        [HttpPost("[controller]/CreateSiswaAsync")]
        public async Task<string> CreateSiswaAsync([FromBody] CreateSiswaModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
            Encoding.UTF8,
            "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7249/api/Siswa/createSiswa", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }

        [HttpGet("[controller]/ReadSiswaAsync")]
        public async Task<IActionResult> ReadSiswaAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7249/api/Siswa/readSiswa");

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


        [HttpPost("[controller]/DeleteSiswaAsync")]
        public async Task<string> DeleteSiswaAsync([FromBody] DeleteSiswaModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
            Encoding.UTF8,
            "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7249/api/Siswa/deleteSiswa", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }

        [HttpPost("[controller]/UpdateSiswaAsync")]
        public async Task<string> UpdateSiswaAsync([FromBody] UpdateSiswaModel model)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
            "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7249/api/Siswa/updateSiswa", content);
            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }



    }
}

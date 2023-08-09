using Microsoft.AspNetCore.Mvc;
using MKKWebApplication.Models;
using System.Text;
using System.Text.Json;

namespace MKKWebApplication.Controllers
{
    public class LaporanKasController : Controller
    {
        private readonly HttpClient _httpClient;

        public LaporanKasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult KasReport()
        {
            return View();
        }

        public IActionResult RincianKas()
        {
            return View();
        }

        [HttpGet("[controller]/ReadLaporanKasAsync")]
        public async Task<IActionResult> ReadLaporanKasAsync([FromBody] ReadPelaporanTransaksiModel model)
        {
            try
            {
                
                var requestUrl = $"https://localhost:7249/api/PelaporanTransaksi/readPelaporanTransaksi?startDate={model.startDate}&endDate={model.endDate}&kelas={model.kelas}";
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

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
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }


        }


        [HttpGet("[controller]/ReadRincianKasAsync")]
        public async Task<IActionResult> ReadRincianKasAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7249/api/PelaporanTransaksi/readRincianKas");

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


    }
}

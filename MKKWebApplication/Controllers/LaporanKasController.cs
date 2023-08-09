using Microsoft.AspNetCore.Mvc;
using MKKWebApplication.Models;
using Newtonsoft.Json;
using System;
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

        [HttpPost("[controller]/ReadLaporanKasAsync")]
        public async Task<IActionResult> ReadLaporanKasAsync([FromBody] ReadPelaporanTransaksiModel data)
        {
            try
            {
                var kelas = data.kelas;
                var startDate = data.startDate?.ToString("yyyy-MM-dd"); 
                var endDate = data.endDate?.ToString("yyyy-MM-dd");

                var requestUrl = $"https://localhost:7249/api/PelaporanTransaksi/readPelaporanTransaksi?startDate={startDate}&endDate={endDate}&kelasId={kelas}";
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

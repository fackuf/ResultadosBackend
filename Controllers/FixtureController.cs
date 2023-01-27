using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResultadosBackend.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace ResultadosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        // Puede ser IOptions ApiSettings _apiKey??
        private readonly ApiSettings _apiKey;
        public FixtureController(IOptions<ApiSettings> apiKey)
        {
            _apiKey = apiKey.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetLiveMatches()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://v3.football.api-sports.io/fixtures?live=all"),
                Headers =
            {
                { "X-RapidAPI-Key", $"{_apiKey.apiKey}" },
                { "X-RapidAPI-Host", "v3.football.api-sports.io" },
            },
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return Ok(body);
        }

        [HttpGet("live")]
        public async Task<IActionResult> GetLiveScores()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://v3.football.api-sports.io/fixtures?live=all"),
                Headers =
            {
                { "X-RapidAPI-Key", $"{_apiKey.apiKey}" },
                { "X-RapidAPI-Host", "v3.football.api-sports.io" },
            },
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            //Deserealiza el body 
            var liveScores = JsonConvert.DeserializeObject<Root>(body);
            //De livescore toma solo los valos que me intersan
            var ls = liveScores.response.Select(x => new { x.fixture.id, x.teams,x.goals });
            //Retorna ls con los atributos que me interesan 
            return Ok(ls);
        }
    }
}

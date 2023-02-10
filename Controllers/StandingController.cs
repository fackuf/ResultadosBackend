using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResultadosBackend.Models;
using ResultadosBackend.Models.Standings;
using System.Reflection.PortableExecutable;

namespace ResultadosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingController : ControllerBase
    {
        private readonly ApiSettings _apiKey;
        public StandingController(IOptions<ApiSettings> apiKey)
        {
            _apiKey = apiKey.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetStandings19()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://v3.football.api-sports.io/standings?league=39&season=2019"),
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


        [HttpGet("leagues/Argentina")]
        public async Task<IActionResult> GetStandingsArgentina()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://v3.football.api-sports.io/standings?league=128&season=2019"),
                Headers =
                {
                    { "X-RapidAPI-Key", $"{_apiKey.apiKey}" },
                    { "X-RapidAPI-Host", "v3.football.api-sports.io" },
                },
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var st = JsonConvert.DeserializeObject<Rootobject>(body);
            var sts = st.response.Select(x => x.league.standings);
            return Ok(sts);

        }

        [HttpGet("leagues/{LeagueId}")]
        //Argentina 128
        public async Task<IActionResult> GetStandingsArgentinaByIDandYear(int LeagueId,int Season)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://v3.football.api-sports.io/standings?league={LeagueId}&season={Season}"),
                Headers =
                {
                    { "X-RapidAPI-Key", $"{_apiKey.apiKey}" },
                    { "X-RapidAPI-Host", "v3.football.api-sports.io" },
                },
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var st = JsonConvert.DeserializeObject<Rootobject>(body);
            var sts = st.response.Select(x => x.league.standings);
            return Ok(sts);

        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService service;

        public ScoreController(IScoreService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://api.openweathermap.org")
            };

            var response = await client.GetAsync($"/data/2.5/weather?q=Leeds&appid=d536187460c357fe43f89f4dcc8f9ab8&units=metric");

            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();

            return stringResult;
        }

        [HttpPost]
        public int Post(CustomerDto customerDto)
        {
            Task<string> weather = Get();

            CustomerDto dto = service.SaveCustomer(customerDto, weather);

            return dto.Score;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

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
        public string Get()
        {
            return "Welcome to your Credit Score API!";
        }

        [HttpPost]
        public int Post(Customer customer)
        {
            int score = service.GetScore(customer.Name);

            return score;
        }
    }
}

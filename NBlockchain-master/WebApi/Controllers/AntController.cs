using System.Collections.Generic;
using BlockCycle.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlockCycle.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AntController : Controller
    {
        // GET api/values
        [HttpGet("get")]
        public Ant Get()
        {
            var test = Startup._ant;
            return test;
        }
    }
}

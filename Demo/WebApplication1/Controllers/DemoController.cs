using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IConfiguration config;

        public DemoController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        public string GetValue()
        {
            var dbstring = config.GetValue<string>("MySettings:DbConnection");
            return dbstring;
        }
    }
}

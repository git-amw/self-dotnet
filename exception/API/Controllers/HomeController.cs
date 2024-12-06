using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAccount accService;

        public HomeController(IAccount  accService)
        {
            this.accService = accService;
        }
        
        [HttpGet("balance/{id}")]
        public async Task<int> GetBalance(int id)
        {
            return await accService.CheckBalace(id);
        }
        

        [HttpGet("")]
        public string Get()
        {
            return "home controller live ";
        }

        
    }
}
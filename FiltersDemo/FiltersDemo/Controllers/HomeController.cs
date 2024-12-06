using FiltersDemo.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ActionLogs]
    [ExceptionFilter]
    public class HomeController : ControllerBase
    {
        List<string> CodingLanguages = new List<string>
        {
            "C++",
            "C#",
            "Java",
            "Python"
        };

        [HttpGet]
        public string Get()
        {
            return "API is UP";
        }

        [HttpGet]
        [Route("languagelist")]
        [AuthorizeFilter("Write")]   // change Write -> Read to authorize 
        public List<string> Getlist()
        {
            return CodingLanguages;
        }
        [HttpPost]
        [Route("cal")]
        public void fun(int num1, int num2)
        {
            var resutl = num1 / num2; // simplest example to test exception 
        }
    }
}

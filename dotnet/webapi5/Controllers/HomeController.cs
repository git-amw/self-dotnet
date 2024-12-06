using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi5.Data;

namespace webapi5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<bool> CreateUserAsync()
        {
            var identityUser = new ApplicationUser()
            {
                UserName = "newemail@email.com",
                Email = "newemail@email.com",
                PhoneNumber = "1234567887",

            };
            var res = await userManager.CreateAsync(identityUser, "Amar@123");
            return true;
        }

    }
}

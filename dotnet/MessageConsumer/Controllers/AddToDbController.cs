using MessageConsumer.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToDbController : ControllerBase
    {
        private readonly IAddToDb addToDb;

        public AddToDbController(IAddToDb addToDb)
        {
            this.addToDb = addToDb;
        }

        [HttpPost]
        public async Task<IActionResult> Save(int number)
        {
            var ok = await addToDb.SaveToDb(number);
            if (ok)
            {
                return Ok("Save Successfully!!");
            }
            return BadRequest();
        }
    }
}

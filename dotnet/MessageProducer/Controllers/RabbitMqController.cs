using MessageProducer.MessageService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
        private readonly IMessageProducer messageProducer;

        //public readonly int AccountNumber = 123456;

        public RabbitMqController(IMessageProducer messageProducer)
        {
            this.messageProducer = messageProducer;
        }

        [HttpGet] 
        public IActionResult Publish([FromQuery] int AccountNumber)
        {
            messageProducer.SendMessage<int>(AccountNumber);
            return Ok("Publish Successfully");
        }


    }
}

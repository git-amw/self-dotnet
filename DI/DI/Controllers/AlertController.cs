using AlertLibrary.Interface;
using AlertLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlert alertService1;
        private readonly IAlert alertService2;

        public AlertController(IAlert alertService1, IAlert alertService2)
        {
           this.alertService1 = alertService1;
            this.alertService2 = alertService2;
        }


        [HttpGet]
        [Route("sms")]
        public string GetSMSAlert()
        {
            var result =  alertService1.SendSmsAlert();
            var result2 = alertService2.SendSmsAlert();
            return result;
        }

        [HttpGet]
        [Route("email")]
        public string GetEmailAlert()
        {
            var result = alertService1.SendEmailAlert();
            return result;
        }

    }
}

using AlertLibrary.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertLibrary.Service
{
    public class AlertService : IAlert, IDisposable
    {
        private readonly Guid _id = Guid.NewGuid();
        private readonly ILogger<AlertService> logger;

        public AlertService(ILogger<AlertService> logger)
        {
           
            this.logger = logger;
            logger.LogInformation("{type} is created, id: {id}", nameof(AlertService), _id);
        }

        public void Dispose()
        {
            logger.LogInformation("{type} is disposed, id: {id}", nameof(AlertService), _id);
        }

        public string SendEmailAlert()
        {
            return "Sending Alert on Email";
        }
        public string SendSmsAlert()
        {
            return "Sending Alert on SMS";
        }
    }
}

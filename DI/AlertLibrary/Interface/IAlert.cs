using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertLibrary.Interface
{
    public interface IAlert
    {
       string SendEmailAlert();
       string SendSmsAlert();
    }
}

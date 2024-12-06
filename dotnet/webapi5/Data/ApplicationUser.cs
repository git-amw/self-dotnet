using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi5.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int AccNumber { get; set; }
    }
}

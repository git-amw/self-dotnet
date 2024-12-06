using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAccessLayer.Entities
{
    public class User : PrimaryKeyEntity
    {
        public int UserId { get; set; }
    }
}

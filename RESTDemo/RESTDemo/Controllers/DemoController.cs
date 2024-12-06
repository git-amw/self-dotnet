using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private DemoData _demoData;
        public DemoController()
        {
            _demoData = new DemoData();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello world");
        }
        [HttpGet]
        [Route("list")]
        public List<Inventory> ShowList()
        {
            return _demoData.ShowList();
        }
        [HttpPost]
        [Route("listadd")]
        public List<Inventory> AddToList(int? itemId, string itemType)
        {
            if (itemId != null && itemType != null)
            {
                _demoData.AddToList((int)itemId, itemType);
                return _demoData.ShowList();
            }
            return _demoData.ShowList();
        }
    }
}

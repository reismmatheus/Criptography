using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cryptography.Controllers
{
    [ApiController]
    [Route("")]
    public class CriptographyController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return null;
        }

        public IActionResult GetAll()
        {
            return null;
        }


        [HttpPost]
        public IActionResult Create([FromBody] string full)
        {
            return null;
        }
    }
}

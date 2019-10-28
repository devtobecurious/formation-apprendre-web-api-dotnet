using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _0041_First_Application.Controllers
{
    [ApiController]
    [Route("[controller]-[controller]")]
    public class WookieController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            

            return this.Ok(new { ok = "1" });
        }
    }
}

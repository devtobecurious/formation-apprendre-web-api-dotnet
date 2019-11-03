using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _0102_First_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //[EnableCors("customOrigin2")]
        [EnableCors("customOrigin")]
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(new { isSuccess = true });
        }

        [EnableCors("customOrigin2")]
        [HttpPost]
        public IActionResult Post()
        {
            return this.Ok(new { isSuccess = true });
        }
    }
}
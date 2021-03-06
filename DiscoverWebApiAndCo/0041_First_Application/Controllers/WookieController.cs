﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _0041_First_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WookieController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return this.Ok(new { ok = "1" });
        }

        // Pas obligé d'avoir le même nom de méthode, mais pas deux fois la même méthode get
        //[HttpGet()]
        //public IActionResult Test()
        //{
        //    return this.Ok(new { ok = "1" });
        //}

        //[HttpGet()]
        //public IActionResult Get()
        //{
        //    return this.Ok(new { ok = "1" });
        //}

        // Pas besoin d'avoir le HttpGet => si une seul méthode, sinon comment faire la différence ?
        //public IActionResult Get()
        //{
        //    return this.Ok(new { ok = "1" });
        //}

        // Pas besoin d'avoir le HttpGet => si une seul méthode, sinon comment faire la différence ?
        //public IActionResult Test()
        //{
        //    return this.Ok(new { ok = "1" });
        //}
    }
}

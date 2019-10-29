using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0041_First_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace _0041_First_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WookieController : ControllerBase
    {
        #region Génération du model
        // Retour d'un élément dynamique
        //[HttpGet()]
        //public IActionResult Get()
        //{
        //    return this.Ok(new { ok = "1" });
        //}

        // Retour d'un tableau
        //[HttpGet()]
        //public IActionResult Get()
        //{
        //    var array = Enumerable.Range(0, 100);

        //    return this.Ok(array);
        //}

        [HttpGet()]
        public IActionResult Get()
        {
            return this.Ok(new Wookie("Chewie", WarriorType.Chief));
        }
        #endregion

        #region Tests Get methods
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
        #endregion
    }
}

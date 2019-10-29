using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0041_First_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace _0041_First_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WookieController : ControllerBase
    {

        #region 003 - Tests sur la Configuration
        private IConfiguration _configuration;

        public WookieController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var starWarsSection = this._configuration.GetSection("starwars");
            Film infosFilm = starWarsSection.Get<Models.Film>(options =>
            {
                options.BindNonPublicProperties = false;
            });

            starWarsSection.Bind(infosFilm, options =>
            {
                options.BindNonPublicProperties = false;
            });

            // https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.0#getsection-getchildren-and-exists
            return this.Ok(new
            {
                test01 = this._configuration["test01"],
                test02 = this._configuration["test02"], // ne ramène rien, car ici, nous avons un noeud enfant
                test020 = this._configuration["test02:test020"],
                test021 = this._configuration["test02:test021"],
                test021a = this._configuration["test02:test021:a"],
                test021b = this._configuration["test02:test021:b"],
                infosFilm = infosFilm.Nb
            });


        }
        #endregion

        #region 002 - Avec Entities
        //private Models.Contexts.DefaultContext _context = null;

        //public WookieController(Models.Contexts.DefaultContext context)
        //{
        //    this._context = context;
        //}

        //[HttpGet()]
        //public IActionResult Get()
        //{
        //    var query = from wookie in this._context.Wookies
        //                select wookie;

        //    return this.Ok(query);
        //}
        #endregion

        #region 001 - Génération du model
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

        //[HttpGet()]
        //public IActionResult Get()
        //{
        //    return this.Ok(new Wookie("Chewie", WarriorType.Chief));
        //}
        #endregion

        #region 000 - Tests Get methods
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

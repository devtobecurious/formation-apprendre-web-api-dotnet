using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0041_First_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _0041_First_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WookieController : ControllerBase
    {
        #region 004 - Multiples méthodes : GET / POST, ...
        private IConfiguration _configuration;
        private Models.Contexts.DefaultContext _context = null;

        public WookieController(IConfiguration configuration, Models.Contexts.DefaultContext context)
        {
            this._configuration = configuration;
            this._context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this._context.Wookies.ToListAsync());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return this.Ok(this._context.Wookies.First(item => item.Id == id));
        }

        [HttpPost]
        public IActionResult Post(Models.Wookie wookie)
        {

            return this.Ok(wookie);
        }

        [HttpPut]
        public IActionResult Put(Models.Wookie wookie)
        {
            // Attach : permet de lier l'objet au context, sans indiquer un état Modified. 
            this._context.Attach(wookie);
            // Cela permet après de faire : 
            //this._context.Entry<Wookie>(wookie).Property<string>(item => item.Name).CurrentValue = "Chewie 8";

            wookie.Name = "hallo";

            this._context.SaveChanges();

            //this._context.Entry<Wookie>(wookie).State = EntityState.Modified;

            return this.Ok(wookie);
        }

        [HttpDelete("{id:int}/{id2}")]
        public IActionResult Delete(string id, int id2)
        {
            return this.Ok(this._context.Wookies.First(item => item.Id == int.Parse(id)));
        }
        #endregion

        #region 003 - Tests sur la Configuration
        //private IConfiguration _configuration;

        //public WookieController(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //}

        //[HttpGet()]
        //public IActionResult Get()
        //{
        //    var starWarsSection = this._configuration.GetSection("starwars");
        //    Film infosFilm = starWarsSection.Get<Models.Film>(options =>
        //    {
        //        options.BindNonPublicProperties = false;
        //    });

        //    starWarsSection.Bind(infosFilm, options =>
        //    {
        //        options.BindNonPublicProperties = false;
        //    });

        //    // https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.0#getsection-getchildren-and-exists
        //    return this.Ok(new
        //    {
        //        test01 = this._configuration["test01"],
        //        test02 = this._configuration["test02"], // ne ramène rien, car ici, nous avons un noeud enfant
        //        test020 = this._configuration["test02:test020"],
        //        test021 = this._configuration["test02:test021"],
        //        test021a = this._configuration["test02:test021:a"],
        //        test021b = this._configuration["test02:test021:b"],
        //        infosFilm = infosFilm.Nb
        //    });


        //}
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

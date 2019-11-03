﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0041_First_Application.Models;
using _0041_First_Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace _0041_First_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WookieController : ControllerBase
    {
        #region 0081 - Tests validate binding
        private WookieService _service = null;
        private ILogger<WookieController> _logger;

        public WookieController(WookieService service, ILogger<WookieController> logger)
        {
            this._service = service;
            this._logger = logger;

            this._logger.LogInformation("wookie controller constructor");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this._service.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Models.Wookie wookie)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok();
            }
            else
            {
                return this.Problem("Detail");
            }

            return this.Ok();
        }
        #endregion

        #region 008 - Tests binding
        //private WookieService _service = null;
        //private ILogger<WookieController> _logger;

        //public WookieController(WookieService service, ILogger<WookieController> logger)
        //{
        //    this._service = service;
        //    this._logger = logger;

        //    this._logger.LogInformation("wookie controller constructor");
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return this.Ok(this._service.GetAll());
        //}

        //[HttpPost]
        //public IActionResult Post(Models.Wookie wookie)
        //{
        //    return this.Ok();
        //}

        //[HttpPost]
        //public IActionResult Post()
        //{
        //    return this.Ok();
        //}

        //[FromBody]
        //public Wookie MonWookie { get; set; }



        #endregion

        #region 007 - Tests logging
        //private WookieService _service = null;
        //private ILogger<WookieController> _logger;

        //public WookieController(WookieService service, ILogger<WookieController> logger)
        //{
        //    this._service = service;
        //    this._logger = logger;

        //    this._logger.LogInformation("wookie controller constructor");
        //}
        #endregion

        #region 006 - Tests injections dépendances
        //private WookieService _service = null;

        //public WookieController(WookieService service)
        //{
        //    this._service = service;
        //}
        #endregion

        #region 005 - Tests avec les contraints custom d'url
        //[HttpGet]
        //public IActionResult Get()
        //{


        //    return this.Ok(this._service.GetAll());
        //}

        //[HttpGet("{id:wexists}")]
        //public IActionResult Get(int id)
        //{
        //    return this.Ok(new Models.Wookie("essai", WarriorType.Chief));
        //}

        //[HttpPost()]
        //public IActionResult Post(Marator model) // Pas obligé la même classe, seules les noms des champs sont importants
        //{
        //    return this.Ok(model);
        //}
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

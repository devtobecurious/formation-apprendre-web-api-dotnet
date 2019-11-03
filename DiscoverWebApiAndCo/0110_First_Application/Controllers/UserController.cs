using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0041_First_Application.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace _0102_First_Application.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region 011 - Tests autorisation avec IdendityContext
        private IConfiguration _configuration = null;

        private UserManager<IdentityUser> _userManager = null;
        private SignInManager<IdentityUser> _signInManager = null;

        public UserController(IConfiguration configuration, UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager)
        {
            this._configuration = configuration;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login()
        {
            var user = await this._userManager.FindByNameAsync(this.LoginUser.Login).ConfigureAwait(true);
            var result = await this._signInManager.CheckPasswordSignInAsync(user, this.LoginUser.Password, true).ConfigureAwait(true);

            return this.Ok(new
            {
                token = this.CreateToken()
            });
        }

        [FromBody]
        public LoginModel LoginUser { get; set; }

        private string CreateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(this._configuration["jwt:issuer"],
                                             this._configuration["jwt:issuer"],
                                             expires: DateTime.Now.AddMinutes(30),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

        #region 010 - Tests autorisation
        //private IConfiguration _configuration = null;

        //public UserController(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return this.Ok(new
        //    {
        //        token = this.CreateToken()
        //    });
        //}

        //[FromBody]
        //public LoginModel LoginUser { get; set; }

        //private string CreateToken()
        //{
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["jwt:key"]));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(this._configuration["jwt:issuer"],
        //                                     this._configuration["jwt:issuer"],
        //                                     expires: DateTime.Now.AddMinutes(30),
        //                                     signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        #endregion
    }
}
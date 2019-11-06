using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0041_First_Application.Constraints
{
    public class WookieExistRouteContraint : IRouteConstraint
    {
        private Models.Contexts.DefaultContext _context = null;

        public WookieExistRouteContraint()
        {
            
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var context = httpContext.RequestServices.GetService(typeof(Models.Contexts.DefaultContext));
            return false;
        }
    }
}

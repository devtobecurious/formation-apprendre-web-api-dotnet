using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0041_First_Application.Services
{
    public class WookieService
    {
        public static int __COUNT = 0;

        private Models.Contexts.DefaultContext _context = null;

        public WookieService(Models.Contexts.DefaultContext context)
        {
            this._context = context;
            // Ici, on voit que le transient instancie une nouvelle instance
            __COUNT++;
        }

        public IEnumerable<Models.Wookie> GetAll()
        {
            return this._context.Wookies.ToList();
        }
    }
}

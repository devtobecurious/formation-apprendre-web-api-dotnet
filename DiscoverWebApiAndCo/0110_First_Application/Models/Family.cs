using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0041_First_Application.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Wookie> Wookies { get; set; }
    }
}

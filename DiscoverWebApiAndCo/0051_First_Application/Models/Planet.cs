using System;
using System.Collections.Generic;

namespace _0041_First_Application
{
    public partial class Planet
    {
        public Planet()
        {
            Padawann = new HashSet<Padawann>();
        }

        public decimal Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Padawann> Padawann { get; set; }
    }
}

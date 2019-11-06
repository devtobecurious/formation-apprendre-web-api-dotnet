using System;
using System.Collections.Generic;

namespace _0111_First_Application.Models
{
    public partial class EquipeCombat
    {
        public EquipeCombat()
        {
            Droide = new HashSet<Droide>();
        }

        public string Name { get; set; }
        public decimal Id { get; set; }

        public virtual ICollection<Droide> Droide { get; set; }
    }
}

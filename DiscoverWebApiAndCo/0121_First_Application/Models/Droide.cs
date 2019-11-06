using System;
using System.Collections.Generic;

namespace _0111_First_Application.Models
{
    public partial class Droide
    {
        public string Matricule { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Id { get; set; }
        public decimal? IdEquipeCombat { get; set; }

        public virtual EquipeCombat IdEquipeCombatNavigation { get; set; }
    }
}

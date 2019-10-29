using System;
using System.Collections.Generic;

namespace _0041_First_Application
{
    public partial class Padawann
    {
        public Padawann()
        {
            Lesson = new HashSet<Lesson>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal PlanetId { get; set; }
        public int? LevelValue { get; set; }

        public virtual Planet Planet { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}

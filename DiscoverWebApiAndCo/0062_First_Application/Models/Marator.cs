using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _0041_First_Application.Models
{
    public class Marator : IWarrior
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public WarriorType WarriorType { get; set; }
    }
}

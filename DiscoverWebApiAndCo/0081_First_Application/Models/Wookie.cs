using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _0041_First_Application.Models
{
    public class Wookie : IWarrior
    {
        public static int ACCOUNT_ID = 0;

        public Wookie(string name, WarriorType warriorType) : this()
        {
            this.Name = name;
            this.WarriorType = warriorType;
        }

        public Wookie()
        {
            this.Id = ++ACCOUNT_ID;
            this.BirthDay = DateTime.Now;

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public WarriorType WarriorType { get; set; }
    }
}

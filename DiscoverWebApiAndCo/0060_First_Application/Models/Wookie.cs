using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _0041_First_Application.Models
{
    public class Wookie
    {
        public static int ACCOUNT_ID = 0;

        public Wookie()
        {
            this.Id = ++ ACCOUNT_ID;
            this.BirthDay = DateTime.Now;
        }

        public Wookie(string name, WarriorType warriorType) : this()
        {
            this.Name = name;
            this.WarriorType = warriorType;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; private set; }

        public WarriorType WarriorType { get; set; }
    }
}

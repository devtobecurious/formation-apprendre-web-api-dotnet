using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _0041_First_Application.Models
{
    public class Wookie
    {
        private static int ACCOUNT_ID = 0;

        public Wookie(string name, WarriorType warriorType)
        {
            this.Id = ACCOUNT_ID++;
            this.Name = name;
            this.BirthDay = DateTime.Now;
            this.WarriorType = warriorType;
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public DateTime BirthDay { get; private set; }

        public WarriorType WarriorType { get; set; }
    }
}

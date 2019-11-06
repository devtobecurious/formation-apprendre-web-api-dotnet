using System;
using System.Collections.Generic;

namespace _0111_First_Application.Models
{
    public partial class Utilisateur
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
    }
}

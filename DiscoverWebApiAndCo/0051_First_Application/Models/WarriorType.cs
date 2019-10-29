using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _0041_First_Application.Models
{
    // Aider le converter à ne pas générer d'entier, mais les enum réellement
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WarriorType
    {
        Chief,
        Snipper,
        Gun
    }
}

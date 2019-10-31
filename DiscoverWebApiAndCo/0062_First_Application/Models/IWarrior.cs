using System;

namespace _0041_First_Application.Models
{
    public interface IWarrior
    {
        DateTime BirthDay { get; }
        int Id { get; set; }
        string Name { get; }
        WarriorType WarriorType { get; set; }
    }
}
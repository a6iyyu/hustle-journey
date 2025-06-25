using Assets.App.Scripts.Interfaces;
using System;

namespace Assets.App.Scripts.Entities
{
    public class Character: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid PhysiqueId { get; set; }

        public Character(string name, int age, Guid physiqueId)
        {
            Id = Guid.NewGuid();
            PhysiqueId = physiqueId;
            Name = name;
            Age = age;
        }
    }
}
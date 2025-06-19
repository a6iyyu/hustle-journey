using System;
using Assets.App.Enums;
using Assets.App.Interfaces;
namespace Assets.App.Entities
{
    public class Character: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public SexType Sex { get; set; }
        public Guid PhysiqueId { get; set; }
        public Character(string name, int age, SexType sex, Guid physiqueId)
        {
            Id = Guid.NewGuid();
            PhysiqueId = physiqueId;
            Name = name;
            Age = age;
            Sex = sex;
        }
    }
}
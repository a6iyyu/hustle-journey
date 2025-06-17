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
        public Character(string name, int age, SexType sex)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Sex = sex;
        }
    }
}
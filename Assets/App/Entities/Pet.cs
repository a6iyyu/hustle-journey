using System;
using Assets.App.Enums;
using Assets.App.Interfaces;

namespace Assets.App.Entities
{
    public class Pet: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public SexType Sex { get; set; }
        public Guid OwnerId { get; set; }
        public Pet(string name, int age, string breed, SexType sex, Guid ownerId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Breed = breed;
            Sex = sex;
            OwnerId = ownerId;
        }
    }
}
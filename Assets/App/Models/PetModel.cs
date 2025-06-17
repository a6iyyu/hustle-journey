using System;
using System.Collections.Generic;
using Assets.App.Enums;
using Assets.App.Entities;
using Assets.App.Scripts.Singletons;
namespace Assets.App.Models
{
    public class PetModel : Model<Pet>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public SexType Sex { get; set; }
        public CharacterModel Owner { get; set; }
        public static PetModel Make(string name, int age, string breed, SexType sex, CharacterModel owner)
        {
            var pet = new PetModel();
            pet.Id = Guid.NewGuid();
            pet.Name = name;
            pet.Age = age;
            pet.Breed = breed;
            pet.Sex = sex;
            pet.Owner = owner;
            return pet;
        }
        /// <summary>
        /// Find a pet entity by id and map it intp a pet model
        /// </summary>
        /// <param name="id" type="Guid"></param>
        /// <returns type="PetModel"></returns>
        public static PetModel Find(Guid id) => Find<PetModel>(id);
        protected override Pet ToEntity()
        {
            return new Pet(Name, Age, Breed, Sex, Owner.Id)
            {
                Id = Id == Guid.Empty ? Guid.NewGuid() : Id
            };
        }

        protected override void FromEntity(Pet entity)
        {
            Name = entity.Name;
            Age = entity.Age;
            Breed = entity.Breed;
            Sex = entity.Sex;
            Owner = CharacterModel.Find(entity.OwnerId);
        }

        protected override Dictionary<Guid, Pet> GetStore()
        {
            return Indexer.Instance.Pets;
        }
    }
}
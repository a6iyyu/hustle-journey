using System;
using Assets.App.Enums;
using Assets.App.Entities;
using Assets.App.Scripts.Singletons;
using System.Collections.Generic;
namespace Assets.App.Models
{
    public class CharacterModel : Model<Character>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public SexType Sex { get; set; }

        protected override Character ToEntity()
        {
            return new Character(Name, Age, Sex)
            {
                Id = Id == Guid.Empty ? Guid.NewGuid() : Id
            };
        }

        protected override void FromEntity(Character entity)
        {
            Name = entity.Name;
            Age = entity.Age;
            Sex = entity.Sex;
        }

        protected override Dictionary<Guid, Character> GetStore()
        {
            return Indexer.Instance.Characters;
        }
        public static CharacterModel Find(Guid id) => Find<CharacterModel>(id);
    }
}
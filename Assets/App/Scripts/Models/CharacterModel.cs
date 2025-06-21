using System;
using Assets.App.Scripts.Singletons;
using System.Collections.Generic;
using Assets.App.Scripts.Entities;
namespace Assets.App.Scripts.Models
{
    public class CharacterModel : Model<Character>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public PhysiqueModel Physique { get; set; }

        protected override Character ToEntity()
        {
            return new Character(Name, Age, Physique.Id)
            {
                Id = Id == Guid.Empty ? Guid.NewGuid() : Id
            };
        }

        protected override void FromEntity(Character entity)
        {
            Name = entity.Name;
            Age = entity.Age;
            Physique = PhysiqueModel.Find(entity.PhysiqueId);
        }

        protected override Dictionary<Guid, Character> GetStore()
        {
            return Indexer.Instance.Characters;
        }
        public static CharacterModel Find(Guid id) => Find<CharacterModel>(id);
    }
}
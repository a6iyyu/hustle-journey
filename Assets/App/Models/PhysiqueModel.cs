using System;
using System.Collections.Generic;
using Assets.App.Entities;
using Assets.App.Scripts.Helpers;
using Assets.App.Scripts.Singletons;

namespace Assets.App.Models
{
    public class PhysiqueModel : Model<Physique>
    {
        public float HeightPoint { get => _heightPoint; set => _heightPoint = Math.Clamp(value, 0, 100); }
        private float _heightPoint { get; set; }
        public float FatPoint { get => _fatPoint; set => _fatPoint = Math.Clamp(value, 0, 100); }
        private float _fatPoint { get; set; }
        public float MusclePoint { get => _musclePoint; set => _musclePoint = Math.Clamp(value, 0, 100); }
        private float _musclePoint { get; set; }
        public float Height()
        {
            return PointMapper.MapPointToReal(HeightPoint, 150, 200);
        }
        protected override void FromEntity(Physique entity)
        {
            HeightPoint = entity.HeightPoint;
            FatPoint = entity.FatPoint;
            MusclePoint = entity.MusclePoint;
        }

        protected override Dictionary<Guid, Physique> GetStore()
        {
            return Indexer.Instance.Physiques;
        }

        protected override Physique ToEntity()
        {
            return new Physique(HeightPoint, FatPoint, MusclePoint)
            {
                Id = Id == Guid.Empty ? Guid.NewGuid() : Id
            };
        }
        public static PhysiqueModel Find(Guid id) => Find<PhysiqueModel>(id);
    }
}
using System;
using System.Collections.Generic;
using Assets.App.Entities;
using Assets.App.Enums;
using Assets.App.Scripts.Helpers;
using Assets.App.Scripts.Singletons;

namespace Assets.App.Models
{
    public class PhysiqueModel : Model<Physique>
    {
        public SexType Sex { get; set; }
        public float HeightPoint { get => _heightPoint; set => _heightPoint = Math.Clamp(value, 0, 100); }
        private float _heightPoint { get; set; }
        public float FatPoint { get => _fatPoint; set => _fatPoint = Math.Clamp(value, 0, 100); }
        private float _fatPoint { get; set; }
        public float MusclePoint { get => _musclePoint; set => _musclePoint = Math.Clamp(value, 0, 100); }
        private float _musclePoint { get; set; }
        public float Height
        {
            get => PointMapper.MapPointToReal(HeightPoint, 150, 200);
        }

        // good quadratic fat
        public float Weight
        {
            get
            {
                // Clamp inputs to [0, 100]
                float heightPoint = Math.Clamp(HeightPoint, 0f, 100f);
                float musclePoint = Math.Clamp(MusclePoint, 0f, 100f);
                float fatPoint = Math.Clamp(FatPoint, 0f, 100f);

                // Base weight and sex multiplier
                float baseWeight = Sex.Equals(SexType.Male) ? 30f : 35f; // Male: 30 kg, Female: 35 kg
                float sexMultiplier = Sex.Equals(SexType.Male) ? 1.8667f : 0.6f; // Male: 1.8667, Female: 0.6

                // Calculate weight contribution from points
                float weightContribution = (heightPoint * 0.2f) + (musclePoint * 0.4f) + (fatPoint * 0.05f + fatPoint * fatPoint * 0.001f);

                // Final weight
                float weight = baseWeight + (sexMultiplier * weightContribution);

                return weight;
            }
        }

        // good linear
        // public float Weight
        // {
        //     get
        //     {
        //         // Clamp inputs to [0, 100]

        //         // Base weight and sex multiplier
        //         float baseWeight = Sex.Equals(SexType.Male) ? 34f : 35f; // Male: 34 kg, Female: 35 kg
        //         float sexMultiplier = Sex.Equals(SexType.Male) ? 1.236f : 0.6f; // Male: 1.236, Female: 0.6

        //         // Calculate weight contribution from points
        //         float weightContribution = (HeightPoint * 0.3f) + (MusclePoint * 0.6f) + (FatPoint * 0.2f);

        //         // Final weight
        //         float weight = baseWeight + (sexMultiplier * weightContribution);

        //         return weight;
        //     }
        // }

        // outdated linear
        // public float Weight
        // {
        //     get
        //     {
        //         // Base weight and sex multiplier
        //         float baseWeight = Sex.Equals(SexType.Male) ? 50f : 35f; // Male: 50 kg, Female: 35 kg
        //         float sexMultiplier = Sex.Equals(SexType.Male) ? 1.0f : 0.6f; // Male: 1.0, Female: 0.6

        //         // Calculate weight contribution from points
        //         float weightContribution = (HeightPoint * 0.4f) + (MusclePoint * 0.6f) + (FatPoint * 0.2f);

        //         // Final weight
        //         float weight = baseWeight + (sexMultiplier * weightContribution);

        //         return weight;
        //     }
        // }
        protected override void FromEntity(Physique entity)
        {
            Sex = entity.Sex;
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
            return new Physique(Sex, HeightPoint, FatPoint, MusclePoint)
            {
                Id = Id == Guid.Empty ? Guid.NewGuid() : Id
            };
        }
        public static PhysiqueModel Find(Guid id) => Find<PhysiqueModel>(id);
    }

}
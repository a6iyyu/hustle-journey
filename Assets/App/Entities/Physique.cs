using System;
using System.Collections.Generic;
using Assets.App.Interfaces;
namespace Assets.App.Entities
{

    public class Physique : IEntity
    {
        public Guid Id { get; set; }
        public Physique(float heightPoint, float fatPoint, float musclePoint)
        {
            Id = Guid.NewGuid();
            HeightPoint = heightPoint;
            FatPoint = fatPoint;
            MusclePoint = musclePoint;
        }
        /// <summary>
        /// The height of the character in scale of 1 to 100.
        /// </summary>
        public float HeightPoint
        {
            get { return _heightPoint; }
            set
            {
                if (value > 100 || value < 0) throw new Exception("Height must be between 0 and 100");
                _heightPoint = value;
            }
        }
        private float _heightPoint;

        /// <summary>
        /// The fatness of the character in scale of 1 to 100. Doesn't include muscle and correlate with height directly.
        /// </summary>
        public float FatPoint
        {
            get => _fatPoint;
            set
            {
                if (value > 100 || value < 0) throw new Exception("Fat must be between 0 and 100");
                _fatPoint = value;
            }
        }
        private float _fatPoint;
        /// <summary>
        /// The muscle of the character in scale of 1 to 100.
        /// </summary>
        public float MusclePoint
        {
            get => _musclePoint;
            set
            {
                if (value > 100 || value < 0) throw new Exception("Muscle must be between 0 and 100");
                _musclePoint = value;
            }
        }
        private float _musclePoint;
    }
}
using System;
namespace Assets.App.Scripts.Player
{
    public class Need
    {
        private float _value;
        public float MaxValue{ get; }
        public float MinValue{ get; }
        public float Value { get => _value; set => _value = Math.Clamp(value, MinValue, MaxValue); }
        public Need(float value = 20, float minValue = 0, float maxValue = 20)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            _value = value; // Initialize to max value
        }
    }
}
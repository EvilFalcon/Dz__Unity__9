using System;

namespace CodeBase.Hero
{
    public class Point
    {
        private float _value;

        public Point(float maxValue)
        {
            Max = maxValue;
            Value = Max;
        }

        public event Action Changed;

        public float Max { get; }

        public float Value
        {
            get => _value;
            private set
            {
                _value = Math.Clamp(value, 0, Max);
                Changed?.Invoke();
            }
        }

        public void Heal(float points)
        {
            if (points <= 0)
                return;

            Value += points;
        }

        public void TakeDamage(float attack)
        {
            if (attack <= 0)
                return;

            Value -= attack;
        }
    }
}
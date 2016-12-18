using System;

namespace God.Atributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CoupleAttribute : Attribute
    {
        public string Pair { get; }
        public double Probability { get; }
        public string ChildType { get; }
        private readonly Random _random = new Random();
        public CoupleAttribute(string pair, double probability, string childType)
        {
            if (string.IsNullOrEmpty(pair) || string.IsNullOrEmpty(childType))
            {
                throw new ArgumentNullException();
            }
            if (probability < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Pair = pair;
            Probability = probability;
            ChildType = childType;
        }
        public bool GenerateDecision(bool isTestMode)
        {
            return isTestMode || _random.Next(0, 10) < Probability * 10;
        }
    }
}

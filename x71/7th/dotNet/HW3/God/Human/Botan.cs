using System;

namespace God
{
    internal sealed class Botan : Student
    {
        private const float MinRate = 3;
        public double AverageRating { get; }       

        public Botan(double averageRating, string patronymic, string name, int age, Gender gender)
            : base(patronymic, name, age, gender)
        {
            AverageRating = averageRating > MinRate ? averageRating : MinRate;
            PrintColour = ConsoleColor.Yellow;
        }
       
        public override string ToString()
        {
            return base.ToString() + ", " + Resource.AvgScore + ": " + AverageRating;
        }
    }
}

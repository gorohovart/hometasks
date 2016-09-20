using System;

namespace God
{
    internal class Botan : Student
    {
        private float minRate = 3;
        public double AverageRating { get; private set; }       

        public Botan(double averageRating, string patronymic, string name, int age, Gender gender)
            : base(patronymic, name, age, gender)
        {
            AverageRating = averageRating > minRate ? averageRating : minRate;
            PrintColour = ConsoleColor.Yellow;
        }
       
        public override string ToString()
        {
            return base.ToString() + String.Format(", Средняя оценка: {0}", AverageRating.ToString("F"));
        }
    }
}

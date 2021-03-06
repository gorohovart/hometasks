﻿using System;
using God.Helpers;

namespace God
{
    internal sealed class Botan : Student
    {
        private const float MinRate = 3;
        public double AverageRating { get; }
        private string AverageRatingToString()
        {
            return string.Format("{0:0.##}", AverageRating);
        }

        public Botan(double averageRating, string patronymic, string name, int age, Gender gender)
            : base(patronymic, name, age, gender)
        {
            AverageRating = averageRating > MinRate ? averageRating : MinRate;
            PrintColour = ColorHelper.ParseColor(Resource.BotanColor);
        }
       
        public override string ToString()
        {
            return base.ToString() + ", " + Resource.AvgScore + ": " + AverageRatingToString();
        }
    }
}

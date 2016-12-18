using God.Atributes;
using God.Enums;
using God.Helpers;

namespace God.Creatures
{
    [Couple("Girl", 0.7, "SmartGirl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.8, "Book")]
    public sealed class Botan : Student
    {
        private const float MinRate = 3;
        public double AverageRating { get; }
        private string AverageRatingToString()
        {
            return $"{AverageRating:0.##}";
        }

        public Botan(string name, string patronymic, double averageRating)
            : base(name, patronymic)
        {
            AverageRating = averageRating > MinRate ? averageRating : MinRate;
            PrintColor = ColorHelper.ParseColor(Resource.BotanColor);
        }
       
        public override string ToString()
        {
            return base.ToString() + ", " + Resource.AvgScore + ": " + AverageRatingToString();
        }
    }
}

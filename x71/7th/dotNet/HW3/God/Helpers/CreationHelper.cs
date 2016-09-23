using System;
using System.Collections.Generic;

namespace God
{
    internal sealed class CreationHelper
    {
        private readonly List<string> _manNames = new List<string> { "Егор", "Владимир", "Петр", "Константин", "Иван", "Семен" };
        private readonly List<string> _womanNames = new List<string> { "Вика", "Светлана", "Татьяна", "Валентина", "Екатерина" };
        private const int PatronymicEndLength = 4;
        private const string ManPatronymicEnd = "ович";
        private const string WomanPatronymicEnd = "овна";

        private readonly Random _random = new Random();

        public string GetRandomName(Gender gender)
        {
            var nameList = gender == Gender.Male ? _manNames : _womanNames;
            var nameIndex = _random.Next(0, _manNames.Count - 1);
            return nameList[nameIndex];
        }

        public string GetNameByPatronymic(string patronymic)
        {
            return patronymic?.Substring(0, patronymic.Length - PatronymicEndLength) ?? string.Empty;
        }

        public int GetStudentRandomAge()
        {
            const int minAge = 15;
            const int maxAge = 25;
            return _random.Next(minAge, maxAge);
        }

        public int GetParentRandomAge()
        {
            const int minAge = 26;
            const int maxAge = 60;
            return _random.Next(minAge, maxAge);
        }

        public Gender GetRandomGender()
        {
            return (Gender)_random.Next(0, 2);
        }

        public string GetRandomPatronymic(Gender gender)
        {
            var name = GetRandomName(Gender.Male);
            return gender == Gender.Male ? (name + ManPatronymicEnd) : (name + WomanPatronymicEnd);
        }

        public int GetRandomMoney()
        {
            const int minMoney = 10000;
            const int maxMoney = 100000;
            return _random.Next(minMoney, maxMoney);
        }

        public int GetRandomChildrenCount()
        {
            const int minCount = 1;
            const int maxCount = 7;
            return _random.Next(minCount, maxCount);
        }

        public double GetRandomAverageRating()
        {
            const double startRating = 4.0;
            var modifier = _random.NextDouble();
            return modifier + startRating;
        }

        public HumanType GetRandomHumanType()
        {
            var humanTypesCount = Enum.GetNames(typeof(HumanType)).Length;
            var rnd = _random.Next(1, humanTypesCount);
            return (HumanType)rnd;
        }

        public int GetMomeyByRating(double rating)
        {
            const int baseMod = 10;
            return (int)Math.Pow(baseMod, (rating));
        }

        public double GetAvgRatingByMoney(int money)
        {
            return Math.Log10(money);
        }
    }
}

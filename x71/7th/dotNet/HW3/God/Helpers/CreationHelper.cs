using System;
using System.Collections.Generic;

namespace God
{
    internal sealed class CreationHelper
    {
        private readonly List<string> ManNames = new List<string> { "Егор", "Владимир", "Петр", "Константин", "Иван", "Семен" };
        private readonly List<string> WomanNames = new List<string> { "Вика", "Светлана", "Татьяна", "Валентина", "Екатерина" };
        private readonly Random Random = new Random();
        private const int PatronymicEndLength = 4;
        private const string ManPatronymicEnd = "ович";
        private const string WomanPatronymicEnd = "овна";

        public string GetRandomName(Gender gender)
        {
            var nameList = gender == Gender.Male ? ManNames : WomanNames;
            var nameIndex = Random.Next(0, ManNames.Count - 1);
            return nameList[nameIndex];
        }

        public string GetNameByPatronymic(string patronymic)
        {
            return patronymic?.Substring(0, patronymic.Length - PatronymicEndLength) ?? string.Empty;
        }

        public string GetPatronymicByParent(Parent parent, Gender gender)
        {
            if (parent == null) throw new NullReferenceException();
            if (parent.Gender == Gender.Female)
            {
                return GetRandomPatronymic(gender);
            }
            else
            {
                return GetPatronymicByName(parent.Name, gender);
            }
        }

        public int GetStudentRandomAge()
        {
            const int minAge = 15;
            const int maxAge = 25;
            return Random.Next(minAge, maxAge);
        }

        public int GetParentRandomAge()
        {
            const int minAge = 26;
            const int maxAge = 60;
            return Random.Next(minAge, maxAge);
        }

        public Gender GetRandomGender()
        {
            return (Gender)Random.Next(0, 2);
        }

        public string GetRandomPatronymic(Gender gender)
        {
            var name = GetRandomName(Gender.Male);
            return gender == Gender.Male ? (name + ManPatronymicEnd) : (name + WomanPatronymicEnd);
        }

        public string GetPatronymicByName(string name, Gender gender)
        {
            return gender == Gender.Male ? (name + ManPatronymicEnd) : (name + WomanPatronymicEnd);
        }

        public int GetRandomMoney()
        {
            const int minMoney = 10000;
            const int maxMoney = 100000;
            return Random.Next(minMoney, maxMoney);
        }

        public int GetRandomChildrenCount()
        {
            //const int minCount = 1;
            //const int maxCount = 7;
            //return Random.Next(minCount, maxCount);
            return 1;
        }

        public double GetRandomAverageRating()
        {
            const double startRating = 4.0;
            var modifier = Random.NextDouble();
            return modifier + startRating;
        }

        public HumanType GetRandomHumanType()
        {
            var humanTypesCount = Enum.GetNames(typeof(HumanType)).Length;
            var rnd = Random.Next(1, humanTypesCount);
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

using System;
using System.Collections.Generic;

namespace God
{
    internal class God : IGod
    {
        private readonly CreationHelper _helper = new CreationHelper();
        public List<Human> Humans { get; set; }       

        public God()
        {
            Humans = new List<Human>();
        }

        public int this[int i]
        {
            get
            {
                if (i < 0 && i > Humans.Count - 1)
                {
                    return 0;
                }
                var coolParent = Humans[i] as CoolParent;
                return coolParent?.MoneyCount ?? 0;
            }
        }

        public int GetAllMoney()
        {
            int summ = 0;
            for (int i = 0; i < Humans.Count; i++)
            {
                summ += this[i];
            }
            return summ;
        }

        public Human CreateHuman()
        {
            Gender gender = _helper.GetRandomGender();
            return CreateHuman(gender);
        }

        public Human CreateHuman(Gender gender)
        {
            Human human;
            var name = _helper.GetRandomName(gender);
            var humanType = _helper.GetRandomHumanType();
            switch (humanType)
            {
                case HumanType.Student:
                    human = CreateStudent(name, gender);
                    break;

                case HumanType.Botan:
                    human = CreateBotan(name, gender);
                    break;

                case HumanType.Parent:
                    human = CreateParent(name, gender);
                    break;

                case HumanType.CoolParent:
                    human = CreateCoolParent(name, gender);
                    break;

                default:
                    throw new NotSupportedException();
            }
            Humans.Add(human);
            return human;
        }

        public Human CreatePair(Human human)
        {
            if (human == null)
            {
                return null;
            }

            Human pair = null;

            if (human is Student)
            {
                var student = human as Student;
                var name = _helper.GetNameByPatronymic(student.Patronymic);
                var botan = student as Botan;

                if (botan != null)
                {
                    var rating = botan.AverageRating;
                    pair = CreateCoolParent(name, Gender.Male, rating);
                }
                else
                {
                    pair = CreateParent(name, Gender.Male);
                }
            }
            else if (human is Parent)
            {
                var gender = _helper.GetRandomGender();
                var name = _helper.GetRandomName(gender);

                var coolParent = human as CoolParent;
                if (coolParent != null)
                {
                    var money = coolParent.MoneyCount;
                    pair = CreateBotan(name, gender, money);
                }
                else
                {
                    pair = CreateStudent(name, gender);
                }
            }
            else
            {
                throw new Exception("Can't create pair for Human.");
            }
            Humans.Add(pair);
            return pair;
        }

        private Student CreateStudent(string name, Gender gender)
        {
            var age = _helper.GetStudentRandomAge();
            var patronymic = _helper.GetRandomPatronymic(gender);

            return new Student(patronymic, name, age, gender);
        }

        private Botan CreateBotan(string name, Gender gender, int? money = null)
        {
            var age = _helper.GetStudentRandomAge();
            var patronymic = _helper.GetRandomPatronymic(gender);
            var averageRating = money == null ? _helper.GetRandomAverageRating() : _helper.GetAvgRatingByMoney(money.Value);

            return new Botan(averageRating, patronymic, name, age, gender);
        }

        private Parent CreateParent(string name, Gender gender)
        {
            var age = _helper.GetParentRandomAge();
            var childrenCount = _helper.GetRandomChildrenCount();

            return new Parent(childrenCount, name, age, gender);
        }

        private CoolParent CreateCoolParent(string name, Gender gender, double? avgRating = null)
        {
            var age = _helper.GetParentRandomAge();
            var childrenCount = _helper.GetRandomChildrenCount();
            var money = avgRating == null ? _helper.GetRandomMoney() : _helper.GetMomeyByRating(avgRating.Value);

            return new CoolParent(money, childrenCount, name, age, gender);
        }
    }
}

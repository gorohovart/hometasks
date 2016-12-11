using System;
using System.Collections.Generic;

namespace God
{
    internal sealed class God : IGod
    {
        private readonly CreationHelper Helper = new CreationHelper();
        private List<Human> Humans = new List<Human>();

        public God()
        {
        }

        public int this[int i]
        {
            get
            {
                if (i < 0 || i > Humans.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                var coolParent = Humans[i] as CoolParent;
                return coolParent?.MoneyCount ?? 0;
            }
        }

        public int GetAllMoney()
        {
            var summ = 0;
            for (var i = 0; i < Humans.Count; i++)
            {
                summ += this[i];
            }
            return summ;
        }

        public Human CreateHuman()
        {
            var gender = Helper.GetRandomGender();
            return CreateHuman(gender);
        }

        public Human CreateHuman(Gender gender)
        {
            Human human;
            var name = Helper.GetRandomName(gender);
            var humanType = Helper.GetRandomHumanType();
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

            Human pair;

            var student = human as Student;
            if (student != null)
            {
                var name = Helper.GetNameByPatronymic(student.Patronymic);
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
                var parent = human as Parent;
                var gender = Helper.GetRandomGender();
                var name = Helper.GetRandomName(gender);
                var partonymic = Helper.GetPatronymicByParent(parent, gender);
                var coolParent = human as CoolParent;
                if (coolParent != null)
                {
                    var money = coolParent.MoneyCount;
                    pair = CreateBotan(name, gender, partonymic, money);
                }
                else
                {
                    pair = CreateStudent(name, gender, partonymic);
                }
            }
            else
            {
                throw new Exception("Can't create pair for Human.");
            }
            Humans.Add(pair);
            return pair;
        }

        private Student CreateStudent(string name, Gender gender, string _patronymic = null)
        {
            var age = Helper.GetStudentRandomAge();
            var patronymic = _patronymic == null
                ? Helper.GetRandomPatronymic(gender)
                : _patronymic;

            return new Student(patronymic, name, age, gender);
        }

        private Botan CreateBotan(string name, Gender gender, string _patronymic = null, int? money = null)
        {
            var age = Helper.GetStudentRandomAge();
            var patronymic = _patronymic == null
                ? Helper.GetRandomPatronymic(gender)
                : _patronymic;
            var averageRating = money == null
                ? Helper.GetRandomAverageRating()
                : Helper.GetAvgRatingByMoney(money.Value);

            return new Botan(averageRating, patronymic, name, age, gender);
        }

        private Parent CreateParent(string name, Gender gender)
        {
            var age = Helper.GetParentRandomAge();
            var childrenCount = Helper.GetRandomChildrenCount();

            return new Parent(childrenCount, name, age, gender);
        }

        private CoolParent CreateCoolParent(string name, Gender gender, double? avgRating = null)
        {
            var age = Helper.GetParentRandomAge();
            var childrenCount = Helper.GetRandomChildrenCount();
            var money = avgRating == null ? Helper.GetRandomMoney() : Helper.GetMomeyByRating(avgRating.Value);

            return new CoolParent(money, childrenCount, name, age, gender);
        }
    }
}
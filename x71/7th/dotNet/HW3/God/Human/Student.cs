using System;
using God.Helpers;

namespace God
{
    internal class Student : Human
    {
        public string Patronymic { get; }
        public Student(string patronymic, string name, int age, Gender gender)
            : base(name, age, gender)
        {
            Patronymic = patronymic;
            PrintColour = ColorHelper.ParseColor(Resource.StudentColor);
        }

        public override string ToString()
        {
            return base.ToString() + ", " + Resource.Patronymic + ": " + Patronymic;
        }
    }
}

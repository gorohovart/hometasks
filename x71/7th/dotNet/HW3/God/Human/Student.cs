using System;

namespace God
{
    internal class Student : Human
    {
        public string Patronymic { get; private set; }
        public Student(string patronymic, string name, int age, Gender gender)
            : base(name, age, gender)
        {
            Patronymic = patronymic;
            PrintColour = ConsoleColor.Red;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Отчество: {0}", Patronymic);
        }
    }
}

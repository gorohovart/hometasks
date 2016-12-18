using System;
using System.Linq;
using God.Enums;
using God.Helpers;

namespace God.Creatures
{
    public abstract class Human : IHasName
    {
        public static string NameOfMethod => "GetChildName";
        public string Name { get; }
        public string Patronymic { get; }
        public int Age { get; }
        public Gender Gender { get; }
        public ConsoleColor PrintColor { get; internal set; }      

        protected Human(string name, string patronymic, int age, Gender gender)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            if (string.IsNullOrWhiteSpace(patronymic))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(patronymic));
            if (age <= 0) throw new ArgumentOutOfRangeException(nameof(age));
            Patronymic = patronymic;
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string GetChildName()
        {
            return new CreationHelper().GetRandomName(Gender.Female);
        }

        public override string ToString()
        {
            return
                $"{GetType().ToString().Split('.').Last()} {Name} {Patronymic}. {Resource.Age}: {Age}";
        }
    }
}

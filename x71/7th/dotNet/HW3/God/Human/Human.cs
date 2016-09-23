using System;

namespace God
{
    internal abstract class Human
    {
        public string Name { get; }
        public int Age { get; }
        public Gender Gender { get; }
        public ConsoleColor PrintColour { get; internal set; }      

        protected Human(string name, int age, Gender gender)
        {
            Name = string.IsNullOrWhiteSpace(name) ? string.Empty : name;
            Age = age > 0 ? age : 0;
            Gender = gender;
        }
        
        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Пол: {(Gender == Gender.Male ? "М" : "Ж")}";
        }
    }
}

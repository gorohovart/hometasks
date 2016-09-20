using System;

namespace God
{
    internal abstract class Human
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public ConsoleColor PrintColour { get; internal set; }      

        protected Human(string name, int age, Gender gender)
        {
            Name = String.IsNullOrWhiteSpace(name) ? string.Empty : name;
            Age = age > 0 ? age : 0;
            Gender = gender;
        }
        
        public override string ToString()
        {
            return String.Format("Имя: {0}, Возраст: {1}, Пол: {2}", Name, Age, Gender == Gender.Male ? "М" : "Ж");
        }
    }
}

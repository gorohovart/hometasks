using System;

namespace God
{
    internal class Parent : Human
    {
        public int ChildrenCount { get; }
        public Parent(int childrenCount, string name, int age, Gender gender)
            : base(name, age, gender)
        {
            ChildrenCount = childrenCount > 0 ? childrenCount : 0;
            PrintColour = ConsoleColor.Green;
        }
        
        public override string ToString()
        {
            return base.ToString() + $", Количество детей: {ChildrenCount}";
        }
    }
}

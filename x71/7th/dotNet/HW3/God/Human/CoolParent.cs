using System;

namespace God
{
    internal sealed class CoolParent : Parent
    {
        public int MoneyCount { get; private set; }

        public CoolParent(int moneyCount, int childrenCount, string name, int age, Gender gender)
            : base(childrenCount, name, age, gender)
        {
            MoneyCount = moneyCount > 0 ? moneyCount : 0;
            PrintColour = ConsoleColor.Green;
        }       

        public override string ToString()
        {
            return base.ToString() + ", " + Resource.MoneyAmount + ": ";
        }
    }
}

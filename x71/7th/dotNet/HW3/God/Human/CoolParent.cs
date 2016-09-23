using System;

namespace God
{
    internal class CoolParent : Parent
    {
        public int MoneyCount { get; private set; }

        public CoolParent(int moneyCount, int childrenCount, string name, int age, Gender gender)
            : base(childrenCount, name, age, gender)
        {
            MoneyCount = moneyCount > 0 ? moneyCount : 0;
        }       

        public override string ToString()
        {
            return base.ToString() + ", Количество денег: ";
        }
    }
}

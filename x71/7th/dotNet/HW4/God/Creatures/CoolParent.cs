using God.Enums;
using God.Helpers;

namespace God.Creatures
{
    public sealed class CoolParent : Parent
    {
        public int MoneyCount { get; private set; }

        public CoolParent(int moneyCount, int childrenCount, string name, string patronymic, int age, Gender gender)
            : base(childrenCount, name, patronymic, age, gender)
        {
            MoneyCount = moneyCount > 0 ? moneyCount : 0;
            PrintColor = ColorHelper.ParseColor(Resource.CoolParentColor);
        }       

        public override string ToString()
        {
            return base.ToString() + ", " + Resource.MoneyAmount + ": ";
        }
    }
}

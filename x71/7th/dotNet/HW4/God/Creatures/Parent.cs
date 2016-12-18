using God.Enums;
using God.Helpers;

namespace God.Creatures
{
    public class Parent : Human
    {
        public int ChildrenCount { get; }
        public Parent(int childrenCount, string name, string patronymic, int age, Gender gender)
            : base(name, patronymic, age, gender)
        {
            ChildrenCount = childrenCount > 0 ? childrenCount : 0;
            PrintColor = ColorHelper.ParseColor(Resource.ParentColor);

        }
        
        public override string ToString()
        {
            return base.ToString() + ", " + Resource.ChildrenCount + ": " + ChildrenCount;
        }
    }
}

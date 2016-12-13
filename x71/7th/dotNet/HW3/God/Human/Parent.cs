using System;
using God.Helpers;

namespace God
{
    internal class Parent : Human
    {
        public int ChildrenCount { get; }
        public Parent(int childrenCount, string name, int age, Gender gender)
            : base(name, age, gender)
        {
            ChildrenCount = childrenCount > 0 ? childrenCount : 0;
            PrintColour = ColorHelper.ParseColor(Resource.ParentColor);

        }
        
        public override string ToString()
        {
            return base.ToString() + ", " + Resource.ChildrenCount + ": " + ChildrenCount;
        }
    }
}

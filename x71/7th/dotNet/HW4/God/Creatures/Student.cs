using God.Atributes;
using God.Enums;
using God.Helpers;

namespace God.Creatures
{
    [Couple("Girl", 0.7, "Girl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.5, "Girl")]
    public class Student : Human
    {
        public Student(string name, string patronymic)
            : base(name, patronymic, new CreationHelper().GetRandomAge(), Gender.Male)
        {
            PrintColor = ColorHelper.ParseColor(Resource.StudentColor);
        }
    }
}

using God.Atributes;
using God.Enums;
using God.Helpers;

namespace God.Creatures
{
    [Couple("Student", 0.7, "Girl")]
    [Couple("Botan", 0.3, "SmartGirl")]
    public class Girl : Human
    {
        public Girl(string name, string patronymic) : base(name, patronymic, age: new CreationHelper().GetRandomAge(), gender: Gender.Female)
        {
            PrintColor = ColorHelper.ParseColor(Resource.Girl);
        }

    }
}

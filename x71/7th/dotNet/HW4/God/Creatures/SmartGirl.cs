using God.Atributes;
using God.Helpers;

namespace God.Creatures
{
    [Couple("Student", 0.2, "Girl")]
    [Couple("Botan", 0.5, "Book")]
    public sealed class SmartGirl : Girl
    {
        public SmartGirl(string name, string patronymic) : base(name, patronymic)
        {
        }
    }
}

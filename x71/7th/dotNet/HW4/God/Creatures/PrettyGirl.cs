using God.Atributes;
using God.Helpers;

namespace God.Creatures
{
    [Couple("Student", 0.4, "PrettyGirl")]
    [Couple("Botan", 0.1, "PrettyGirl")]
    public sealed class PrettyGirl : Girl
    {
        public PrettyGirl(string name, string patronymic) : base(name, patronymic)
        {
        }
    }
}

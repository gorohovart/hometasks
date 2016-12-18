using God.Creatures;
using God.Enums;

namespace God
{
    internal interface IGod
    {
        Human CreateHuman();
        Human CreateHuman(Gender gender);
        Human CreatePair(Human human);
    }
}

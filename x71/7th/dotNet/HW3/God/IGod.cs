namespace God
{
    internal interface IGod
    {
        Human CreateHuman();
        Human CreateHuman(Gender gender);
        Human CreatePair(Human human);
    }
}

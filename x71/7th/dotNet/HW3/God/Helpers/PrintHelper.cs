using System;

namespace God.Helpers
{
    internal sealed class PrintHelper
    {
        public void PrintHuman(Human human)
        {
            if (human == null)
            {
                return;
            }

            Console.ForegroundColor = human.PrintColour;
            Console.Write(human.ToString());

            var coolParent = human as CoolParent;
            if (coolParent != null)
            {
                Console.BackgroundColor = ColorHelper.ParseColor(Resource.MoneyBackgroundColor);
                Console.Write(coolParent.MoneyCount.ToString("C"));
            }
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintPair(Human pair)
        {
            Console.BackgroundColor = ColorHelper.ParseColor(Resource.PairBackgroundColor);
            PrintHuman(pair);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintColourInfo()
        {

            Console.ForegroundColor = ColorHelper.ParseColor(Resource.ParentColor); 
            Console.Write(Resource.Parents);

            Console.ForegroundColor = ColorHelper.ParseColor(Resource.StudentColor);
            Console.Write(@" " + Resource.Students);

            Console.ForegroundColor = ColorHelper.ParseColor(Resource.BotanColor);
            Console.Write(@" " + Resource.Botans);

            Console.ForegroundColor = ColorHelper.ParseColor(Resource.CoolParentColor);
            Console.Write(@" " + Resource.CoolParents);

            Console.WriteLine(string.Empty);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Resource.OutputFileName + @" " + Resource.TotalMoneyGreeting);

            Console.WriteLine(string.Empty);
        }
    }
}

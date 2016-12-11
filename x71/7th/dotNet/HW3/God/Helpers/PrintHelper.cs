using System;
namespace God
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
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(coolParent.MoneyCount.ToString("C"));
            }
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintPair(Human pair)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            PrintHuman(pair);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintColourInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Resource.Parents);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" " + Resource.Students);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" " + Resource.Botans);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" " + Resource.CoolParents);

            Console.WriteLine(string.Empty);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Resource.OutputFileName + " " + Resource.TotalMoneyGreeting);

            Console.WriteLine(string.Empty);
        }
    }
}

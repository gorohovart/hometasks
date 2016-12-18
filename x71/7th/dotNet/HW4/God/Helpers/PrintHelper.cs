using System;
using God.Creatures;

namespace God.Helpers
{
    public static class PrintHelper
    {
        public static void PrintHuman(Human human)
        {
            if (human == null) throw new ArgumentNullException();
            Console.ForegroundColor = human.PrintColor;
            Console.Write($"-->  {human}");

            var coolParent = human as CoolParent;
            if (coolParent != null)
            {
                Console.BackgroundColor = ColorHelper.ParseColor(Resource.MoneyBackgroundColor);
                Console.Write(coolParent.MoneyCount.ToString("C"));
            }
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintChild(IHasName child)
        {
            if (child == null) throw new ArgumentNullException();
            var human = child as Human;
            if (human != null)
            {
                Console.ForegroundColor = human.PrintColor;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine($"  {Resource.ChildBorn}{child}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintPair(Human pair)
        {
            if (pair == null) throw new ArgumentNullException();
            Console.BackgroundColor = ColorHelper.ParseColor(Resource.PairBackgroundColor);
            PrintHuman(pair);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void PrintColourInfo()
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

        public static void PrintColourError(string str)
        {
            if (str == null) throw new ArgumentNullException();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

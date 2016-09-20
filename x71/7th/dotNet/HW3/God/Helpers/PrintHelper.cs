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
            Console.Write("Классные родители");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Студенты");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Ботаны");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Крутые предки\n");

            Console.Write(string.Empty);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Суммарные деньги крутых предков выведены в файл TotalMoney.txt,");
            Console.WriteLine("который находится рядом с исполняемым файлом.");

            Console.WriteLine(string.Empty);
        }
    }
}

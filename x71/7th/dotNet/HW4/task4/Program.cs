using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using God;
using God.Creatures;
using God.Enums;
using God.Helpers;

namespace task4
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            if (!SundayCheck())
            {
                Console.WriteLine(Resource.SundayError);
                return;
            }

            PrintInfo();

            ConsoleKeyInfo cki;
            do
            {
                var ch = new CreationHelper();

                var human1 = ch.GetRandomHumanForDate();
                var human2 = ch.GetRandomHumanForDate();
                PrintHelper.PrintHuman(human1);
                PrintHelper.PrintHuman(human2);
                try
                {
                    var child = DatingHelper.Couple(human1, human2);
                    if (child != null)
                    {
                        PrintHelper.PrintChild(child); 
                    }
                }
                catch (Exception)
                {
                    PrintHelper.PrintColourError(Resource.SameGenderError);
                }

                do
                {
                    cki = Console.ReadKey(true);
                } while (!(KeyIsEnterKey(cki.Key) || KeyIsExitKey(cki.Key)));

            } while (KeyIsEnterKey(cki.Key));
        }

        private static void PrintInfo()
        {
            Console.WriteLine(Resource.Hello);
            Console.WriteLine(Resource.PressButton);
        }

        private static bool SundayCheck()
        {
            var date = DateTime.Now;
            return true; //date.DayOfWeek != DayOfWeek.Sunday;
        }

        private static bool KeyIsExitKey(ConsoleKey key)
        {
            return (key == ConsoleKey.Q) || (key == ConsoleKey.Escape);
        }

        private static bool KeyIsEnterKey(ConsoleKey key)
        {
            return (key == ConsoleKey.Enter);
        }
    }
}

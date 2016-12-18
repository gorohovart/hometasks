using System;
using God;
using God.Creatures;
using God.Helpers;

namespace CoupleTest
{
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            TestEachToEach();
        }

        private static Human[] _people =
        {
            new Student("Артем", "Владимирович"),
            new Botan("Артем", "Александрович", 14.88),
            new Girl("Катерина", "Олеговна"),
            new PrettyGirl("Елизавета", "Петровна"),
            new SmartGirl("Анастасия", "Владимировна")
        };

        private static void TestEachToEach()
        {
            DatingHelper.IsTestMode = true;

            for (var i = 0; i < 5; i++)
            {
                for (var j = i; j < 5; j++)
                {
                    var human1 = _people[i];
                    var human2 = _people[j];
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
                }
        }
        }
    }
}

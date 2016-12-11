﻿using System;

namespace God
{
    internal sealed class GodConsole
    {
        private readonly God God;
        private string Path = Resource.OutputFileName;
        private readonly PrintHelper PrintHelper;

        public GodConsole()
        {
            God = new God();
            PrintHelper = new PrintHelper();
        }

        public void Run()
        {
            if (!CheckDate())
            {
                Console.WriteLine(Resource.SundayError);
                return;
            }

            Console.WriteLine(Resource.Greeting);

            int humansCount;
            while (!int.TryParse(Console.ReadLine(), out humansCount) || humansCount < 1)
            {
                Console.WriteLine(Resource.InputError);
            }

            PrintHelper.PrintColourInfo();

            for (var i = 0; i < humansCount; i++)
            {
                Human human;
                switch (i)
                {
                    case 0:
                        human = God.CreateHuman(Gender.Male);
                        break;
                    case 1:
                        human = God.CreateHuman(Gender.Female);
                        break;
                    default:
                        human = God.CreateHuman();
                        break;
                }

                PrintHelper.PrintHuman(human);

                var pair = God.CreatePair(human);
                PrintHelper.PrintPair(pair);
            }

            PrintTotalMoney(God);
        }

        private static bool CheckDate()
        {
            var date = DateTime.Now;
            return date.DayOfWeek != DayOfWeek.Sunday;
        }

        private void PrintTotalMoney(God god)
        {
            var money = god.GetAllMoney();            
            System.IO.File.WriteAllText(Path, money.ToString());
        }
    }
}

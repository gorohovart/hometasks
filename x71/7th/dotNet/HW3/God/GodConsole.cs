using System;

namespace God
{
    internal sealed class GodConsole
    {
        private readonly IGod _god;
        private const string path = @"TotalMoney.txt";
        private PrintHelper printHelper;

        public GodConsole()
        {
            _god = new God();
            printHelper = new PrintHelper();
        }

        public void Run()
        {
            if (!CheckDate())
            {
                Console.WriteLine("Извините, сегодня воскресение. Сотворить людей не получится!");
                return;
            }

            Console.WriteLine("Добрый день. Вы используете консоль бога.\nСколько людей вы хотите сотворить?");

            int humansCount;
            while (!Int32.TryParse(Console.ReadLine(), out humansCount) || humansCount < 1)
            {
                Console.WriteLine("Вы ввели некорректное число. Попробуйте еще раз");
            }

            printHelper.PrintColourInfo();

            for (var i = 0; i < humansCount; i++)
            {
                Human human;
                if (i == 0)
                {
                    human = _god.CreateHuman(Gender.Male);
                }
                else if (i == 1)
                {
                    human = _god.CreateHuman(Gender.Female);
                }
                else
                {
                    human = _god.CreateHuman();
                }

                printHelper.PrintHuman(human);

                var pair = _god.CreatePair(human);
                printHelper.PrintPair(pair);
            }

            PrintTotalMoney();
        }

        private static bool CheckDate()
        {
            var date = DateTime.Now;
            return date.DayOfWeek != DayOfWeek.Sunday;
        }

        private void PrintTotalMoney()
        {
            var god = _god as God;
            if (god == null) return;

            var money = god.GetAllMoney();            
            System.IO.File.WriteAllText(path, money.ToString());
        }
    }
}

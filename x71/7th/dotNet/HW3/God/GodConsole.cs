using System;

namespace God
{
    internal sealed class GodConsole
    {
        private readonly IGod _god;
        private const string Path = @"TotalMoney.txt";
        private readonly PrintHelper _printHelper;

        public GodConsole()
        {
            _god = new God();
            _printHelper = new PrintHelper();
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
            while (!int.TryParse(Console.ReadLine(), out humansCount) || humansCount < 1)
            {
                Console.WriteLine("Вы ввели некорректное число. Попробуйте еще раз");
            }

            _printHelper.PrintColourInfo();

            for (var i = 0; i < humansCount; i++)
            {
                Human human;
                switch (i)
                {
                    case 0:
                        human = _god.CreateHuman(Gender.Male);
                        break;
                    case 1:
                        human = _god.CreateHuman(Gender.Female);
                        break;
                    default:
                        human = _god.CreateHuman();
                        break;
                }

                _printHelper.PrintHuman(human);

                var pair = _god.CreatePair(human);
                _printHelper.PrintPair(pair);
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
            System.IO.File.WriteAllText(Path, money.ToString());
        }
    }
}

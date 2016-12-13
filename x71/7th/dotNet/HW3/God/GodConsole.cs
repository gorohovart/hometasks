using System;
using God.Helpers;

namespace God
{
    internal sealed class GodConsole
    {
        private readonly God _god;
        private readonly PrintHelper _printHelper;

        public GodConsole()
        {
            _god = new God();
            _printHelper = new PrintHelper();
        }

        public void Run()
        {
            if (!SundayCheck())
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

                Console.WriteLine(string.Empty);
            }
            var money = _god.GetAllMoney();
            MoneyPrinter.PrintTotalMoney(money);
        }

        private static bool SundayCheck()
        {
            var date = DateTime.Now;
            return true; //date.DayOfWeek != DayOfWeek.Sunday;
        }

        
    }
}

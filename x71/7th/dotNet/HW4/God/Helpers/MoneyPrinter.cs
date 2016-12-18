using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace God.Helpers
{
    public sealed class MoneyPrinter
    {
        private const string Path = @"TotalMoney.txt";
        public static void PrintTotalMoney(int money)
        {
            
            System.IO.File.WriteAllText(Path, money.ToString());
        }
    }
}

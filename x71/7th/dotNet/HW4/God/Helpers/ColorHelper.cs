using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace God.Helpers
{
    internal static class ColorHelper
    {
        public static ConsoleColor ParseColor(string colorName)
        {
            if (colorName == null) throw new ArgumentNullException();
            ConsoleColor color;
            Enum.TryParse(colorName, out color);
            return color;
        }
    }
}

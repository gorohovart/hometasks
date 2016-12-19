using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace God.Helpers
{
    public static class NameHelper
    {
        public static string GetTypeName(object obj)
        {
            return obj?.GetType().ToString().Split('.').Last();
        }
    }
}

using System;
using System.Linq;
using FilmLibruary.Model;

namespace FilmLibruary.Views.FieldValidator
{
    internal sealed class FieldValidator
    {
        private readonly string _badChars = "~!@#$%^&abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public bool IsStringValid(string str)
        {
            return str != null && _badChars.All(c => !str.Contains(c));
        }

        public bool IsYearValid(string strYear)
        {
            if (strYear == null) return false;
            if (strYear == string.Empty) return true;
            int year = Convert.ToInt32(strYear);
            return (year <= SearchDescriptor.MaxYear && year >= SearchDescriptor.MinYear);
        }
    }
}

using System;

namespace MyFilmDatabase.Helpers
{
    public static class UserInputChecker
    {
        public static bool IsYear(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            int year;
            if (int.TryParse(text, out year))
            {
                return false;
            }

            return (1895 <= year) && (year <= DateTime.Now.Year);
        }
    }
}
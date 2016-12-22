using System;

namespace FilmLibruary.Model
{
    public sealed class SearchDescriptor
    {
        public const int MinYear = 1896;
        public static readonly int MaxYear = DateTime.Now.Year;
        public const int NumberOfDigitsInYear = 4;

        private int _yearTo;
        private int _yearFrom;

        public int Id { get; set; }
        public string Country { get; set; }
        public string FilmName { get; set; }
        public string Producer { get; set; }
        public string MainActors { get; set; }

        public int YearTo
        {
            get
            {
                return _yearTo;
            }
            set
            {
                if (value <= MaxYear && value >= MinYear)
                {
                    _yearTo = value;
                }
            }
        }

        public int YearFrom
        {
            get
            {
                return _yearFrom;
            }
            set
            {
                if (value <= MaxYear && value >= MinYear)
                {
                    _yearFrom = value;
                }
            }
        }
    }
}

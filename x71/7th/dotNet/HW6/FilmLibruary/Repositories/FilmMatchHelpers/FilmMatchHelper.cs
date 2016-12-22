using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FilmLibruary.Model;

namespace FilmLibruary.Repositories.FilmMatchHelpers
{
    internal sealed class FilmMatchHelper : IFilmMatchHelper
    {
        public bool Match(Film film, SearchDescriptor descriptor)
        {
            return MatchFilmName(film.Name.ToLower(), descriptor.FilmName) &&
                MatchYear(film.Year, descriptor.YearFrom, descriptor.YearTo) &&
                MatchCountry(film.Country.ToLower(), descriptor.Country) &&
                MatchProducer(film.Producer.Name.ToLower(), descriptor.Producer) &&
                MatchActors(film.MainActors, descriptor.MainActors);
        }

        #region MatchMethods
        private static bool MatchFilmName(string filmName, string descriptorfilmName)
        {
            if (filmName == null || descriptorfilmName == null) return false;
            if (filmName == descriptorfilmName || descriptorfilmName == string.Empty) return true;
            if (filmName.Contains(descriptorfilmName)) return true;
            var regexpStr = StringToRegexString(descriptorfilmName);
            var regex = new Regex(regexpStr);
            var result = regex.IsMatch(filmName);
            return result;
        }

        private static bool MatchYear(int filmYear, int descriptorYearFrom, int descriptorYearTo)
        {
            return (filmYear >= descriptorYearFrom && filmYear <= descriptorYearTo);
        }

        private static bool MatchCountry(string filmCountry, string descriptorCountry)
        {
            if (filmCountry == null || descriptorCountry == null) return false;
            if (filmCountry == descriptorCountry || descriptorCountry == string.Empty) return true;

            var regexpStr = StringToRegexString(descriptorCountry);
            var regex = new Regex(regexpStr);
            return regex.IsMatch(filmCountry);
        }

        private bool MatchProducer(string filmProducer, string descriptorProducer)
        {
            if (filmProducer == null || descriptorProducer == null) return false;
            if (filmProducer == descriptorProducer || descriptorProducer == string.Empty) return true;

            var regexpStr = StringToRegexString(descriptorProducer);
            var regex = new Regex(regexpStr);
            return regex.IsMatch(filmProducer);
        }

        private static bool MatchActors(IReadOnlyCollection<Actor> actors, string descriptorActors)
        {
            if (actors == null || descriptorActors == null || actors.Count == 0 && descriptorActors != String.Empty) return false;
            if (descriptorActors == String.Empty)
            {
                return true;
            }

            var regexpStr = StringToRegexString(descriptorActors);
            var regex = new Regex(regexpStr);

            IEnumerable<string> actorNamesList = actors.Select(a => a.Name);
            return actorNamesList.Any(name => regex.IsMatch(name.ToLower()));
        }

        private static string StringToRegexString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            var strWithReplacedMult = str.Replace("*", "(.)*");
            var strWithReplacedAsk = strWithReplacedMult.Replace("?", "(.)?");

            return "^" + strWithReplacedAsk + "$";
        }
        #endregion
    }
}

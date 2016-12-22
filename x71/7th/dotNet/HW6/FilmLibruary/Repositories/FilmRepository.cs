using System.Collections.Generic;
using System.Linq;
using FilmLibruary.DbAdapter;
using FilmLibruary.Model;
using FilmLibruary.Repositories.FilmMatchHelpers;

namespace FilmLibruary.Repositories
{
    internal sealed class FilmRepository : IFilmRepository
    {
        private List<Film> _films;
        private readonly FilmDbAdapter _filmDbAdapter;
        private readonly IFilmMatchHelper _filmMatchHelper;

        public FilmRepository()
        {
            _filmDbAdapter = new FilmDbAdapter();
            _filmMatchHelper = new FilmMatchHelper();
        }

        public List<Film> GetAllFilms()
        {
            return _films = _filmDbAdapter.GetAllFilms();
        }

        public bool EditFilm(FilmEditDescriptor descriptor)
        {
            foreach (var film in _films.Where(film => film.Id == descriptor.FilmId))
            {
                film.Name = descriptor.Name;
                film.Producer = new Producer(descriptor.Producer);
                film.Year = descriptor.Year;
            }
            return _filmDbAdapter.EditFilm(descriptor);
        }

        public bool RemoveFilms(List<int> ids)
        {
            var listForRemove = (from film in _films from id in ids where film.Id == id select film).ToList();

            foreach (var film in listForRemove)
            {
                _films.Remove(film);
            }

            return _filmDbAdapter.RemoveFilm(ids);
        }

        public List<Film> FindFilms(SearchDescriptor descriptor)
        {
            return _films.Where(film => _filmMatchHelper.Match(film, descriptor)).ToList();
        }

        public void SetConnection(string connectionString)
        {
            _filmDbAdapter.SetConnection(connectionString);
        }
    }
}

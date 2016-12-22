using System.Collections.Generic;
using FilmLibruary.Model;
using FilmLibruary.Repositories;
using FilmLibruary.Views;

namespace FilmLibruary.Controller
{
    internal sealed class FilmController : IFilmController
    {
        private readonly IFilmRepository _filmRepository;
        private readonly LibraryView _libruaryView;

        public FilmController(LibraryView libruaryView, IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
            _libruaryView = libruaryView;
            _libruaryView.SetController(this);
        }

        #region ViewToModelMethods
        public bool EditFilm(FilmEditDescriptor descriptor)
        {
            return descriptor != null && _filmRepository.EditFilm(descriptor);
        }

        public bool RemoveFilms(List<int> ids)
        {
            return ids != null && _filmRepository.RemoveFilms(ids);
        }

        public List<Film> FindFilms(SearchDescriptor descriptor)
        {
            if (descriptor == null)
            {
                return new List<Film>();
            }
            return _filmRepository.FindFilms(descriptor);
        }

        public List<Film> GetFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        public void OpenNewDbFilms(string connectionString)
        {
            _filmRepository.SetConnection(connectionString);
        }
        #endregion
    }
}

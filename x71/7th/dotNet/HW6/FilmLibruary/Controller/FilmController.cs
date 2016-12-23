using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FilmLibruary.Model;
using FilmLibruary.Repositories;
using FilmLibruary.Views;

namespace FilmLibruary.Controller
{
    internal sealed class FilmController : IFilmController
    {
        private readonly IFilmRepository _filmRepository;
        private readonly LibraryView _libruaryView;
        private string _connectionString;
        private BindingList<FilmViewModel> _filmBindingList;
        private SearchDescriptor _searchDescriptor;
        public event EventHandler LoadComplete;
        public event EventHandler SearchComplete;
        public event EventHandler ExeptionHappened;

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

        public BindingList<FilmViewModel> GetFilmBindingList()
        {
            return _filmBindingList;
        }

        public List<Film> FindFilms(SearchDescriptor descriptor)
        {
            if (descriptor == null)
            {
                return new List<Film>();
            }
            return _filmRepository.FindFilms(descriptor);
        }

        private List<Film> GetFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        private static List<FilmViewModel> FilmsToViewModel(IEnumerable<Film> films)
        {
            return (from film in films
                    let producerName = film.Producer.Name
                    let mainActorsNames = film.MainActors.Select(actor => actor.Name)
                    let actors = string.Join(", ", mainActorsNames)
                    let picture = new Bitmap(film.Picture, new Size(100, 100))
                    select new FilmViewModel
                    {
                        Id = film.Id,
                        Name = film.Name,
                        Picture = picture,
                        Year = film.Year,
                        Country = film.Country,
                        Producer = producerName,
                        Actors = actors
                    }).ToList();
        }

        private void StartLoad()
        {
            _filmRepository.SetConnection(_connectionString);
            var films = GetFilms();
            var viewFilms = FilmsToViewModel(films);
            _filmBindingList = new BindingList<FilmViewModel>(viewFilms);
            LoadComplete?.Invoke(this, EventArgs.Empty);
        }

        public void StartFilmsLoad(string connectionString)
        {
            _connectionString = connectionString;
            var task = new Task(StartLoad);
            task.ContinueWith(ExceptionHandler, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        private void StartSearch()
        {
            var list = _searchDescriptor == null ? new List<Film>() : _filmRepository.FindFilms(_searchDescriptor);
            _filmBindingList = new BindingList<FilmViewModel>(FilmsToViewModel(list));
            SearchComplete?.Invoke(this, EventArgs.Empty);
        }

        public void StartFilmsSearch(SearchDescriptor searchDescriptor)
        {
            _searchDescriptor = searchDescriptor;
            new Task(StartSearch).Start();
        }
        private void ExceptionHandler(Task task)
        {
            var exception = task.Exception;
            ExeptionHappened?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}

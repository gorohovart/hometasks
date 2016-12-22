using System.Collections.Generic;
using FilmLibruary.Model;

namespace FilmLibruary.Controller
{
    public interface IFilmController
    {
        bool EditFilm(FilmEditDescriptor descriptor);
        bool RemoveFilms(List<int> ids);
        List<Film> GetFilms();
        List<Film> FindFilms(SearchDescriptor descriptor);
        void OpenNewDbFilms(string connectionString);
    }
}

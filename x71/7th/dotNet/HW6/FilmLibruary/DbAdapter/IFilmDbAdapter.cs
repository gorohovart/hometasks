using System.Collections.Generic;
using FilmLibruary.Model;

namespace FilmLibruary.DbAdapter
{
    public interface IFilmDbAdapter
    {
        List<Film> GetAllFilms();
        bool EditFilm(FilmEditDescriptor descriptor);
        bool RemoveFilms(List<int> ids);
        List<Film> FindFilms();
        void SetConnection(string connectionString);
    }
}

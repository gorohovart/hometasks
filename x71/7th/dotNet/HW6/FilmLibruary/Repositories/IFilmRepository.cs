using System.Collections.Generic;
using FilmLibruary.Model;

namespace FilmLibruary.Repositories
{
    public interface IFilmRepository
    {
        List<Film> GetAllFilms();
        bool EditFilm(FilmEditDescriptor descriptor);
        bool RemoveFilms(List<int> ids);
        List<Film> FindFilms(SearchDescriptor descriptor);
        void SetConnection(string connectionString);
    }
}

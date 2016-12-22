using FilmLibruary.Model;

namespace FilmLibruary.Repositories.FilmMatchHelpers
{
    public interface IFilmMatchHelper
    {
        bool Match(Film film, SearchDescriptor descriptor);
    }
}

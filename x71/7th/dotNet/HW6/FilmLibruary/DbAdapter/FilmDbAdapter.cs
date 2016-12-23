using System.Collections.Generic;
using System.Data.Common;
using FilmLibruary.DbAdapter.DBHelper;
using FilmLibruary.DbWorkers;
using FilmLibruary.Model;

namespace FilmLibruary.DbAdapter
{
    internal sealed class FilmDbAdapter
    {

        private readonly FilmDbHelper _dbHelper = new FilmDbHelper();
        private readonly FilmDbWorker _filmDbWorker = new FilmDbWorker();

        public List<Film> GetAllFilms()
        {
            const string getFilmsQuery = "select * from films";
            const string getActorsToFilmQuery = "select filmId, name from Actor, ActorToFilm where Actor.Id = ActorToFilm.ActorId";

            var tempDictionary = new Dictionary<int, Film>();

            var filmWithoutActors = _filmDbWorker.ExecuteQuery(getFilmsQuery);

            foreach (DbDataRecord rec in filmWithoutActors)
            {
                var film = _dbHelper.ConvertRecordToFilm(rec);
                tempDictionary.Add(film.Id, film);
            }

            //add actors
            var filmIdToActorsRecs = _filmDbWorker.ExecuteQuery(getActorsToFilmQuery);
            foreach (DbDataRecord rec in filmIdToActorsRecs)
            {
                var filmIdToActor = _dbHelper.ConvertRecordToActorToFilm(rec);
                if (tempDictionary.ContainsKey(filmIdToActor.FilmId))
                {
                    tempDictionary[filmIdToActor.FilmId].MainActors.Add(filmIdToActor.Actor);
                }              
            }

            var filmList = new List<Film>();
            filmList.AddRange(tempDictionary.Values);

            return filmList;
        }

        public bool EditFilm(FilmEditDescriptor descriptor)
        {
            const string editFilmQuery = "update Films set Name = '{0}', Year = {1}, Producer = '{2}' where Id = {3}";
            var formattedQuery = string.Format(editFilmQuery, descriptor.Name, descriptor.Year, descriptor.Producer, descriptor.FilmId);
            _filmDbWorker.ExecuteQuery(formattedQuery);

            return true;
        }

        public bool RemoveFilm(List<int> ids)
        {
            const string deleteFilmQuery = "delete from Films where id = {0}";
            foreach (int i in ids)
            {
                var formattedString = string.Format(deleteFilmQuery, i);
                _filmDbWorker.ExecuteQuery(formattedString);
            }

            return true;
        }

        public void SetConnection(string connectionString)
        {
            _filmDbWorker.SetConnectionString(connectionString);
        }
    }
}

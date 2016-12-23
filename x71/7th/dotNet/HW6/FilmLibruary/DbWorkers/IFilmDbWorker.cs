using System.Collections.Generic;
using System.Data.Common;

namespace FilmLibruary.DbWorkers
{
    internal interface IFilmDbWorker
    {
        void SetConnectionString(string connectionString);
        List<DbDataRecord> ExecuteQuery(string query);
    }
}

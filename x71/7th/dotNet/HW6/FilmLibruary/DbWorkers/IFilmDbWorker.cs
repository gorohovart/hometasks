using System.Collections.Generic;
using System.Data.Common;

namespace FilmLibruary.DbWorkers
{
    internal interface IFilmDbWorker
    {
        void SetConnection(string connectionString);
        List<DbDataRecord> ExecuteReadQuery(string query);
    }
}

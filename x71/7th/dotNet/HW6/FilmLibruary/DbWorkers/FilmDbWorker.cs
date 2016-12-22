using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace FilmLibruary.DbWorkers
{
    internal sealed class FilmDbWorker : IFilmDbWorker
    {
        private SqlConnection _currentConnection;
        //private string _connectionString = @"Data Source=(local);Initial Catalog=Films;Integrated Security=true";
        private string _fileConnectionString = //@"Data Source=(local);Database=Films;AttachDbFilename={0};Integrated Security=SSPI";
            @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security = True; Connect Timeout = 30";

        public void SetConnection(string fileName)
        {
            var connectionString = string.Format(_fileConnectionString, fileName);
            var sqlConnection = new SqlConnection(connectionString);
            _currentConnection = sqlConnection;
        }

        public List<DbDataRecord> ExecuteReadQuery(string query)
        {
            _currentConnection.Open();
            var commandGetArtistsToFilm = new SqlCommand(query, _currentConnection);
            var reader = commandGetArtistsToFilm.ExecuteReader();

            var result = reader.Cast<DbDataRecord>().ToList();

            _currentConnection.Close();
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace FilmLibruary.DbWorkers
{
    internal sealed class FilmDbWorker : IFilmDbWorker
    {
        private string _connectionString;
        //private string _connectionString = @"Data Source=(local);Initial Catalog=Films;Integrated Security=true";
        private string _fileConnectionString =
            //@"Data Source=(local);Database=Films;AttachDbFilename={0};Integrated Security=SSPI";
            @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security = True; Connect Timeout = 30";

        public void SetConnectionString(string fileName)
        {
            _connectionString = string.Format(_fileConnectionString, fileName);
        }


        public List<DbDataRecord> ExecuteQuery(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                return reader.Cast<DbDataRecord>().ToList();   
            }
        }
    }
}

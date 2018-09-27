using System.Collections.Generic;
using Npgsql;

namespace fishfriends.Biz.Database
{
    public class PostgreSQLConnection : IDbConnection
    {
        public string ConnectionString { get; set; }

        public PostgreSQLConnection()
        {
            ConnectionString = "Host=127.0.0.1;Port=5433;Username=postgres;Password=Password1;Database=fishfriends";
        }

        public List<List<string>> ExecuteCommand(string command)
        {

        }

        private NpgsqlConnection ConnectToPostgreSQL()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);

            return connection;
        }
    }
}

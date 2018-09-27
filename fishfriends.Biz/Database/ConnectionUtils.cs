using System.Collections.Generic;
using Npgsql;

namespace fishfriends.Biz.Database
{
    public static class ConnectionUtils
    {
        public static List<List<string>> ExecuteCommandOnPostgreSQL(string command)
        {
            NpgsqlConnection connection = ConnectToPostgreSQL();

            connection.Open();

            var cmd = new NpgsqlCommand(command, connection);
            var results = ReadDBResults(cmd.ExecuteReader());

            connection.Close();

            return results;
        }

        private static NpgsqlConnection ConnectToPostgreSQL()
        {
            string connectionString = "Host=127.0.0.1;Port=5433;Username=postgres;Password=Password1;Database=fishfriends";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            return connection;
        }

        private static List<List<string>> ReadDBResults(NpgsqlDataReader dataReader)
        {
            List<List<string>> results = CreateEmptyResultSet(dataReader.FieldCount);

            while (dataReader.Read())
            {
                for (var col = 0; col < dataReader.FieldCount; col++)
                {
                    results[col].Add(dataReader[col].ToString());
                }
            }

            return results;
        }

        private static List<List<string>> CreateEmptyResultSet(int numCols)
        {
            List<List<string>> resultSet = new List<List<string>>();

            for (var col = 0; col < numCols; col++)
            {
                resultSet.Add(new List<string>());
            }

            return resultSet;
        }


    }
}

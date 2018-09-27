using System.Collections.Generic;
using Npgsql;

namespace fishfriends.Biz.Database
{
    public static class ConnectionUtils
    {
        static readonly string connString = "Host=127.0.0.1;Port=5433;Username=postgres;Password=Password1;Database=fishfriends";

        static readonly NpgsqlConnection conn = new NpgsqlConnection(connString);

        public static List<List<string>> GetResultSet(string command)
        {
            conn.Open();

            var cmd = new NpgsqlCommand(command, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            List<List<string>> results = CreateEmptyResultSet(dr.FieldCount);

            while (dr.Read())
            {
                for (var col = 0; col < dr.FieldCount; col++)
                {
                    results[col].Add(dr[col].ToString());
                }
            }

            conn.Close();
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

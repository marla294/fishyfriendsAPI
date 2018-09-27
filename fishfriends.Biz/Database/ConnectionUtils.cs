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
            List<List<string>> results = new List<List<string>>();
            int numCols = dr.FieldCount;

            for (var col = 0; col < numCols; col++)
            {
                results.Add(new List<string>());
            }

            while (dr.Read())
            {
                for (var col = 0; col < numCols; col++)
                {
                    results[col].Add(dr[col].ToString());
                }
            }

            conn.Close();
            return results;
        }
    }
}

using System.Collections.Generic;
using Npgsql;

namespace fishfriends.Biz.Database
{
    public class ConnectionUtils
    {
        static readonly string connString = "Host=127.0.0.1;Port=5433;Username=postgres;Password=Password1;Database=fishfriends";

        readonly NpgsqlConnection conn = new NpgsqlConnection(connString);

        public List<string> RunCommand(string command)
        {
            conn.Open();

            var cmd = new NpgsqlCommand(command, conn);
            //var reader = cmd.ExecuteReader();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            List<string> results = new List<string>();

            while (dr.Read())
            {
                results.Add(dr.GetString(0));
                //str = reader.GetString(0);
            }

            conn.Close();

            return results;
        }
    }
}

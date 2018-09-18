using System;
using System.Data;
using Npgsql;

namespace fishfriends.Biz.Database
{
    public class ConnectionUtils
    {
        static readonly string connString = "Host=127.0.0.1;Port=5433;Username=postgres;Password=Password1;Database=fishfriends";

        readonly NpgsqlConnection conn = new NpgsqlConnection(connString);

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public string RunCommand(string command)
        {
            var cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();

            string str = "";

            while (reader.Read())
            {
                str = reader.GetString(0);
            }

            return str;
        }
    }
}

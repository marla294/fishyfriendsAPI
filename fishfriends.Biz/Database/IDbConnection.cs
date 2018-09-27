using System.Collections.Generic;

namespace fishfriends.Biz.Database
{
    public interface IDbConnection
    {
        string ConnectionString { get; set; }

        List<List<string>> ExecuteCommand(string command);
    }
}

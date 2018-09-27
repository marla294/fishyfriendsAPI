using System.Collections.Generic;

namespace fishfriends.Biz.Database
{
    public interface IDbConnection
    {
        List<List<string>> ExecuteCommand(string command);
    }
}

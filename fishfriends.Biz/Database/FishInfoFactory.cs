using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;
using System.Linq;

namespace fishfriends.Biz.Database
{
    public static class FishInfoFactory
    {
        public static FishInfo LoadInfoSingleFish(string fishName)
        {
            var fishInfo = new FishInfo(fishName);

            var sql = String.Format("select info from fishinfo where fish = {0} order by infoid;", fishInfo.Fish.Id);

            var infoResultSet = ConnectionUtils.ExecuteCommand(new PostgreSQLConnection(), sql);

            for (var i = 0; i < infoResultSet[0].Count; i++)
            {
                fishInfo.Info.Add(infoResultSet[0][i]);
            }

            return fishInfo;
        }
    }
}

using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;

namespace fishfriends.Biz.Database
{
    public class CompatibilityChecker
    {
        //How compatible the fish are, 0 - 10
        //0 - bad
        //10 - good
        public int Compatible { get; private set; }
     
        public void GetCompatibility(Fish fishone, Fish fishtwo)
        {
            var dB = new ConnectionUtils();

            var compatibilityResultSet = dB.GetResultSet("select c.compatible from compatibility c inner join fish f1 on c.fishone = f1.id inner join fish f2 on c.fishtwo = f2.id where f1.name = 'anthias' and f2.name = 'anthias'; ");
        }
    }
}

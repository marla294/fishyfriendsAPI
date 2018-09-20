using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;

namespace fishfriends.Biz.Database
{
    public class CompatibilityChecker
    {
        public int GetCompatibility(Fish fishone, Fish fishtwo)
        {
            var dB = new ConnectionUtils();

            var command = String.Format("select c.compatible " +
                                        "from compatibility c " +
                                        "inner join fish f1 " +
                                        "on c.fishone = f1.id " +
                                        "inner join fish f2 " +
                                        "on c.fishtwo = f2.id " +
                                        "where f1.name = '{0}' " +
                                        "and f2.name = '{1}';",
                                        fishone.Name, fishtwo.Name);
                                        
            switch (dB.GetResultSet(command)[0][0])
            {
                case "Yes":
                    return 10;
                case "No":
                    return 0;
                case "Maybe":
                    return 5;
                default:
                    return 0;
            }
        }
    }
}

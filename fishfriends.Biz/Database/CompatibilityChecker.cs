using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;
using System.Linq;

namespace fishfriends.Biz.Database
{
    public class CompatibilityChecker
    {
        //Returns compatibility, 0 - 10
        //0 - not compatible
        //10 - very compatible
        public int GetCompatibility(Fish fishOne, Fish fishTwo)
        {
            CheckInputValidity(new List<Fish>(){fishOne, fishTwo});

            var dB = new ConnectionUtils();

            var command = String.Format("select c.compatible " +
                                        "from compatibility c " +
                                        "inner join fish f1 " +
                                        "on c.fishone = f1.id " +
                                        "inner join fish f2 " +
                                        "on c.fishtwo = f2.id " +
                                        "where f1.name = '{0}' " +
                                        "and f2.name = '{1}';",
                                        fishOne.Name, fishTwo.Name);
                                        
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

        void CheckInputValidity(List<Fish> fishList)
        {
            var testFishList = new FishLoader().FishList;

            foreach (var f in fishList)
            {
                var testFish = testFishList.FirstOrDefault(fish => fish.Name == f.Name);

                if (testFish == null)
                {
                    throw new ArgumentException("One or more of the input arguments are invalid");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;
using System.Linq;

namespace fishfriends.Biz.Database
{
    public class CompatibilityChecker
    {
        //Returns compatibility of a group of two or more fish 
        //Ranges from 0 - 10
        //0 - not compatible
        //10 - very compatible
        public int GetCompatibility(List<Fish> fishList)
        {
            CheckInputValidity(fishList);

            int totalCompatibility = 0;
            int compareCount = 0;

            for (var i = 0; i < fishList.Count; i++)
            {
                for (var j = 0; j < fishList.Count; j++)
                {
                    if (i != j)
                    {
                        compareCount++;
                        totalCompatibility += GetCompatibility(fishList[i], fishList[j]);
                    }
                }
            }

            return (Int32)Math.Floor((decimal)(totalCompatibility / compareCount));
        }

        //Returns compatibility of 2 fish 
        //Ranges from 0 - 10
        //0 - not compatible
        //10 - very compatible
        int GetCompatibility(Fish fishOne, Fish fishTwo)
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
            if (fishList.Count < 2)
            {
                throw new ArgumentException("2 or more arguments required");
            }

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

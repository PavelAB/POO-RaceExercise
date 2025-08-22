using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_firstTry.Utils
{
    public static class Utils
    {
        

        public static int RandomRange(int lowerBound, int higherBound)
        {
            Random rng = new Random();
            return rng.Next(lowerBound, higherBound);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_firstTry.models
{
    public class Track
    {
        public string Name { get; set; }
        public int Lap { get; set; }
        public int Distance { get; set; }


        public Track(string name, int lap, int distance)
        {
            Name = name;
            Lap = lap;
            Distance = distance;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_firstTry.models
{
    public class LapRecord
    {
        public Car Car { get; set; }
        public int Speed { get; set; }
        public int Lap {  get; set; }

        public float Time { get; set; }

        public LapRecord(Car car, int speed, int lap, float time) {
            Car = car;
            Speed = speed;
            Lap = lap;
            Time = time;
        }

        public void DisplayHistory()
        {
            Console.WriteLine($"{Car.GetFullName()} - lap: {Lap} - {Speed} - {Time}");
        }
    }
}

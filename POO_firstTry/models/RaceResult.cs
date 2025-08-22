using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_firstTry.models
{
    public class RaceResult
    {
        public Car Car { get; set; }
        public float Time { get; set; }
        public int MaxSpeed { get; set; }
        public int MinSpeed { get; set; }
        

        public RaceResult(Car car, float time, int maxSpeed, int minSpeed) {
            Car = car;
            Time = time;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
        }

        public void DisplayResult()
        {
            Console.WriteLine($"{ Car.GetFullName(),-25 } {SecondsToString(), 25} {MaxSpeed, 10} {MinSpeed,10}");
        }

        private string SecondsToString()
        {
            TimeSpan time = TimeSpan.FromSeconds( Time );
            return time.ToString(@"hh\:mm\:ss\:fff");
        }
    }
}

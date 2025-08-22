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
        public float FuelRemain { get; set; }
        public int PitStop { get; set; }
        

        public RaceResult(Car car, float time, int maxSpeed, int minSpeed, float fuel, int pitStop) {
            Car = car;
            Time = time;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
            FuelRemain = fuel;
            PitStop = pitStop;
        }

        public void DisplayResult()
        {
            Console.WriteLine($"{ Car.GetFullName(),-25 } {SecondsToString(), 25} {MaxSpeed, 10} {MinSpeed,10} {FuelRemain,10} {PitStop,7}");
        }

        private string SecondsToString()
        {
            TimeSpan time = TimeSpan.FromSeconds( Time );
            return time.ToString(@"hh\:mm\:ss\:fff");
        }
    }
}

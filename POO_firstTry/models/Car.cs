using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POO_firstTry.Utils;

namespace POO_firstTry.models
{
    public class Car
    {
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public int RegNumber { get; set; }
        public int MaxSpeed { get; set; }
        public int MinSpeed {  get; set; }

        public Car(Brand brand, Model model, int regNumber, int minSpeed, int maxSpeed) {
            Brand = brand;
            Model = model;
            RegNumber = regNumber;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{RegNumber} - {Brand.Name} - {Model.Name}, Range of speed: {MinSpeed} - {MaxSpeed}");
        }
        public string GetFullName()
        {
            return $"{Brand.Name} - {Model.Name}";
        }

        public int GetSpeed()
        {
            return Utils.Utils.RandomRange(MinSpeed, MaxSpeed);
        }

    }
}

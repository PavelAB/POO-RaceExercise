using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        public int Weight { get; set; }
        public int TankCapacity { get; set; }

        public float FuelInTank { get; set; }

        // Constants used for fuel consumption calculations -> ChatGPT
        public float Base { get; set; } = 8f;

        public float K_weight { get; set; } = 3f;

        public float K_speed { get; set; } = 7.5f;


        public Car(Brand brand, Model model, int regNumber, int minSpeed, int maxSpeed, int weight, int tankCapacity) {
            Brand = brand;
            Model = model;
            RegNumber = regNumber;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
            Weight = weight;
            TankCapacity = tankCapacity;
            FuelInTank = FuelStart(tankCapacity);
        }

        private float FuelStart(int tankCapacity)
        {
            return (float)tankCapacity * ((float)Utils.Utils.RandomRange(90, 100) / 100); 
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{GetFullName(), -25} Range of speed: {MinSpeed} - {MaxSpeed}, Fuel: {FuelInTank,10}, Fuel Consumption: {FuelConsumptionPer100Km(GetSpeed())}");
        }
        public string GetFullName()
        {
            return $"{Brand.Name} - {Model.Name}";
        }

        public int GetSpeed()
        {
            return Utils.Utils.RandomRange(MinSpeed, MaxSpeed);
        }

        public float FuelConsumptionPer100Km(int speed)
        {
            return Base + K_weight * ((Weight + FuelInTank) / 1000) + K_speed * (float)Math.Pow((speed / 100), 2);
        }

        public void AddFuel()
        {
            FuelInTank = TankCapacity;
        }

        public bool MoreFuelThen(float fuel)
        {
            if (FuelInTank > fuel)
                return true;
            return false;
        }

        public void RemoveFuel(float fuel)
        {
            FuelInTank -= fuel;
        }

        public bool PitStop(int speed, Track track)
        {
            float fuelConsumptionPrevision = FuelByLap(track.Distance, speed);


            if (!MoreFuelThen(fuelConsumptionPrevision))
            {
                AddFuel();
                RemoveFuel(fuelConsumptionPrevision);
                return true;
            }

            RemoveFuel(fuelConsumptionPrevision);
            return false;


        }
        public float FuelByLap(int distance, int speed)
        {
            return (FuelConsumptionPer100Km(speed) / 100) * distance;
        }


    }
}

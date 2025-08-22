using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_firstTry.models
{
    public class Race
    {
        public List<Car> Cars { get; set; }
        public Track Track { get; set; }
        public List<LapRecord> History { get; set; } = new();

        private bool isFinished { get; set; } = false;

        public List<RaceResult> RaceResult { get; set; } = new();

        public List<RaceResult> LiveResult { get; set; } = new();

        public Race(List<Car> cars, Track track)
        {
            Cars = cars;
            Track = track;
        }

        public void DisplayParticipants()
        {
            foreach(Car car in Cars)
            {
                car.DisplayInfo();
            }
        }


        public void StartRace()
        {
            for(int i = 0; i < Track.Lap; i++)
            {
                foreach (Car car in Cars)
                {
                    int speed = car.GetSpeed();
                    float timePerLap;
                    float fuelConsumptionPrevision = FuelByLap(car, speed);
                    float pitStopTime = 0; 
                    bool isPitStop = false;



                    if (!car.MoreFuelThen(fuelConsumptionPrevision))
                    {
                        isPitStop = true;
                        car.AddFuel();
                        pitStopTime = Track.PitStopTime;
                    }


                    timePerLap = GetLapTimeSeconds(speed) + pitStopTime;
                    car.FuelInTank = car.FuelInTank - fuelConsumptionPrevision;

                    History.Add(new LapRecord(
                        car, 
                        speed, 
                        i + 1, 
                        timePerLap, 
                        isPitStop? 1 : null));
                }

                if(i < Track.Lap - 1)
                {
                    Console.WriteLine($"{"Lap "+ (i+1), 150}");
                    DisplayLapResult();

                }


            }

            isFinished = true;
            
        }

        
        public void DisplayHistory()
        {
            foreach(LapRecord record in History)
            {
                record.DisplayHistory();
            }
        }

        private float GetLapTimeSeconds(int speed)
        {
            int SECONDS_IN_HOUR = 3600;
            return ((float)Track.Distance / speed ) * SECONDS_IN_HOUR ; 
        }
        private float GetRaceTime(Car car)
        {
            return History
                    .Where(record => record.Car.RegNumber == car.RegNumber)
                    .Sum(record => record.Time);
        }

        private int GetMaxSpeed(Car car)
        {
            return History
                    .Where(record => record.Car.RegNumber == car.RegNumber)
                    .Max(record => record.Speed);
        }
        private int GetMinSpeed(Car car)
        {
            return History
                    .Where(record => record.Car.RegNumber == car.RegNumber)
                    .Min(record => record.Speed);
        }
        private int GetPitStop(Car car)
        {
            return History
                    .Where(record => record.Car.RegNumber == car.RegNumber)
                    .Sum(record => record.PitStop > 0 ? (int)record.PitStop : 0);
        }
        private void OrderResult()
        {
            RaceResult = RaceResult
                            .OrderBy(record => record.Time)
                            .ToList();
        }
        private void GetRaceResults()
        {
            if (isFinished)
            {
                foreach(Car car in Cars)
                {
                    RaceResult.Add(new RaceResult(car, GetRaceTime(car), GetMaxSpeed(car), GetMinSpeed(car), car.FuelInTank, GetPitStop(car)));
                }
                OrderResult();
            }
        }
        private void GetLapResults()
        {
            LiveResult.Clear();
            foreach (Car car in Cars)
            {
                LiveResult.Add(new RaceResult(car, GetRaceTime(car), GetMaxSpeed(car), GetMinSpeed(car), car.FuelInTank, GetPitStop(car)));
            }
            LiveResult = LiveResult
                            .OrderBy(record => record.Time)
                            .ToList();
        }
        public void DisplayRaceResult()
        {
            GetRaceResults();

            Console.WriteLine($"{"Car", -25} {"Time",25} {"MaxSpeed",10} {"MinSpeed",10} {"Fuel",10} {"PitStop",7}\n");
            foreach (RaceResult RaceResult in RaceResult) {
                RaceResult.DisplayResult();
            }
        }
        public void DisplayLapResult()
        {
            GetLapResults();

            Console.WriteLine($"{"Car",-25} {"Time",25} {"MaxSpeed",10} {"MinSpeed",10} {"Fuel",10} {"PitStop",7}\n");
            foreach (RaceResult LapResult in LiveResult)
            {
                LapResult.DisplayResult();
            }
        }
        public float FuelByLap(Car car, int speed)
        {
            return (car.FuelConsumptionPer100Km(speed) / 100) * Track.Distance;
        }
        

    }
}

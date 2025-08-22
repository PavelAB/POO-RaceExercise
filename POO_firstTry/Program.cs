using POO_firstTry.models;

namespace POO_firstTry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Racers!\n");

            Car firstCar = new Car(new Brand("Ferrari"), new Model("488"), 16, 300, 350);
            Car secondCar = new Car(new Brand("Bugatti"), new Model("Veyron"), 44, 270, 380);
            Car thirdCar = new Car(new Brand("Lamborghini"), new Model("Aventador"), 81, 320, 330);

            Track firstTrack = new Track("Indianapolis", 10, 10);

            Race firstRace = new Race(new List<Car>() { firstCar, secondCar, thirdCar }, firstTrack);

            firstRace.DisplayParticipants();

            Console.WriteLine("");
            Console.WriteLine("================\n");

            firstRace.StartRace();
            //firstRace.DisplayHistory();
            firstRace.DisplayRaceResult();
            
        }
    }
}

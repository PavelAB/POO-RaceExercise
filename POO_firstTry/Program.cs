using POO_firstTry.models;

namespace POO_firstTry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Racers!\n");

            

            Track firstTrack = new Track("Indianapolis", 20, 15, 250f);

            List<Car> cars = new List<Car>() {
                new Car(new Brand("Ferrari"),      new Model("488"),        16, 300, 350, 1475, 78),
                new Car(new Brand("Bugatti"),      new Model("Veyron"),     44, 270, 380, 1888, 100),
                new Car(new Brand("Lamborghini"),  new Model("Aventador"),  81, 320, 330, 1575, 90),
                new Car(new Brand("Ferrari"),      new Model("F8 Tributo"),  1, 320, 335, 1435, 78),
                new Car(new Brand("McLaren"),      new Model("720S"),        4, 315, 330, 1419, 72),
                new Car(new Brand("Ferrari"),      new Model("488 GTB"),    55, 310, 325, 1475, 78),
                new Car(new Brand("Aston Martin"), new Model("Vantage"),    22, 305, 320, 1530, 73),
                new Car(new Brand("Mercedes"),     new Model("AMG GT"),     63, 318, 332, 1640, 75),
                new Car(new Brand("Porsche"),      new Model("911 Turbo S"),12, 325, 340, 1640, 67),
                new Car(new Brand("Lamborghini"),  new Model("Huracán"),    87, 322, 338, 1422, 80)
            };

            Race firstRace = new Race(cars, firstTrack);

            firstRace.DisplayParticipants();

            Console.WriteLine("");
            Console.WriteLine("================\n");

            firstRace.StartRace();
            //firstRace.DisplayHistory();
            firstRace.DisplayRaceResult();
            
        }
    }
}

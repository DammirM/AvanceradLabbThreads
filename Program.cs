using AvanceradLabbThreads;
using System;
using System.Diagnostics;

namespace AvanceradLabbThreads
{
    internal class Program
    {
        public static List<Car> Race = new List<Car>();

        public static void Main(string[] args)
        {


            Car car1 = new Car("Renault");
            Car car2 = new Car("Kia");
            Car car3 = new Car("Opel");

            Race.Add(car1);
            Race.Add(car2);
            Race.Add(car3);

            Thread thread1 = new Thread(car1.RaceStart);
            Thread thread2 = new Thread(car2.RaceStart);
            Thread thread3 = new Thread(car3.RaceStart);


            Thread thread4 = new Thread(() => StatusCheck());

            thread1.Start();
            thread2.Start();
            thread3.Start();

           
                Console.Clear();
                Console.WriteLine("Race status:");
                foreach (var car in Race)
                {
                    Console.WriteLine($"{car.Name}: {car.Distance:F2} km, {car.Speed} km/h");
                }
                Console.WriteLine();
            

            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();


            Console.WriteLine("Time Scores");
            foreach (var item in Race)
            {
                Console.WriteLine($"Car: {item.Name} Time: {item.RaceTime.ToString("mm\\:ss\\.fff")} Ending Speed: {item.Speed}");
            }
        }

        public static void StatusCheck()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    string input = Console.ReadLine();
                    if (input == "status")
                    {
                        foreach (var item in Race)
                        {
                            Console.WriteLine($"{item.Name} has driven {item.Distance.ToString("0.00")} and is at a speed of {item.Speed} km/h");
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }

    }
}

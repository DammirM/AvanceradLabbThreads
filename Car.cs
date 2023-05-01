using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AvanceradLabbThreads
{
    internal class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public double Distance { get; set; }

        public static string Winner;
        public TimeSpan RaceTime { get; set; }

        public Car(string name)
        {
            Name = name;
            Speed = 120;
            Distance = 0;
        }

        public void RaceStart()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine($"{Name} started the Race!!");

            int i = 0;
            while (Distance < 1 && i <= 300)
            {
                Thread.Sleep(1000);
                Distance += (double)Speed / 3600;

                if (i % 5 == 0 && i != 0)
                {
                    CarTrouble();
                }
                i++;
            }

            Console.WriteLine($"{Name} has finished the race");

            if (Car.Winner == null)
            {
                
                Car.Winner = Name;
                Console.WriteLine($"Contragulations to the Winner: -----  {Name}  ----");
            }

            RaceTime = sw.Elapsed;

        }
     
        public void CarTrouble()
        {
            Random random = new Random();

            int randomIncident = random.Next(1, 51);

            if (randomIncident == 1)
            {
                OutofGas();
            }
            else if (randomIncident > 1 && randomIncident <= 3)
            {
                Punction();
            }
            else if (randomIncident > 3 && randomIncident <= 8)
            {
                BirdonWind();
            }
            else if (randomIncident > 8 && randomIncident <= 18)
            {
                EngineProblem();
            }

        }

        public void OutofGas()
        {
            Console.WriteLine($"{Name} has run out of fuel and requires 3 seconds to refill the gas tank.");
            Thread.Sleep(3000);
        }

        public void Punction()
        {
            Console.WriteLine($"{Name} has a flat tire it takes 2 seconds to fix that");
            Thread.Sleep(2000);
        }

        public void BirdonWind()
        {
            Console.WriteLine($"{Name} has a bird on the windshield, it takes 1 seconds to fix that.");
            Thread.Sleep(1000);
        }

        public void EngineProblem()
        {
            Speed = Speed - 1;
            Console.WriteLine($"{Name} has engine problem, the speed is reduced by 1km/h, new {Speed} is km/h");
        }

    }

}
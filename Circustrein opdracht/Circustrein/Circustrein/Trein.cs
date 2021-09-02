using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Circustrein
{
    public class Trein
    {
        List<Dier> Dieren = new List<Dier>();
        List<Wagon> Wagons = new List<Wagon>();
        Verdeler verdeler = new Verdeler();


        public void CreateDier(Type GivenType, Grootte GivenGrootte)
        {
            Dier dier = new Dier(GivenType, GivenGrootte);
            Dieren.Add(dier);
        }


        public void StartVerdeler()
        {
            Dieren = Dieren.OrderBy(o => o.type).ThenByDescending(o => o.grootte).ToList();

            
            for (int i = 0; i < Dieren.Count; i++)
            {
                if (Dieren[i].type.Equals(Type.Carnivoor) && Dieren[i].grootte.Equals(Grootte.Klein))
                {
                    Dieren = Dieren.OrderBy(o => o.grootte).ThenByDescending(o => o.type).ToList();
                }
            }           


            Wagons = verdeler.Start(Dieren);

            ShowWagons();
        }

        public int GetWagonCount()
        {
            return Wagons.Count;
        }



        private void ShowWagons()
        {
            Console.WriteLine("Totaal aantal wagons: " + Wagons.Count);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");

            foreach (Wagon wagon in Wagons)
            {
                foreach (Dier dier in wagon.GetDieren())
                {
                    Console.WriteLine("- Type: " + dier.type);
                    Console.WriteLine("- Size: " + dier.grootte);
                    Console.WriteLine("");
                }

                Console.WriteLine("Totaal aantal punten: " + wagon.BerekenPunten());
              
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();
            }
        }
    }
}

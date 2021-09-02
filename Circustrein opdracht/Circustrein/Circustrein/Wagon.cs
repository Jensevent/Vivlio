using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    class Wagon
    {
        List<Dier> Dieren = new List<Dier>();


        public void AddDier(Dier GivenDier)
        {
            Dieren.Add(GivenDier);
        }


        public int BerekenPunten()
        {
            int TotaalPunten = 0;
            for (int i = 0; i < Dieren.Count; i++)
            {
                TotaalPunten += Dieren[i].Punten;
            }
            return TotaalPunten;
        }


        public List<Dier> GetDieren()
        {
            return Dieren;
        }


        public Dier GetCarnivoor()
        {
            int location = 0;
            for (int i = 0; i < Dieren.Count; i++)
            {
                if (Dieren[i].type == Type.Carnivoor)
                {
                    location = i;
                }
            }

            return Dieren[location];
        }


    }
}

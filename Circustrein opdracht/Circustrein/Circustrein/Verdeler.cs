using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Circustrein
{
    class Verdeler
    {
        List<Dier> Dieren = new List<Dier>();
        List<Wagon> Wagons = new List<Wagon>();




        private void CreateWagon()
        {
            Wagon wagon = new Wagon();
            Wagons.Add(wagon);
        }



        public List<Wagon> Start(List<Dier> GivenDieren)
        {
            Wagons.Clear();

            Dieren = GivenDieren;

            if (Dieren.Count != 0)
            {
                CreateWagon();
            }

            for (int x = 0; x < Wagons.Count; x++)
                {
                    for (int i = 0; i < Dieren.Count; i++)
                    {
                       if ( !TenCheck(Dieren[i].Punten, Wagons[x].BerekenPunten()) && TypeCheck(Wagons[x], Dieren[i]))
                        {
                            Wagons[x].AddDier(Dieren[i]);
                            Dieren.RemoveAt(i);
                            i = -1;
                        }
                    }

                if (Dieren.Count != 0)
                {
                    CreateWagon();
                }
            }

            return Wagons;
        }



        private bool TenCheck(int DierPunten, int WagonPunten )
        {
            int Totalpoints = DierPunten + WagonPunten;
            if (Totalpoints > 10)
            {
                return true;
            }
            return false;
        }



        private bool WagonContainsCarnivoor(Wagon GivenWagon)
        {
            List<Dier> GivenDieren = GivenWagon.GetDieren();

            for (int i = 0; i < GivenDieren.Count; i++)
            {
                if (GivenDieren[i].type.Equals(Type.Carnivoor))
                {
                    return true;
                }
            }
            
            return false;
        }



        private bool IsDierCarnivoor(Dier GivenDier)
        {
            if (GivenDier.type == Type.Carnivoor)
            {
                return true;
            }
            return false;
        }



        private bool TypeCheck(Wagon GivenWagon, Dier GivenDier)
        {
            if ( WagonContainsCarnivoor(GivenWagon) && IsDierCarnivoor(GivenDier))
            {
                return false;
            }

            else if(!WagonContainsCarnivoor(GivenWagon) && IsDierCarnivoor(GivenDier))
            {
                for (int i = 0; i < GivenWagon.GetDieren().Count; i++)
                {
                    if (GivenDier.Punten >= GivenWagon.GetDieren()[i].Punten)
                    {
                        return false;
                    }
                }
            }

            else if (WagonContainsCarnivoor(GivenWagon) && !IsDierCarnivoor(GivenDier))
            {
                if (GivenWagon.GetCarnivoor().Punten >= GivenDier.Punten)
                {
                    return false;
                }
            }

            return true;
        }

    }
}

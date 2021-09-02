using System;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein
{
    class Program
    { 
        static void Main(string[] args)
        {
            Trein trein = new Trein();

            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);

            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);

            trein.CreateDier(Type.Carnivoor, Grootte.Klein);

            trein.StartVerdeler();
        }
    }
}

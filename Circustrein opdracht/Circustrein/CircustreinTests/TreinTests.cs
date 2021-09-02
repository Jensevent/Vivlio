using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein.Tests
{
    [TestClass()]
    public class TreinTests
    {
        Trein trein;


        [TestInitialize]
        public void TestInitialize()
        {
            trein = new Trein();
        }


        [TestMethod()]
        public void VerdelerMetGeenDieren()
        {
            trein.StartVerdeler();
            Assert.AreEqual(0, trein.GetWagonCount());
        }

        [TestMethod()]
        public void VerdelerZonderCarnivoor()
        {
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);

            trein.StartVerdeler();
            Assert.AreEqual(2, trein.GetWagonCount());
        }

        [TestMethod()]
        public void VerdelerMetCarnivoor()
        {
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);

            trein.CreateDier(Type.Carnivoor, Grootte.Klein);

            trein.CreateDier(Type.Carnivoor, Grootte.Middel);
            trein.CreateDier(Type.Carnivoor, Grootte.Middel);
            trein.CreateDier(Type.Carnivoor, Grootte.Middel);

            trein.CreateDier(Type.Carnivoor, Grootte.Groot);
            trein.CreateDier(Type.Carnivoor, Grootte.Groot);

            trein.StartVerdeler();
            Assert.AreEqual(6, trein.GetWagonCount());
        }


        [TestMethod()]
        public void VerdelerAchtWagons()
        {
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);

            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);

            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);

            trein.CreateDier(Type.Carnivoor, Grootte.Klein);
            trein.CreateDier(Type.Carnivoor, Grootte.Klein);
            
            trein.CreateDier(Type.Carnivoor, Grootte.Middel);
            trein.CreateDier(Type.Carnivoor, Grootte.Middel);

            trein.CreateDier(Type.Carnivoor, Grootte.Groot);
            trein.CreateDier(Type.Carnivoor, Grootte.Groot);

            trein.StartVerdeler();
            Assert.AreEqual(8, trein.GetWagonCount());
        }



        [TestMethod()]
        public void VerdelerTweeWagons()
        {
            trein.CreateDier(Type.Herbivoor, Grootte.Klein);

            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);

            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);

            trein.StartVerdeler();
            Assert.AreEqual(2, trein.GetWagonCount());
        }


        [TestMethod()]
        public void VerdelerTweeWagonsV2()
        { 
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);
            trein.CreateDier(Type.Herbivoor, Grootte.Middel);

            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            trein.CreateDier(Type.Herbivoor, Grootte.Groot);
            
            trein.CreateDier(Type.Carnivoor, Grootte.Klein);

            trein.StartVerdeler();
            Assert.AreEqual(2, trein.GetWagonCount());
        }


    }
}
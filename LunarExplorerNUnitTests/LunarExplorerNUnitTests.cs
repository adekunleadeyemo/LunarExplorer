using System;
using LunarExplorer.Service;
using LunarExplorer.Model;
using NUnit.Framework;


namespace LunarRoverNUnitTests
{

    public class Tests
    {
        private LunarExplorerService ls;
        private Plateau pl;
        private List<Rover> rvs;

        [SetUp]
        public void Setup()
        {
         pl = new Plateau {
                Length = 5,
                Breadth = 5
            };
        rvs = new List<Rover>(); 

          
        }

        //Test case for supplied test data
        [Test]
        public void Test1()
        {
            Rover r1 = new Rover(1, 2,"N","LMLMLMLMM");
            Rover r2 = new Rover(3, 3, "E", "MMRMMRMRRM");
            rvs.Add(r1);
            rvs.Add(r2);

            ls = new LunarExplorerService(pl,rvs);
            List<string> output = ls.Explore();

            Assert.That(output[0], Is.EqualTo("1 3 N"));
            Assert.That(output[1], Is.EqualTo("5 1 E"));
            
            
        }

        //Test case for rover moving off plateau
        [Test]
        public void Test2()
        {
            Rover r1 = new Rover(1, 2,"N","MMMMMMM");
            Rover r2 = new Rover(1, 3,"W","MMMMMMM");
            Rover r3 = new Rover(2, 3,"E","MMMMMMM");
            Rover r4 = new Rover(4, 3,"S","MMMMMMM");
            rvs.Add(r1);
            rvs.Add(r2);
            rvs.Add(r3);
            rvs.Add(r4);

            ls = new LunarExplorerService(pl,rvs);
            List<string> output = ls.Explore();

            Assert.That(output[0], Is.EqualTo("1 6 N Rover Stopped! it has reached the maximum length of the plateau"));
            Assert.That(output[1], Is.EqualTo("-1 3 W Rover Stopped! it has reached the minimum breadth of the plateau"));
            Assert.That(output[2], Is.EqualTo("6 3 E Rover Stopped! it has reached the maximum breadth of the plateau"));
            Assert.That(output[3], Is.EqualTo("4 -1 S Rover Stopped! it has reached the minimum length of the plateau"));
            
        }


         //Test case for two rovers having similar starting position
        [Test]
        public void Test3()
        {
             Rover r1 = new Rover(1, 2,"N","MMMMMMM");
            Rover r2 = new Rover(1, 2,"W","MMMMMMM");
           
            rvs.Add(r1);
            rvs.Add(r2);
           

            ls = new LunarExplorerService(pl,rvs);
            List<string> output = ls.Explore();

            Assert.That(output[1], Is.EqualTo("1 2 W Rover Stopped! due to same start point with another rover"));
           
            
        }

        //Test case for collision of rovers
        [Test]
        public void Test4()
        {
            Rover r1 = new Rover(1, 3,"N","M");
            Rover r2 = new Rover(1, 1,"N","MMMM");
           
            rvs.Add(r1);
            rvs.Add(r2);
           

            ls = new LunarExplorerService(pl,rvs);
            List<string> output = ls.Explore();

            Assert.That(output[1], Is.EqualTo("1 4 N Rover Stopped! it has collided with another rover")); 
           
            
        }



    }
}
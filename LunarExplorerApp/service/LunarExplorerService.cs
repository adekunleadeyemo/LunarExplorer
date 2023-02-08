using System;
using System.Collections.Generic;
using LunarExplorer.Model;

namespace LunarExplorer.Service
{
    public  class LunarExplorerService
    {
        private Plateau plateau = new Plateau();
        private List<Rover> rovers = new List<Rover>();


        public  LunarExplorerService(Plateau plateau, List<Rover> rovers)
        {
            this.rovers.AddRange(rovers);
            this.plateau= plateau;
        }

        public List<String> Explore()
        {
            List<int[]> constriant = new List<int[]>();
            List<String> output = new List<String>();
            List<int[]> strt = new List<int[]>();
           

            foreach(Rover rov in this.rovers)
            {  
                int [] rs = {(int)rov.XCord, (int)rov.YCord}; 
                bool sameStat = false;
               
                foreach(int[] k in strt)
                {
                    if(k[0]==rov.XCord && k[1]==rov.YCord)
                    {
                        sameStat = true;
                        output.Add( $"{rov.XCord} {rov.YCord} {rov.Orient} Rover Stopped! due to same start point with another rover");
                    }
                }

            if(sameStat == false)
            {
                 String rovPos = rov.moveRover(this.plateau.Breadth, this.plateau.Length, constriant);
                int xCs = Convert.ToInt32(rovPos.Split(' ')[0]);
                int yCs = Convert.ToInt32(rovPos.Split(' ')[1]);
                int [] cs = {xCs,yCs};
                constriant.Add(cs);
                strt.Add(rs);
                output.Add(rovPos);
            }
               
            }

            return output;
        }
    }
}

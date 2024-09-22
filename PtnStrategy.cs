using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ptns_Strategy_State
{
    public class Map
    {
        private char[,] map = new char[6, 6];

        public char this[int x, int y]
        {
            get { return map[x, y]; }
            set { map[x, y] = value; }
        }


        public void print()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

    interface IGenerateMap
    {
        void Generate(Map map);
    }
    public class GenerateMountainMap : IGenerateMap
    {
        public GenerateMountainMap(Map map)
        {
            Generate(map);
            map.print();
        }

        public void Generate(Map map)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int rand = new Random().Next();
                    if (rand % 2 == 0)
                        map[i, j] = '^';
                    else if (rand % 3 == 0)
                        map[i, j] = '&';
                    else
                        map[i, j] = '.';

                }

            }
        }
    }
    public class GenerateOseanMap : IGenerateMap
    {
        public GenerateOseanMap(Map map)
        {
            Generate(map);
            map.print();
        }

        public void Generate(Map map)
        {
            int maxMountainCount = new Random().Next(4, 10);
            int mountainCount = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int rand = new Random().Next();
                    if (rand % 2 == 0 || mountainCount == maxMountainCount)
                        map[i, j] = '~';
                    else
                    {                        
                        map[i, j] = '^';
                        mountainCount++;
                    }


                }

            }
        }
    }
    public class GenerateRiverMap : IGenerateMap
    {
        public GenerateRiverMap(Map map)
        {
            Generate(map);
            map.print();
        }

        public void Generate(Map map)
        {
            int riverPoint = new Random().Next(0, 5);
            int placeTree;
            for (int i = 0; i < 5 ; i++)
            {
                placeTree = new Random().Next(0, 10);
                if (placeTree == 1)
                    map[0, i] = '&';
                else map[0, i] = '.';
            }
            map[0, riverPoint] = '~';
            for (int i = 1; i < 5 ; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    placeTree = new Random().Next(0, 10);
                    if (placeTree == 1)
                        map[i, j] = '&';
                    else map[i, j] = '.';
                }
                int minPoint = --riverPoint;
                int maxPoint = ++riverPoint;
                if (minPoint < 0)
                    minPoint = 0;
                if (maxPoint > 5)
                    maxPoint = 5;
                
                riverPoint = new Random ().Next(minPoint, maxPoint);
                map[i, riverPoint] = '~';
            }

           
        }
    }
    

}

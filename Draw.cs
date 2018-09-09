using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    class Draw : FindWay
    {
        public void DrField()
        {
            GetData();         
            for (int y = 0; y < Field.GetLength(1); y++)
            {
                for (int x = 0; x < Field.GetLength(0); x++)
                {

                    if (Field[x, y] == 0)
                    {
                        Console.Write('.');
                    }
                    if (Field[x, y] == 1)
                    {
                        Console.Write('O');
                    }               
                    Console.Write("   ");
                }
                Console.WriteLine(" ");
            }
        }
        public void PathMap(int[,] cMap, char[,]ChArr)
        {
            int x, y;
            //Writing map with Way
            for (y = 0; y < Height; y++)
            {
                Console.WriteLine();
                for (x = 0; x < Width; x++)
                {
                    if (y == LDot.Y && x == LDot.X)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("F");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    if (y == SDot.Y && x == SDot.X)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("S");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else
                    if (cMap[x, y] == -1)
                    {
                        Console.Write(".");
                    }
                    else
                    if (cMap[x, y] == -2)
                        Console.Write("O");
                    else
                    if (cMap[x, y] > -1)
                    {
                        if (ChArr[x, y] == '\0')
                            Console.Write('.');
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(ChArr[x, y]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.Write("   ");
                }
            }
        }
    }
}


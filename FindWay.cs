using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lines
{
    class FindWay : Init
    {

        String Way;
        Boolean add;
        private int step;
        protected char[,] ChArr = new char[Width, Height];


        /// <summary>
        /// Find the way
        /// </summary>
        public void FindWave()
        {
            GetData();
            add = true;
            int[,] cMap = new int[Width, Height];
            int x, y = 0; step = 0;
            for (y = 0; y < Height; y++)
                for (x = 0; x < Width; x++)
                {
                    if (Field[x, y] == 1)
                        cMap[x, y] = -2;//wall index
                    else
                        cMap[x, y] = -1;//if we dont step there place
                }

            if (SDot.X > Width || SDot.Y > Height || LDot.Y > Height || LDot.X > Width)
                throw new ArgumentOutOfRangeException("Invalid Data");

            cMap[SDot.X, SDot.Y] = 0;
            while (add == true)
            {
                add = false;
                for (x = 0; x < Width; x++)
                    for (y = 0; y < Height; y++)
                    {
                        if (cMap[x, y] == step)
                        {
                            if (x - 1 >= 0 && cMap[x - 1, y] != -2 && cMap[x - 1, y] == -1)
                                cMap[x - 1, y] = step + 1;
                            if (y - 1 >= 0 && cMap[x, y - 1] != -2 && cMap[x, y - 1] == -1)
                                cMap[x, y - 1] = step + 1;
                            if (x + 1 < Width && cMap[x + 1, y] != -2 && cMap[x + 1, y] == -1)
                                cMap[x + 1, y] = step + 1;
                            if (y + 1 < Height && cMap[x, y + 1] != -2 && cMap[x, y + 1] == -1)
                                cMap[x, y + 1] = step + 1;
                        }
                    }
                step++;
                add = true;

                if (cMap[LDot.X, LDot.Y] != -1)
                {
                    add = false;
                    Console.WriteLine(true);
                    Console.WriteLine("The Length of Path is: " + step);
                    Console.WriteLine("The shortest path is: " + FindBestWay(cMap) );
                }//path was found

                if (step > Width * Height)
                {
                    Console.WriteLine("there is no path");
                    add = false;
                }//path not found
            }
            //Drawing new Field with path
            Draw draw =new Draw();
            draw.PathMap(cMap,ChArr);

        }

        /// <summary>
        /// Find the best way
        /// </summary>
        /// <param name="Map"></param>
        /// <returns>Way</returns>
        string FindBestWay(int[,] Map)
        {
            int x = LDot.X;
            int y = LDot.Y;
            do
            {
                if (x < Width - 1)
                    if (Map[x + 1, y] == step - 1)
                    {
                        ChArr[x, y] = 'L';
                        Way += 'L';
                        x++;
                    }
                if (y < Height - 1)
                    if (Map[x, y + 1] == step - 1)
                    {
                        ChArr[x, y] = 'U';
                        Way += 'U';
                        y++;
                    }
                if (x > 0)
                    if (Map[x - 1, y] == step - 1)
                    {
                        ChArr[x, y] = 'R';
                        Way += 'R';
                        x--;
                    }
                if (y > 0)
                    if (Map[x, y - 1] == step - 1)
                    {
                        ChArr[x, y] = 'D';
                        Way += 'D';
                        y--;
                    }
                step--;
            } while (step != 0);

            char[] charArray = Way.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
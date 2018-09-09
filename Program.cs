/*
 * © Kameniev R.V., 2018
*/
using System;
using System.Text;

namespace Lines
{
    class Program
    { 
        /// <summary>
        /// Start the program
        /// </summary>
        public static void Main(string[] args)
        {
            Draw draw = new Draw();
            draw.DrField();
            FindWay findWay = new FindWay();
            findWay.FindWave();
            Console.ReadKey(false);
        }


    }
}

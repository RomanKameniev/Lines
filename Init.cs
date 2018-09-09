using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    struct SDot
    {
        public static int X, Y;
        public SDot(int x, int y)
        {
            X = x;
            Y = y;
        }
    }//Choords of start dot
    struct LDot
    {
        public static int X, Y;
        public LDot(int x, int y)
        {
            X = x;
            Y = y;
        }
    }//Choords of last dot

    abstract class Init
    {
        
        String fName = "Data.txt";//:bin/debug/Data.txt
        //name of file with data
        TextReader textR;
        String line;
        string[] subs;

        public static int Width { get; set; }
        public static int Height { get; set; }
        protected int[,] Field = new int[Width, Height];
        /// <summary>
        /// Getting data from txtfile
        /// </summary>
        protected void GetData()
        {
            textR = new StreamReader(fName);
            Height = Convert.ToInt32(textR.ReadLine());
            Width = Convert.ToInt32(textR.ReadLine());
            //determine height and Width
            string BgnPos = textR.ReadLine().Trim();
            string LstPos = textR.ReadLine().Trim();
            subs = BgnPos.Split(',');

            SDot sdot = new SDot(int.Parse(subs[0].Substring(1).ToString()), int.Parse(subs[1].Substring(0,subs.Length-1).ToString()));
            //determine choord of start dot

            subs = LstPos.Split(',');
            LDot ldot = new LDot(int.Parse(subs[0].Substring(1).ToString()), int.Parse(subs[1].Substring(0,subs.Length-1).ToString()));
            //determine choord of final dot

            Field = new int[Width, Height];

            int y = 0, x = 0;
            while ((line = textR.ReadLine()) != null)
            {
                x = 0;
                String[] substr = line.Split(' ');

                foreach (var sub in substr)
                {
                    Field[x, y] = int.Parse(sub);
                    x++;
                }
                y++;
            }//getting data in array
            textR.Close();

        }
    }
}

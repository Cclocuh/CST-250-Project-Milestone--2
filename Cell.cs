using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneConsoleApp
{
    public class Cell
    {
        public int x; public int y;
        public int Row = -1;
        public int Col = -1;

        public Cell() 
        {
            Random rand = new Random();
            bool[] n = new bool[100];

            for (int i = 0; i < 90;  i++)
                n[i] = false;

            for(int i = 0; i < 100;  i++)
                n[i] = true;

            for(int i = 0; i < 100; i++)
            {
                int pos = rand.Next(100);
                bool save = n[i];
                n[i] = n[pos];
                n[pos] = save;
            }

            for(int i = 0;i < 100; i++)
            {
                if (n[i])
                    Console.WriteLine("*");
                else
                    Console.WriteLine(".");
                if((i + 1) % 10 == 0)
                    Console.WriteLine();
            }

            Console.ReadLine();
        }

        public Cell(int x, int y, int row, int col)
        {
            this.x = x;
            this.y = y;
            Row = row;
            Col = col;
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public int getRow(int x)
        {
            return Row;
        }

        public int getCol()
        {
            return Col;
        }

        public void setRow() 
        {
            
        }

        public void setCol()
        {
            
        }
    }
}

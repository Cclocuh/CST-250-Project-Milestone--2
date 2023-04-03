using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using MilestoneConsoleApp;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using SharpDX.DXGI;

namespace MilestoneConsoleApp
{
    public class Board
    {
        public int BOARD_SIZE { get; set; }

        public cell[,] theGrid;

        public object CELL_WIDTH { get; set; }
        public object CELL_HEIGHT { get; set; }

        public struct cell
        {
            public bool hasBomb;
            public bool hasFlag;
            public bool isUncovered;
            public int neighboringBombs;
            public Texture2D texture;
            public int X;
            public int Y;

            public cell(int r, int c) : this()
            {
                R = r;
                C = c;
            }

            // 2d array of cell objects 
            public cell[,] theGrid { get; set; }
            public object position { get; set; }
            //public object CELL_WIDTH { get; internal set; }
            public int R { get; }
            public int C { get; }
        }

        public Board()
        {
            
            const int BOARD_SIZE = 10;
            const int CELL_WIDTH = 48;
            const int CELL_HEIGHT = 96;
            cell[,] cell = new cell[BOARD_SIZE + 2, BOARD_SIZE + 2];
            Texture2D[] numbers = new Texture2D[9];


        }

        public Board(int BOARD_SIZE)
        {
            //InitializeBoard();
            PlantBombs();
            CountNeighbors();
        }

        public void InitializeBoard(int BOARD_SIZE)
        {
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                for (int c  = 0; c < BOARD_SIZE; c++)
                {
                    Texture2D[] numbers = new Texture2D[10];
                    cell[,] cell = new cell[r, c];
                    cell[r, c].hasBomb = false;
                    cell[r, c].hasFlag = false;
                    cell[r, c].isUncovered = false;
                    cell[r, c].neighboringBombs = 0;
                    cell[r, c].position = CELL_WIDTH;
                    cell[r, c].position = CELL_HEIGHT;
                }
            }

            // we must initialize the array to avoid Null exception errors.
            theGrid = new cell[BOARD_SIZE, BOARD_SIZE];
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                for (int c = 0; c < BOARD_SIZE; c++)
                {
                    theGrid[r, c] = new cell(r, c);
                }
            }
        }

        void PlantBombs()
        {
            Random rand = new Random();
            bool[] n = new bool[100];

            for (int i = 0; i < 90; i++)
                n[i] = false;

            for (int i = 0; i < 100; i++)
                n[i] = true;

            for (int i = 0; i < 100; i++)
            {
                int pos = rand.Next(100);
                bool save = n[i];
                n[i] = n[pos];
                n[pos] = save;
            }

            for (int i = 0; i < 100; i++)
            {
                int c = i % 10;
                int r = i / 10;

            }

            for (int i = 0; i < 100; i++)
            {
                if (n[i])
                    Console.WriteLine("*");
                else
                    Console.WriteLine(".");
                if ((i + 1) % 10 == 0)
                    Console.WriteLine();
            }

            Console.ReadLine();

        }

        void CountNeighbors()
        {
            cell[,] cell = new cell[BOARD_SIZE, BOARD_SIZE];
            for (int r = 0; r < BOARD_SIZE; r++)
            {
                for (int c = 0; c < BOARD_SIZE; c++)
                {
                    int Count = 0;
                    if (cell[r - 1, c - 1].hasBomb)
                        Count++;
                    if (cell[r - 1, c].hasBomb)
                        Count++;
                    if (cell[r - 1, c + 1].hasBomb)
                        Count++;
                    if (cell[r, c - 1].hasBomb)
                        Count++;
                    if (cell[r, c + 1].hasBomb)
                        Count++;
                    if (cell[r + 1, c - 1].hasBomb)
                        Count++;
                    if (cell[r + 1, c].hasBomb)
                        Count++;
                    if (cell[r + 1, c + 1].hasBomb)
                        Count++;
                    cell[r, c].neighboringBombs = Count;
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string v)
        {
            throw new NotImplementedException();
        }
    }
}

using MilestoneConsoleApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilestoneFormsApp1
{
    public partial class Form1 : Form
    {
        static public Board myBoard = new Board(10);
        public Button[,] btnGrid = new Button[myBoard.BOARD_SIZE, myBoard.BOARD_SIZE];
  
        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        public void populateGrid()
        {
            int buttonBOARD_SIZE = panel1.Width / myBoard.BOARD_SIZE; // calculate the width of each button on the Grid 
            panel1.Height = panel1.Width; 

            // nested loop. Create buttons and place them  in the Panel
            for (int r = 0; r < myBoard.BOARD_SIZE; r++)
            {
                for (int c = 0; c < myBoard.BOARD_SIZE; c++)
                {
                    btnGrid[r, c] = new Button();

                    // make each button square 
                    btnGrid[r, c].Width = buttonBOARD_SIZE;
                    btnGrid[r, c].Height = buttonBOARD_SIZE;

                    btnGrid[r, c].Click += Grid_Button_Click; // Add the same click event to each button.
                    panel1.Controls.Add(btnGrid[r, c]); 
                    btnGrid[r, c].Location = new Point(buttonBOARD_SIZE * r, buttonBOARD_SIZE * c);

                    // the Tag attribute will hold the row and column number in a string
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }

        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            // get the row and column number of the button just clicked.
            string[] strArr = (sender as Button).Tag.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            UpdateButtonLabels();

            // reset the background color of all buttons to the default (original) color.
            for (int i = 0; i < myBoard.BOARD_SIZE; i++)
            {
                for (int j = 0; j < myBoard.BOARD_SIZE; j++)
                {
                    btnGrid[i, j].BackColor = default(Color);
                }
            }

            // set the background color of the clicked button to something different. 
            (sender as Button).BackColor = Color.Cornsilk;
        }

        public void UpdateButtonLabels()
        {


            for (int r = 0; r < myBoard.BOARD_SIZE; r++)
            {
                for (int c = 0; c < myBoard.BOARD_SIZE; c++)
                {
                    btnGrid[r, c].Text = "";
                }
            }
        }
    }
}

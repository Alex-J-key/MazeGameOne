namespace MazeGameOne
{
    /*
 TCreative Commons Attribution-NonCommercial 4.0 International
 (CC BY-NC 4.0)

 Copyright © 2025 Alexander Keyser
 https://Website-ajk.uk

 This project is licensed under the Creative Commons
 Attribution-NonCommercial 4.0 International License.

 Full license text:
 https://creativecommons.org/licenses/by-nc/4.0/
 Or open the LICENSE File within this project
 */

    /*
     "MazeGameOne" is a maze type game where you attempt to reach the green cell.
     This is Version 2.0
    */

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum Status
        {
            Empty,
            Wall,
            Enemy,
            Target
        }

        int XPOS = 50;
        int YPOS = 50;
        int Speed = 50;

        int CoordinatesX = 1;
        int CoordinatesY = 1;

        int Score = 0;

        Status[,] Cells = {
            {Status.Wall, Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall},
            {Status.Wall, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Empty, Status.Wall,  Status.Wall,  Status.Wall,  Status.Empty, Status.Wall},
            {Status.Wall, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Empty, Status.Wall},
            {Status.Wall, Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall,  Status.Wall}
            };



        public Graphics g;
        public Brush BrushBlue = Brushes.Blue;
        public Brush BrushGray = Brushes.Gray;
        public Brush BrushWhite = Brushes.White;
        public Brush BrushBlack = Brushes.Black;
        public Brush BrushGreen = Brushes.Green;


        public Pen PenRed = Pens.Red;
        public void MovePlayer(int x, int y)
        {
            g = CreateGraphics();
            g.FillRectangle(BrushBlue, x, y, 40, 40);

        }

        public void ClearPlayer(int x, int y)
        {
            //Thread.Sleep(20);
            g.FillRectangle(BrushWhite, x, y, 40, 40);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        bool start = true;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            g = CreateGraphics();
                g.Clear(BackColor);


                g.FillRectangle(BrushWhite, 0, 0, this.Width, this.Height);
                g.FillRectangle(BrushBlue, XPOS, YPOS, 40, 40);

                /*
                g.FillRectangle(BrushGray, 0, 0, 40, 900);
                g.FillRectangle(BrushGray, 0, 0, 900, 40);
                g.FillRectangle(BrushGray, 0, 900, 900, 40);
                g.FillRectangle(BrushGray, 900, 0, 40, 1000);
                */

                for (int i = 0; i <= 18; i++)
                {
                    for (int j = 0; j <= 18; j++)
                    {
                        if (Cells[i, j] == Status.Wall)
                        {
                            g.FillRectangle(BrushGray, j*50, i*50, 40, 40);
                        }
                        else if (Cells[i, j] == Status.Target)
                        {
                            g.FillRectangle(BrushGreen, i*50, j*50, 40, 40);
                        }
                    }
                }
            if (start)
            {
                CreateTarget();
                start = false;
            }
            


            //this.Text = "Game - " + (CoordinatesX-1) + " " + (CoordinatesY-1);
            this.Text = "Maze Game V2.0 - Score: " + Score;
            
        }



        public void CreateTarget()
        {
            Random RNG = new Random();
            int NumX;
            int NumY;

            bool NewTargetAdded = false;

            while (true)
            {
                NumX = RNG.Next(1, 18);
                NumY = RNG.Next(1, 18);
                if (Cells[NumX, NumY] == Status.Empty)
                {
                    g.FillRectangle(BrushGreen, NumX*50, NumY*50, 40, 40);
                    Cells[NumX, NumY] = Status.Target;
                    return;
                }
            }


        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                if (Cells[CoordinatesY - 1, CoordinatesX] != Status.Wall)
                {
                    CoordinatesY--;
                    ClearPlayer(XPOS, YPOS);
                    YPOS -= Speed;
                    MovePlayer(XPOS, YPOS);
                }
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                if (Cells[CoordinatesY + 1, CoordinatesX] != Status.Wall)
                {
                    CoordinatesY++;
                    ClearPlayer(XPOS, YPOS);
                    YPOS += Speed;
                    MovePlayer(XPOS, YPOS);
                }
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                if (Cells[CoordinatesY, CoordinatesX - 1] != Status.Wall)
                {
                    CoordinatesX--;
                    ClearPlayer(XPOS, YPOS);
                    XPOS -= Speed;
                    MovePlayer(XPOS, YPOS);
                }
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                if (Cells[CoordinatesY, CoordinatesX + 1] != Status.Wall)
                {
                    CoordinatesX++;
                    ClearPlayer(XPOS, YPOS);
                    XPOS += Speed;
                    MovePlayer(XPOS, YPOS);
                }
            }
            if (Cells[CoordinatesX, CoordinatesY] == Status.Target)
            {
                //MessageBox.Show("Yay");

                CreateTarget();
                Cells[CoordinatesX, CoordinatesY] = Status.Empty;
                Score++;

            }
            //this.Text = "Game - " + (CoordinatesX-1) + " " + (CoordinatesY-1);
            this.Text = "Maze Game V2.0 - Score: " + Score;
        }
        
    }
}

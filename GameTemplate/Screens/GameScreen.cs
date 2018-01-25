//Tron Light Cycles, Max Senez, Jan.25.2018
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameTemplate.Dialogs;
using System.Threading;
using System.Media;
using System.IO;


namespace GameTemplate.Screens
{


    public partial class GameScreen : UserControl
    {
        //lists
        List<int> p1xBeen = new List<int>();
        List<int> p1yBeen = new List<int>();

        List<int> p2xBeen = new List<int>();
        List<int> p2yBeen = new List<int>();

        //variables
        int p1X = 925;
        int p1Y = 592;
        string P1Direction = "up";
        string P2Direction = "down";
        int p2X = 65;
        int p2Y = 0;
        int player1Speed = 6;
        int player2Speed = 6;
        int p2W = 10, p2H = 10, p1W = 10, p1H = 10;

        String player1 = "Player 2";
        String player2 = "Player 1";

        //Sounds
        SoundPlayer death = new SoundPlayer(Properties.Resources.death2);
        SoundPlayer startUp = new SoundPlayer(Properties.Resources.StartUp);
        System.Windows.Media.MediaPlayer lightCycle2;
        System.Windows.Media.MediaPlayer lightCycle;
        SoundPlayer tick = new SoundPlayer(Properties.Resources.ding);
        SoundPlayer buzz = new SoundPlayer(Properties.Resources.Space_default_sound);
        SoundPlayer endGameSound = new SoundPlayer(Properties.Resources.game_over_sound);

        bool gameStarted = false;
        Thread newThread;
        int frameCounter = 0;

        public GameScreen()
        {
            InitializeComponent();
                                   
            //Light cycle p1
            lightCycle = new System.Windows.Media.MediaPlayer();
            lightCycle.Open(new Uri(Application.StartupPath + "/Resources/LightCycle.wav"));
            //Light cycle p2
            lightCycle2 = new System.Windows.Media.MediaPlayer();
            lightCycle2.Open(new Uri(Application.StartupPath + "/Resources/LightCycle.wav"));

            //Lives
            Form1.p1_1.Visible = true;
            Form1.p1_2.Visible = true;
            Form1.p1_3.Visible = true;
            Form1.p2_1.Visible = true;
            Form1.p2_2.Visible = true;
            Form1.p2_3.Visible = true;
        }


        #region required global values - DO NOT CHANGE

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        #endregion

        //TODO - Place game global variables here 
        //---------------------------------------

        private void GameScreen_Load(object sender, EventArgs e)
        {
            newThread = new Thread(TimeStart);
            newThread.Start();
        }

        // Brushes/Pens
        SolidBrush heroBrush = new SolidBrush(Color.FromArgb(167, 167, 167));
        SolidBrush monsterBrush = new SolidBrush(Color.FromArgb(167, 167, 167));

        SolidBrush tailBrush = new SolidBrush(Color.FromArgb(255, 145, 0));
        SolidBrush tailBrush2 = new SolidBrush(Color.FromArgb(0, 140, 255));

        SolidBrush backColour = new SolidBrush(Color.FromArgb(0, 9, 36));
        Pen border = new Pen(Color.FromArgb(0, 255, 247), 10);
                
        //Methods

        //Crash Method
        private void Crash(int x, int y)
        {
            //Stop bike sound
            lightCycle.Stop();
            lightCycle2.Stop();

            //Play death sound
            death.Play();

            Graphics fg = this.CreateGraphics();

            for (int loop = 0; loop < 3; loop++)
            {
                fg.FillRectangle(heroBrush, p1X, p1Y, p1W, p1H);
                fg.FillRectangle(monsterBrush, p2X, p2Y, p2W, p2H);

                for (int i = 5; i < p1xBeen.Count; i++)
                {
                    fg.FillRectangle(tailBrush, p1xBeen[i], p1yBeen[i], p1W, p1H);
                }

                for (int i = 5; i < p2xBeen.Count; i++)
                {
                    fg.FillRectangle(tailBrush2, p2xBeen[i], p2yBeen[i], p2W, p2H);
                }
                //Blink player
                fg.FillRectangle(backColour, x, y, p1W, p1H);
                Thread.Sleep(250);
                fg.FillRectangle(heroBrush, x, y, p2W, p2H);
                Thread.Sleep(250);
            }
        }
        //Tie method
        private void Tie()
        {
            Graphics fg = this.CreateGraphics();

            for (int loop = 0; loop < 3; loop++)
            {
                lightCycle.Stop();
                lightCycle2.Stop();

                //Blink both players
                fg.FillRectangle(backColour, p1X, p1Y, p1W, p1H);
                fg.FillRectangle(backColour, p2X, p2Y, p1W, p1H);
                Thread.Sleep(250);
                fg.FillRectangle(heroBrush, p1X, p1Y, p2W, p2H);
                fg.FillRectangle(heroBrush, p2X, p2Y, p2W, p2H);
                Thread.Sleep(250);
            }

        }
        //Time start method
        private void TimeStart()
        {
            Thread.Sleep(5000);
            gameStarted = true;
        }
        //Reset method
        private void Reset()
        {
            frameCounter = 0;
            //positions
            p1X = 925;
            p1Y = 592;
            P1Direction = "up";
            P2Direction = "down";
            p2X = 65;
            p2Y = 0;

            //Paths
            p1xBeen.Clear();
            p1yBeen.Clear();
            p2xBeen.Clear();
            p2yBeen.Clear();

            //Countdown
            gameStarted = false;
            newThread = new Thread(TimeStart);
            newThread.Start();
        }
        //Game over method
        private void GameOver(string player)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.White);
            SolidBrush backing = new SolidBrush(Color.FromArgb(0, 255, 247));
            SolidBrush backColour = new SolidBrush(Color.FromArgb(0, 9, 36));
            Font title = new Font("Onky", 25);
            Font sub = new Font("Onky", 20);
            Font going = new Font("Onky", 8);
            gameTimer.Stop();
            lightCycle.Stop();
            lightCycle2.Stop();

            g.Clear(Color.FromArgb(0, 9, 36));

            g.DrawString("Game Over!", title, backing, Width / 2 - 217, Height / 2 - 97);
            g.DrawString("Game Over!", title, sb, Width / 2 - 220, Height / 2 - 100);
            endGameSound.Play();
            Thread.Sleep(750);

            g.DrawString(player + " wins!", sub, sb, Width / 2 - 220, Height / 2 - 20);
            Thread.Sleep(250);

            g.DrawString(player + " wins!", sub, backColour, Width / 2 - 220, Height / 2 - 20);
            Thread.Sleep(250);

            g.DrawString(player + " wins!", sub, sb, Width / 2 - 220, Height / 2 - 20);
            Thread.Sleep(250);

            g.DrawString(player + " wins!", sub, backColour, Width / 2 - 220, Height / 2 - 20);
            Thread.Sleep(250);

            g.DrawString(player + " wins!", sub, sb, Width / 2 - 220, Height / 2 - 20);
            Thread.Sleep(250);

            g.DrawString(player + " wins!", sub, backColour, Width / 2 - 220, Height / 2 - 20);
            Thread.Sleep(250);

            g.DrawString(player + " wins!", sub, sb, Width / 2 - 220, Height / 2 - 20);
            Thread.Sleep(500);

            g.DrawString("Returning to menu screen in... ", going, sb, Width / 2 - 190, Height / 2 + 100);
            Thread.Sleep(500);

            g.DrawString("Returning to menu screen in... 3", going, sb, Width / 2 - 190, Height / 2 + 100);
            Thread.Sleep(1000);

            g.DrawString("Returning to menu screen in... 3", going, backColour, Width / 2 - 190, Height / 2 + 100);
            g.DrawString("Returning to menu screen in... 2", going, sb, Width / 2 - 190, Height / 2 + 100);
            Thread.Sleep(1000);

            g.DrawString("Returning to menu screen in... 2", going, backColour, Width / 2 - 190, Height / 2 + 100);
            g.DrawString("Returning to menu screen in... 1", going, sb, Width / 2 - 190, Height / 2 + 100);
            Thread.Sleep(1000);
            
            Refresh();
            Form1.p1_1.Visible = false;
            Form1.p1_2.Visible = false;
            Form1.p1_3.Visible = false;
            Form1.p2_1.Visible = false;
            Form1.p2_2.Visible = false;
            Form1.p2_3.Visible = false;

            Form1.p1life = 3;
            Form1.p2life = 3;
            ScreenControl.changeScreen(this, "MenuScreen");
        }

        //Lives Method
        private void Lives(int p)
        {
            //                                  Graphics/Movement for arcade???

            //Wait one second then blink lives
            Thread.Sleep(1000);

            if (p == 1)
            {
                //p1
                if (Form1.p1life == 2)
                {
                    Form1.p1_3.Visible = false;
                    Form1.p1_3.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_3.Visible = true;
                    Form1.p1_3.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_3.Visible = false;
                    Form1.p1_3.Refresh();
                    Thread.Sleep(500);
                    Form1.p1_3.Visible = true;
                    Form1.p1_3.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_3.Visible = false;
                    Form1.p1_3.Refresh();
                    Thread.Sleep(500);
                    Form1.p1_3.Visible = true;
                    Form1.p1_3.Refresh();
                     buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_3.Visible = false;
                    Form1.p1_3.Refresh();
                    Thread.Sleep(500);
                }
                if (Form1.p1life == 1)
                {
                    Form1.p1_2.Visible = false;
                    Form1.p1_2.Refresh();
                    Thread.Sleep(500);
                    Form1.p1_2.Visible = true;
                    Form1.p1_2.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_2.Visible = false;
                    Form1.p1_2.Refresh();
                    Thread.Sleep(500);
                    Form1.p1_2.Visible = true;
                    Form1.p1_2.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_2.Visible = false;
                    Form1.p1_2.Refresh();
                    Thread.Sleep(500);
                    Form1.p1_2.Visible = true;
                    Form1.p1_2.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_2.Visible = false;
                    Form1.p1_2.Refresh();
                    Thread.Sleep(500);
                }
                if (Form1.p1life == 0)
                {
                    Form1.p1_1.Visible = false;
                    Form1.p1_1.Refresh();
                    Thread.Sleep(500);
                    Form1.p1_1.Visible = true;
                    Form1.p1_1.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_1.Visible = false;
                    Form1.p1_1.Refresh();
                    Thread.Sleep(500);
                    Form1.p1_1.Visible = true;
                    Form1.p1_1.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_1.Visible = false;
                    Form1.p1_1.Refresh();
                    Thread.Sleep(500);
                    Form1.p1_1.Visible = true;
                    Form1.p1_1.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p1_1.Visible = false;
                    Form1.p1_1.Refresh();
                    Thread.Sleep(500);
                }

            }
            //p2
            else
            {
                if (Form1.p2life == 2)
                {
                    Form1.p2_3.Visible = false;
                    Form1.p2_3.Refresh();
                    Thread.Sleep(500);
                    Refresh();
                    Form1.p2_3.Visible = true;
                    Form1.p2_3.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_3.Visible = false;
                    Form1.p2_3.Refresh();
                    Thread.Sleep(500);
                    Form1.p2_3.Visible = true;
                    Form1.p2_3.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_3.Visible = false;
                    Form1.p2_3.Refresh();
                    Thread.Sleep(500);
                    Form1.p2_3.Visible = true;
                    Form1.p2_3.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_3.Visible = false;
                    Form1.p2_3.Refresh();
                    Thread.Sleep(500);
                }
                if (Form1.p2life == 1)
                {
                    Form1.p2_2.Visible = false;
                    Form1.p2_2.Refresh();
                    Thread.Sleep(500);
                    Form1.p2_2.Visible = true;
                    Form1.p2_2.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_2.Visible = false;
                    Form1.p2_2.Refresh();
                    Thread.Sleep(500);
                    Form1.p2_2.Visible = true;
                    Form1.p2_2.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_2.Visible = false;
                    Form1.p2_2.Refresh();
                    Thread.Sleep(500);
                    Form1.p2_2.Visible = true;
                    Form1.p2_2.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_2.Visible = false;
                    Form1.p2_2.Refresh();
                    Thread.Sleep(500);
                }
                if (Form1.p2life == 0)
                {
                    Form1.p2_1.Visible = false;
                    Form1.p2_1.Refresh();
                    Thread.Sleep(500);
                    Form1.p2_1.Visible = true;
                    Form1.p2_1.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_1.Visible = false;
                    Form1.p2_1.Refresh();
                    Thread.Sleep(500);
                    Form1.p2_1.Visible = true;
                    Form1.p2_1.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_1.Visible = false;
                    Form1.p2_1.Refresh();
                    Thread.Sleep(500);
                    Form1.p2_1.Visible = true;
                    Form1.p2_1.Refresh();
                    buzz.Play();
                    Thread.Sleep(500);
                    Form1.p2_1.Visible = false;
                    Form1.p2_1.Refresh();
                    Thread.Sleep(500);
                }
            }
        }
                
        //----------------------------------------

        // PreviewKeyDown required for UserControl instead of KeyDown as on a form
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!gameStarted)
            {

            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    pauseGame();
                }

                //player 1 button presses
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        leftArrowDown = true;
                        P2Direction = "left";
                        lightCycle.Stop();
                        lightCycle.Play();
                        break;
                    case Keys.Down:
                        downArrowDown = true;
                        P2Direction = "down";
                        lightCycle.Stop();
                        lightCycle.Play();
                        break;
                    case Keys.Right:
                        rightArrowDown = true;
                        P2Direction = "right";
                        lightCycle.Stop();
                        lightCycle.Play();
                        break;
                    case Keys.Up:
                        upArrowDown = true;
                        P2Direction = "up";
                        lightCycle.Stop();
                        lightCycle.Play();
                        break;
                    default:
                        break;
                }
            
                //player 2 button presses
                switch (e.KeyCode)
                {
                    case Keys.A:
                        aDown = true;
                        P1Direction = "left";
                        lightCycle2.Stop();
                        lightCycle2.Play();
                        break;
                    case Keys.S:
                        sDown = true;
                        P1Direction = "down";
                        lightCycle2.Stop();
                        lightCycle2.Play();
                        break;
                    case Keys.D:
                        dDown = true;
                        P1Direction = "right";
                        lightCycle2.Stop();
                        lightCycle2.Play();
                        break;
                    case Keys.W:
                        wDown = true;
                        P1Direction = "up";
                        lightCycle2.Stop();
                        lightCycle2.Play();
                        break;
                        default:
                        break;
                }
            }
        }
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (!gameStarted)
            {

            }
            else
            {
                //player 1 button releases
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        leftArrowDown = false;
                        break;
                    case Keys.Down:
                        downArrowDown = false;
                        break;
                    case Keys.Right:
                        rightArrowDown = false;
                        break;
                    case Keys.Up:
                        upArrowDown = false;
                        break;
                    default:
                        break;
                }

                //player 2 button releases
                switch (e.KeyCode)
                {
                    case Keys.A:
                        aDown = false;
                        break;
                    case Keys.S:
                        sDown = false;
                        break;
                    case Keys.D:
                        dDown = false;
                        break;
                    case Keys.W:
                        wDown = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// All game update logic must be placed in this event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region main character movements



            if (gameStarted)
            {
                p1xBeen.Insert(0, p1X);
                p1yBeen.Insert(0, p1Y);

                if (P1Direction == "right")
                {
                    p1X = p1X + player1Speed;
                }
                else if (P1Direction == "down")
                {
                    p1Y = p1Y + player1Speed;
                }
                else if (P1Direction == "up")
                {
                    p1Y = p1Y - player1Speed;
                }
                else if (P1Direction == "left")
                {
                    p1X = p1X - player1Speed;
                }

                p2xBeen.Insert(0, p2X);
                p2yBeen.Insert(0, p2Y);

                if (P2Direction == "right")
                {
                    p2X = p2X + player2Speed;
                }
                else if (P2Direction == "down")
                {
                    p2Y = p2Y + player2Speed;
                }
                else if (P2Direction == "up")
                {
                    p2Y = p2Y - player2Speed;
                }
                else if (P2Direction == "left")
                {
                    p2X = p2X - player2Speed;
                }
            }
            #endregion

            #region monster movements - TO BE COMPLETED
            //if (drawX > monsterX)
            //{
            //    monsterX++;
            //}
            //if (drawX < monsterX)
            //{
            //    monsterX--;
            //}
            //if (drawY < monsterY)
            //{
            //    monsterY--;
            //}
            //if (drawY > monsterY)
            //{
            //    monsterY++;
            //}

            #endregion

            #region collision detection - TO BE COMPLETED

            //Player hitboxs
            Rectangle p1Rec = new Rectangle(p1X, p1Y, p1W, p1H);
            Rectangle p2Rec = new Rectangle(p2X, p2Y, p2W, p2H);

            //p1 Collide with p2 path
            for (int i = 0; i < p2xBeen.Count; i++)
            {
                Rectangle p2Pathrec = new Rectangle(p2xBeen[i], p2yBeen[i], p2W, p2H);
                if (p2Pathrec.IntersectsWith(p1Rec))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p1X, p1Y);
                    Refresh();
                    Form1.p1life--;
                    Lives(1);
                    if (Form1.p1life == 0)
                    {
                        GameOver(player1);
                    }
                    Reset();
                    
                    return;
                }
            }
            //p2 collide with p1 path
            for (int i = 0; i < p1xBeen.Count; i++)
            {
                Rectangle p1Pathrec = new Rectangle(p1xBeen[i], p1yBeen[i], p1W, p1H);

                if (p1Pathrec.IntersectsWith(p2Rec))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p2X, p2Y);
                    Refresh();
                    Form1.p2life--;
                    Lives(2);
                    if (Form1.p2life == 0)
                    {
                        GameOver(player2);

                    }
                    Reset();

                    return;
                }
            }
            //p1 collide with p2
            if (p1Rec.IntersectsWith(p2Rec) && p2Rec.IntersectsWith(p1Rec))
            {
                gameStarted = false;
                Refresh();
                Tie();
                Refresh();
                Reset();
                return;
            }

            //p1 collide with p1 path
            for (int i = 10; i < p1xBeen.Count; i++)
            {
                Rectangle p1Pathrec = new Rectangle(p1xBeen[i], p1yBeen[i], p1W, p1H);

                if (p1Pathrec.IntersectsWith(p1Rec))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p1X, p1Y);
                    Refresh();
                    Form1.p1life--;
                    Lives(1);
                    if (Form1.p1life == 0)
                    {
                        GameOver(player1);
                    }
                    Reset();

                    return;
                }
            }

            //p2 collide with p2 path
            for (int i = 10; i < p2xBeen.Count; i++)
            {
                Rectangle p2Pathrec = new Rectangle(p2xBeen[i], p2yBeen[i], p2W, p2H);

                if (p2Pathrec.IntersectsWith(p2Rec))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p2X, p2Y);
                    Refresh();
                    Form1.p2life--;
                    Lives(2);
                    if (Form1.p2life == 0)
                    {
                        GameOver(player2);
                    }
                    Reset();

                    return;
                }
            }
           
            //P1 borders
            for (int i = 10; i < p1xBeen.Count; i++)
            {
                Rectangle rightWall = new Rectangle(Width, 0, 10, Height);
                Rectangle floor = new Rectangle(0, Height, Width, 10);
                Rectangle leftWall = new Rectangle(0, 0, 10, Height);
                Rectangle ceiling = new Rectangle(0, 0, Width, 10);

                if (p1Rec.IntersectsWith(leftWall))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p1X, p1Y);
                    Refresh();
                    Form1.p1life--;
                    Lives(1);
                    if (Form1.p1life == 0)
                    {
                        GameOver(player1);
                    }
                    Reset();
                    return;
                }

                if (p1Rec.IntersectsWith(floor) || p1Y > Width)
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p1X, p1Y);
                    Refresh();
                    Form1.p1life--;
                    Lives(1);
                    if (Form1.p1life == 0)
                    {
                       GameOver(player1);
                    }
                    Reset();
                    return;
                }

                if (p1Rec.IntersectsWith(rightWall))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p1X, p1Y);
                    Refresh();
                    Form1.p1life--;
                    Lives(1);
                    if (Form1.p1life == 0)
                    {
                        GameOver(player1);
                    }
                    Reset();
                    return ;
                }

                if (p1Rec.IntersectsWith(ceiling))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p1X, p1Y);
                    Refresh();
                    Form1.p1life--;
                    Lives(1);
                    if (Form1.p1life == 0)
                    {
                        GameOver(player1);
                    }
                    Reset();
                    return;
                }
            }
            //P2 borders
            for (int i = 10; i < p2xBeen.Count; i++)
            {
                Rectangle leftWall = new Rectangle(Width, 0, 10, Height);
                Rectangle floor = new Rectangle(0, Height, Width, 10);
                Rectangle rightWall = new Rectangle(0, 0, 10, Height);
                Rectangle ceiling = new Rectangle(0, 0, Width, 10);

                if (p2Rec.IntersectsWith(leftWall))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p2X, p2Y);
                    Refresh();
                    Form1.p2life--;
                    Lives(2);
                    if (Form1.p2life == 0)
                    {
                        GameOver(player2);
                    }
                    Reset();
                    return;
                }

                if (p2Rec.IntersectsWith(floor))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p2X, p2Y);
                    Refresh();
                    Form1.p2life--;
                    Lives(2);
                    if (Form1.p2life == 0)
                    {
                        GameOver(player2);
                    }
                    Reset();
                    return;
                }

                if (p2Rec.IntersectsWith(rightWall))
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p2X, p2Y);
                    Refresh();
                    Form1.p2life--;
                    Lives(2);
                    if (Form1.p2life == 0)
                    {
                        GameOver(player2);
                    }
                    Reset();
                    return;
                }

                if (p2Rec.IntersectsWith(ceiling) || p2Rec.Location.Y < 0)
                {
                    gameStarted = false;
                    Refresh();
                    Crash(p2X, p2Y);
                    Refresh();
                    Form1.p2life--;
                    Lives(2);
                    if (Form1.p2life == 0)
                    {
                        GameOver(player2);
                    }
                    Reset();
                    return;
                }
            }
                #endregion
            
                //refresh the screen, which causes the GameScreen_Paint method to run
                Refresh();
        }
      
        /// <summary>
        /// Open the pause dialog box and gets Cancel or Abort result from it
        /// </summary>
        private void pauseGame()
        {
            gameTimer.Enabled = false;
            rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;
            lightCycle.Stop();
            lightCycle2.Stop();
            
            DialogResult result = PauseDialog.Show();

            if (result == DialogResult.Cancel)
            {
                gameTimer.Enabled = true;
                lightCycle.Play();
                lightCycle2.Play();
            }
            if (result == DialogResult.Abort)
            {
                ScreenControl.changeScreen(this, "MenuScreen");
            }
        }

        /// <summary>
        /// All drawing, (and only drawing), to be done here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Timer Brushes
            SolidBrush sb = new SolidBrush(Color.White);
            Font f = new Font("Onky", 25);

            //boarder
            e.Graphics.DrawLine(border, Width, 0, Width, Height);
            e.Graphics.DrawLine(border, Width, Height, 0, Height);
            e.Graphics.DrawLine(border, 0, 0, 0, Height);
            e.Graphics.DrawLine(border, 0, 0, Width, 0);

            //Help
            if (!gameStarted)
            {
                frameCounter++;

                //Countdown / startup noises
                if (frameCounter < 40)
                {
                    e.Graphics.DrawString("Ready!", f, sb, Width / 2 - 125, Height / 2 - 25);
                    tick.Play();
                }
                else if (frameCounter >= 40 && frameCounter < 79)
                {
                    e.Graphics.DrawString("3", f, sb, Width / 2 - 20, Height / 2 - 25);
                }
                else if (frameCounter >= 79 && frameCounter < 80)
                {
                    tick.Play();
                }
                else if (frameCounter >= 80 && frameCounter < 119)
                {
                    e.Graphics.DrawString("2", f, sb, Width / 2 - 20, Height / 2 - 25);
                }
                else if (frameCounter >= 119 && frameCounter < 120)
                {
                    tick.Play();
                }
                else if (frameCounter >= 120 && frameCounter < 159)
                {
                    e.Graphics.DrawString("1", f, sb, Width / 2 - 20, Height / 2 - 25);
                }
                else if (frameCounter >= 159 && frameCounter < 160)
                {
                    startUp.Play();

                }
                else if (frameCounter >= 160 && frameCounter < 195)
                {
                    e.Graphics.DrawString("Go!", f, sb, Width / 2 - 50, Height / 2 - 25);
                }
                else if (frameCounter >= 195 && frameCounter < 200)
                {
                    lightCycle.Play();
                    lightCycle2.Play();
                }
                else if (frameCounter >= 200)
                {
                    e.Graphics.DrawString("Go!", f, sb, Width, Height);
                }

                //pre game cycles
                e.Graphics.FillRectangle(heroBrush, p1X, p1Y, p1W, p1H);
                e.Graphics.FillRectangle(monsterBrush, p2X, p2Y, p2W, p2H);
            }

            if (gameStarted)
            {
                //Draw cycles
                e.Graphics.FillRectangle(heroBrush, p1X, p1Y, p1W, p1H);
                e.Graphics.FillRectangle(monsterBrush, p2X, p2Y, p2W, p2H);

                //Draw paths
                for (int i = 5; i < p1xBeen.Count; i++)
                {
                    e.Graphics.FillRectangle(tailBrush, p1xBeen[i], p1yBeen[i], p1W, p1H);
                }

                for (int i = 5; i < p2xBeen.Count; i++)
                {
                    e.Graphics.FillRectangle(tailBrush2, p2xBeen[i], p2yBeen[i], p2W, p2H);
                }
            }
        }
    }
}

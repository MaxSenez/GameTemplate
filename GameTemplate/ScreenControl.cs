using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameTemplate.Screens;
using System.Media;
using System.IO;

namespace GameTemplate
{
    class ScreenControl
    {
        // high score values
        public static List<int> highScores = new List<int>();

        // screen and user control values
        public static int controlWidth = 1000;
        public static int controlHeight = 600;
        
        public static int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        public static int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
        
        public static Point startCentre = new Point(screenWidth / 2 - controlWidth / 2, screenHeight / 2 - controlHeight / 2);

        // button values
        public static Size buttonSize = new Size(220, 100);
        public static Color buttonBackColor = Color.FromArgb(16, 16, 16);
        public static Color buttonActiveColor = Color.FromArgb(32, 32, 32);
        public static FlatStyle buttonFlatStyle = FlatStyle.Flat;
        public static Font buttonFont = new Font("Onky", 10, FontStyle.Bold);

        public static Boolean firstTime = true;

        public static void buttonLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = buttonBackColor;
        }

        public static void buttonEnter(object sender, EventArgs e)
        {
            //System.Windows.Media.MediaPlayer menuPlayer;

            //menuPlayer = new System.Windows.Media.MediaPlayer();
            //menuPlayer.Open(new Uri(Application.StartupPath + "/Resources/blip.wav"));
            SoundPlayer menuPlayer = new SoundPlayer(Properties.Resources.Menu_sound);


            Button btn = (Button)sender;
            btn.BackColor = buttonActiveColor;
            menuPlayer.Play();
        }

        public static void changeScreen(UserControl current, string next)
        {

            //tmp is set to the form that this control is on
            Form tmp = current.FindForm();
            tmp.Controls.Remove(current);
            UserControl ns = null;

            switch (next)
            {
                case "GameScreen":
                    ns = new GameScreen();
                    break;
                case "InstructionScreen":
                    ns = new InstructionScreen();
                    break;
                case "MenuScreen":
                    ns = new MenuScreen();
                    break;
                case "OptionScreen":
                    ns = new OptionScreen();
                    break;
                case "ScoreScreen":
                    ns = new ScoreScreen();
                    break;

            }

            ns.Size = new Size(controlWidth, controlHeight);
            ns.Location = startCentre;
            tmp.Controls.Add(ns);
            ns.Focus();
        }

        public static void setComponentValues(UserControl uc)
        {
            foreach (Control c in uc.Controls)
            {
                //will make the font of all components equal to buttonFont value
                c.Font = buttonFont;

                if (c is Button)
                {
                    Button b = new Button();
                    b = (Button)c;

                    b.Font = buttonFont;
                    b.BackColor = buttonBackColor;
                    b.Size = buttonSize;
                    b.FlatStyle = buttonFlatStyle;
                    b.Enter += buttonEnter;
                    b.Leave += buttonLeave;
                }

                // centre components on user control
                c.Location = new Point(controlWidth / 2 - c.Width / 2, c.Location.Y);
            }
        }

        public static void setComponentValues(Form f)
        {
            foreach (Control c in f.Controls)
            {
                //will make the font of all components equal to buttonFont value
                c.Font = buttonFont;

                if (c is Button)
                {
                    Button b = new Button();
                    b = (Button)c;

                    b.Font = buttonFont;
                    b.BackColor = buttonBackColor;
                    b.Size = buttonSize;
                    b.FlatStyle = buttonFlatStyle;
                }
                // tuy9s 9aposdfpoaisd fpoyiad 
                // centre components on user control
                c.Location = new Point(controlWidth / 2 - c.Width / 2, c.Location.Y);
            }
        }
    }
}

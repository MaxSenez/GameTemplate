using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTemplate
{
    public partial class Form1 : Form
    {
        public static int p1life = 3;
        public static int p2life = 3;

        public static Label p1_1, p1_2, p1_3;
        public static Label p2_1, p2_2, p2_3;

        public Form1()
        {
            InitializeComponent();
                       
            p2life1.Location = new Point(1409, 170);
            p2life2.Location = new Point(1345, 170);
            p2life3.Location = new Point(1281, 170);

            p1life1.Location = new Point(463, 170);
            p1life2.Location = new Point(526, 170);
            p1life3.Location = new Point(589, 170);
            
            p1_1 = p2life1;
            p1_2 = p2life2;
            p1_3 = p2life3;

            p2_1 = p1life1;
            p2_2 = p1life2;
            p2_3 = p1life3;


            // hide the mouse cursor
            Cursor.Hide();

            // display the main menu
            Screens.MenuScreen mm = new Screens.MenuScreen();

            // set the menu to display centre screen based on screen size defaults
            mm.Size = new Size(ScreenControl.controlWidth, ScreenControl.controlHeight);
            mm.Location = ScreenControl.startCentre;

            // add main menu screen to form
            this.Controls.Add(mm);
        }
    }
}

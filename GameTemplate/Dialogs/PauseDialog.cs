using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace GameTemplate.Dialogs
{
    class PauseDialog : Form
    {
        private static Button exitButton;
        private static Button continueButton;

        private static PauseDialog pauseDialog;
        private static DialogResult buttonResult = new DialogResult();
        private static List<Button> _buttonCollection = new List<Button>();

        public static DialogResult Show()
        {
            pauseDialog = new PauseDialog();
                  
            pauseDialog.FormBorderStyle = FormBorderStyle.None;
            pauseDialog.StartPosition = FormStartPosition.CenterScreen;
            pauseDialog.Size = new Size(ScreenControl.controlWidth, ScreenControl.controlHeight);
            pauseDialog.BackColor = Color.FromArgb(0, 9, 36);
                   
            continueButton = new Button();
            continueButton.Location = new Point(10, pauseDialog.Height / 2 - ScreenControl.buttonSize.Height - 10);
            continueButton.Text = "Play";
            continueButton.ForeColor = Color.FromArgb(0, 255, 247);
            continueButton.FlatAppearance.BorderSize = 4;
            continueButton.FlatAppearance.BorderColor = Color.FromArgb(0, 68, 66);
            continueButton.BackColor = Color.FromArgb(16, 16, 16);
            continueButton.Click += ButtonClick;
            continueButton.Enter += ScreenControl.buttonEnter;
            continueButton.Leave += ScreenControl.buttonLeave;
            pauseDialog.Controls.Add(continueButton);

            exitButton = new Button();
            exitButton.Location = new Point(10, pauseDialog.Height / 2 + 10);
            exitButton.Text = "Exit";
            exitButton.ForeColor = Color.FromArgb(0, 255, 247);
            exitButton.FlatAppearance.BorderSize = 4;
            exitButton.FlatAppearance.BorderColor = Color.FromArgb(0, 68, 66);
            exitButton.BackColor = Color.FromArgb(16, 16, 16);
            exitButton.Click += ButtonClick;
            exitButton.Enter += ScreenControl.buttonEnter;
            exitButton.Leave += ScreenControl.buttonLeave;
            pauseDialog.Controls.Add(exitButton);

            ScreenControl.setComponentValues(pauseDialog);

            pauseDialog.ShowDialog();
            return buttonResult;
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "Play":
                    buttonResult = DialogResult.Cancel;
                    break;
                case "Exit":
                    buttonResult = DialogResult.Abort;
                    break;
            }

            pauseDialog.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PauseDialog
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PauseDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PauseDialog_Load);
            this.ResumeLayout(false);

        }

        private void PauseDialog_Load(object sender, EventArgs e)
        {

        }
    }
}

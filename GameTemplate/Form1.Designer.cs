namespace GameTemplate
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.p2life1 = new System.Windows.Forms.Label();
            this.p2life2 = new System.Windows.Forms.Label();
            this.p2life3 = new System.Windows.Forms.Label();
            this.p1life1 = new System.Windows.Forms.Label();
            this.p1life2 = new System.Windows.Forms.Label();
            this.p1life3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // p2life1
            // 
            this.p2life1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.p2life1.ForeColor = System.Drawing.Color.White;
            this.p2life1.Location = new System.Drawing.Point(13, 13);
            this.p2life1.Name = "p2life1";
            this.p2life1.Size = new System.Drawing.Size(51, 20);
            this.p2life1.TabIndex = 0;
            this.p2life1.Visible = false;
            // 
            // p2life2
            // 
            this.p2life2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.p2life2.ForeColor = System.Drawing.Color.White;
            this.p2life2.Location = new System.Drawing.Point(82, 13);
            this.p2life2.Name = "p2life2";
            this.p2life2.Size = new System.Drawing.Size(51, 20);
            this.p2life2.TabIndex = 1;
            this.p2life2.Visible = false;
            // 
            // p2life3
            // 
            this.p2life3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.p2life3.ForeColor = System.Drawing.Color.White;
            this.p2life3.Location = new System.Drawing.Point(149, 13);
            this.p2life3.Name = "p2life3";
            this.p2life3.Size = new System.Drawing.Size(51, 20);
            this.p2life3.TabIndex = 2;
            this.p2life3.Visible = false;
            // 
            // p1life1
            // 
            this.p1life1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.p1life1.ForeColor = System.Drawing.Color.White;
            this.p1life1.Location = new System.Drawing.Point(696, 13);
            this.p1life1.Name = "p1life1";
            this.p1life1.Size = new System.Drawing.Size(51, 20);
            this.p1life1.TabIndex = 5;
            this.p1life1.Visible = false;
            // 
            // p1life2
            // 
            this.p1life2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.p1life2.ForeColor = System.Drawing.Color.White;
            this.p1life2.Location = new System.Drawing.Point(629, 13);
            this.p1life2.Name = "p1life2";
            this.p1life2.Size = new System.Drawing.Size(51, 20);
            this.p1life2.TabIndex = 4;
            this.p1life2.Visible = false;
            // 
            // p1life3
            // 
            this.p1life3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.p1life3.ForeColor = System.Drawing.Color.White;
            this.p1life3.Location = new System.Drawing.Point(560, 13);
            this.p1life3.Name = "p1life3";
            this.p1life3.Size = new System.Drawing.Size(51, 20);
            this.p1life3.TabIndex = 3;
            this.p1life3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.p1life1);
            this.Controls.Add(this.p1life2);
            this.Controls.Add(this.p1life3);
            this.Controls.Add(this.p2life3);
            this.Controls.Add(this.p2life2);
            this.Controls.Add(this.p2life1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Label p2life1;
        private System.Windows.Forms.Label p2life2;
        private System.Windows.Forms.Label p2life3;
        private System.Windows.Forms.Label p1life1;
        private System.Windows.Forms.Label p1life2;
        private System.Windows.Forms.Label p1life3;
    }
}


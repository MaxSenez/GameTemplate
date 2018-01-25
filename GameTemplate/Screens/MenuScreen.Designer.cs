namespace GameTemplate.Screens
{
    partial class MenuScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.gameTitle = new System.Windows.Forms.Label();
            this.instructionButton = new System.Windows.Forms.Button();
            this.p1Graphic = new System.Windows.Forms.Label();
            this.p1Cycle = new System.Windows.Forms.Label();
            this.p2Cycle = new System.Windows.Forms.Label();
            this.p2Graphic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.exitButton.Location = new System.Drawing.Point(148, 327);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(167, 52);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Quit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.playButton.Font = new System.Drawing.Font("Onky", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.playButton.Location = new System.Drawing.Point(137, 137);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(199, 77);
            this.playButton.TabIndex = 6;
            this.playButton.Tag = "GameScreen";
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // gameTitle
            // 
            this.gameTitle.Font = new System.Drawing.Font("Onky", 28F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTitle.ForeColor = System.Drawing.Color.White;
            this.gameTitle.Location = new System.Drawing.Point(91, 24);
            this.gameTitle.Name = "gameTitle";
            this.gameTitle.Size = new System.Drawing.Size(659, 142);
            this.gameTitle.TabIndex = 5;
            this.gameTitle.Text = "TRON LIGHTCYCLES";
            this.gameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // instructionButton
            // 
            this.instructionButton.BackColor = System.Drawing.Color.White;
            this.instructionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instructionButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.instructionButton.Location = new System.Drawing.Point(142, 233);
            this.instructionButton.Name = "instructionButton";
            this.instructionButton.Size = new System.Drawing.Size(181, 57);
            this.instructionButton.TabIndex = 7;
            this.instructionButton.Text = "High-Score";
            this.instructionButton.UseVisualStyleBackColor = false;
            this.instructionButton.Click += new System.EventHandler(this.instructionButton_Click);
            // 
            // p1Graphic
            // 
            this.p1Graphic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.p1Graphic.Location = new System.Drawing.Point(384, 194);
            this.p1Graphic.Name = "p1Graphic";
            this.p1Graphic.Size = new System.Drawing.Size(20, 500);
            this.p1Graphic.TabIndex = 11;
            // 
            // p1Cycle
            // 
            this.p1Cycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.p1Cycle.Location = new System.Drawing.Point(374, 155);
            this.p1Cycle.Name = "p1Cycle";
            this.p1Cycle.Size = new System.Drawing.Size(20, 20);
            this.p1Cycle.TabIndex = 12;
            // 
            // p2Cycle
            // 
            this.p2Cycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.p2Cycle.Location = new System.Drawing.Point(26, 155);
            this.p2Cycle.Name = "p2Cycle";
            this.p2Cycle.Size = new System.Drawing.Size(20, 20);
            this.p2Cycle.TabIndex = 13;
            // 
            // p2Graphic
            // 
            this.p2Graphic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.p2Graphic.Location = new System.Drawing.Point(26, 194);
            this.p2Graphic.Name = "p2Graphic";
            this.p2Graphic.Size = new System.Drawing.Size(20, 500);
            this.p2Graphic.TabIndex = 14;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.p2Graphic);
            this.Controls.Add(this.p2Cycle);
            this.Controls.Add(this.p1Cycle);
            this.Controls.Add(this.p1Graphic);
            this.Controls.Add(this.instructionButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.gameTitle);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(482, 455);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label gameTitle;
        private System.Windows.Forms.Button instructionButton;
        private System.Windows.Forms.Label p1Graphic;
        private System.Windows.Forms.Label p1Cycle;
        private System.Windows.Forms.Label p2Cycle;
        private System.Windows.Forms.Label p2Graphic;
    }
}

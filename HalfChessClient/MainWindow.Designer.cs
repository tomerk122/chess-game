namespace HalfChessClient
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.TurnTicker = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.webSiteButton = new System.Windows.Forms.Button();
            this.comboBox_time = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_player_id = new System.Windows.Forms.Label();
            this.label_player_name = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_clear_drawing = new System.Windows.Forms.Button();
            this.button_load_game = new System.Windows.Forms.Button();
            this.button_new_game = new System.Windows.Forms.Button();
            this.BlackPlayerRemainTime = new System.Windows.Forms.Label();
            this.WhitePlayerRemainTime = new System.Windows.Forms.Label();
            this.WhitePlayerTime = new System.Windows.Forms.Label();
            this.BlackPlayerTime = new System.Windows.Forms.Label();
            this.WhitePlayerName = new System.Windows.Forms.Label();
            this.BlackPlayerName = new System.Windows.Forms.Label();
            this.WhitePlayerImage = new System.Windows.Forms.PictureBox();
            this.BlackPlayerImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WhitePlayerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackPlayerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TurnTicker
            // 
            this.TurnTicker.Interval = 500;
            this.TurnTicker.Tick += new System.EventHandler(this.TurnTicker_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.webSiteButton);
            this.panel1.Controls.Add(this.comboBox_time);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label_player_id);
            this.panel1.Controls.Add(this.label_player_name);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_clear_drawing);
            this.panel1.Controls.Add(this.button_load_game);
            this.panel1.Controls.Add(this.button_new_game);
            this.panel1.Controls.Add(this.BlackPlayerRemainTime);
            this.panel1.Controls.Add(this.WhitePlayerRemainTime);
            this.panel1.Controls.Add(this.WhitePlayerTime);
            this.panel1.Controls.Add(this.BlackPlayerTime);
            this.panel1.Controls.Add(this.WhitePlayerName);
            this.panel1.Controls.Add(this.BlackPlayerName);
            this.panel1.Controls.Add(this.WhitePlayerImage);
            this.panel1.Controls.Add(this.BlackPlayerImage);
            this.panel1.ForeColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(286, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 505);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 31);
            this.label5.TabIndex = 11;
            this.label5.Text = "Chess Alert";
            this.label5.Visible = false;
            // 
            // webSiteButton
            // 
            this.webSiteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webSiteButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.webSiteButton.Location = new System.Drawing.Point(32, 170);
            this.webSiteButton.Name = "webSiteButton";
            this.webSiteButton.Size = new System.Drawing.Size(136, 32);
            this.webSiteButton.TabIndex = 10;
            this.webSiteButton.Text = "Website";
            this.webSiteButton.UseVisualStyleBackColor = true;
            this.webSiteButton.Click += new System.EventHandler(this.webSiteButton_Click);
            // 
            // comboBox_time
            // 
            this.comboBox_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_time.FormattingEnabled = true;
            this.comboBox_time.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60"});
            this.comboBox_time.Location = new System.Drawing.Point(120, 15);
            this.comboBox_time.Name = "comboBox_time";
            this.comboBox_time.Size = new System.Drawing.Size(47, 26);
            this.comboBox_time.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Think Time: ";
            // 
            // label_player_id
            // 
            this.label_player_id.AutoSize = true;
            this.label_player_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player_id.ForeColor = System.Drawing.Color.Black;
            this.label_player_id.Location = new System.Drawing.Point(101, 466);
            this.label_player_id.Name = "label_player_id";
            this.label_player_id.Size = new System.Drawing.Size(32, 18);
            this.label_player_id.TabIndex = 7;
            this.label_player_id.Text = "225";
            // 
            // label_player_name
            // 
            this.label_player_name.AutoSize = true;
            this.label_player_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_player_name.ForeColor = System.Drawing.Color.Black;
            this.label_player_name.Location = new System.Drawing.Point(101, 443);
            this.label_player_name.Name = "label_player_name";
            this.label_player_name.Size = new System.Drawing.Size(49, 18);
            this.label_player_name.TabIndex = 7;
            this.label_player_name.Text = "Player";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(24, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Player ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Player\'s Information";
            // 
            // button_clear_drawing
            // 
            this.button_clear_drawing.Enabled = false;
            this.button_clear_drawing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear_drawing.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_clear_drawing.Location = new System.Drawing.Point(32, 132);
            this.button_clear_drawing.Name = "button_clear_drawing";
            this.button_clear_drawing.Size = new System.Drawing.Size(136, 32);
            this.button_clear_drawing.TabIndex = 6;
            this.button_clear_drawing.Text = "Clear Drawing";
            this.button_clear_drawing.UseVisualStyleBackColor = true;
            this.button_clear_drawing.Click += new System.EventHandler(this.ClearDrawing_Click);
            // 
            // button_load_game
            // 
            this.button_load_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_load_game.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_load_game.Location = new System.Drawing.Point(31, 95);
            this.button_load_game.Name = "button_load_game";
            this.button_load_game.Size = new System.Drawing.Size(136, 32);
            this.button_load_game.TabIndex = 6;
            this.button_load_game.Text = "Load Game";
            this.button_load_game.UseVisualStyleBackColor = true;
            this.button_load_game.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // button_new_game
            // 
            this.button_new_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_new_game.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_new_game.Location = new System.Drawing.Point(31, 58);
            this.button_new_game.Name = "button_new_game";
            this.button_new_game.Size = new System.Drawing.Size(136, 32);
            this.button_new_game.TabIndex = 6;
            this.button_new_game.Text = "New Game";
            this.button_new_game.UseVisualStyleBackColor = true;
            this.button_new_game.Click += new System.EventHandler(this.NewGame_Click);
            this.button_new_game.MouseEnter += new System.EventHandler(this.button_new_game_MouseEnter);
            this.button_new_game.MouseLeave += new System.EventHandler(this.button_new_game_MouseLeave);
            // 
            // BlackPlayerRemainTime
            // 
            this.BlackPlayerRemainTime.BackColor = System.Drawing.SystemColors.Control;
            this.BlackPlayerRemainTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackPlayerRemainTime.ForeColor = System.Drawing.Color.Red;
            this.BlackPlayerRemainTime.Location = new System.Drawing.Point(73, 216);
            this.BlackPlayerRemainTime.Name = "BlackPlayerRemainTime";
            this.BlackPlayerRemainTime.Size = new System.Drawing.Size(114, 24);
            this.BlackPlayerRemainTime.TabIndex = 5;
            this.BlackPlayerRemainTime.Text = "20";
            this.BlackPlayerRemainTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BlackPlayerRemainTime.Click += new System.EventHandler(this.BlackPlayerRemainTime_Click);
            // 
            // WhitePlayerRemainTime
            // 
            this.WhitePlayerRemainTime.BackColor = System.Drawing.SystemColors.Control;
            this.WhitePlayerRemainTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhitePlayerRemainTime.ForeColor = System.Drawing.Color.Red;
            this.WhitePlayerRemainTime.Location = new System.Drawing.Point(68, 312);
            this.WhitePlayerRemainTime.Name = "WhitePlayerRemainTime";
            this.WhitePlayerRemainTime.Size = new System.Drawing.Size(119, 24);
            this.WhitePlayerRemainTime.TabIndex = 5;
            this.WhitePlayerRemainTime.Text = "20";
            this.WhitePlayerRemainTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WhitePlayerTime
            // 
            this.WhitePlayerTime.BackColor = System.Drawing.SystemColors.Control;
            this.WhitePlayerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhitePlayerTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.WhitePlayerTime.Location = new System.Drawing.Point(68, 336);
            this.WhitePlayerTime.Name = "WhitePlayerTime";
            this.WhitePlayerTime.Size = new System.Drawing.Size(119, 24);
            this.WhitePlayerTime.TabIndex = 5;
            this.WhitePlayerTime.Text = "00:00:00";
            this.WhitePlayerTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BlackPlayerTime
            // 
            this.BlackPlayerTime.BackColor = System.Drawing.SystemColors.Control;
            this.BlackPlayerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackPlayerTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BlackPlayerTime.Location = new System.Drawing.Point(73, 244);
            this.BlackPlayerTime.Name = "BlackPlayerTime";
            this.BlackPlayerTime.Size = new System.Drawing.Size(114, 24);
            this.BlackPlayerTime.TabIndex = 4;
            this.BlackPlayerTime.Text = "00:00:00";
            this.BlackPlayerTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WhitePlayerName
            // 
            this.WhitePlayerName.BackColor = System.Drawing.Color.Transparent;
            this.WhitePlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhitePlayerName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WhitePlayerName.Location = new System.Drawing.Point(24, 366);
            this.WhitePlayerName.Name = "WhitePlayerName";
            this.WhitePlayerName.Size = new System.Drawing.Size(165, 24);
            this.WhitePlayerName.TabIndex = 3;
            this.WhitePlayerName.Text = "Player";
            this.WhitePlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WhitePlayerName.Click += new System.EventHandler(this.WhitePlayerName_Click);
            // 
            // BlackPlayerName
            // 
            this.BlackPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.BlackPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackPlayerName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BlackPlayerName.Location = new System.Drawing.Point(27, 269);
            this.BlackPlayerName.Name = "BlackPlayerName";
            this.BlackPlayerName.Size = new System.Drawing.Size(160, 24);
            this.BlackPlayerName.TabIndex = 2;
            this.BlackPlayerName.Text = "Server";
            this.BlackPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BlackPlayerName.Click += new System.EventHandler(this.BlackPlayerName_Click);
            // 
            // WhitePlayerImage
            // 
            this.WhitePlayerImage.BackColor = System.Drawing.Color.Transparent;
            this.WhitePlayerImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WhitePlayerImage.BackgroundImage")));
            this.WhitePlayerImage.Location = new System.Drawing.Point(22, 313);
            this.WhitePlayerImage.Name = "WhitePlayerImage";
            this.WhitePlayerImage.Size = new System.Drawing.Size(45, 50);
            this.WhitePlayerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WhitePlayerImage.TabIndex = 1;
            this.WhitePlayerImage.TabStop = false;
            // 
            // BlackPlayerImage
            // 
            this.BlackPlayerImage.BackColor = System.Drawing.Color.Transparent;
            this.BlackPlayerImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BlackPlayerImage.BackgroundImage")));
            this.BlackPlayerImage.Location = new System.Drawing.Point(22, 216);
            this.BlackPlayerImage.Name = "BlackPlayerImage";
            this.BlackPlayerImage.Size = new System.Drawing.Size(45, 50);
            this.BlackPlayerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BlackPlayerImage.TabIndex = 0;
            this.BlackPlayerImage.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(487, 505);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HalfChess";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WhitePlayerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackPlayerImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TurnTicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_load_game;
        private System.Windows.Forms.Button button_new_game;
        public System.Windows.Forms.Label WhitePlayerTime;
        public System.Windows.Forms.Label BlackPlayerTime;
        public System.Windows.Forms.Label WhitePlayerName;
        public System.Windows.Forms.Label BlackPlayerName;
        public System.Windows.Forms.PictureBox WhitePlayerImage;
        public System.Windows.Forms.PictureBox BlackPlayerImage;
        public System.Windows.Forms.Label WhitePlayerRemainTime;
        public System.Windows.Forms.Label BlackPlayerRemainTime;
        public System.Windows.Forms.Label label_player_id;
        public System.Windows.Forms.Label label_player_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_clear_drawing;
        private System.Windows.Forms.Button webSiteButton;
        private System.Windows.Forms.Label label5;
    }
}


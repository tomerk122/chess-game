namespace HalfChessClient
{
    partial class LoadGameWindow
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
            this.listView_games = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_load = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.comboBoxSortCriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.comboBoxWinnerFilter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listView_games
            // 
            this.listView_games.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.PlayerId});
            this.listView_games.FullRowSelect = true;
            this.listView_games.GridLines = true;
            this.listView_games.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_games.HideSelection = false;
            this.listView_games.Location = new System.Drawing.Point(13, 17);
            this.listView_games.Margin = new System.Windows.Forms.Padding(4);
            this.listView_games.Name = "listView_games";
            this.listView_games.Size = new System.Drawing.Size(860, 233);
            this.listView_games.TabIndex = 0;
            this.listView_games.UseCompatibleStateImageBehavior = false;
            this.listView_games.View = System.Windows.Forms.View.Details;
            this.listView_games.SelectedIndexChanged += new System.EventHandler(this.listView_games_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "GameID";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Player Name";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Start Time";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Think Time";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Finished";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Winner";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Reason";
            this.columnHeader7.Width = 80;
            // 
            // PlayerId
            // 
            this.PlayerId.Text = "Player ID";
            this.PlayerId.Width = 80;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(523, 258);
            this.button_load.Margin = new System.Windows.Forms.Padding(4);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(112, 32);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(643, 259);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(112, 32);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // comboBoxSortCriteria
            // 
            this.comboBoxSortCriteria.FormattingEnabled = true;
            this.comboBoxSortCriteria.Location = new System.Drawing.Point(127, 261);
            this.comboBoxSortCriteria.Name = "comboBoxSortCriteria";
            this.comboBoxSortCriteria.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSortCriteria.TabIndex = 3;
            this.comboBoxSortCriteria.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortCriteria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sort By:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(920, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // comboBoxWinnerFilter
            // 
            this.comboBoxWinnerFilter.FormattingEnabled = true;
            this.comboBoxWinnerFilter.Location = new System.Drawing.Point(127, 293);
            this.comboBoxWinnerFilter.Name = "comboBoxWinnerFilter";
            this.comboBoxWinnerFilter.Size = new System.Drawing.Size(121, 26);
            this.comboBoxWinnerFilter.TabIndex = 6;
            this.comboBoxWinnerFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxWinnerFilter_SelectedIndexChanged);
            // 
            // LoadGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 322);
            this.Controls.Add(this.comboBoxWinnerFilter);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSortCriteria);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.listView_games);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoadGameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadGameWindow";
            this.Load += new System.EventHandler(this.LoadGameWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_games;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader PlayerId;
        private System.Windows.Forms.ComboBox comboBoxSortCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ComboBox comboBoxWinnerFilter;
    }
}
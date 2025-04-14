namespace HalfChessClient
{
    partial class PromoWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromoWindow));
            this.pictureBox_rook = new System.Windows.Forms.PictureBox();
            this.pictureBox_knight = new System.Windows.Forms.PictureBox();
            this.pictureBox_bishop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_rook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_knight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bishop)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_rook
            // 
            this.pictureBox_rook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBox_rook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_rook.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_rook.Image")));
            this.pictureBox_rook.Location = new System.Drawing.Point(13, 13);
            this.pictureBox_rook.Name = "pictureBox_rook";
            this.pictureBox_rook.Size = new System.Drawing.Size(52, 50);
            this.pictureBox_rook.TabIndex = 0;
            this.pictureBox_rook.TabStop = false;
            this.pictureBox_rook.Click += new System.EventHandler(this.pictureBox_rook_Click);
            // 
            // pictureBox_knight
            // 
            this.pictureBox_knight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBox_knight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_knight.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_knight.Image")));
            this.pictureBox_knight.Location = new System.Drawing.Point(84, 13);
            this.pictureBox_knight.Name = "pictureBox_knight";
            this.pictureBox_knight.Size = new System.Drawing.Size(52, 50);
            this.pictureBox_knight.TabIndex = 0;
            this.pictureBox_knight.TabStop = false;
            this.pictureBox_knight.Click += new System.EventHandler(this.pictureBox_knight_Click);
            // 
            // pictureBox_bishop
            // 
            this.pictureBox_bishop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBox_bishop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_bishop.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_bishop.Image")));
            this.pictureBox_bishop.Location = new System.Drawing.Point(152, 13);
            this.pictureBox_bishop.Name = "pictureBox_bishop";
            this.pictureBox_bishop.Size = new System.Drawing.Size(52, 50);
            this.pictureBox_bishop.TabIndex = 0;
            this.pictureBox_bishop.TabStop = false;
            this.pictureBox_bishop.Click += new System.EventHandler(this.pictureBox_bishop_Click);
            // 
            // PromoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 75);
            this.Controls.Add(this.pictureBox_bishop);
            this.Controls.Add(this.pictureBox_knight);
            this.Controls.Add(this.pictureBox_rook);
            this.Name = "PromoWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PromoWindow";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_rook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_knight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bishop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_rook;
        private System.Windows.Forms.PictureBox pictureBox_knight;
        private System.Windows.Forms.PictureBox pictureBox_bishop;
    }
}
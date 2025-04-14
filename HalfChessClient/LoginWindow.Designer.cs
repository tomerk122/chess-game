namespace HalfChessClient
{
    partial class LoginWindow
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
            this.label_player_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_player_name
            // 
            this.label_player_name.AutoSize = true;
            this.label_player_name.Location = new System.Drawing.Point(71, 36);
            this.label_player_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_player_name.Name = "label_player_name";
            this.label_player_name.Size = new System.Drawing.Size(98, 20);
            this.label_player_name.TabIndex = 0;
            this.label_player_name.Text = "Player Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player ID";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(199, 33);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(156, 26);
            this.textBox_name.TabIndex = 2;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(199, 75);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(156, 26);
            this.textBox_ID.TabIndex = 3;
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(34, 122);
            this.button_login.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(112, 35);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(163, 122);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(112, 35);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // SignIn
            // 
            this.SignIn.Location = new System.Drawing.Point(292, 122);
            this.SignIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(112, 35);
            this.SignIn.TabIndex = 6;
            this.SignIn.Text = "Sign In";
            this.SignIn.UseVisualStyleBackColor = true;
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 185);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_player_name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_player_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button SignIn;
    }
}
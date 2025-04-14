using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalfChessClient
{
    public partial class LoginWindow : Form
    {
        public bool Success;
        public string PlayerName;
        public int PlayerId;

        public LoginWindow()
        {
            InitializeComponent();
            this.AcceptButton = button_login;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            PlayerName = textBox_name.Text;
            try
            {
                PlayerId = Int32.Parse(textBox_ID.Text);
            }
            catch 
            {
                PlayerId = 0;
            }

            Success = true;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Success = false;
            this.Close();
        }

        

        private void SignIn_Click(object sender, EventArgs e)
        {
            // create User
            System.Diagnostics.Process.Start("http://localhost:5284/Players/Create");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUBHUB_PROJECT
{
    public partial class RegisterForm : Form
    {
        LoginForm loginform = null;
        public RegisterForm(LoginForm lf)
        {
            InitializeComponent();
            loginform = lf;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            RegisterLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            RegisterLabel.ForeColor = System.Drawing.Color.MidnightBlue;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loginform.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (FullNameTextBox.Text.Length <= 0 || FullNameTextBox.Text == "Full name")
                MessageBox.Show("Enter Your Full Name.");
            if (AddressTextBox.Text.Length <= 0 || AddressTextBox.Text == "Address")
                MessageBox.Show("Enter your Address.");
            if (EmailTextBox.Text.Length <= 0 || EmailTextBox.Text == "Email")
                MessageBox.Show("Enter your Email.");
            if (PasswordTextBox.Text.Length <= 0 || PasswordTextBox.Text == "Password")
                MessageBox.Show("Enter your Password.");
        }
    }
}

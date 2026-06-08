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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.CornflowerBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.MidnightBlue;
        }

        private void RegisterLabel_MouseHover(object sender, EventArgs e)
        {
            RegisterLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
        }

        private void RegisterLabel_MouseLeave(object sender, EventArgs e)
        {
            RegisterLabel.ForeColor = System.Drawing.Color.MidnightBlue;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text.Length > 0 && PasswordTextBox.Text.Length > 0)
            {
                MessageBox.Show("Bole");
                MainMenu form = new MainMenu(this);
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tkle");
            }
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm(this);
            form.Show();
            this.Hide();
        }
    }
}

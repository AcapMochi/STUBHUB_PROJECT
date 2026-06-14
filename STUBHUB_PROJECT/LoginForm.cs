using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUBHUB_PROJECT
{
    public partial class LoginForm : Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            labelAdmin.ForeColor = System.Drawing.Color.CornflowerBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            labelAdmin.ForeColor = System.Drawing.Color.MidnightBlue;
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
            if (TextBoxUsername.Text.Length > 0 && TextBoxPassword.Text.Length > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Username, Password FROM [User] WHERE Username=@Username AND Password=@Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", TextBoxUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", TextBoxPassword.Text);

                        conn.Open();
                        var result = cmd.ExecuteReader();
                        if (result.HasRows)
                        {
                            MessageBox.Show("Valid Login, Welcome back!");
                            MainMenu form = new MainMenu(this);
                            this.Hide();
                            form.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login, try again.");
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter your Username and Password!");
            }
        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm(this);
            form.Show();
            this.Hide();
        }

        private void labelAdmin_Click(object sender, EventArgs e)
        {
            AdminLoginForm form = new AdminLoginForm(this);
            this.Hide();
            form.ShowDialog();
        }
    }
}

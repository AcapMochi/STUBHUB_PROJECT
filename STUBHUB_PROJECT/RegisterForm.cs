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
    public partial class RegisterForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
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
            if (TextBoxUsername.Text.Length <= 0 || TextBoxUsername.Text == "Username")
                MessageBox.Show("Enter Your Username.");
            if (TextBoxFullName.Text.Length <= 0 || TextBoxFullName.Text == "Full Name")
                MessageBox.Show("Enter your Full Name.");
            if (TextBoxEmail.Text.Length <= 0 || TextBoxEmail.Text == "Email")
                MessageBox.Show("Enter your Email.");
            if (TextBoxPassword.Text.Length <= 0 || TextBoxPassword.Text == "Password")
                MessageBox.Show("Enter your Password.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [User] (Username, Password, Email, FullName, Role, CreatedAt) VALUES (@Username, @Password, @Email, @FullName, @Role, @CreatedAt)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", TextBoxUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", TextBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@FullName", TextBoxFullName.Text);
                    cmd.Parameters.AddWithValue("@Role", "User");

                    DateTime dt = DateTime.Now;
                    cmd.Parameters.AddWithValue("@CreatedAt", dt);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registered Successfully!");
                        }
                        else
                        {
                            MessageBox.Show("The query ran, but 0 rows were inserted.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL Error: " + ex.Message);
                    }
                    this.Close();
                    loginform.Show();
                }
            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                Application.Exit();
        }
    }
}

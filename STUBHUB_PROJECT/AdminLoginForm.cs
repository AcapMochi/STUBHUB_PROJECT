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
    public partial class AdminLoginForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        LoginForm form = null;
        public AdminLoginForm(LoginForm alf)
        {
            InitializeComponent();
            form = alf;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            int userID = ValidateCredentials(username, password);

            if (userID != 0)
            {
                MessageBox.Show("Valid Login, Welcome back!");
                FormAdminDashboard form = new FormAdminDashboard(userID, this);
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Login, try again.");
            }
        }
        private int ValidateCredentials(string username, string password)
        {
            string query = "SELECT UserID FROM [dbo].[User] WHERE Username = @Username AND Password = @Password AND Role = 'Admin'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }

                        conn.Close();
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database authentication error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }

        private void LabelRegister_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Close();
        }

        private void AdminLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
             Application.Exit();
        }
    }
}

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
using static STUBHUB_PROJECT.EventForm;

namespace STUBHUB_PROJECT
{
    public partial class AdminProfileForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        int userID;
        public AdminProfileForm(int id)
        {
            InitializeComponent();
            userID = id;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadProfile()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Username, Email FROM [User] WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            string email = reader["Email"].ToString();
                            textBoxUsername.Text = username;
                            textBoxEmail.Text = email;
                        }
                        else
                        {
                            MessageBox.Show("No user exists with that ID.");
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Username, Email, Password cannot be empty.");
                return;
            }

            string query = "UPDATE [User] SET Username = @Username, Email = @Email, Password = @Password WHERE UserID = @UserID AND Role = 'Admin'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Username", textBoxUsername.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Profile updated successfully!");

                    LoadProfile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating profile: " + ex.Message);
                }
            }
        }

        private void AdminProfileForm_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }
    }
}

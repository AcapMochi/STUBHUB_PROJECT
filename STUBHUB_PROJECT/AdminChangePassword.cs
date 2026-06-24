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
    public partial class AdminChangePassword : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        int userID;
        AdminProfileForm profileForm;
        public AdminChangePassword(int userID, AdminProfileForm form)
        {
            InitializeComponent();
            this.userID = userID;
            profileForm = form;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCurrentPassword.Text))
            {
                MessageBox.Show("Please enter your Current Password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                MessageBox.Show("Please enter your New Password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string verifyQuery = "SELECT Password FROM [User] WHERE UserID = @UserID";

                    using (SqlCommand verifyCmd = new SqlCommand(verifyQuery, conn))
                    {
                        verifyCmd.Parameters.AddWithValue("@UserID", userID);
                        object result = verifyCmd.ExecuteScalar();

                        if (result != null)
                        {
                            string dbCurrentPassword = result.ToString();

                            if (dbCurrentPassword == textBoxCurrentPassword.Text)
                            {
                                string updateQuery = "UPDATE [User] SET Password = @NewPassword WHERE UserID = @UserID";

                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@NewPassword", textBoxNewPassword.Text);
                                    updateCmd.Parameters.AddWithValue("@UserID", userID);

                                    int rowsAffected = updateCmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                        profileForm.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("The current password you entered is incorrect.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User record not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A database error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            profileForm.Show();
        }

        private void AdminChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}

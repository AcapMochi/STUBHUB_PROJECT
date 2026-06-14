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
using System.Xml.Linq;

namespace STUBHUB_PROJECT
{
    public partial class AdminUserAccountsForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        int currentUser = 0;
        public AdminUserAccountsForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dgvUsers.DataSource is DataTable dt)
            {
                string filterText = txtFilterRole.Text.Trim();

                dt.DefaultView.RowFilter = string.Format("Role LIKE '{0}%'", filterText);
            }
        }

        private void AdminUserAccountsForm_Load(object sender, EventArgs e)
        {
            LoadUserAccounts();
        }
        private void LoadUserAccounts()
        {

            string query = "SELECT UserID, Username, Email, Role FROM [User]";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvUsers.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(labelName.Text))
            {
                MessageBox.Show("Please select a user from the list first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"UPDATE [User] SET Username = @Username, Email = @Email, Role = @Role WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DataGridViewRow row = dgvUsers.Rows[currentUser];

                        cmd.Parameters.AddWithValue("@Username", row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Email", row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@Role", comboBoxRole.Text);
                        cmd.Parameters.AddWithValue("@UserID", row.Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("User account updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserAccounts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelName.Text))
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM [User] WHERE UserID = @UserID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            DataGridViewRow row = dgvUsers.Rows[currentUser];

                            cmd.Parameters.AddWithValue("@UserID", row.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("User account deleted.");
                            LoadUserAccounts();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting user: " + ex.Message);
                    }
                }
            }
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            if (dgvUsers.DataSource is DataTable dt)
            {
                string filterText = txtSearchUser.Text.Trim();

                dt.DefaultView.RowFilter = string.Format("Username LIKE '%{0}%' OR Email LIKE '%{0}%'", filterText);
            }
        }
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentUser = e.RowIndex;
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    labelName.Text = "Name: " + row.Cells[1].Value.ToString();
                    labelEmail.Text = "Email: " + row.Cells[2].Value.ToString();
                }

                if (row.Cells[3].Value != null)
                    comboBoxRole.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}

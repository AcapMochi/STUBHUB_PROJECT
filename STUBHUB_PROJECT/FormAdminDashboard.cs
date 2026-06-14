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
    public partial class FormAdminDashboard : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        int userID;

        AdminLoginForm loginForm = null;
        public FormAdminDashboard(int id, AdminLoginForm loginForm)
        {
            InitializeComponent();
            userID = id;
            this.loginForm = loginForm;
        }

        private void FormAdminDashboard_Load(object sender, EventArgs e)
        {
            LoadEventsOverview();
        }
        public void LoadEventsOverview()
        {
            string query = @"
                SELECT 
                    se.SubEventID AS [ID],
                    e.Title AS [Event Title],
                    v.VenueName AS [Venue Location],
                    se.EventDateTime AS [Date & Time],
                    se.Status AS [Status]
                FROM [dbo].[SubEvents] se
                INNER JOIN [dbo].[Events] e ON se.EventID = e.EventID
                INNER JOIN [dbo].[Venues] v ON se.VenueID = v.VenueID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvEventsOverview.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CancelEventInDatabase(string subEventId)
        {
            string query = "UPDATE [dbo].[SubEvents] SET [Status] = 'Cancelled' WHERE [SubEventID] = @SubEventID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubEventID", subEventId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Event status has been set to Cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEventsOverview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating event status: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvEventsOverview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvEventsOverview.Rows[e.RowIndex].Selected = true;
            }
        }

        private void buttonAdminProfile_Click(object sender, EventArgs e)
        {
            AdminProfileForm form = new AdminProfileForm(userID);
            form.ShowDialog();
        }

        private void buttonUserAccounts_Click(object sender, EventArgs e)
        {
            AdminUserAccountsForm form = new AdminUserAccountsForm();
            form.ShowDialog();
        }

        private void buttonTandB_Click(object sender, EventArgs e)
        {
            AdminTransactionsForm form = new AdminTransactionsForm();
            form.ShowDialog();
        }

        private void buttonSandP_Click(object sender, EventArgs e)
        {
            AdminSeatingForm form = new AdminSeatingForm();
            form.ShowDialog();
        }

        private void buttonManageEvents_Click(object sender, EventArgs e)
        {
            AdminManageEvents form = new AdminManageEvents();
            form.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dgvEventsOverview.CurrentRow != null)
            {
                string selectedSubEventID = dgvEventsOverview.CurrentRow.Cells["ID"].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Are you sure you want to cancel Sub-Event ID {selectedSubEventID}?",
                                                       "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    CancelEventInDatabase(selectedSubEventID);
                }
            }
            else
            {
                MessageBox.Show("Please select an event row from the dashboard list to cancel.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dgvEventsOverview.CurrentRow != null)
            {
                string selectedSubEventID = dgvEventsOverview.CurrentRow.Cells["ID"].Value.ToString();

                MessageBox.Show($"Opening Edit System for Sub-Event ID: {selectedSubEventID}", "Edit Event");
            }
            else
            {
                MessageBox.Show("Please select an event row from the dashboard list first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                Application.Exit();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }
    }
}

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
using System.Windows.Forms.VisualStyles;

namespace STUBHUB_PROJECT
{
    public partial class AdminManageTickets : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        public AdminManageTickets()
        {
            InitializeComponent();
        }
        private void LoadComboBoxEventID()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT EventID, Title FROM Events";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);

                        // Assign DataSource LAST
                        comboBoxEventID.DisplayMember = "Title";
                        comboBoxEventID.ValueMember = "EventID";
                        comboBoxEventID.DataSource = dt;
                    }
                }
            }
        }

        private void LoadComboBoxSubEventID()
        {
            if (comboBoxEventID.SelectedValue == null || comboBoxEventID.SelectedValue is DataRowView)
            {
                comboBoxSubEventID.DataSource = null;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SubEventID, SubEventTitle FROM SubEvents WHERE EventID = @EventID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventID", Convert.ToInt32(comboBoxEventID.SelectedValue));

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);

                        comboBoxSubEventID.DisplayMember = "SubEventTitle";
                        comboBoxSubEventID.ValueMember = "SubEventID";
                        comboBoxSubEventID.DataSource = dt;
                    }
                }
            }
        }
        private void LoadTickets()
        {
            if (comboBoxEventID.SelectedValue == null || comboBoxEventID.SelectedValue is DataRowView ||
                comboBoxSubEventID.SelectedValue == null || comboBoxSubEventID.SelectedValue is DataRowView)
            {
                dataGridViewTicketsOverview.DataSource = null;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                t.* FROM TicketTiers t
            INNER JOIN SubEvents s ON t.SubEventID = s.SubEventID
            WHERE s.EventID = @EventID AND s.SubEventID = @SubEventID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventID", Convert.ToInt32(comboBoxEventID.SelectedValue));
                    cmd.Parameters.AddWithValue("@SubEventID", Convert.ToInt32(comboBoxSubEventID.SelectedValue));

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);
                        dataGridViewTicketsOverview.DataSource = dt;
                    }
                }
            }
        }
        private void AdminManageTickets_Load(object sender, EventArgs e)
        {
            LoadComboBoxEventID();
            LoadComboBoxSubEventID();
            LoadTickets();
        }

        private void dataGridViewTicketsOverview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonUploadTicket_Click(object sender, EventArgs e)
        {
            if (comboBoxSubEventID.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a venue from the dropdown.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTierName.Text))
            {
                MessageBox.Show("Please enter a Tier Name for the sub-event.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                MessageBox.Show("Please enter a Price for the ticket.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTotalSeats.Text))
            {
                MessageBox.Show("Please enter a Total Seats for the ticket.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TicketTiers (SubEventID, TierName, Price, TotalSeats, SeatsSold) VALUES (@SubEventID, @TierName, @Price, @TotalSeats, @SeatsSold)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubEventID", Convert.ToInt32(comboBoxSubEventID.SelectedValue));
                    cmd.Parameters.AddWithValue("@TierName", textBoxTierName.Text);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(textBoxPrice.Text));
                    cmd.Parameters.AddWithValue("@TotalSeats", int.Parse(textBoxTotalSeats.Text));
                    cmd.Parameters.AddWithValue("@SeatsSold", 0);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket added successfully!");

                    textBoxTierName.Clear();
                    textBoxPrice.Clear();
                    textBoxTotalSeats.Clear();
                    LoadTickets();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxEventID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEventID.SelectedIndex == -1 || comboBoxEventID.SelectedValue is DataRowView)
                return;

            LoadComboBoxSubEventID();
        }

        private void comboBoxSubEventID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubEventID.SelectedIndex == -1 || comboBoxSubEventID.SelectedValue is DataRowView)
            {
                dataGridViewTicketsOverview.DataSource = null;
                return;
            }
            LoadTickets();
        }

        private void buttonDeleteTicket_Click(object sender, EventArgs e)
        {
            if (dataGridViewTicketsOverview.CurrentRow == null)
            {
                MessageBox.Show("Please select a ticket tier to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this ticket tier? This action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                int tierId = Convert.ToInt32(dataGridViewTicketsOverview.CurrentRow.Cells["TierID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        string query = "DELETE FROM TicketTiers WHERE TierID = @TierID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TierID", tierId);

                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Ticket tier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadTickets();
                            }
                            else
                            {
                                MessageBox.Show("No record was deleted. The ticket might have already been removed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("A database error occurred. It's possible this ticket cannot be deleted because it is tied to existing sales.\n\nError details: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
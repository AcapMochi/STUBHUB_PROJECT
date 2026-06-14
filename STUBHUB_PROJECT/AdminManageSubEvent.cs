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
    public partial class AdminManageSubEvent : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        int eventID;
        int selectedSubEventID = -1;
        public AdminManageSubEvent(int eventID)
        {
            InitializeComponent();
            this.eventID = eventID;
        }

        private void LoadComboBoxVenue()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT VenueID, VenueName FROM Venues";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);

                        comboBoxVenue.DataSource = dt;
                        comboBoxVenue.DisplayMember = "VenueName";
                        comboBoxVenue.ValueMember = "VenueID";
                    }
                }
            }
        }

        private void LoadSubEvent()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM SubEvents WHERE EventID = @EventID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventID", eventID);
                    conn.Open();

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);

                        dataGridViewSubEvents.DataSource = dt;
                    }
                }
            }
        }

        private void AdminManageSubEvent_Load(object sender, EventArgs e)
        {
            LoadSubEvent();
            LoadComboBoxVenue();
        }

        private void buttonUploadSubEvent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSubEventTitle.Text))
            {
                MessageBox.Show("Please enter a title for the sub-event.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            if (comboBoxVenue.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a venue from the dropdown.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an event status.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePickerVenue.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("The event date cannot be in the past. Please select a valid future date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = textBoxSubEventTitle.Text;
            int venueID = Convert.ToInt32(comboBoxVenue.SelectedValue);
            string status = comboBoxStatus.SelectedItem.ToString();
            DateTime eventDate = dateTimePickerVenue.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query;

                if (selectedSubEventID == -1)
                {
                    query = "INSERT INTO SubEvents (EventID, VenueID, SubEventTitle, EventDateTime, Status) VALUES (@EventID, @VenueID, @SubEventTitle, @EventDateTime, @Status)";
                }
                else
                {
                    query = "UPDATE SubEvents SET VenueID = @VenueID, SubEventTitle = @SubEventTitle, EventDateTime = @EventDateTime, Status = @Status WHERE SubEventID = @SubEventID";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VenueID", venueID);
                    cmd.Parameters.AddWithValue("@SubEventTitle", title);
                    cmd.Parameters.AddWithValue("@EventDateTime", eventDate);
                    cmd.Parameters.AddWithValue("@Status", status);

                    if (selectedSubEventID == -1)
                    {
                        cmd.Parameters.AddWithValue("@EventID", eventID);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SubEventID", selectedSubEventID);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            if (selectedSubEventID == -1)
                MessageBox.Show("Sub-event uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Sub-event updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadSubEvent(); 
            selectedSubEventID = -1;
            textBoxSubEventTitle.Text = "";
            comboBoxVenue.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            dateTimePickerVenue.Value = DateTime.Now;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewSubEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSubEvents.Rows[e.RowIndex];

                selectedSubEventID = Convert.ToInt32(row.Cells["SubEventID"].Value);
                textBoxSubEventTitle.Text = row.Cells["SubEventTitle"].Value.ToString();

                comboBoxVenue.SelectedValue = row.Cells["VenueID"].Value;
                comboBoxStatus.SelectedItem = row.Cells["Status"].Value.ToString();
                dateTimePickerVenue.Value = Convert.ToDateTime(row.Cells["EventDateTime"].Value);
            }
        }
    }
}

using System.IO;
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
        byte[] existingImageBytes = null;

        private string selectedImage;
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

            byte[] finalImageBytes;

            if (!string.IsNullOrEmpty(selectedImage))
            {
                finalImageBytes = File.ReadAllBytes(selectedImage);
            }
            else
            {
                finalImageBytes = existingImageBytes;
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
                    query = "INSERT INTO SubEvents (EventID, VenueID, SubEventTitle, EventDateTime, ImageData, Status) VALUES (@EventID, @VenueID, @SubEventTitle, @EventDateTime, @ImageData, @Status)";
                }
                else
                {
                    query = "UPDATE SubEvents SET VenueID = @VenueID, SubEventTitle = @SubEventTitle, EventDateTime = @EventDateTime, ImageData = @ImageData, Status = @Status WHERE SubEventID = @SubEventID";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VenueID", venueID);
                    cmd.Parameters.AddWithValue("@SubEventTitle", title);
                    cmd.Parameters.AddWithValue("@EventDateTime", eventDate);
                    cmd.Parameters.AddWithValue("@ImageData", finalImageBytes);
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

                object imageDataObj = row.Cells["ImageData"].Value;

                if (imageDataObj != DBNull.Value && imageDataObj != null && imageDataObj is byte[])
                {
                    existingImageBytes = (byte[])imageDataObj;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(existingImageBytes);
                    pictureBoxImage.Image = Image.FromStream(ms);
                    pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pictureBoxImage.Image = null;
                    existingImageBytes = null;
                }
            }
        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

                selectedImage = openFileDialog1.FileName;
            }
        }

        private void buttonDeleteSubEvent_Click(object sender, EventArgs e)
        {
            if (selectedSubEventID == -1)
            {
                MessageBox.Show("Please select a sub-event from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this sub-event? This action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        string query = "DELETE FROM SubEvents WHERE SubEventID = @SubEventID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@SubEventID", selectedSubEventID);

                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Sub-event deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                selectedSubEventID = -1;
                                textBoxSubEventTitle.Text = "";
                                comboBoxVenue.SelectedIndex = -1;
                                comboBoxStatus.SelectedIndex = -1;
                                dateTimePickerVenue.Value = DateTime.Now;
                                pictureBoxImage.Image = null;
                                existingImageBytes = null;
                                selectedImage = null;

                                LoadSubEvent();
                            }
                            else
                            {
                                MessageBox.Show("No sub-event was deleted. It might have already been removed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("A database error occurred. It's likely this sub-event cannot be deleted because it has ticket tiers or orders linked to it.\n\nError details: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

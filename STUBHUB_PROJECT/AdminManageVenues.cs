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
    public partial class AdminManageVenues : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        byte[] existingImageBytes = null;
        private string selectedImage;
        private int selectedVenueId = -1;

        private Dictionary<string, List<string>> countryStates = new Dictionary<string, List<string>>()
        {
            { "Malaysia", new List<string> { "Malacca", "Kuala Lumpur", "Penang", "Johor" } },
            { "United States", new List<string> { "California", "New York", "Texas", "Florida" } },
            { "Canada", new List<string> { "Ontario", "British Columbia", "Quebec", "Alberta" } },
            { "United Kingdom", new List<string> { "England", "Scotland", "Wales", "Northern Ireland" } },
            { "Japan", new List<string> { "Osaka", "Yokohama", "Tokyo", "Kyoto"} }

        };

        public AdminManageVenues()
        {
            InitializeComponent();
        }

        private void AdminManageVenues_Load(object sender, EventArgs e)
        {
            LoadVenue();
            comboBoxCountry.Items.Clear();
            comboBoxCountry.Items.AddRange(countryStates.Keys.ToArray());

            comboBoxState.Enabled = false;
        }

        private void LoadVenue()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Venues";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            dataAdapter.Fill(dt);
                            dataGridViewVenues.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading venues: " + ex.Message);
                    }
                }
            }
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxState.Items.Clear();
            comboBoxState.Text = ""; 

            if (comboBoxCountry.SelectedItem != null)
            {
                string selectedCountry = comboBoxCountry.SelectedItem.ToString();

                if (countryStates.ContainsKey(selectedCountry))
                {
                    comboBoxState.Items.AddRange(countryStates[selectedCountry].ToArray());
                    comboBoxState.Enabled = true; 
                }
            }
            else
            {
                comboBoxState.Enabled = false;
            }
        }
        private void buttonUploadVenue_Click(object sender, EventArgs e)
        {
            if (comboBoxCountry.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Country from the dropdown.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxState.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a State from the dropdown.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxVenueName.Text) ||
                string.IsNullOrWhiteSpace(textBoxVenueType.Text) ||
                string.IsNullOrWhiteSpace(textBoxCapacity.Text))
            {
                MessageBox.Show("Please fill out all text fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] finalImageBytes = null;
            if (!string.IsNullOrEmpty(selectedImage))
            {
                finalImageBytes = File.ReadAllBytes(selectedImage);
            }
            else if (selectedVenueId != -1 && existingImageBytes != null)
            {
                finalImageBytes = existingImageBytes;
            }
            else
            {
                MessageBox.Show("Please upload an image.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query;

                if (selectedVenueId == -1)
                {
                    query = "INSERT INTO Venues (VenueName, VenueType, State, Country, Capacity, ImageData) VALUES (@VenueName, @VenueType, @State, @Country, @Capacity, @ImageData)";
                }
                else
                {
                    query = "UPDATE Venues SET VenueName = @VenueName, VenueType = @VenueType, State = @State, Country = @Country, Capacity = @Capacity, ImageData = @ImageData WHERE VenueID = @VenueID";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VenueName", textBoxVenueName.Text);
                    cmd.Parameters.AddWithValue("@VenueType", textBoxVenueType.Text);
                    cmd.Parameters.AddWithValue("@State", comboBoxState.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Country", comboBoxCountry.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Capacity", int.Parse(textBoxCapacity.Text)); 

                    if (finalImageBytes != null)
                        cmd.Parameters.AddWithValue("@ImageData", finalImageBytes);
                    else
                        cmd.Parameters.AddWithValue("@ImageData", DBNull.Value);

                    if (selectedVenueId != -1)
                    {
                        cmd.Parameters.AddWithValue("@VenueID", selectedVenueId);
                    }

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        if (selectedVenueId == -1)
                            MessageBox.Show("Venue added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Venue updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        selectedVenueId = -1;
                        textBoxVenueName.Clear();
                        textBoxVenueType.Clear();
                        textBoxCapacity.Clear();
                        comboBoxCountry.SelectedIndex = -1;
                        comboBoxState.SelectedIndex = -1;
                        pictureBoxImage.Image = null;
                        selectedImage = null;
                        existingImageBytes = null;

                        LoadVenue();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving venue: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void dataGridViewVenues_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewVenues.Rows[e.RowIndex];
                selectedVenueId = Convert.ToInt32(row.Cells["VenueID"].Value);

                textBoxVenueName.Text = row.Cells["VenueName"].Value.ToString();
                textBoxVenueType.Text = row.Cells["VenueType"].Value.ToString();
                textBoxCapacity.Text = row.Cells["Capacity"].Value.ToString();

                comboBoxCountry.SelectedItem = row.Cells["Country"].Value.ToString();
                comboBoxState.SelectedItem = row.Cells["State"].Value.ToString();

                if (row.Cells["ImageData"].Value != DBNull.Value)
                {
                    existingImageBytes = (byte[])row.Cells["ImageData"].Value;
                    using (MemoryStream ms = new MemoryStream(existingImageBytes))
                    {
                        pictureBoxImage.Image = Image.FromStream(ms);
                        pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    pictureBoxImage.Image = null;
                    existingImageBytes = null;
                }
            }
        }

        // 5. Implement Delete functionality
        private void buttonDeleteVenue_Click(object sender, EventArgs e)
        {
            if (selectedVenueId == -1)
            {
                MessageBox.Show("Please select a venue from the list to delete.", "Select Venue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this venue?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Venues WHERE VenueID = @VenueID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VenueID", selectedVenueId);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Venue deleted successfully.");

                            selectedVenueId = -1;
                            textBoxVenueName.Clear();
                            textBoxVenueType.Clear();
                            textBoxCapacity.Clear();
                            comboBoxCountry.SelectedIndex = -1;
                            pictureBoxImage.Image = null;

                            LoadVenue();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting venue: " + ex.Message);
                        }
                    }
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
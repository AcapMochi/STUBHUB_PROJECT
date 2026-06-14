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
    public partial class AdminAddEvent : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        AdminManageEvents form;

        string constraintMode;
        int currentEventID;
        string selectedImage = "";
        byte[] existingImageBytes = null;
        public AdminAddEvent(AdminManageEvents form, string constraint, int eventID = -1)
        {
            InitializeComponent();
            this.form = form;
            this.constraintMode = constraint;
            this.currentEventID = eventID;

            if (constraintMode == "Update" && currentEventID != -1)
            {
                LoadEventData();
                buttonUploadEvent.Text = "Update Event"; 
            }
        }
        private void LoadEventData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Title, Category, Description, ImageData FROM Events WHERE EventID = @EventID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventID", currentEventID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxTitle.Text = reader["Title"].ToString();
                            textBoxCategory.Text = reader["Category"].ToString();
                            textBoxDescription.Text = reader["Description"].ToString();

                            // Safely load the image if it exists
                            if (reader["ImageData"] != DBNull.Value)
                            {
                                existingImageBytes = (byte[])reader["ImageData"];
                                System.IO.MemoryStream ms = new System.IO.MemoryStream(existingImageBytes);
                                pictureBoxImage.Image = Image.FromStream(ms);
                                pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                    }
                }
            }
        }

        private void AdminAddEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void buttonUploadEvent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                string.IsNullOrWhiteSpace(textBoxCategory.Text) ||
                string.IsNullOrWhiteSpace(textBoxDescription.Text))
            {
                MessageBox.Show("Please fill in the title, category, and description before uploading.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pictureBoxImage.Image == null)
            {
                MessageBox.Show("Please select an image before uploading.", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query;

                if (constraintMode == "Add")
                {
                    query = "INSERT INTO Events (Title, Category, Description, ImageData) VALUES (@Title, @Category, @Description, @ImageData)";
                }
                else
                {
                    query = "UPDATE Events SET Title = @Title, Category = @Category, Description = @Description, ImageData = @ImageData WHERE EventID = @EventID";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 120;

                    cmd.Parameters.AddWithValue("@Title", textBoxTitle.Text);
                    cmd.Parameters.AddWithValue("@Category", textBoxCategory.Text);
                    cmd.Parameters.AddWithValue("@Description", textBoxDescription.Text);
                    cmd.Parameters.AddWithValue("@ImageData", finalImageBytes);

                    if (constraintMode == "Update")
                    {
                        cmd.Parameters.AddWithValue("@EventID", currentEventID);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            string successMessage = constraintMode == "Add" ? "Upload successful!" : "Update successful!";
            MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
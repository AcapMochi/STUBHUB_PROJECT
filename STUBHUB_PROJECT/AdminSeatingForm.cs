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
    public partial class AdminSeatingForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        public AdminSeatingForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedCategory = comboBox1.SelectedItem.ToString();

                LoadDataGridByCategory(selectedCategory);
            }
        }
        private void LoadDataGridByCategory(string categoryName)
        {

            string query = @"
                SELECT 
                    se.SubEventID AS [ID],
                    e.Title AS [Event Name],
                    e.Category AS [Category],
                    se.EventDateTime AS [Date & Time],
                    se.Status AS [Status]
                FROM [dbo].[SubEvents] se
                INNER JOIN [dbo].[Events] e ON se.EventID = e.EventID
                WHERE e.Category = @CategoryName AND se.Status = 'Scheduled'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
              
                        adapter.SelectCommand.Parameters.AddWithValue("@CategoryName", categoryName);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvTicketTiers.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading filtered seating view: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxData()
        {

            string query = @"
        SELECT 
            se.SubEventID, 
            e.Title + ' - (' + FORMAT(se.EventDateTime, 'dd MMM yyyy') + ')' AS EventDisplay
        FROM [dbo].[SubEvents] se
        INNER JOIN [dbo].[Events] e ON se.EventID = e.EventID
        WHERE se.Status = 'Scheduled'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        comboBox1.DataSource = dt;             
                        comboBox1.DisplayMember = "EventDisplay"; 
                        comboBox1.ValueMember = "SubEventID";     
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading dropdown data: " + ex.Message, "Database Error");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedCategory = comboBox1.SelectedItem.ToString();

                LoadDataGridByCategory(selectedCategory);

                MessageBox.Show("Data successfully refreshed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a category first before refreshing.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dgvTicketTiers.Rows.Count == 0)
            {
                MessageBox.Show("There is no data available to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string updateQuery = @"
        UPDATE [dbo].[SubEvents]
        SET [Status] = @Status,
            [EventDateTime] = @DateTime
        WHERE [SubEventID] = @SubEventID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    int rowsUpdated = 0;

                    foreach (DataGridViewRow row in dgvTicketTiers.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.Cells["ID"].Value == null ||
                            row.Cells["Status"].Value == null ||
                            row.Cells["Date & Time"].Value == null)
                        {
                            continue; 
                        }

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@SubEventID", Convert.ToInt32(row.Cells["ID"].Value));
                            cmd.Parameters.AddWithValue("@Status", row.Cells["Status"].Value.ToString());
                            cmd.Parameters.AddWithValue("@DateTime", Convert.ToDateTime(row.Cells["Date & Time"].Value));

                            rowsUpdated += cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"{rowsUpdated} configuration row(s) updated successfully!", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (comboBox1.SelectedItem != null)
                    {
                        LoadDataGridByCategory(comboBox1.SelectedItem.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving changes:\n\n" + ex.Message, "Database Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminSeatingForm_Load(object sender, EventArgs e)
        {
            //LoadComboBoxData();
        }
    }
}
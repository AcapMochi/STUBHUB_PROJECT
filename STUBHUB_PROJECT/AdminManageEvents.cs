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
    public partial class AdminManageEvents : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        public AdminManageEvents()
        {
            InitializeComponent();
        }

        private void LoadEvents()
        {
            string query = "SELECT * FROM Events";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);

                        dataGridViewEvents.DataSource = dt;
                    }
                }
            }
        }

        private void AdminManageEvents_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            AdminAddEvent form = new AdminAddEvent(this, "Add");
            this.Hide();
            form.ShowDialog();
        }

        private void AdminManageEvents_Activated(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private void buttonEditEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                int eventID = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["EventID"].Value);

                AdminAddEvent form = new AdminAddEvent(this, "Update", eventID);
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a transaction row from the grid first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                int eventID = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["EventID"].Value);

            }
            else
            {
                MessageBox.Show("Please select a transaction row from the grid first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonManageSubEvents_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                int eventID = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["EventID"].Value);

                AdminManageSubEvent form = new AdminManageSubEvent(eventID);
                form.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a transaction row from the grid first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonManageTickets_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dataGridViewEvents.SelectedRows[0].Cells["EventID"].Value);

            }
            else
            {
                MessageBox.Show("Please select a transaction row from the grid first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

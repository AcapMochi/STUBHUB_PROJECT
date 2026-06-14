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
    public partial class MainMenu : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";

        private void LoadEvents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Title FROM Events";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                comboBoxEvents.DataSource = dt;
                comboBoxEvents.DisplayMember = "Title";
            }
        }

        public MainMenu(LoginForm lf)
        {
            InitializeComponent();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private void ChooseEventButton_Click(object sender, EventArgs e)
        {
            comboBoxEvents.Visible = !comboBoxEvents.Visible;
        }

        private void DateButton_Click(object sender, EventArgs e)
        {
            dateTimePickerTicket.Visible = !dateTimePickerTicket.Visible;
        }

        private void FindTicketButton_Click(object sender, EventArgs e)
        {
            if (comboBoxEvents.Text == null)
            {
                MessageBox.Show("Select an Event.");
                return;
            }

            string index = null;
            string title = comboBoxEvents.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT EventID FROM Events WHERE Title = @Title";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        index = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("SQL Error: Database Redundancy");
                    }
                    conn.Close();
                }
            }

            EventForm form = new EventForm(this, index, title);
            this.Hide();
            form.ShowDialog();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

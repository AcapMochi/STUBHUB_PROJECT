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
using static STUBHUB_PROJECT.EventForm;

namespace STUBHUB_PROJECT
{
    public partial class EventForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        MainMenu form = null;
        string SelectedItem = null;
        string Title = null;

        private int userID;
        private DateTime selectedDate;

        public class Event
        {
            public Panel panelEvent;
            public Label labelEventTitle;
            public Label labelSubEventTitle;
            public Label labelEventDate;
            public Label labelVenue;
            public Button buttonSeeTickets;

            private int userID;
            private string eventID;
            private string subEventID;
            private string eventTitle;
            private string subEventTitle;
            private string subEventDate;
            private string venueName;

            public Panel newEventPanel(string id, string subid, string title, string subTitle, string date, string venue, int userid)
            {
                userID = userid;

                eventID = id;
                subEventID = subid;

                panelEvent = new Panel();
                panelEvent.Size = new Size(850, 97);
                panelEvent.BackColor = Color.White;

                labelEventTitle = new Label();
                labelEventTitle.Parent = panelEvent;
                labelEventTitle.Text = title;
                eventTitle = title;

                labelEventTitle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                labelEventTitle.Location = new Point(19, 7);
                labelEventTitle.AutoSize = true;

                labelSubEventTitle = new Label();
                labelSubEventTitle.Parent = panelEvent;
                labelSubEventTitle.Text = subTitle;
                subEventTitle = subTitle;

                labelSubEventTitle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                labelSubEventTitle.Location = new Point(17, 27);
                labelSubEventTitle.AutoSize = true;

                labelEventDate = new Label();
                labelEventDate.Parent = panelEvent;
                labelEventDate.Text = date;
                subEventDate = date;

                labelEventDate.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
                labelEventDate.Location = new Point(19, 52);
                labelEventDate.AutoSize = true;

                labelVenue = new Label();
                labelVenue.Parent = panelEvent;
                labelVenue.Text = venue;
                venueName = venue;

                labelVenue.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
                labelVenue.Location = new Point(19, 72);
                labelVenue.AutoSize = true;

                buttonSeeTickets = new Button();
                buttonSeeTickets.Parent = panelEvent;
                buttonSeeTickets.Size = new Size(100, 40);
                buttonSeeTickets.Text = "See Tickets";
                buttonSeeTickets.BackColor = Color.Orchid;
                buttonSeeTickets.ForeColor = Color.White;
                buttonSeeTickets.Location = new Point(700, 25);

                buttonSeeTickets.Click += ButtonSeeTickets_Click;

                return panelEvent;
            }

            private void ButtonSeeTickets_Click(object sender, EventArgs e)
            {
                EventTicketForm form = new EventTicketForm(subEventID, eventTitle, subEventTitle, subEventDate, venueName, userID);
                form.ShowDialog();
            }
        }
        public EventForm(MainMenu mmform, string SI, string T, int userID, DateTime dateTime)
        {
            InitializeComponent();
            form = mmform;
            SelectedItem = SI;
            Title = T;
            this.userID = userID;
            this.selectedDate = dateTime;
        }
        private void LoadTicketCounter()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(oi.Quantity), 0) FROM OrderItems oi INNER JOIN Orders o ON oi.OrderID = o.OrderID WHERE o.UserID = @UserID AND o.OrderStatus = 'Paid'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        con.Open();
                        int ticketCount = Convert.ToInt32(cmd.ExecuteScalar());

                        labelTicketCounter.Text = ticketCount.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading ticket count: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        labelTicketCounter.Text = "0";
                    }
                }
            }
        }

        private void LoadEvents()
        {
            // Update the label to reflect the starting date
            labelEvent.Text = "Upcoming " + Title + " Events from " + selectedDate.ToString("dd MMM yyyy") + " onwards";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Changed the '=' to '>=' to get events on AND after the selected date
                string query = @"
            SELECT e.EventID, e.Title, e.ImageData, se.SubEventID, se.SubEventTitle, se.EventDateTime, v.VenueName, v.State, v.Country 
            FROM Events e 
            INNER JOIN SubEvents se ON e.EventID = se.EventID 
            INNER JOIN Venues v ON se.VenueID = v.VenueID 
            WHERE e.EventID = @EventID 
            AND CAST(se.EventDateTime AS DATE) >= CAST(@SelectedDate AS DATE)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventID", int.Parse(SelectedItem));
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        int rowsFound = sqlDataAdapter.Fill(dt);

                        if (rowsFound > 0)
                        {
                            flowLayoutPanel1.Controls.Clear();

                            if (dt.Rows[0]["ImageData"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])dt.Rows[0]["ImageData"];
                                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes);
                                flowLayoutPanel1.BackgroundImage = Image.FromStream(ms);
                                flowLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
                            }
                            else
                            {
                                flowLayoutPanel1.BackgroundImage = null;
                            }

                            foreach (DataRow row in dt.Rows)
                            {
                                string id = row["EventID"].ToString();
                                string subid = row["SubEventID"].ToString();
                                string title = row["Title"].ToString();
                                string subTitle = row["SubEventTitle"].ToString();

                                DateTime rawDate = Convert.ToDateTime(row["EventDateTime"]);
                                string date = rawDate.ToString("dddd, dd MMMM yyyy, h:mm tt");

                                string venueInfo = $"{row["VenueName"]}, {row["State"]}, {row["Country"]}";

                                Event customEventCard = new Event();
                                Panel finishedPanel = customEventCard.newEventPanel(id, subid, title, subTitle, date, venueInfo, userID);

                                flowLayoutPanel1.Controls.Add(finishedPanel);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There are no events scheduled from this date onwards.", "No Events", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
        }
        private void EventForm_Load(object sender, EventArgs e)
        {
            LoadTicketCounter();
            LoadEvents();
        }

        private void EventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        private void EventForm_Activated(object sender, EventArgs e)
        {
            LoadTicketCounter();
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            InventoryForm form = new InventoryForm(userID);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}

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

        public class Event
        {
            public Panel panelEvent;
            public Label labelEventTitle;
            public Label labelSubEventTitle;
            public Label labelEventDate;
            public Label labelVenue;
            public Button buttonSeeTickets;

            private string eventID;
            private string subEventID;
            private string eventTitle;
            private string subEventTitle;
            private string subEventDate;
            private string venueName;

            public Panel newEventPanel(string id, string subid, string title, string subTitle, string date, string venue)
            {
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
                labelSubEventTitle.Location= new Point(17, 27);
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
                EventTicketForm form = new EventTicketForm(subEventID, eventTitle, subEventTitle, subEventDate, venueName);
                form.ShowDialog();
            }
        }

        public EventForm(MainMenu mmform, string SI, string T)
        {
            InitializeComponent();
            form = mmform;
            SelectedItem = SI;
            Title = T;
        }
        private void EventForm_Load(object sender, EventArgs e)
        {
            labelEvent.Text = "Upcoming " + Title + " Events";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
    SELECT e.EventID, e.Title, e.ImageData, se.SubEventID, se.SubEventTitle, se.EventDateTime, v.VenueName, v.City, v.Country 
    FROM Events e 
    INNER JOIN SubEvents se ON e.EventID = se.EventID 
    INNER JOIN Venues v ON se.VenueID = v.VenueID 
    WHERE e.EventID = @EventID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventID", int.Parse(SelectedItem));

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

                                string venueInfo = $"{row["VenueName"]}, {row["City"]}, {row["Country"]}";

                                Event customEventCard = new Event();
                                Panel finishedPanel = customEventCard.newEventPanel(id, subid, title, subTitle, date, venueInfo);

                                flowLayoutPanel1.Controls.Add(finishedPanel);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There are no Sub Events entries.");
                        }
                    }
                }
            }
        }

        private void EventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }
    }
}

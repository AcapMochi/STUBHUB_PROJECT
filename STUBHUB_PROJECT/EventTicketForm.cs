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
    public partial class EventTicketForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        string currentSubEventID;
        public EventTicketForm(string subEventId, string eventTitle, string subEventTitle, string subEventDate, string venueName)
        {
            InitializeComponent();
            currentSubEventID = subEventId;

            labelEventTitle.Text = eventTitle;
            labelSubEventTitle.Text = subEventTitle;
            labelSubEventDate.Text = subEventDate;
            labelSubEventVenue.Text = venueName;

            labelEvent.Text = eventTitle + " Tickets";
        }

        public class TicketTierCard
        {
            public Panel panelTicket;
            public Label labelTicketName;
            public Label labelPrice;
            public ComboBox comboQuantity;
            public Button buttonGetNow;

            private string ticketTierID;
            private decimal ticketPrice;

            public Panel CreateTicketPanel(string id, string name, decimal price)
            {
                ticketTierID = id;
                ticketPrice = price;

                panelTicket = new Panel();
                panelTicket.Size = new Size(430, 90);
                panelTicket.BackColor = Color.White;
                panelTicket.BorderStyle = BorderStyle.FixedSingle;

                labelTicketName = new Label();
                labelTicketName.Text = name;
                labelTicketName.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                labelTicketName.Location = new Point(0, 0);
                labelTicketName.AutoSize = true;

                labelPrice = new Label();
                labelPrice.Text = $"RM{price} /each";
                labelPrice.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Italic);
                labelPrice.ForeColor = Color.DimGray;
                labelPrice.Location = new Point(300, 4);
                labelPrice.AutoSize = true;

                comboQuantity = new ComboBox();
                comboQuantity.DropDownStyle = ComboBoxStyle.DropDownList;
                comboQuantity.Items.AddRange(new object[] { "1 Ticket", "2 Tickets", "3 Tickets", "4 Tickets", "5 Tickets" });
                comboQuantity.SelectedIndex = 0;
                comboQuantity.Size = new Size(135, 28);
                comboQuantity.Location = new Point(280, 25);

                buttonGetNow = new Button();
                buttonGetNow.Text = "Get Now";
                buttonGetNow.BackColor = Color.DarkGreen;
                buttonGetNow.ForeColor = Color.White;
                buttonGetNow.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                buttonGetNow.Size = new Size(135, 30);
                buttonGetNow.Location = new Point(280, 50);
                buttonGetNow.FlatStyle = FlatStyle.Flat;

                buttonGetNow.Click += ButtonGetNow_Click;
                panelTicket.Controls.Add(labelTicketName);
                panelTicket.Controls.Add(labelPrice);
                panelTicket.Controls.Add(comboQuantity);
                panelTicket.Controls.Add(buttonGetNow);

                return panelTicket;
            }

            private void ButtonGetNow_Click(object sender, EventArgs e)
            {
                int quantity = comboQuantity.SelectedIndex + 1;
                decimal totalPrice = quantity * ticketPrice;

                MessageBox.Show($"You selected {quantity} tickets for {labelTicketName.Text}.\nTotal: RM{totalPrice}");
            }
        }

        private void EventTicketForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TierID, TierName, Price FROM TicketTiers WHERE SubEventID = @SubEventID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubEventID", int.Parse(currentSubEventID));

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanelTickets.Controls.Clear();

                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Tickets are not yet available for this event.");
                            this.Close();
                        }

                        while (reader.Read())
                        {
                            string tierId = reader["TierID"].ToString();
                            string tierName = reader["TierName"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);

                            TicketTierCard ticketCard = new TicketTierCard();
                            Panel newTierPanel = ticketCard.CreateTicketPanel(tierId, tierName, price);

                            flowLayoutPanelTickets.Controls.Add(newTierPanel);
                        }
                    }
                }
            }
        }
    }
}

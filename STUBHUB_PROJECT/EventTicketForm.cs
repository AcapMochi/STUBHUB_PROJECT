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
        private string currentSubEventID;
        private int userID;

        // NEW: Tracks all active cards on the screen to read their quantities later
        private List<TicketTierCard> activeTicketCards = new List<TicketTierCard>();

        public EventTicketForm(string subEventId, string eventTitle, string subEventTitle, string subEventDate, string venueName, int userID)
        {
            InitializeComponent();
            currentSubEventID = subEventId;

            labelEventTitle.Text = eventTitle;
            labelSubEventTitle.Text = subEventTitle;
            labelSubEventDate.Text = subEventDate;
            labelSubEventVenue.Text = venueName;

            labelEvent.Text = eventTitle + " Tickets";
            this.userID = userID;
        }

        public class TicketTierCard
        {
            public Panel panelTicket;
            public Label labelTicketName;
            public Label labelPrice;
            public Button buttonSubtract;
            public Label labelCounter;
            public Button buttonAdd;

            // NEW: Expose properties to easily build the Ticket objects later
            public int TierID { get; private set; }
            public string TierName { get; private set; }
            public decimal Price { get; private set; }
            public int Quantity { get; private set; } = 0;

            public Panel CreateTicketPanel(int id, string name, decimal price)
            {
                this.TierID = id;
                this.TierName = name;
                this.Price = price;

                panelTicket = new Panel();
                panelTicket.Size = new Size(450, 90);
                panelTicket.BackColor = Color.White;
                panelTicket.BorderStyle = BorderStyle.FixedSingle;

                labelTicketName = new Label();
                labelTicketName.Text = $"{id} - {name}";
                labelTicketName.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                labelTicketName.Location = new Point(10, 12);
                labelTicketName.AutoSize = true;

                labelPrice = new Label();
                labelPrice.Text = $"RM{price} /each";
                labelPrice.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Italic);
                labelPrice.ForeColor = Color.DimGray;
                labelPrice.Location = new Point(10, 42);
                labelPrice.AutoSize = true;

                int stepperY = 28;

                buttonSubtract = new Button();
                buttonSubtract.Text = "-";
                buttonSubtract.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                buttonSubtract.Size = new Size(35, 35);
                buttonSubtract.Location = new Point(310, stepperY);

                labelCounter = new Label();
                labelCounter.Text = "0";
                labelCounter.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                labelCounter.Size = new Size(45, 35);
                labelCounter.Location = new Point(350, stepperY);
                labelCounter.TextAlign = ContentAlignment.MiddleCenter;

                buttonAdd = new Button();
                buttonAdd.Text = "+";
                buttonAdd.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                buttonAdd.Size = new Size(35, 35);
                buttonAdd.Location = new Point(400, stepperY);

                buttonAdd.Click += (s, e) =>
                {
                    Quantity++;
                    labelCounter.Text = Quantity.ToString();
                };

                buttonSubtract.Click += (s, e) =>
                {
                    if (Quantity > 0)
                    {
                        Quantity--;
                        labelCounter.Text = Quantity.ToString();
                    }
                };

                panelTicket.Controls.Add(labelTicketName);
                panelTicket.Controls.Add(labelPrice);
                panelTicket.Controls.Add(buttonSubtract);
                panelTicket.Controls.Add(labelCounter);
                panelTicket.Controls.Add(buttonAdd);

                return panelTicket;
            }
        }

        private void LoadVenue()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Query to fetch the venue's image by linking it through SubEvents
                string query = @"
            SELECT v.ImageData 
            FROM Venues v
            INNER JOIN SubEvents se ON v.VenueID = se.VenueID
            WHERE se.SubEventID = @SubEventID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SubEventID", int.Parse(currentSubEventID));

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader["ImageData"] != DBNull.Value)
                            {
                                // Extract the byte array and reconstruct the image
                                byte[] imageBytes = (byte[])reader["ImageData"];
                                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                                {
                                    pictureBoxVenue.BackgroundImage = Image.FromStream(ms);
                                    pictureBoxVenue.BackgroundImageLayout = ImageLayout.Stretch;
                                }
                            }
                            else
                            {
                                // Fallback if the venue does not have an image assigned
                                pictureBoxVenue.BackgroundImage = null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading venue image: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBoxVenue.BackgroundImage = null;
                    }
                }
            }
        }

        private void LoadSubEvents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 1. Load sub-event background image
                string query1 = "SELECT ImageData FROM SubEvents WHERE SubEventID = @SubEventID";
                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("@SubEventID", currentSubEventID);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sqlDataAdapter.Fill(dt);
                        if (dt.Rows.Count > 0 && dt.Rows[0]["ImageData"] != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])dt.Rows[0]["ImageData"];
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                            {
                                pictureBoxSubEvent.BackgroundImage = Image.FromStream(ms);
                                pictureBoxSubEvent.BackgroundImageLayout = ImageLayout.Stretch;
                            }
                        }
                        else
                        {
                            pictureBoxSubEvent.BackgroundImage = null;
                        }
                    }
                }

                // 2. Load and build ticket tiers UI layout
                string query2 = "SELECT TierID, TierName, Price FROM TicketTiers WHERE SubEventID = @SubEventID";
                using (SqlCommand cmd = new SqlCommand(query2, conn))
                {
                    cmd.Parameters.AddWithValue("@SubEventID", int.Parse(currentSubEventID));
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        flowLayoutPanelTickets.Controls.Clear();
                        activeTicketCards.Clear(); // Clear tracking list for fresh load

                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Tickets are not yet available for this event.");
                            this.Close();
                            return;
                        }

                        while (reader.Read())
                        {
                            int tierId = Convert.ToInt32(reader["TierID"]);
                            string tierName = reader["TierName"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);

                            TicketTierCard ticketCard = new TicketTierCard();
                            Panel newTierPanel = ticketCard.CreateTicketPanel(tierId, tierName, price);

                            // Save the object reference into tracking list
                            activeTicketCards.Add(ticketCard);
                            flowLayoutPanelTickets.Controls.Add(newTierPanel);
                        }
                    }
                }
            }
        }

        // NEW: Event Handler for your green Checkout Button
        private void buttonCheckout_Click(object sender, EventArgs e)
        {
            List<Ticket> selectedTickets = new List<Ticket>();

            // Loop through tracked cards and find ones where user changed quantity
            foreach (TicketTierCard card in activeTicketCards)
            {
                if (card.Quantity > 0)
                {
                    selectedTickets.Add(new Ticket
                    {
                        TierID = card.TierID,
                        TierName = card.TierName,
                        Quantity = card.Quantity,
                        Price = card.Price
                    });
                }
            }

            // Ensure they actually picked something
            if (selectedTickets.Count == 0)
            {
                MessageBox.Show("Please select at least one ticket tier before proceeding.", "No Tickets Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CheckoutForm billingForm = new CheckoutForm(selectedTickets, int.Parse(currentSubEventID), userID);
            this.Hide();
            billingForm.ShowDialog();
            this.Show();
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

        private void EventTicketForm_Load(object sender, EventArgs e)
        {
            LoadTicketCounter();
            LoadSubEvents();
            LoadVenue();
        }

        private void EventTicketForm_Activated(object sender, EventArgs e)
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
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
using System.Windows.Forms.VisualStyles;
using static STUBHUB_PROJECT.EventForm;

namespace STUBHUB_PROJECT
{
    public partial class EventTicketForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        string currentSubEventID;
        private int userID;
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
            public Label labelLevel;
            public ComboBox comboQuantity;
            public Button buttonGetNow;

            // Notice we removed the DB logic from here!
            public Panel CreateTicketPanel(string id, string name, decimal price)
            {
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

                labelLevel = new Label();
                labelLevel.Text = id;
                labelLevel.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                labelLevel.Location = new Point(0, 0);
                labelLevel.AutoSize = true;

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

                panelTicket.Controls.Add(labelTicketName);
                panelTicket.Controls.Add(labelPrice);
                panelTicket.Controls.Add(labelLevel);
                panelTicket.Controls.Add(comboQuantity);
                panelTicket.Controls.Add(buttonGetNow);

                return panelTicket;
            }
        }

        private void LoadTicketCounter()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(oi.Quantity), 0) FROM OrderItems oi INNER JOIN Orders o ON oi.OrderID = o.OrderID WHERE o.UserID = @UserID AND o.OrderStatus = 'Pending'";

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

        private void LoadSubEvents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query1 = "SELECT ImageData FROM SubEvents WHERE SubEventID = @SubEventID";

                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("@SubEventID", currentSubEventID);

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        int rowsFound = sqlDataAdapter.Fill(dt);

                        if (rowsFound > 0)
                        {

                            if (dt.Rows[0]["ImageData"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])dt.Rows[0]["ImageData"];

                                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes);
                                pictureBoxSubEvent.BackgroundImage = Image.FromStream(ms);

                                pictureBoxSubEvent.BackgroundImageLayout = ImageLayout.Stretch;
                            }
                            else
                            {
                                pictureBoxSubEvent.BackgroundImage = null;
                            }
                        }
                    }
                }

                string query2 = "SELECT TierID, TierName, TierLevel, Price FROM TicketTiers WHERE SubEventID = @SubEventID";

                using (SqlCommand cmd = new SqlCommand(query2, conn))
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
                            string tierIdString = reader["TierID"].ToString();
                            string tierName = reader["TierName"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);

                            int tierId = int.Parse(tierIdString);

                            TicketTierCard ticketCard = new TicketTierCard();
                            Panel newTierPanel = ticketCard.CreateTicketPanel(tierIdString, tierName, price);

                            ticketCard.buttonGetNow.Click += (sender, e) =>
                            {
                                int selectedQty = ticketCard.comboQuantity.SelectedIndex + 1;
                                AddToCart(tierId, selectedQty, price);
                            };

                            flowLayoutPanelTickets.Controls.Add(newTierPanel);
                        }
                    }
                }
            }
        }

        private void AddToCart(int ticketTierID, int quantity, decimal ticketPrice)
        {
            decimal totalPrice = quantity * ticketPrice;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    int currentOrderID = 0;

                    string checkOrderQuery = "SELECT OrderID FROM Orders WHERE UserID = @UserID AND OrderStatus = 'Pending'";
                    using (SqlCommand cmdCheck = new SqlCommand(checkOrderQuery, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@UserID", this.userID);
                        object result = cmdCheck.ExecuteScalar();

                        if (result != null)
                        {
                            currentOrderID = Convert.ToInt32(result);
                        }
                        else
                        {
                            string createOrderQuery = @"
                        INSERT INTO [Orders] (UserID, TotalAmount, OrderStatus, OrderDate) 
                        VALUES (@UserID, 0, 'Pending', GETDATE());
                        SELECT SCOPE_IDENTITY();";

                            using (SqlCommand cmdCreate = new SqlCommand(createOrderQuery, conn))
                            {
                                cmdCreate.Parameters.AddWithValue("@UserID", this.userID);
                                currentOrderID = Convert.ToInt32(cmdCreate.ExecuteScalar());
                            }
                        }
                    }

                    string insertItemQuery = @"
                INSERT INTO [OrderItems] (OrderID, TierID, Quantity, PriceAtPurchase) 
                VALUES (@OrderID, @TierID, @Quantity, @PriceAtPurchase)";

                    using (SqlCommand cmdItem = new SqlCommand(insertItemQuery, conn))
                    {
                        cmdItem.Parameters.AddWithValue("@OrderID", currentOrderID);
                        cmdItem.Parameters.AddWithValue("@TierID", ticketTierID);
                        cmdItem.Parameters.AddWithValue("@Quantity", quantity);
                        cmdItem.Parameters.AddWithValue("@PriceAtPurchase", totalPrice);

                        cmdItem.ExecuteNonQuery();
                    }

                    MessageBox.Show("Added to cart successfully!");

                    LoadTicketCounter();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Error: " + ex.Message);
                }
            }
        }

        private void EventTicketForm_Load(object sender, EventArgs e)
        {
            LoadTicketCounter();
            LoadSubEvents();
        }

        private void EventTicketForm_Activated(object sender, EventArgs e)
        {
            LoadTicketCounter();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUBHUB_PROJECT
{
    public partial class MyCart : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        string currentSubEventID;
        private int userID;

        Form originalForm = null;

        public MyCart(int userID, Form form)
        {
            InitializeComponent();
            this.userID = userID;
            originalForm = form;
        }

        public class TicketTierCard
        {
            public Panel panelTicket;
            public Label labelTicketName;
            public Label labelDate;
            public Label labelVenue;
            public Label labelQuantity;
            public Label labelSubEventTitle;

            public Button buttonDelete;

            private string ticketTierID;

            public Panel CreateTicketPanel(string id, string name, string set, string venue, int quantity, string date)
            {
                ticketTierID = id;

                panelTicket = new Panel();
                panelTicket.Size = new Size(633, 96);
                panelTicket.BackColor = Color.White;
                panelTicket.BorderStyle = BorderStyle.FixedSingle;

                labelTicketName = new Label();
                labelTicketName.Text = name;
                labelTicketName.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                labelTicketName.Location = new Point(0, 0);
                labelTicketName.AutoSize = true;

                labelSubEventTitle = new Label();
                labelSubEventTitle.Text = set;
                labelSubEventTitle.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                labelSubEventTitle.Location = new Point(149, 12);
                labelSubEventTitle.AutoSize = true;

                labelVenue = new Label();
                labelVenue.Text = venue;
                labelVenue.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Italic);
                labelVenue.ForeColor = Color.DimGray;
                labelVenue.Location = new Point(154, 55);
                labelVenue.AutoSize = true;

                labelQuantity = new Label();
                labelQuantity.Text = $"x{quantity}";
                labelQuantity.Font = new Font("Microsoft Sans Serif", 11);
                labelQuantity.ForeColor = Color.DimGray;
                labelQuantity.Location = new Point(516, 39);
                labelQuantity.AutoSize = true;

                labelDate = new Label();
                labelDate.Text = date;
                labelDate.Font = new Font("Microsoft Sans Serif", 11);
                labelDate.ForeColor = Color.DimGray;
                labelDate.Location = new Point(154, 37);
                labelDate.AutoSize = true;

                buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Italic);
                buttonDelete.Size = new Size(80, 30);
                buttonDelete.Location = new Point(400, 20);
                buttonDelete.AutoSize = true;

                panelTicket.Controls.Add(labelTicketName);
                panelTicket.Controls.Add(labelVenue);
                panelTicket.Controls.Add(labelQuantity);
                panelTicket.Controls.Add(labelDate);
                panelTicket.Controls.Add(buttonDelete);
                panelTicket.Controls.Add(labelSubEventTitle);

                return panelTicket;
            }
        }

        private void LblLocation_Click(object sender, EventArgs e)
        {

        }

        private void MyCart_Load(object sender, EventArgs e)
        { 
            LoadMyCart();
        }

        private void LoadSummary()
        {
            decimal overallCartTotal = 0;

            LblBasicAmount.Text = "x0";
            LblPremiumAmount.Text = "x0";
            LblVIPAmount.Text = "x0";
            LblBasicPrice.Text = "RM 0.00";
            LblPremiumPrice.Text = "RM 0.00";
            LblVIPPrice.Text = "RM 0.00";
            LblTotalPrice.Text = "RM 0.00";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT tt.TierName, SUM(oi.Quantity) as TotalQuantity, SUM(oi.PriceAtPurchase) as TotalPrice
            FROM OrderItems oi
            INNER JOIN Orders o ON oi.OrderID = o.OrderID
            INNER JOIN TicketTiers tt ON oi.TierID = tt.TierID
            WHERE o.UserID = @UserID AND o.OrderStatus = 'Pending'
            GROUP BY tt.TierName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", this.userID);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tierName = reader["TierName"].ToString().ToLower();
                                int totalQty = Convert.ToInt32(reader["TotalQuantity"]);
                                decimal totalPrice = Convert.ToDecimal(reader["TotalPrice"]);

                                overallCartTotal += totalPrice;

                                if (tierName.Contains("basic"))
                                {
                                    LblBasicTicket.Visible = LblBasicAmount.Visible = LblBasicPrice.Visible = true;
                                    LblBasicAmount.Text = $"x{totalQty}";
                                    LblBasicPrice.Text = $"RM {totalPrice:0.00}";
                                }
                                else if (tierName.Contains("premium"))
                                {
                                    LblPremiumTicket.Visible = LblPremiumAmount.Visible = LblPremiumPrice.Visible = true;
                                    LblPremiumAmount.Text = $"x{totalQty}";
                                    LblPremiumPrice.Text = $"RM {totalPrice:0.00}";
                                }
                                else if (tierName.Contains("vip"))
                                {
                                    LblVIPTicket.Visible = LblVIPAmount.Visible = LblVIPPrice.Visible = true;
                                    LblVIPAmount.Text = $"x{totalQty}";
                                    LblVIPPrice.Text = $"RM {totalPrice:0.00}";
                                }
                            }
                        }

                        LblTotalPrice.Visible = true;
                        LblTotalPrice.Text = $"RM {overallCartTotal:0.00}";
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error loading summary: " + ex.Message);
                    }
                }
            }
        }

        private void LoadEventDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string query = @"
            SELECT TOP 1 se.SubEventTitle, se.EventDateTime, v.VenueName 
            FROM Orders o
            INNER JOIN OrderItems oi ON o.OrderID = oi.OrderID
            INNER JOIN TicketTiers tt ON oi.TierID = tt.TierID
            INNER JOIN SubEvents se ON tt.SubEventID = se.SubEventID
            INNER JOIN Venues v ON se.VenueID = v.VenueID
            WHERE o.UserID = @UserID AND o.OrderStatus = 'Pending'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", this.userID);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LblSubEventName.Text = reader["SubEventTitle"].ToString();

                                if (DateTime.TryParse(reader["EventDateTime"].ToString(), out DateTime eventDate))
                                {
                                    LblDate.Text = eventDate.ToString("dddd, dd MMMM yyyy, h:mm tt");
                                }
                                else
                                {
                                    LblDate.Text = reader["EventDateTime"].ToString();
                                }

                                LblLocation.Text = reader["VenueName"].ToString();
                            }
                            else
                            {
                                LblSubEventName.Text = "Your Cart is Empty";
                                LblDate.Text = "";
                                LblLocation.Text = "Add tickets to see them here!";
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error loading event details: " + ex.Message);
                    }
                }
            }
        }

        private void LoadMyCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE Orders 
            SET TotalAmount = (
                SELECT ISNULL(SUM(PriceAtPurchase), 0) 
                FROM OrderItems 
                WHERE OrderID = Orders.OrderID
            ) 
            WHERE UserID = @UserID AND OrderStatus = 'Pending'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", this.userID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error syncing cart total: " + ex.Message);
                    }
                }
            }

            LoadEventDetails();
            LoadItem();
            LoadSummary();
        }

        private void LoadItem()
        {
            flowLayoutPanelCart.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT oi.OrderItemID, tt.TierName, oi.Quantity, v.VenueName, se.SubEventTitle ,se.EventDateTime 
            FROM OrderItems oi
            INNER JOIN Orders o ON oi.OrderID = o.OrderID
            INNER JOIN TicketTiers tt ON oi.TierID = tt.TierID
            INNER JOIN SubEvents se ON tt.SubEventID = se.SubEventID
            INNER JOIN Venues v ON se.VenueID = v.VenueID
            WHERE o.UserID = @UserID AND o.OrderStatus = 'Pending'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", this.userID);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string orderItemId = reader["OrderItemID"].ToString();
                                string tierName = reader["TierName"].ToString();
                                string venue = reader["VenueName"].ToString();
                                string subEventName = reader["SubEventTitle"].ToString();
                                int quantity = Convert.ToInt32(reader["Quantity"]);

                                string dateText = reader["EventDateTime"].ToString();
                                if (DateTime.TryParse(dateText, out DateTime parsedDate))
                                {
                                    dateText = parsedDate.ToString("dd MMM yyyy, h:mm tt");
                                }

                                TicketTierCard card = new TicketTierCard();
                                Panel itemPanel = card.CreateTicketPanel(orderItemId, tierName, subEventName, venue, quantity, dateText);

                                card.buttonDelete.Click += (s, ev) =>
                                {
                                    DeleteCartItem(orderItemId); 
                                };

                                flowLayoutPanelCart.Controls.Add(itemPanel);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error loading items: " + ex.Message);
                    }
                }
            }
        }

        private void DeleteCartItem(string orderItemId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM OrderItems WHERE OrderItemID = @OrderItemID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderItemID", orderItemId);

                    try
                    {

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            LoadMyCart();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error deleting item: " + ex.Message);
                    }
                    

                    
                }
            }
        }

        private void MyCart_FormClosed(object sender, FormClosedEventArgs e)
        {
            originalForm.Show();
        }

        private void BtnCheckoutCart_Click(object sender, EventArgs e)
        {

        }
    }
}

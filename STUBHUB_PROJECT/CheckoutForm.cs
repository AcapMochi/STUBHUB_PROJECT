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
    public partial class CheckoutForm : Form
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        private List<Ticket> selectedTickets;
        private int subEventID;
        private int userID;

        public bool ifCreditCard = false;
        public string creditCardName;

        decimal grandTotal;
        public CheckoutForm(List<Ticket> selectedTickets, int subEventID, int userID)
        {
            this.selectedTickets = selectedTickets;
            this.subEventID = subEventID;
            InitializeComponent();

            grandTotal = selectedTickets.Sum(t => t.TotalPrice);
            this.userID = userID;
        }

        private void LoadCheckout()
        {
            LblTotalPrice.Text = $"RM {grandTotal:0.00}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string eventQuery = @"
    SELECT se.SubEventTitle, se.EventDateTime, se.ImageData,
           v.VenueName, v.State, v.Country
    FROM SubEvents se
    INNER JOIN Venues v ON se.VenueID = v.VenueID
    WHERE se.SubEventID = @SubEventID";

                using (SqlCommand cmd = new SqlCommand(eventQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@SubEventID", subEventID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LblSubEventName.Text = reader["SubEventTitle"].ToString();

                            if (reader["EventDateTime"] != DBNull.Value)
                            {
                                DateTime eventDate = Convert.ToDateTime(reader["EventDateTime"]);
                                LblDate.Text = eventDate.ToString("dddd, dd MMMM yyyy, h:mm tt");
                            }

                            LblLocation.Text = $"{reader["VenueName"]}, {reader["State"]}, {reader["Country"]}";

                            if (reader["ImageData"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["ImageData"];
                                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                                {
                                    pictureBoxCheckout.BackgroundImage = Image.FromStream(ms);
                                    pictureBoxCheckout.BackgroundImageLayout = ImageLayout.Stretch;
                                }
                            }
                            else
                            {

                                pictureBoxCheckout.BackgroundImage = null;
                            }
                        }
                    }
                }

                string tierQuery = "SELECT TierID, TierLevel FROM TicketTiers WHERE SubEventID = @SubEventID";
                Dictionary<int, int> tierLevels = new Dictionary<int, int>();

                using (SqlCommand cmd = new SqlCommand(tierQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@SubEventID", subEventID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["TierID"]);
                            int level = Convert.ToInt32(reader["TierLevel"]);
                            tierLevels[id] = level;
                        }
                    }
                }

                LblBasicTicket.Visible = false;
                LblBasicAmount.Visible = false;
                LblPremiumTicket.Visible = false;
                LblPremiumAmount.Visible = false;
                LblVIPTicket.Visible = false;
                LblVIPAmount.Visible = false;

                foreach (var ticket in selectedTickets)
                {
                    if (tierLevels.ContainsKey(ticket.TierID) && ticket.Quantity > 0)
                    {
                        int level = tierLevels[ticket.TierID];

                        if (level == 1) // Basic
                        {
                            LblBasicTicket.Text = $"{ticket.TierName} (x{ticket.Quantity})";
                            LblBasicAmount.Text = $"RM {ticket.TotalPrice:0.00}";

                            LblBasicTicket.Visible = true;
                            LblBasicAmount.Visible = true;
                        }
                        else if (level == 2) // Premium
                        {
                            LblPremiumTicket.Text = $"{ticket.TierName} (x{ticket.Quantity})";
                            LblPremiumAmount.Text = $"RM {ticket.TotalPrice:0.00}";

                            LblPremiumTicket.Visible = true;
                            LblPremiumAmount.Visible = true;
                        }
                        else if (level == 3) // VIP
                        {
                            LblVIPTicket.Text = $"{ticket.TierName} (x{ticket.Quantity})";
                            LblVIPAmount.Text = $"RM {ticket.TotalPrice:0.00}";

                            LblVIPTicket.Visible = true;
                            LblVIPAmount.Visible = true;
                        }
                    }
                }
            }
        }

        private void CheckoutBillingForm_Load(object sender, EventArgs e)
        {
            if (ifCreditCard)
            {
                RadBtnCredit.Checked = true;
                labelCardUsername.Text = creditCardName;
                MessageBox.Show("You already filled in the Credit Card Information");
            }
            LoadCheckout();
        }

        private void BtnContinueCheckout_Click(object sender, EventArgs e)
        {
            if (!RadBtnCredit.Checked)
            {
                MessageBox.Show("Choose a payment method!");
                return;
            }

            int currentUserID = userID;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Create the Order
                        string insertOrderQuery = @"
            INSERT INTO Orders (UserID, TotalAmount, BillingName, OrderStatus) 
            VALUES (@UserID, @TotalAmount, @BillingName, 'Paid');
            SELECT SCOPE_IDENTITY();";

                        int newOrderID;

                        using (SqlCommand orderCmd = new SqlCommand(insertOrderQuery, conn, transaction))
                        {
                            orderCmd.Parameters.AddWithValue("@UserID", currentUserID);
                            orderCmd.Parameters.AddWithValue("@TotalAmount", grandTotal);
                            orderCmd.Parameters.AddWithValue("@BillingName", labelCardUsername.Text);

                            newOrderID = Convert.ToInt32(orderCmd.ExecuteScalar());
                        }

                        // 2. Insert Order Items AND Deduct Seats
                        string insertItemQuery = @"
            INSERT INTO OrderItems (OrderID, TierID, Quantity, PriceAtPurchase) 
            VALUES (@OrderID, @TierID, @Quantity, @PriceAtPurchase);";

                        // Updated to match your schema: Add to SeatsSold instead of subtracting
                        string updateSeatsQuery = @"
    UPDATE TicketTiers 
    SET SeatsSold = ISNULL(SeatsSold, 0) + @Quantity 
    WHERE TierID = @TierID;";

                        using (SqlCommand itemCmd = new SqlCommand(insertItemQuery, conn, transaction))
                        using (SqlCommand updateCmd = new SqlCommand(updateSeatsQuery, conn, transaction)) // Added command for updating seats
                        {
                            foreach (Ticket ticket in selectedTickets)
                            {
                                if (ticket.Quantity > 0)
                                {
                                    // Insert into OrderItems
                                    itemCmd.Parameters.Clear();
                                    itemCmd.Parameters.AddWithValue("@OrderID", newOrderID);
                                    itemCmd.Parameters.AddWithValue("@TierID", ticket.TierID);
                                    itemCmd.Parameters.AddWithValue("@Quantity", ticket.Quantity);
                                    itemCmd.Parameters.AddWithValue("@PriceAtPurchase", ticket.Price);
                                    itemCmd.ExecuteNonQuery();

                                    // Update available seats
                                    updateCmd.Parameters.Clear();
                                    updateCmd.Parameters.AddWithValue("@Quantity", ticket.Quantity);
                                    updateCmd.Parameters.AddWithValue("@TierID", ticket.TierID);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 3. Insert Payment Details
                        string insertPaymentQuery = @"
            INSERT INTO Payments (OrderID, PaymentMethod, TransactionRef, PaymentStatus) 
            VALUES (@OrderID, @PaymentMethod, @TransactionRef, 'Paid');";

                        using (SqlCommand paymentCmd = new SqlCommand(insertPaymentQuery, conn, transaction))
                        {
                            paymentCmd.Parameters.AddWithValue("@OrderID", newOrderID);
                            paymentCmd.Parameters.AddWithValue("@PaymentMethod", "Credit Card");

                            string generatedTxnRef = "TXN-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                            paymentCmd.Parameters.AddWithValue("@TransactionRef", generatedTxnRef);

                            paymentCmd.ExecuteNonQuery();
                        }

                        // 4. Commit all changes to the database
                        transaction.Commit();

                        MessageBox.Show("Payment Successful! Your tickets have been booked.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // If anything fails (including the seat deduction), rollback everything
                        transaction.Rollback();
                        MessageBox.Show("An error occurred while processing your order: " + ex.Message, "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAddCard_Click(object sender, EventArgs e)
        {
            if (RadBtnCredit.Checked)
                RadBtnCredit.Checked = false;

            using (CheckoutBillingForm form = new CheckoutBillingForm())
            {
                this.Hide();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.ifCreditCard = true;
                    RadBtnCredit.Checked = true;
                    labelCardUsername.Text = form.cardName;

                    creditCardName = form.cardName;
                }
                else
                {
                    this.ifCreditCard = false;
                }

                this.Show();
            }
        }
    }
}

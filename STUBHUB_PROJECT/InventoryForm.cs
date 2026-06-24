using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace STUBHUB_PROJECT
{
    public partial class InventoryForm : Form
    {
        private List<PrintTicketData> ticketsToPrint = new List<PrintTicketData>();
        private int currentTicketIndex = 0;
        private int currentPageForTicket = 1;
        public class PrintTicketData
        {
            public string OrderId { get; set; }
            public string OrderItemId { get; set; }
            public string SubEventTitle { get; set; }
            public string VenueName { get; set; }
            public string TierName { get; set; }
            public string DateText { get; set; }
            public int Quantity { get; set; }
        }

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True";
        private int userID;

        public InventoryForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        public class TicketTierCard
        {
            public Panel panelTicket;
            public Label labelTicketName;
            public Label labelDate;
            public Label labelVenue;
            public Label labelQuantity;
            public Label labelSubEventTitle;
            public PictureBox pictureBoxEvent;

            public Button buttonViewTicket;
            private string ticketTierID;
            public Panel CreateTicketPanel(string id, string name, string set, string venue, int quantity, string date, byte[] imageBytes)
            {
                ticketTierID = id;

                panelTicket = new Panel();
                panelTicket.Size = new Size(1103, 96);
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

                buttonViewTicket = new Button();
                buttonViewTicket.Text = "View Ticket(s)";
                buttonViewTicket.BackColor = Color.DarkGreen;
                buttonViewTicket.ForeColor = Color.White;
                buttonViewTicket.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Italic);
                buttonViewTicket.Size = new Size(130, 50);
                buttonViewTicket.Location = new Point(600, 17);
                buttonViewTicket.AutoSize = true;

                pictureBoxEvent = new PictureBox();
                pictureBoxEvent.Size = new Size(121, 57);
                pictureBoxEvent.Location = new Point(22, 16);

                pictureBoxEvent.SizeMode = PictureBoxSizeMode.StretchImage;
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                    {
                        pictureBoxEvent.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBoxEvent.Image = null;
                }

                panelTicket.Controls.Add(labelTicketName);
                panelTicket.Controls.Add(labelVenue);
                panelTicket.Controls.Add(labelQuantity);
                panelTicket.Controls.Add(labelDate);
                panelTicket.Controls.Add(buttonViewTicket);
                panelTicket.Controls.Add(labelSubEventTitle);
                panelTicket.Controls.Add(pictureBoxEvent);

                return panelTicket;
            }
        }

        private void MyCart_Load(object sender, EventArgs e)
        { 
            LoadMyCart();
        }

        private void StartTicketPrintJob(string orderId)
        {
            ticketsToPrint.Clear();
            currentTicketIndex = 0;
            currentPageForTicket = 1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT oi.OrderItemID, oi.Quantity, tt.TierName, 
                   se.SubEventTitle, se.EventDateTime, v.VenueName
            FROM OrderItems oi
            INNER JOIN TicketTiers tt ON oi.TierID = tt.TierID
            INNER JOIN SubEvents se ON tt.SubEventID = se.SubEventID
            INNER JOIN Venues v ON se.VenueID = v.VenueID
            WHERE oi.OrderID = @OrderID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime eventDate = Convert.ToDateTime(reader["EventDateTime"]);

                                ticketsToPrint.Add(new PrintTicketData
                                {
                                    OrderId = orderId,
                                    OrderItemId = reader["OrderItemID"].ToString(),
                                    SubEventTitle = reader["SubEventTitle"].ToString(),
                                    VenueName = reader["VenueName"].ToString(),
                                    TierName = reader["TierName"].ToString(),
                                    DateText = eventDate.ToString("dd MMMM yyyy, h:mm tt"),
                                    Quantity = Convert.ToInt32(reader["Quantity"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database error preparing layout: " + ex.Message);
                        return;
                    }
                }
            }

            if (ticketsToPrint.Count == 0) return;
            PrintDocument printDoc = new PrintDocument();

            printDoc.DefaultPageSettings.Landscape = true;

            printDoc.PrintPage += new PrintPageEventHandler(PrintDoc_PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.Width = 800;
            previewDialog.Height = 600;
            previewDialog.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (currentTicketIndex >= ticketsToPrint.Count)
            {
                e.HasMorePages = false;
                return;
            }

            PrintTicketData currentTicket = ticketsToPrint[currentTicketIndex];
            Graphics g = e.Graphics;

            Font headerFont = new Font("Arial", 22, FontStyle.Bold);
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font normalFont = new Font("Arial", 12, FontStyle.Regular);
            Font smallFont = new Font("Arial", 10, FontStyle.Italic);

            int width = e.MarginBounds.Width;
            int height = e.MarginBounds.Height;
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;

            // 1. Draw Outer Ticket Frame
            Pen borderPen = new Pen(Color.DarkGreen, 3);
            g.DrawRectangle(borderPen, leftMargin, topMargin, width, height);

            // 2. Draw Text Details
            g.DrawString("VIBE CHECKS ADMISSION TICKET", headerFont, Brushes.DarkBlue, leftMargin + 20, topMargin + 30);
            g.DrawString(currentTicket.SubEventTitle, titleFont, Brushes.Black, leftMargin + 20, topMargin + 90);
            g.DrawString($"Venue: {currentTicket.VenueName}", normalFont, Brushes.DimGray, leftMargin + 20, topMargin + 130);
            g.DrawString($"Date: {currentTicket.DateText}", normalFont, Brushes.DimGray, leftMargin + 20, topMargin + 150);
            g.DrawString($"Tier: {currentTicket.TierName}", titleFont, Brushes.DarkGreen, leftMargin + 20, topMargin + 200);

            string uniqueCode = $"TKT-{currentTicket.OrderId}-{currentTicket.OrderItemId}-{currentPageForTicket}";
            g.DrawString($"Ticket Reference: {uniqueCode}", smallFont, Brushes.Black, leftMargin + 20, topMargin + height - 40);
            g.DrawString($"Page: Copy {currentPageForTicket} of {currentTicket.Quantity}", smallFont, Brushes.Black, leftMargin + width - 150, topMargin + height - 40);

            int qrSize = 120;
            int qrX = leftMargin + width - 140;
            int qrY = topMargin + 90;

            try
            {
                Image qrImage = Properties.Resources.qr;
                g.DrawImage(qrImage, qrX, qrY, qrSize, qrSize);
            }
            catch (Exception ex)
            {
                g.DrawRectangle(Pens.Red, qrX, qrY, qrSize, qrSize);
                g.DrawString("IMAGE", smallFont, Brushes.Red, qrX + 35, qrY + 40);
                g.DrawString("MISSING", smallFont, Brushes.Red, qrX + 30, qrY + 60);
                MessageBox.Show("Error: " + ex.Message);
            }

            currentPageForTicket++;

            if (currentPageForTicket > currentTicket.Quantity)
            {
                currentPageForTicket = 1;
                currentTicketIndex++;
            }

            if (currentTicketIndex < ticketsToPrint.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
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
        }

        private void LoadItem()
        {
            flowLayoutPanelCart.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                o.OrderID, 
                Summary.TotalQuantity,
                Details.SubEventTitle, 
                Details.VenueName, 
                Details.EventDateTime,
                Details.ImageData
            FROM Orders o
            INNER JOIN (
                SELECT oi.OrderID, SUM(oi.Quantity) AS TotalQuantity
                FROM OrderItems oi
                GROUP BY oi.OrderID
            ) Summary ON o.OrderID = Summary.OrderID
            CROSS APPLY (
                SELECT TOP 1 se2.SubEventTitle, se2.EventDateTime, se2.ImageData, v2.VenueName
                FROM OrderItems oi2
                INNER JOIN TicketTiers tt2 ON oi2.TierID = tt2.TierID
                INNER JOIN SubEvents se2 ON tt2.SubEventID = se2.SubEventID
                INNER JOIN Venues v2 ON se2.VenueID = v2.VenueID
                WHERE oi2.OrderID = o.OrderID
            ) Details
            WHERE o.UserID = @UserID AND o.OrderStatus = 'Paid'
            ORDER BY o.OrderID DESC";

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
                                string orderId = reader["OrderID"].ToString();
                                string subEventName = reader["SubEventTitle"].ToString();
                                string venue = reader["VenueName"].ToString();
                                int totalQuantity = Convert.ToInt32(reader["TotalQuantity"]);

                                string dateText = reader["EventDateTime"].ToString();
                                if (DateTime.TryParse(dateText, out DateTime parsedDate))
                                {
                                    dateText = parsedDate.ToString("dd MMM yyyy, h:mm tt");
                                }

                                byte[] imageBytes = null;
                                if (reader["ImageData"] != DBNull.Value)
                                {
                                    imageBytes = (byte[])reader["ImageData"];
                                }

                                TicketTierCard card = new TicketTierCard();
                                Panel itemPanel = card.CreateTicketPanel(
                                    orderId,
                                    $"Order #{orderId}",
                                    subEventName,
                                    venue,
                                    totalQuantity,
                                    dateText,
                                    imageBytes
                                );

                                card.buttonViewTicket.Click += (s, ev) =>
                                {
                                    MessageBox.Show($"Opening details window for Order #{orderId}");
                                    StartTicketPrintJob(orderId);
                                };

                                flowLayoutPanelCart.Controls.Add(itemPanel);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error loading inventory items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MyCart_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void BtnCheckoutCart_Click(object sender, EventArgs e)
        {
            PaymentMethodForm form = new PaymentMethodForm();
            this.Hide();
            form.ShowDialog();
        }
    }
}

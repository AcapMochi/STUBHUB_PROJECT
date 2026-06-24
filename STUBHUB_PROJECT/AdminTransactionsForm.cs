using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUBHUB_PROJECT
{
    public partial class AdminTransactionsForm : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VibeCheckDatabase.mdf;Integrated Security=True;";
        public AdminTransactionsForm()
        {
            InitializeComponent();

        }

        private void AdminTransactionsForm_Load(object sender, EventArgs e)
        {
            LoadTransactionHistory();
        }
        private void LoadTransactionHistory()
        {
            string query = @"
        SELECT 
            o.OrderID AS [Order ID],
            u.Username AS [Customer],
            o.OrderDate AS [Booking Date],
            o.TotalAmount AS [Total Paid (RM)],
            p.PaymentMethod AS [Payment Method],
            p.PaymentStatus AS [Payment Status]
        FROM [dbo].[Orders] o
        INNER JOIN [dbo].[User] u ON o.UserID = u.UserID
        LEFT JOIN [dbo].[Payments] p ON o.OrderID = p.OrderID
        ORDER BY o.OrderDate DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTransactions.DataSource = dt;

                        // --- VISUAL FIX: Force the DataGridView text to be readable ---
                        dgvTransactions.DefaultCellStyle.ForeColor = Color.Black;
                        dgvTransactions.DefaultCellStyle.BackColor = Color.White;
                        dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // So you can see what you highlighted
                        dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.Black;
                        dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                        // --- LIVE SALES SUMMARY CALCULATION (FIXED) ---
                        int totalBookings = 0;
                        decimal totalRevenue = 0m;

                        foreach (DataGridViewRow row in dgvTransactions.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string status = row.Cells["Payment Status"].Value?.ToString();

                            if (status == "Paid")
                            {
                                totalBookings++;

                                // Safely parse the value to avoid DBNull or format crashes
                                if (decimal.TryParse(row.Cells["Total Paid (RM)"].Value?.ToString(), out decimal amount))
                                {
                                    totalRevenue += amount;
                                }
                            }
                        }

                        // Update UI Labels
                        lblTotalBookings.Text = "Tickets Issued: " + totalBookings;
                        lblTotalRevenue.Text = "Total Sales: RM " + totalRevenue.ToString("N2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading booking transactions: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnRefundBooking_Click(object sender, EventArgs e)
        {
            // Check if at least one row is fully selected
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTransactions.SelectedRows[0];

                // Safeguard 1: Ignore if they selected the blank empty row at the bottom
                if (selectedRow.IsNewRow) return;

                // Safeguard 2: Prevent double-refunding
                string currentStatus = selectedRow.Cells["Payment Status"].Value?.ToString();
                if (currentStatus == "Refunded")
                {
                    MessageBox.Show("This order has already been refunded. No further action is required.", "Already Refunded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop the code here
                }

                // Proceed with the refund prompt
                int orderId = Convert.ToInt32(selectedRow.Cells["Order ID"].Value);
                string customerName = selectedRow.Cells["Customer"].Value?.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to cancel and refund Order #{orderId} for {customerName}?", "Confirm Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    ExecuteRefund(orderId);
                }
            }
            else
            {
                // Friendly tip: Users sometimes click a single cell instead of the whole row.
                MessageBox.Show("Please select an entire transaction row from the grid first (click the margin to the left of the row).", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExecuteRefund(int orderId)
        {
            // Updates the transaction status inside your database Payments table
            string updateQuery = "UPDATE [dbo].[Payments] SET [PaymentStatus] = 'Refunded' WHERE [OrderID] = @OrderID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId);

                        // Safeguard 3: Verify the database actually updated something
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order marked as Refunded successfully!", "Refund Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh grid view. This will ALSO re-trigger your LoadTransactionHistory math 
                            // so the Live Sales Summary updates instantly!
                            LoadTransactionHistory();
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not find the payment record in the database. The refund failed.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to process database refund update: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.Rows.Count > 0)
            {
                try
                {
                    PrintDocument printDoc = new PrintDocument();

                    printDoc.DefaultPageSettings.Landscape = true;

                    printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

                    PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                    previewDialog.Document = printDoc;
                    previewDialog.Width = 800;
                    previewDialog.Height = 600;
                    previewDialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Printing Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No data available to print.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font titleFont = new Font("Segoe UI", 24, FontStyle.Bold);
            Font subtitleFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font boldText = new Font("Segoe UI", 10, FontStyle.Bold);
            Font normalText = new Font("Segoe UI", 10, FontStyle.Regular);
            Font smallText = new Font("Segoe UI", 8, FontStyle.Regular);

            SolidBrush darkBlueBrush = new SolidBrush(Color.FromArgb(0, 0, 139));
            SolidBrush darkGreenBrush = new SolidBrush(Color.FromArgb(0, 100, 0));
            Pen darkGreenPen = new Pen(Color.FromArgb(0, 100, 0), 3);

            g.DrawRectangle(darkGreenPen, 30, 30, 765, 1100);

            int currentY = 50;
            int leftMargin = 50;

            g.DrawString("VIBE CHECKS", titleFont, darkBlueBrush, leftMargin, currentY);
            currentY += 40;
            g.DrawString("Transaction Ledger & Revenue Statement", subtitleFont, Brushes.DimGray, leftMargin, currentY);
            currentY += 35;

            g.DrawString("Generated Date: " + DateTime.Now.ToString("dd MMM yyyy, hh:mm tt"), normalText, Brushes.Black, leftMargin, currentY);
            currentY += 20;
            g.DrawString("Event Reference: Stray Kids - New World (15 June 2026)", normalText, Brushes.Black, leftMargin, currentY);
            currentY += 20;
            g.DrawString("Venue: Mega Star Arena", normalText, Brushes.Black, leftMargin, currentY);
            currentY += 35;

            string ticketsCount = lblTotalBookings.Text.Replace("Tickets Issued: ", "").Trim();
            string salesTotal = lblTotalRevenue.Text.Replace("Total Sales: RM ", "").Trim();

            g.FillRectangle(Brushes.WhiteSmoke, leftMargin, currentY, 725, 75);
            g.FillRectangle(darkGreenBrush, leftMargin, currentY, 5, 75); // Green accent stripe on the left

            g.DrawString("TICKETS ISSUED", boldText, Brushes.DimGray, leftMargin + 25, currentY + 15);
            g.DrawString(ticketsCount, new Font("Segoe UI", 18, FontStyle.Bold), darkGreenBrush, leftMargin + 25, currentY + 35);

            g.DrawString("TOTAL SALES (RM)", boldText, Brushes.DimGray, leftMargin + 300, currentY + 15);
            g.DrawString(salesTotal, new Font("Segoe UI", 18, FontStyle.Bold), darkGreenBrush, leftMargin + 300, currentY + 35);

            currentY += 100;

            g.FillRectangle(darkBlueBrush, leftMargin, currentY, 725, 30);

            g.DrawString("Order ID", boldText, Brushes.White, leftMargin + 10, currentY + 5);
            g.DrawString("Customer", boldText, Brushes.White, leftMargin + 110, currentY + 5);
            g.DrawString("Booking Date", boldText, Brushes.White, leftMargin + 300, currentY + 5);

            StringFormat rightAlign = new StringFormat();
            rightAlign.Alignment = StringAlignment.Far;
            g.DrawString("Amount (RM)", boldText, Brushes.White, leftMargin + 550, currentY + 5, rightAlign);

            g.DrawString("Status", boldText, Brushes.White, leftMargin + 600, currentY + 5);

            currentY += 40;

            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                if (row.IsNewRow) continue;

                string orderId = row.Cells["Order ID"].Value?.ToString() ?? "";
                string customer = row.Cells["Customer"].Value?.ToString() ?? "";
                string date = Convert.ToDateTime(row.Cells["Booking Date"].Value).ToString("dd/MM/yyyy");
                string amount = row.Cells["Total Paid (RM)"].Value?.ToString() ?? "0.00";
                string status = row.Cells["Payment Status"].Value?.ToString() ?? "";

                g.DrawString(orderId, normalText, Brushes.Black, leftMargin + 10, currentY);

                if (customer.Length > 20) customer = customer.Substring(0, 17) + "...";
                g.DrawString(customer, normalText, Brushes.Black, leftMargin + 110, currentY);

                g.DrawString(date, normalText, Brushes.Black, leftMargin + 300, currentY);

                g.DrawString(amount, new Font("Courier New", 10, FontStyle.Regular), Brushes.Black, leftMargin + 550, currentY, rightAlign);

                Brush statusBrush = (status == "Refunded") ? Brushes.Firebrick : darkGreenBrush;
                g.DrawString(status, boldText, statusBrush, leftMargin + 600, currentY);

                g.DrawLine(Pens.LightGray, leftMargin, currentY + 22, leftMargin + 725, currentY + 22);

                currentY += 30;

                if (currentY > 1030)
                {
                    g.DrawString("... (Additional rows omitted to fit single page)", normalText, Brushes.Gray, leftMargin, currentY + 10);
                    break;
                }
            }

            g.DrawLine(Pens.Silver, leftMargin, 1080, leftMargin + 725, 1080);
            g.DrawString("Report Reference: VC-REP-" + DateTime.Now.ToString("yyyyMMdd") + "-001", smallText, Brushes.Gray, leftMargin, 1085);
            g.DrawString("Page 1 of 1", smallText, Brushes.Gray, leftMargin + 670, 1085);
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchCustomer.Text.Trim().ToLower();

            if (dgvTransactions.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("Customer LIKE '%{0}%' OR Convert([Order ID], 'System.String') LIKE '%{0}%'", filterText);
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

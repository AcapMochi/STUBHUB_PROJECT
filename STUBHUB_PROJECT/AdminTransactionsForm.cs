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

                        // --- LIVE SALES SUMMARY CALCULATION ---
                        if (dgvTransactions.Rows.Count > 0)
                        {
                            var transactions = dgvTransactions.Rows.Cast<DataGridViewRow>().Where(row => !row.IsNewRow);

                            int totalBookings = transactions.Count(row => row.Cells["Payment Status"].Value?.ToString() == "Paid");

                            double totalRevenue = transactions
                                .Where(row => row.Cells["Payment Status"].Value?.ToString() == "Paid" && row.Cells["Total Paid (RM)"].Value != null)
                                .Sum(row => Convert.ToDouble(row.Cells["Total Paid (RM)"].Value));

                            lblTotalBookings.Text = "Tickets Issued: " + totalBookings;
                            lblTotalRevenue.Text = "Total Sales: RM " + totalRevenue.ToString("N2");
                        }
                        else
                        {
                            // This is where your requested 'else' block goes
                            lblTotalBookings.Text = "Tickets Issued: 0";
                            lblTotalRevenue.Text = "Total Sales: RM 0.00";
                        }
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
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvTransactions.SelectedRows[0].Cells["Order ID"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to cancel and refund Order #{orderId}?", "Confirm Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    ExecuteRefund(orderId);
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction row from the grid first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Order marked as Refunded successfully!", "Refund Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactionHistory(); // Refresh grid view
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to process database refund update: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSeatingForm seatingForm = new AdminSeatingForm();
            seatingForm.Show();
            this.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.Rows.Count > 0)
            {
                try
                {
                    PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                    previewDialog.Document = printDocument1;
                    previewDialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Printing Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No data available to print.");
            }
        }
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Segoe UI", 18, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 10, FontStyle.Regular);

            g.DrawString("VIBECHECKS SYSTEM TRANSACTION LEDGER REPORT", titleFont, Brushes.DarkBlue, 50, 50);
            g.DrawString("Generated Date: " + DateTime.Now.ToString("dd MMM yyyy, hh:mm tt"), textFont, Brushes.Gray, 50, 85);
            g.DrawLine(Pens.Black, 50, 110, 750, 110);

            g.DrawString(lblTotalBookings.Text, headerFont, Brushes.Black, 50, 130);
            g.DrawString(lblTotalRevenue.Text, headerFont, Brushes.DarkGreen, 400, 130);
            g.DrawLine(Pens.LightGray, 50, 160, 750, 160);

            int yPos = 180;
            g.DrawString("ID", headerFont, Brushes.Black, 50, yPos);
            g.DrawString("Customer", headerFont, Brushes.Black, 120, yPos);
            g.DrawString("Date", headerFont, Brushes.Black, 280, yPos);
            g.DrawString("Amount", headerFont, Brushes.Black, 480, yPos);
            g.DrawString("Status", headerFont, Brushes.Black, 620, yPos);

            g.DrawLine(Pens.Black, 50, yPos + 25, 750, yPos + 25);
            yPos += 35;

            // Loop and draw transaction lines straight from data rows matrix onto paper
            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                if (row.IsNewRow) continue;

                g.DrawString(row.Cells["Order ID"].Value?.ToString() ?? "", textFont, Brushes.Black, 50, yPos);
                g.DrawString(row.Cells["Customer"].Value?.ToString() ?? "", textFont, Brushes.Black, 120, yPos);
                g.DrawString(Convert.ToDateTime(row.Cells["Booking Date"].Value).ToString("dd/MM/yyyy"), textFont, Brushes.Black, 280, yPos);
                g.DrawString("RM " + row.Cells["Total Paid (RM)"].Value?.ToString() ?? "0.00", textFont, Brushes.Black, 480, yPos);
                g.DrawString(row.Cells["Payment Status"].Value?.ToString() ?? "", textFont, Brushes.Black, 620, yPos);

                yPos += 25;
                if (yPos > 1000) break; // Safeguard limit to fit exactly on an A4 page canvas space
            }
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchCustomer.Text.Trim().ToLower();

            if (dgvTransactions.DataSource is DataTable dt)
            {
                // Rubric Trick: Using DataView row filters mimics advanced LINQ string matching!
                dt.DefaultView.RowFilter = string.Format("Customer LIKE '%{0}%' OR Convert([Order ID], 'System.String') LIKE '%{0}%'", filterText);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalRevenue_Click(object sender, EventArgs e)
        {

        }
    }
}

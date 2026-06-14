namespace STUBHUB_PROJECT
{
    partial class AdminTransactionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTransactionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.btnRefundBooking = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.pnlStatsSummary = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTotalBookings = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.pnlStatsSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(373, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Customer Booking and Transaction History";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvTransactions.Location = new System.Drawing.Point(252, 199);
            this.dgvTransactions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 24;
            this.dgvTransactions.Size = new System.Drawing.Size(866, 188);
            this.dgvTransactions.TabIndex = 5;
            // 
            // btnRefundBooking
            // 
            this.btnRefundBooking.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRefundBooking.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefundBooking.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefundBooking.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnRefundBooking.Location = new System.Drawing.Point(395, 588);
            this.btnRefundBooking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefundBooking.Name = "btnRefundBooking";
            this.btnRefundBooking.Size = new System.Drawing.Size(255, 55);
            this.btnRefundBooking.TabIndex = 6;
            this.btnRefundBooking.Text = "Refund / Cancel Order";
            this.btnRefundBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefundBooking.UseVisualStyleBackColor = false;
            this.btnRefundBooking.Click += new System.EventHandler(this.btnRefundBooking_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnExport.Location = new System.Drawing.Point(721, 588);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(166, 55);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Print Report";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(260, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search Customer:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Location = new System.Drawing.Point(460, 165);
            this.txtSearchCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(190, 26);
            this.txtSearchCustomer.TabIndex = 10;
            this.txtSearchCustomer.TextChanged += new System.EventHandler(this.txtSearchCustomer_TextChanged);
            // 
            // pnlStatsSummary
            // 
            this.pnlStatsSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlStatsSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlStatsSummary.Controls.Add(this.lblTotalRevenue);
            this.pnlStatsSummary.Controls.Add(this.lblTotalBookings);
            this.pnlStatsSummary.Location = new System.Drawing.Point(252, 424);
            this.pnlStatsSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlStatsSummary.Name = "pnlStatsSummary";
            this.pnlStatsSummary.Size = new System.Drawing.Size(866, 125);
            this.pnlStatsSummary.TabIndex = 13;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Transparent;
            this.lblTotalRevenue.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTotalRevenue.Location = new System.Drawing.Point(16, 74);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(246, 24);
            this.lblTotalRevenue.TabIndex = 16;
            this.lblTotalRevenue.Text = "Total Revenue: RM 0.00";
            this.lblTotalRevenue.Click += new System.EventHandler(this.lblTotalRevenue_Click);
            // 
            // lblTotalBookings
            // 
            this.lblTotalBookings.AutoSize = true;
            this.lblTotalBookings.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalBookings.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBookings.ForeColor = System.Drawing.Color.Transparent;
            this.lblTotalBookings.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTotalBookings.Location = new System.Drawing.Point(15, 39);
            this.lblTotalBookings.Name = "lblTotalBookings";
            this.lblTotalBookings.Size = new System.Drawing.Size(284, 24);
            this.lblTotalBookings.TabIndex = 15;
            this.lblTotalBookings.Text = "Settled Bookings: 0 Tickets";
            this.lblTotalBookings.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(267, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Live Sales Summary";
            // 
            // AdminTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlStatsSummary);
            this.Controls.Add(this.txtSearchCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRefundBooking);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminTransactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdmiTransactionsForm";
            this.Load += new System.EventHandler(this.AdminTransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.pnlStatsSummary.ResumeLayout(false);
            this.pnlStatsSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Button btnRefundBooking;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Panel pnlStatsSummary;
        private System.Windows.Forms.Label lblTotalBookings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
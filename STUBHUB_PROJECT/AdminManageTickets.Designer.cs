namespace STUBHUB_PROJECT
{
    partial class AdminManageTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManageTickets));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxTierName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTotalSeats = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonUploadTicket = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewTicketsOverview = new System.Windows.Forms.DataGridView();
            this.buttonDeleteTicket = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSubEventID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxEventID = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTicketsOverview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxTierName
            // 
            this.textBoxTierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTierName.Location = new System.Drawing.Point(41, 217);
            this.textBoxTierName.Name = "textBoxTierName";
            this.textBoxTierName.Size = new System.Drawing.Size(445, 30);
            this.textBoxTierName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tier Name";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrice.Location = new System.Drawing.Point(41, 291);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(445, 30);
            this.textBoxPrice.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price";
            // 
            // textBoxTotalSeats
            // 
            this.textBoxTotalSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalSeats.Location = new System.Drawing.Point(41, 356);
            this.textBoxTotalSeats.Name = "textBoxTotalSeats";
            this.textBoxTotalSeats.Size = new System.Drawing.Size(445, 30);
            this.textBoxTotalSeats.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Seats";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(521, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tickets Overview";
            // 
            // buttonUploadTicket
            // 
            this.buttonUploadTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUploadTicket.Location = new System.Drawing.Point(41, 569);
            this.buttonUploadTicket.Name = "buttonUploadTicket";
            this.buttonUploadTicket.Size = new System.Drawing.Size(151, 54);
            this.buttonUploadTicket.TabIndex = 9;
            this.buttonUploadTicket.Text = "Upload Ticket";
            this.buttonUploadTicket.UseVisualStyleBackColor = true;
            this.buttonUploadTicket.Click += new System.EventHandler(this.buttonUploadTicket_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(355, 569);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(151, 54);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridViewTicketsOverview
            // 
            this.dataGridViewTicketsOverview.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewTicketsOverview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewTicketsOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTicketsOverview.Location = new System.Drawing.Point(526, 65);
            this.dataGridViewTicketsOverview.Name = "dataGridViewTicketsOverview";
            this.dataGridViewTicketsOverview.RowHeadersWidth = 62;
            this.dataGridViewTicketsOverview.RowTemplate.Height = 28;
            this.dataGridViewTicketsOverview.Size = new System.Drawing.Size(678, 466);
            this.dataGridViewTicketsOverview.TabIndex = 11;
            this.dataGridViewTicketsOverview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTicketsOverview_CellClick);
            // 
            // buttonDeleteTicket
            // 
            this.buttonDeleteTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteTicket.Location = new System.Drawing.Point(198, 569);
            this.buttonDeleteTicket.Name = "buttonDeleteTicket";
            this.buttonDeleteTicket.Size = new System.Drawing.Size(151, 54);
            this.buttonDeleteTicket.TabIndex = 12;
            this.buttonDeleteTicket.Text = "Delete Ticket";
            this.buttonDeleteTicket.UseVisualStyleBackColor = true;
            this.buttonDeleteTicket.Click += new System.EventHandler(this.buttonDeleteTicket_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(36, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "Sub Event";
            // 
            // comboBoxSubEventID
            // 
            this.comboBoxSubEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSubEventID.FormattingEnabled = true;
            this.comboBoxSubEventID.Location = new System.Drawing.Point(41, 148);
            this.comboBoxSubEventID.Name = "comboBoxSubEventID";
            this.comboBoxSubEventID.Size = new System.Drawing.Size(445, 33);
            this.comboBoxSubEventID.TabIndex = 15;
            this.comboBoxSubEventID.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubEventID_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(36, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 29);
            this.label6.TabIndex = 16;
            this.label6.Text = "Event";
            // 
            // comboBoxEventID
            // 
            this.comboBoxEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEventID.FormattingEnabled = true;
            this.comboBoxEventID.Location = new System.Drawing.Point(41, 80);
            this.comboBoxEventID.Name = "comboBoxEventID";
            this.comboBoxEventID.Size = new System.Drawing.Size(445, 33);
            this.comboBoxEventID.TabIndex = 17;
            this.comboBoxEventID.SelectedIndexChanged += new System.EventHandler(this.comboBoxEventID_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.comboBoxEventID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxSubEventID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.buttonDeleteTicket);
            this.panel1.Controls.Add(this.dataGridViewTicketsOverview);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonUploadTicket);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxTotalSeats);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxPrice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxTierName);
            this.panel1.Location = new System.Drawing.Point(52, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 651);
            this.panel1.TabIndex = 0;
            // 
            // AdminManageTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "AdminManageTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminAddEvent";
            this.Load += new System.EventHandler(this.AdminManageTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTicketsOverview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxTierName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotalSeats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonUploadTicket;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewTicketsOverview;
        private System.Windows.Forms.Button buttonDeleteTicket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSubEventID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxEventID;
        private System.Windows.Forms.Panel panel1;
    }
}
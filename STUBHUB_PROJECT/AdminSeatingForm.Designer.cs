namespace STUBHUB_PROJECT
{
    partial class AdminSeatingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSeatingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTicketTiers = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketTiers)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(642, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Event to Configure Seating and Pricing";
            // 
            // dgvTicketTiers
            // 
            this.dgvTicketTiers.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvTicketTiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTicketTiers.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dgvTicketTiers.Location = new System.Drawing.Point(254, 212);
            this.dgvTicketTiers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTicketTiers.Name = "dgvTicketTiers";
            this.dgvTicketTiers.RowHeadersWidth = 51;
            this.dgvTicketTiers.RowTemplate.Height = 24;
            this.dgvTicketTiers.Size = new System.Drawing.Size(832, 310);
            this.dgvTicketTiers.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.MidnightBlue;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Concert",
            "Football"});
            this.comboBox1.Location = new System.Drawing.Point(254, 161);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(301, 28);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.MidnightBlue;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.AliceBlue;
            this.button7.Location = new System.Drawing.Point(474, 545);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(179, 55);
            this.button7.TabIndex = 5;
            this.button7.Text = "Save Settings";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.MidnightBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.AliceBlue;
            this.button6.Location = new System.Drawing.Point(691, 545);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(179, 55);
            this.button6.TabIndex = 6;
            this.button6.Text = "Refresh Data";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AdminSeatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dgvTicketTiers);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminSeatingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminSeatingForm";
            this.Load += new System.EventHandler(this.AdminSeatingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketTiers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTicketTiers;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
    }
}
namespace STUBHUB_PROJECT
{
    partial class EventForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventForm));
            this.labelEvent = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTicketCounter = new System.Windows.Forms.Label();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelEvent
            // 
            this.labelEvent.AutoSize = true;
            this.labelEvent.BackColor = System.Drawing.Color.Transparent;
            this.labelEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelEvent.Location = new System.Drawing.Point(393, 108);
            this.labelEvent.Name = "labelEvent";
            this.labelEvent.Size = new System.Drawing.Size(548, 52);
            this.labelEvent.TabIndex = 22;
            this.labelEvent.Text = "Upcoming Foot Ball Events";
            this.labelEvent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-4, 162);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1346, 659);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // labelTicketCounter
            // 
            this.labelTicketCounter.AutoSize = true;
            this.labelTicketCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelTicketCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketCounter.ForeColor = System.Drawing.Color.White;
            this.labelTicketCounter.Location = new System.Drawing.Point(1131, 54);
            this.labelTicketCounter.Name = "labelTicketCounter";
            this.labelTicketCounter.Size = new System.Drawing.Size(30, 32);
            this.labelTicketCounter.TabIndex = 29;
            this.labelTicketCounter.Text = "0";
            // 
            // inventoryButton
            // 
            this.inventoryButton.BackColor = System.Drawing.Color.Transparent;
            this.inventoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.inventoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryButton.ForeColor = System.Drawing.Color.White;
            this.inventoryButton.Location = new System.Drawing.Point(1167, 48);
            this.inventoryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.inventoryButton.Size = new System.Drawing.Size(125, 42);
            this.inventoryButton.TabIndex = 28;
            this.inventoryButton.Text = "Inventory";
            this.inventoryButton.UseVisualStyleBackColor = false;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 818);
            this.Controls.Add(this.labelTicketCounter);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.inventoryButton);
            this.Controls.Add(this.labelEvent);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventForm";
            this.Activated += new System.EventHandler(this.EventForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EventForm_FormClosed);
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelEvent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelTicketCounter;
        private System.Windows.Forms.Button inventoryButton;
    }
}
namespace STUBHUB_PROJECT
{
    partial class InventoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            this.flowLayoutPanelCart = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.LblLocation = new System.Windows.Forms.Label();
            this.pictureBoxEvent = new System.Windows.Forms.PictureBox();
            this.LblSubEventName = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.flowLayoutPanelCart.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCart
            // 
            this.flowLayoutPanelCart.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelCart.Controls.Add(this.panel2);
            this.flowLayoutPanelCart.Location = new System.Drawing.Point(45, 191);
            this.flowLayoutPanelCart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelCart.Name = "flowLayoutPanelCart";
            this.flowLayoutPanelCart.Size = new System.Drawing.Size(1244, 611);
            this.flowLayoutPanelCart.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.LblLocation);
            this.panel2.Controls.Add(this.pictureBoxEvent);
            this.panel2.Controls.Add(this.LblSubEventName);
            this.panel2.Controls.Add(this.LblDate);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1241, 120);
            this.panel2.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1028, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 76);
            this.button1.TabIndex = 20;
            this.button1.Text = "View Ticket(s)";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblLocation.Location = new System.Drawing.Point(173, 69);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(78, 22);
            this.LblLocation.TabIndex = 18;
            this.LblLocation.Text = "Location";
            // 
            // pictureBoxEvent
            // 
            this.pictureBoxEvent.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxEvent.Location = new System.Drawing.Point(25, 20);
            this.pictureBoxEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxEvent.Name = "pictureBoxEvent";
            this.pictureBoxEvent.Size = new System.Drawing.Size(136, 71);
            this.pictureBoxEvent.TabIndex = 19;
            this.pictureBoxEvent.TabStop = false;
            // 
            // LblSubEventName
            // 
            this.LblSubEventName.AutoSize = true;
            this.LblSubEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubEventName.Location = new System.Drawing.Point(168, 15);
            this.LblSubEventName.Name = "LblSubEventName";
            this.LblSubEventName.Size = new System.Drawing.Size(154, 29);
            this.LblSubEventName.TabIndex = 15;
            this.LblSubEventName.Text = "Event Name";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblDate.Location = new System.Drawing.Point(173, 46);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(48, 22);
            this.LblDate.TabIndex = 16;
            this.LblDate.Text = "Date";
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 818);
            this.Controls.Add(this.flowLayoutPanelCart);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCart";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyCart_FormClosed);
            this.Load += new System.EventHandler(this.MyCart_Load);
            this.flowLayoutPanelCart.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Label LblSubEventName;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.PictureBox pictureBoxEvent;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
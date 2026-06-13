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
            this.buttonCart = new System.Windows.Forms.Button();
            this.labelEvent = new System.Windows.Forms.Label();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonEvents = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // buttonCart
            // 
            this.buttonCart.BackColor = System.Drawing.Color.Transparent;
            this.buttonCart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCart.BackgroundImage")));
            this.buttonCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCart.Location = new System.Drawing.Point(1224, 39);
            this.buttonCart.Name = "buttonCart";
            this.buttonCart.Size = new System.Drawing.Size(54, 42);
            this.buttonCart.TabIndex = 18;
            this.buttonCart.UseVisualStyleBackColor = false;
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
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Transparent;
            this.buttonHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.Transparent;
            this.buttonHome.Location = new System.Drawing.Point(48, 41);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(91, 42);
            this.buttonHome.TabIndex = 19;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = false;
            // 
            // buttonEvents
            // 
            this.buttonEvents.BackColor = System.Drawing.Color.Transparent;
            this.buttonEvents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEvents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEvents.ForeColor = System.Drawing.Color.Transparent;
            this.buttonEvents.Location = new System.Drawing.Point(145, 41);
            this.buttonEvents.Name = "buttonEvents";
            this.buttonEvents.Size = new System.Drawing.Size(102, 42);
            this.buttonEvents.TabIndex = 20;
            this.buttonEvents.Text = "Events";
            this.buttonEvents.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-4, 163);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1345, 659);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelEvent);
            this.Controls.Add(this.buttonEvents);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonCart);
            this.DoubleBuffered = true;
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EventForm_FormClosed);
            this.Load += new System.EventHandler(this.EventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCart;
        private System.Windows.Forms.Label labelEvent;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonEvents;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
namespace STUBHUB_PROJECT
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.TicketPanel = new System.Windows.Forms.Panel();
            this.FindTicketButton = new System.Windows.Forms.Button();
            this.DateButton = new System.Windows.Forms.Button();
            this.ChooseEventButton = new System.Windows.Forms.Button();
            this.buttonCart = new System.Windows.Forms.Button();
            this.dateTimePickerTicket = new System.Windows.Forms.DateTimePicker();
            this.comboBoxEvents = new System.Windows.Forms.ComboBox();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonEvents = new System.Windows.Forms.Button();
            this.TicketPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TicketPanel
            // 
            this.TicketPanel.BackColor = System.Drawing.Color.Transparent;
            this.TicketPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TicketPanel.BackgroundImage")));
            this.TicketPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TicketPanel.Controls.Add(this.FindTicketButton);
            this.TicketPanel.Controls.Add(this.DateButton);
            this.TicketPanel.Controls.Add(this.ChooseEventButton);
            this.TicketPanel.Location = new System.Drawing.Point(312, 314);
            this.TicketPanel.Name = "TicketPanel";
            this.TicketPanel.Size = new System.Drawing.Size(691, 54);
            this.TicketPanel.TabIndex = 0;
            // 
            // FindTicketButton
            // 
            this.FindTicketButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.FindTicketButton.ForeColor = System.Drawing.Color.Transparent;
            this.FindTicketButton.Location = new System.Drawing.Point(527, 0);
            this.FindTicketButton.Name = "FindTicketButton";
            this.FindTicketButton.Size = new System.Drawing.Size(164, 54);
            this.FindTicketButton.TabIndex = 2;
            this.FindTicketButton.Text = "Find Ticket";
            this.FindTicketButton.UseVisualStyleBackColor = false;
            this.FindTicketButton.Click += new System.EventHandler(this.FindTicketButton_Click);
            // 
            // DateButton
            // 
            this.DateButton.Location = new System.Drawing.Point(362, 0);
            this.DateButton.Name = "DateButton";
            this.DateButton.Size = new System.Drawing.Size(116, 54);
            this.DateButton.TabIndex = 1;
            this.DateButton.Text = "Date";
            this.DateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DateButton.UseVisualStyleBackColor = true;
            this.DateButton.Click += new System.EventHandler(this.DateButton_Click);
            // 
            // ChooseEventButton
            // 
            this.ChooseEventButton.Location = new System.Drawing.Point(46, 0);
            this.ChooseEventButton.Name = "ChooseEventButton";
            this.ChooseEventButton.Size = new System.Drawing.Size(220, 54);
            this.ChooseEventButton.TabIndex = 0;
            this.ChooseEventButton.Text = "Choose your event";
            this.ChooseEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChooseEventButton.UseVisualStyleBackColor = true;
            this.ChooseEventButton.Click += new System.EventHandler(this.ChooseEventButton_Click);
            // 
            // buttonCart
            // 
            this.buttonCart.BackColor = System.Drawing.Color.Transparent;
            this.buttonCart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCart.BackgroundImage")));
            this.buttonCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCart.Location = new System.Drawing.Point(1230, 41);
            this.buttonCart.Name = "buttonCart";
            this.buttonCart.Size = new System.Drawing.Size(54, 42);
            this.buttonCart.TabIndex = 21;
            this.buttonCart.UseVisualStyleBackColor = false;
            // 
            // dateTimePickerTicket
            // 
            this.dateTimePickerTicket.Location = new System.Drawing.Point(628, 374);
            this.dateTimePickerTicket.Name = "dateTimePickerTicket";
            this.dateTimePickerTicket.Size = new System.Drawing.Size(302, 26);
            this.dateTimePickerTicket.TabIndex = 24;
            this.dateTimePickerTicket.Visible = false;
            // 
            // comboBoxEvents
            // 
            this.comboBoxEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEvents.FormattingEnabled = true;
            this.comboBoxEvents.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g"});
            this.comboBoxEvents.Location = new System.Drawing.Point(312, 374);
            this.comboBoxEvents.Name = "comboBoxEvents";
            this.comboBoxEvents.Size = new System.Drawing.Size(310, 28);
            this.comboBoxEvents.TabIndex = 26;
            this.comboBoxEvents.Visible = false;
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
            this.buttonHome.TabIndex = 22;
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
            this.buttonEvents.Location = new System.Drawing.Point(151, 41);
            this.buttonEvents.Name = "buttonEvents";
            this.buttonEvents.Size = new System.Drawing.Size(102, 42);
            this.buttonEvents.TabIndex = 23;
            this.buttonEvents.Text = "Events";
            this.buttonEvents.UseVisualStyleBackColor = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.comboBoxEvents);
            this.Controls.Add(this.dateTimePickerTicket);
            this.Controls.Add(this.buttonEvents);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonCart);
            this.Controls.Add(this.TicketPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.TicketPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TicketPanel;
        private System.Windows.Forms.Button FindTicketButton;
        private System.Windows.Forms.Button DateButton;
        private System.Windows.Forms.Button ChooseEventButton;
        private System.Windows.Forms.Button buttonCart;
        private System.Windows.Forms.DateTimePicker dateTimePickerTicket;
        private System.Windows.Forms.ComboBox comboBoxEvents;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonEvents;
    }
}
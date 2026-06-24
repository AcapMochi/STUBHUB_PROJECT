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
            this.inventoryButton = new System.Windows.Forms.Button();
            this.dateTimePickerTicket = new System.Windows.Forms.DateTimePicker();
            this.comboBoxEvents = new System.Windows.Forms.ComboBox();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelTicketCounter = new System.Windows.Forms.Label();
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
            this.TicketPanel.Location = new System.Drawing.Point(277, 251);
            this.TicketPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TicketPanel.Name = "TicketPanel";
            this.TicketPanel.Size = new System.Drawing.Size(614, 43);
            this.TicketPanel.TabIndex = 0;
            // 
            // FindTicketButton
            // 
            this.FindTicketButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.FindTicketButton.ForeColor = System.Drawing.Color.Transparent;
            this.FindTicketButton.Location = new System.Drawing.Point(468, 0);
            this.FindTicketButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FindTicketButton.Name = "FindTicketButton";
            this.FindTicketButton.Size = new System.Drawing.Size(146, 43);
            this.FindTicketButton.TabIndex = 2;
            this.FindTicketButton.Text = "Find Ticket";
            this.FindTicketButton.UseVisualStyleBackColor = false;
            this.FindTicketButton.Click += new System.EventHandler(this.FindTicketButton_Click);
            // 
            // DateButton
            // 
            this.DateButton.Location = new System.Drawing.Point(322, 0);
            this.DateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateButton.Name = "DateButton";
            this.DateButton.Size = new System.Drawing.Size(103, 43);
            this.DateButton.TabIndex = 1;
            this.DateButton.Text = "Date";
            this.DateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DateButton.UseVisualStyleBackColor = true;
            this.DateButton.Click += new System.EventHandler(this.DateButton_Click);
            // 
            // ChooseEventButton
            // 
            this.ChooseEventButton.Location = new System.Drawing.Point(41, 0);
            this.ChooseEventButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChooseEventButton.Name = "ChooseEventButton";
            this.ChooseEventButton.Size = new System.Drawing.Size(196, 43);
            this.ChooseEventButton.TabIndex = 0;
            this.ChooseEventButton.Text = "Choose your event";
            this.ChooseEventButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChooseEventButton.UseVisualStyleBackColor = true;
            this.ChooseEventButton.Click += new System.EventHandler(this.ChooseEventButton_Click);
            // 
            // inventoryButton
            // 
            this.inventoryButton.BackColor = System.Drawing.Color.Transparent;
            this.inventoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.inventoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryButton.ForeColor = System.Drawing.Color.White;
            this.inventoryButton.Location = new System.Drawing.Point(1030, 33);
            this.inventoryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(111, 34);
            this.inventoryButton.TabIndex = 21;
            this.inventoryButton.Text = "Inventory";
            this.inventoryButton.UseVisualStyleBackColor = false;
            this.inventoryButton.Click += new System.EventHandler(this.buttonCart_Click);
            // 
            // dateTimePickerTicket
            // 
            this.dateTimePickerTicket.Location = new System.Drawing.Point(558, 299);
            this.dateTimePickerTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerTicket.Name = "dateTimePickerTicket";
            this.dateTimePickerTicket.Size = new System.Drawing.Size(269, 22);
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
            this.comboBoxEvents.Location = new System.Drawing.Point(277, 299);
            this.comboBoxEvents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEvents.Name = "comboBoxEvents";
            this.comboBoxEvents.Size = new System.Drawing.Size(276, 24);
            this.comboBoxEvents.TabIndex = 26;
            this.comboBoxEvents.Visible = false;
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOut.ForeColor = System.Drawing.Color.Transparent;
            this.buttonLogOut.Location = new System.Drawing.Point(43, 33);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(117, 34);
            this.buttonLogOut.TabIndex = 22;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // labelTicketCounter
            // 
            this.labelTicketCounter.AutoSize = true;
            this.labelTicketCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelTicketCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketCounter.ForeColor = System.Drawing.Color.White;
            this.labelTicketCounter.Location = new System.Drawing.Point(998, 38);
            this.labelTicketCounter.Name = "labelTicketCounter";
            this.labelTicketCounter.Size = new System.Drawing.Size(26, 29);
            this.labelTicketCounter.TabIndex = 27;
            this.labelTicketCounter.Text = "0";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1190, 654);
            this.Controls.Add(this.labelTicketCounter);
            this.Controls.Add(this.comboBoxEvents);
            this.Controls.Add(this.dateTimePickerTicket);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.inventoryButton);
            this.Controls.Add(this.TicketPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.Activated += new System.EventHandler(this.MainMenu_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.TicketPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TicketPanel;
        private System.Windows.Forms.Button FindTicketButton;
        private System.Windows.Forms.Button DateButton;
        private System.Windows.Forms.Button ChooseEventButton;
        private System.Windows.Forms.Button inventoryButton;
        private System.Windows.Forms.DateTimePicker dateTimePickerTicket;
        private System.Windows.Forms.ComboBox comboBoxEvents;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Label labelTicketCounter;
    }
}
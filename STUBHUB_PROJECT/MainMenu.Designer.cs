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
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.TicketPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.TicketPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TicketPanel;
        private System.Windows.Forms.Button FindTicketButton;
        private System.Windows.Forms.Button DateButton;
        private System.Windows.Forms.Button ChooseEventButton;
    }
}
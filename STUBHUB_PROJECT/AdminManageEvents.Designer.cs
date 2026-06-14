namespace STUBHUB_PROJECT
{
    partial class AdminManageEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManageEvents));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDeleteEvent = new System.Windows.Forms.Button();
            this.buttonEditEvent = new System.Windows.Forms.Button();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.buttonManageSubEvents = new System.Windows.Forms.Button();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.buttonManageTickets = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.buttonDeleteEvent);
            this.panel1.Controls.Add(this.buttonEditEvent);
            this.panel1.Controls.Add(this.buttonAddEvent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 817);
            this.panel1.TabIndex = 1;
            // 
            // buttonDeleteEvent
            // 
            this.buttonDeleteEvent.BackColor = System.Drawing.Color.Navy;
            this.buttonDeleteEvent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteEvent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteEvent.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonDeleteEvent.Location = new System.Drawing.Point(38, 353);
            this.buttonDeleteEvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDeleteEvent.Name = "buttonDeleteEvent";
            this.buttonDeleteEvent.Size = new System.Drawing.Size(307, 74);
            this.buttonDeleteEvent.TabIndex = 3;
            this.buttonDeleteEvent.Text = "Delete Event";
            this.buttonDeleteEvent.UseVisualStyleBackColor = false;
            this.buttonDeleteEvent.Click += new System.EventHandler(this.buttonDeleteEvent_Click);
            // 
            // buttonEditEvent
            // 
            this.buttonEditEvent.BackColor = System.Drawing.Color.Navy;
            this.buttonEditEvent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEditEvent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditEvent.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonEditEvent.Location = new System.Drawing.Point(38, 251);
            this.buttonEditEvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEditEvent.Name = "buttonEditEvent";
            this.buttonEditEvent.Size = new System.Drawing.Size(307, 74);
            this.buttonEditEvent.TabIndex = 2;
            this.buttonEditEvent.Text = "Edit Event";
            this.buttonEditEvent.UseVisualStyleBackColor = false;
            this.buttonEditEvent.Click += new System.EventHandler(this.buttonEditEvent_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.BackColor = System.Drawing.Color.Navy;
            this.buttonAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddEvent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddEvent.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonAddEvent.Location = new System.Drawing.Point(38, 151);
            this.buttonAddEvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(307, 74);
            this.buttonAddEvent.TabIndex = 1;
            this.buttonAddEvent.Text = "Add Event";
            this.buttonAddEvent.UseVisualStyleBackColor = false;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // buttonManageSubEvents
            // 
            this.buttonManageSubEvents.BackColor = System.Drawing.Color.Navy;
            this.buttonManageSubEvents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonManageSubEvents.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageSubEvents.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonManageSubEvents.Location = new System.Drawing.Point(538, 589);
            this.buttonManageSubEvents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonManageSubEvents.Name = "buttonManageSubEvents";
            this.buttonManageSubEvents.Size = new System.Drawing.Size(310, 55);
            this.buttonManageSubEvents.TabIndex = 2;
            this.buttonManageSubEvents.Text = "Manage SubEvents";
            this.buttonManageSubEvents.UseVisualStyleBackColor = false;
            this.buttonManageSubEvents.Click += new System.EventHandler(this.buttonManageSubEvents_Click);
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Location = new System.Drawing.Point(441, 151);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.RowHeadersWidth = 62;
            this.dataGridViewEvents.RowTemplate.Height = 28;
            this.dataGridViewEvents.Size = new System.Drawing.Size(831, 419);
            this.dataGridViewEvents.TabIndex = 2;
            // 
            // buttonManageTickets
            // 
            this.buttonManageTickets.BackColor = System.Drawing.Color.Navy;
            this.buttonManageTickets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonManageTickets.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageTickets.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonManageTickets.Location = new System.Drawing.Point(876, 589);
            this.buttonManageTickets.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonManageTickets.Name = "buttonManageTickets";
            this.buttonManageTickets.Size = new System.Drawing.Size(287, 55);
            this.buttonManageTickets.TabIndex = 4;
            this.buttonManageTickets.Text = "Manage Tickets";
            this.buttonManageTickets.UseVisualStyleBackColor = false;
            this.buttonManageTickets.Click += new System.EventHandler(this.buttonManageTickets_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(436, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Events List";
            // 
            // AdminManageEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonManageTickets);
            this.Controls.Add(this.buttonManageSubEvents);
            this.Controls.Add(this.dataGridViewEvents);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "AdminManageEvents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminManageEvents";
            this.Activated += new System.EventHandler(this.AdminManageEvents_Activated);
            this.Load += new System.EventHandler(this.AdminManageEvents_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonManageSubEvents;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.Button buttonDeleteEvent;
        private System.Windows.Forms.Button buttonEditEvent;
        private System.Windows.Forms.Button buttonManageTickets;
        private System.Windows.Forms.Label label1;
    }
}
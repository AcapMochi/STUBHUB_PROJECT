namespace STUBHUB_PROJECT
{
    partial class FormAdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAdminProfile = new System.Windows.Forms.Button();
            this.buttonUserAccounts = new System.Windows.Forms.Button();
            this.buttonTandB = new System.Windows.Forms.Button();
            this.buttonSandP = new System.Windows.Forms.Button();
            this.buttonManageEvents = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEventsOverview = new System.Windows.Forms.DataGridView();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventsOverview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLogOut);
            this.panel1.Controls.Add(this.buttonAdminProfile);
            this.panel1.Controls.Add(this.buttonUserAccounts);
            this.panel1.Controls.Add(this.buttonTandB);
            this.panel1.Controls.Add(this.buttonSandP);
            this.panel1.Controls.Add(this.buttonManageEvents);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 817);
            this.panel1.TabIndex = 0;
            // 
            // buttonAdminProfile
            // 
            this.buttonAdminProfile.BackColor = System.Drawing.Color.Navy;
            this.buttonAdminProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAdminProfile.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdminProfile.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonAdminProfile.Location = new System.Drawing.Point(68, 641);
            this.buttonAdminProfile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAdminProfile.Name = "buttonAdminProfile";
            this.buttonAdminProfile.Size = new System.Drawing.Size(234, 61);
            this.buttonAdminProfile.TabIndex = 2;
            this.buttonAdminProfile.Text = "Admin Profile";
            this.buttonAdminProfile.UseVisualStyleBackColor = false;
            this.buttonAdminProfile.Click += new System.EventHandler(this.buttonAdminProfile_Click);
            // 
            // buttonUserAccounts
            // 
            this.buttonUserAccounts.BackColor = System.Drawing.Color.Navy;
            this.buttonUserAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUserAccounts.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUserAccounts.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonUserAccounts.Location = new System.Drawing.Point(38, 454);
            this.buttonUserAccounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonUserAccounts.Name = "buttonUserAccounts";
            this.buttonUserAccounts.Size = new System.Drawing.Size(307, 74);
            this.buttonUserAccounts.TabIndex = 4;
            this.buttonUserAccounts.Text = "User Accounts";
            this.buttonUserAccounts.UseVisualStyleBackColor = false;
            this.buttonUserAccounts.Click += new System.EventHandler(this.buttonUserAccounts_Click);
            // 
            // buttonTandB
            // 
            this.buttonTandB.BackColor = System.Drawing.Color.Navy;
            this.buttonTandB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTandB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTandB.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonTandB.Location = new System.Drawing.Point(38, 349);
            this.buttonTandB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonTandB.Name = "buttonTandB";
            this.buttonTandB.Size = new System.Drawing.Size(307, 85);
            this.buttonTandB.TabIndex = 3;
            this.buttonTandB.Text = "Transactions and Bookings";
            this.buttonTandB.UseVisualStyleBackColor = false;
            this.buttonTandB.Click += new System.EventHandler(this.buttonTandB_Click);
            // 
            // buttonSandP
            // 
            this.buttonSandP.BackColor = System.Drawing.Color.Navy;
            this.buttonSandP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSandP.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSandP.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonSandP.Location = new System.Drawing.Point(38, 251);
            this.buttonSandP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSandP.Name = "buttonSandP";
            this.buttonSandP.Size = new System.Drawing.Size(307, 74);
            this.buttonSandP.TabIndex = 2;
            this.buttonSandP.Text = "Seating and  Pricing";
            this.buttonSandP.UseVisualStyleBackColor = false;
            this.buttonSandP.Click += new System.EventHandler(this.buttonSandP_Click);
            // 
            // buttonManageEvents
            // 
            this.buttonManageEvents.BackColor = System.Drawing.Color.Navy;
            this.buttonManageEvents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonManageEvents.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageEvents.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonManageEvents.Location = new System.Drawing.Point(38, 151);
            this.buttonManageEvents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonManageEvents.Name = "buttonManageEvents";
            this.buttonManageEvents.Size = new System.Drawing.Size(307, 74);
            this.buttonManageEvents.TabIndex = 1;
            this.buttonManageEvents.Text = "Manage Events";
            this.buttonManageEvents.UseVisualStyleBackColor = false;
            this.buttonManageEvents.Click += new System.EventHandler(this.buttonManageEvents_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(439, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Events Overview";
            // 
            // dgvEventsOverview
            // 
            this.dgvEventsOverview.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dgvEventsOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventsOverview.Location = new System.Drawing.Point(446, 285);
            this.dgvEventsOverview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEventsOverview.Name = "dgvEventsOverview";
            this.dgvEventsOverview.RowHeadersWidth = 51;
            this.dgvEventsOverview.RowTemplate.Height = 24;
            this.dgvEventsOverview.Size = new System.Drawing.Size(875, 242);
            this.dgvEventsOverview.TabIndex = 2;
            this.dgvEventsOverview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEventsOverview_CellContentClick);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.Navy;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEdit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonEdit.Location = new System.Drawing.Point(718, 569);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(133, 55);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Navy;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDelete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonDelete.Location = new System.Drawing.Point(909, 569);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(140, 55);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.Color.Navy;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogOut.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOut.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonLogOut.Location = new System.Drawing.Point(68, 722);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(234, 61);
            this.buttonLogOut.TabIndex = 5;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // FormAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.dgvEventsOverview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAdminDashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdminDashboard_FormClosed);
            this.Load += new System.EventHandler(this.FormAdminDashboard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventsOverview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonManageEvents;
        private System.Windows.Forms.Button buttonAdminProfile;
        private System.Windows.Forms.Button buttonUserAccounts;
        private System.Windows.Forms.Button buttonTandB;
        private System.Windows.Forms.Button buttonSandP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEventsOverview;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonLogOut;
    }
}
namespace STUBHUB_PROJECT
{
    partial class AdminManageSubEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManageSubEvent));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxVenue = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerVenue = new System.Windows.Forms.DateTimePicker();
            this.buttonDeleteSubEvent = new System.Windows.Forms.Button();
            this.dataGridViewSubEvents = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUploadSubEvent = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSubEventTitle = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.comboBoxVenue);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePickerVenue);
            this.panel1.Controls.Add(this.buttonDeleteSubEvent);
            this.panel1.Controls.Add(this.dataGridViewSubEvents);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonUploadSubEvent);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxSubEventTitle);
            this.panel1.Location = new System.Drawing.Point(52, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 651);
            this.panel1.TabIndex = 1;
            // 
            // comboBoxVenue
            // 
            this.comboBoxVenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVenue.FormattingEnabled = true;
            this.comboBoxVenue.Location = new System.Drawing.Point(41, 130);
            this.comboBoxVenue.Name = "comboBoxVenue";
            this.comboBoxVenue.Size = new System.Drawing.Size(445, 33);
            this.comboBoxVenue.TabIndex = 17;
            this.comboBoxVenue.Text = "Venue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(36, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "Venue";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Scheduled",
            "Completed",
            "Cancelled"});
            this.comboBoxStatus.Location = new System.Drawing.Point(41, 258);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(445, 33);
            this.comboBoxStatus.TabIndex = 15;
            this.comboBoxStatus.Text = "Scheduled";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Status";
            // 
            // dateTimePickerVenue
            // 
            this.dateTimePickerVenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerVenue.Location = new System.Drawing.Point(41, 198);
            this.dateTimePickerVenue.Name = "dateTimePickerVenue";
            this.dateTimePickerVenue.Size = new System.Drawing.Size(445, 30);
            this.dateTimePickerVenue.TabIndex = 13;
            // 
            // buttonDeleteSubEvent
            // 
            this.buttonDeleteSubEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteSubEvent.Location = new System.Drawing.Point(198, 569);
            this.buttonDeleteSubEvent.Name = "buttonDeleteSubEvent";
            this.buttonDeleteSubEvent.Size = new System.Drawing.Size(151, 54);
            this.buttonDeleteSubEvent.TabIndex = 12;
            this.buttonDeleteSubEvent.Text = "Delete SubEvent";
            this.buttonDeleteSubEvent.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSubEvents
            // 
            this.dataGridViewSubEvents.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewSubEvents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSubEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubEvents.Location = new System.Drawing.Point(526, 65);
            this.dataGridViewSubEvents.Name = "dataGridViewSubEvents";
            this.dataGridViewSubEvents.RowHeadersWidth = 62;
            this.dataGridViewSubEvents.RowTemplate.Height = 28;
            this.dataGridViewSubEvents.Size = new System.Drawing.Size(678, 466);
            this.dataGridViewSubEvents.TabIndex = 11;
            this.dataGridViewSubEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSubEvents_CellClick);
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
            // buttonUploadSubEvent
            // 
            this.buttonUploadSubEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUploadSubEvent.Location = new System.Drawing.Point(41, 569);
            this.buttonUploadSubEvent.Name = "buttonUploadSubEvent";
            this.buttonUploadSubEvent.Size = new System.Drawing.Size(151, 54);
            this.buttonUploadSubEvent.TabIndex = 9;
            this.buttonUploadSubEvent.Text = "Upload SubEvent";
            this.buttonUploadSubEvent.UseVisualStyleBackColor = true;
            this.buttonUploadSubEvent.Click += new System.EventHandler(this.buttonUploadSubEvent_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(521, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "SubEvents Overview";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Event Date Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sub Event Title";
            // 
            // textBoxSubEventTitle
            // 
            this.textBoxSubEventTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubEventTitle.Location = new System.Drawing.Point(41, 65);
            this.textBoxSubEventTitle.Name = "textBoxSubEventTitle";
            this.textBoxSubEventTitle.Size = new System.Drawing.Size(445, 30);
            this.textBoxSubEventTitle.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AdminManageSubEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "AdminManageSubEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminManageSubEvent";
            this.Load += new System.EventHandler(this.AdminManageSubEvent_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDeleteSubEvent;
        private System.Windows.Forms.DataGridView dataGridViewSubEvents;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUploadSubEvent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSubEventTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DateTimePicker dateTimePickerVenue;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxVenue;
        private System.Windows.Forms.Label label5;
    }
}
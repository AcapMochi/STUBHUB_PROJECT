namespace STUBHUB_PROJECT
{
    partial class CheckoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckoutForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RadBtnCredit = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelCardUsername = new System.Windows.Forms.Label();
            this.BtnContinueCheckout = new System.Windows.Forms.Button();
            this.buttonAddCard = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBoxCheckout = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblLocation = new System.Windows.Forms.Label();
            this.LblSubEventName = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblVIPAmount = new System.Windows.Forms.Label();
            this.LblVIPTicket = new System.Windows.Forms.Label();
            this.LblTotalPrice = new System.Windows.Forms.Label();
            this.LblPremiumAmount = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.LblPremiumTicket = new System.Windows.Forms.Label();
            this.LblBasicTicket = new System.Windows.Forms.Label();
            this.LblBasicAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCheckout)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(63, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 61);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(190, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 29);
            this.label4.TabIndex = 42;
            this.label4.Text = "Credit / Debit card";
            // 
            // RadBtnCredit
            // 
            this.RadBtnCredit.AutoSize = true;
            this.RadBtnCredit.Enabled = false;
            this.RadBtnCredit.ForeColor = System.Drawing.Color.DodgerBlue;
            this.RadBtnCredit.Location = new System.Drawing.Point(22, 32);
            this.RadBtnCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RadBtnCredit.Name = "RadBtnCredit";
            this.RadBtnCredit.Size = new System.Drawing.Size(21, 20);
            this.RadBtnCredit.TabIndex = 43;
            this.RadBtnCredit.TabStop = true;
            this.RadBtnCredit.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.labelCardUsername);
            this.panel3.Controls.Add(this.RadBtnCredit);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(50, 200);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(708, 92);
            this.panel3.TabIndex = 36;
            // 
            // labelCardUsername
            // 
            this.labelCardUsername.AutoSize = true;
            this.labelCardUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCardUsername.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelCardUsername.Location = new System.Drawing.Point(192, 52);
            this.labelCardUsername.Name = "labelCardUsername";
            this.labelCardUsername.Size = new System.Drawing.Size(158, 22);
            this.labelCardUsername.TabIndex = 44;
            this.labelCardUsername.Text = "Card User Name";
            // 
            // BtnContinueCheckout
            // 
            this.BtnContinueCheckout.BackColor = System.Drawing.Color.BlueViolet;
            this.BtnContinueCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContinueCheckout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnContinueCheckout.Location = new System.Drawing.Point(50, 688);
            this.BtnContinueCheckout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnContinueCheckout.Name = "BtnContinueCheckout";
            this.BtnContinueCheckout.Size = new System.Drawing.Size(710, 89);
            this.BtnContinueCheckout.TabIndex = 45;
            this.BtnContinueCheckout.Text = "Continue";
            this.BtnContinueCheckout.UseVisualStyleBackColor = false;
            this.BtnContinueCheckout.Click += new System.EventHandler(this.BtnContinueCheckout_Click);
            // 
            // buttonAddCard
            // 
            this.buttonAddCard.BackColor = System.Drawing.Color.White;
            this.buttonAddCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAddCard.Location = new System.Drawing.Point(50, 315);
            this.buttonAddCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddCard.Name = "buttonAddCard";
            this.buttonAddCard.Size = new System.Drawing.Size(710, 89);
            this.buttonAddCard.TabIndex = 46;
            this.buttonAddCard.Text = "+  Add";
            this.buttonAddCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddCard.UseVisualStyleBackColor = false;
            this.buttonAddCard.Click += new System.EventHandler(this.buttonAddCard_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.pictureBoxCheckout);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.LblLocation);
            this.panel5.Controls.Add(this.LblSubEventName);
            this.panel5.Controls.Add(this.LblDate);
            this.panel5.Controls.Add(this.LblVIPAmount);
            this.panel5.Controls.Add(this.LblVIPTicket);
            this.panel5.Controls.Add(this.LblTotalPrice);
            this.panel5.Controls.Add(this.LblPremiumAmount);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Controls.Add(this.LblPremiumTicket);
            this.panel5.Controls.Add(this.LblBasicTicket);
            this.panel5.Controls.Add(this.LblBasicAmount);
            this.panel5.Location = new System.Drawing.Point(801, 200);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(504, 576);
            this.panel5.TabIndex = 47;
            // 
            // pictureBoxCheckout
            // 
            this.pictureBoxCheckout.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxCheckout.Location = new System.Drawing.Point(358, 26);
            this.pictureBoxCheckout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxCheckout.Name = "pictureBoxCheckout";
            this.pictureBoxCheckout.Size = new System.Drawing.Size(116, 71);
            this.pictureBoxCheckout.TabIndex = 34;
            this.pictureBoxCheckout.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(1, 144);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 4);
            this.panel2.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(1, 455);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(513, 4);
            this.panel4.TabIndex = 33;
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblLocation.Location = new System.Drawing.Point(33, 75);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(78, 22);
            this.LblLocation.TabIndex = 25;
            this.LblLocation.Text = "Location";
            // 
            // LblSubEventName
            // 
            this.LblSubEventName.AutoSize = true;
            this.LblSubEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubEventName.Location = new System.Drawing.Point(27, 21);
            this.LblSubEventName.Name = "LblSubEventName";
            this.LblSubEventName.Size = new System.Drawing.Size(154, 29);
            this.LblSubEventName.TabIndex = 23;
            this.LblSubEventName.Text = "Event Name";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblDate.Location = new System.Drawing.Point(33, 52);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(48, 22);
            this.LblDate.TabIndex = 24;
            this.LblDate.Text = "Date";
            // 
            // LblVIPAmount
            // 
            this.LblVIPAmount.AutoSize = true;
            this.LblVIPAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVIPAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblVIPAmount.Location = new System.Drawing.Point(15, 379);
            this.LblVIPAmount.Name = "LblVIPAmount";
            this.LblVIPAmount.Size = new System.Drawing.Size(71, 22);
            this.LblVIPAmount.TabIndex = 22;
            this.LblVIPAmount.Text = "Amount";
            // 
            // LblVIPTicket
            // 
            this.LblVIPTicket.AutoSize = true;
            this.LblVIPTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVIPTicket.Location = new System.Drawing.Point(12, 348);
            this.LblVIPTicket.Name = "LblVIPTicket";
            this.LblVIPTicket.Size = new System.Drawing.Size(132, 29);
            this.LblVIPTicket.TabIndex = 21;
            this.LblVIPTicket.Text = "VIP Ticket";
            // 
            // LblTotalPrice
            // 
            this.LblTotalPrice.AutoSize = true;
            this.LblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalPrice.Location = new System.Drawing.Point(352, 498);
            this.LblTotalPrice.Name = "LblTotalPrice";
            this.LblTotalPrice.Size = new System.Drawing.Size(74, 29);
            this.LblTotalPrice.TabIndex = 19;
            this.LblTotalPrice.Text = "Price";
            // 
            // LblPremiumAmount
            // 
            this.LblPremiumAmount.AutoSize = true;
            this.LblPremiumAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPremiumAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblPremiumAmount.Location = new System.Drawing.Point(15, 289);
            this.LblPremiumAmount.Name = "LblPremiumAmount";
            this.LblPremiumAmount.Size = new System.Drawing.Size(71, 22);
            this.LblPremiumAmount.TabIndex = 16;
            this.LblPremiumAmount.Text = "Amount";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 498);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 29);
            this.label21.TabIndex = 15;
            this.label21.Text = "Total";
            // 
            // LblPremiumTicket
            // 
            this.LblPremiumTicket.AutoSize = true;
            this.LblPremiumTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPremiumTicket.Location = new System.Drawing.Point(12, 258);
            this.LblPremiumTicket.Name = "LblPremiumTicket";
            this.LblPremiumTicket.Size = new System.Drawing.Size(196, 29);
            this.LblPremiumTicket.TabIndex = 14;
            this.LblPremiumTicket.Text = "Premium Ticket";
            // 
            // LblBasicTicket
            // 
            this.LblBasicTicket.AutoSize = true;
            this.LblBasicTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBasicTicket.Location = new System.Drawing.Point(12, 162);
            this.LblBasicTicket.Name = "LblBasicTicket";
            this.LblBasicTicket.Size = new System.Drawing.Size(156, 29);
            this.LblBasicTicket.TabIndex = 12;
            this.LblBasicTicket.Text = "Basic Ticket";
            // 
            // LblBasicAmount
            // 
            this.LblBasicAmount.AutoSize = true;
            this.LblBasicAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBasicAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblBasicAmount.Location = new System.Drawing.Point(15, 194);
            this.LblBasicAmount.Name = "LblBasicAmount";
            this.LblBasicAmount.Size = new System.Drawing.Size(71, 22);
            this.LblBasicAmount.TabIndex = 13;
            this.LblBasicAmount.Text = "Amount";
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::STUBHUB_PROJECT.Properties.Resources.Payment_Form__3_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 818);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.buttonAddCard);
            this.Controls.Add(this.BtnContinueCheckout);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CheckoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckoutBillingForm";
            this.Load += new System.EventHandler(this.CheckoutBillingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCheckout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RadBtnCredit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnContinueCheckout;
        private System.Windows.Forms.Button buttonAddCard;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBoxCheckout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Label LblSubEventName;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblVIPAmount;
        private System.Windows.Forms.Label LblVIPTicket;
        private System.Windows.Forms.Label LblTotalPrice;
        private System.Windows.Forms.Label LblPremiumAmount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label LblPremiumTicket;
        private System.Windows.Forms.Label LblBasicTicket;
        private System.Windows.Forms.Label LblBasicAmount;
        private System.Windows.Forms.Label labelCardUsername;
    }
}
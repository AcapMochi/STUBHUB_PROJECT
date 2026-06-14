namespace STUBHUB_PROJECT
{
    partial class AdminProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminProfileForm));
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelChangePassword = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonHome.Location = new System.Drawing.Point(658, 538);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(179, 55);
            this.buttonHome.TabIndex = 8;
            this.buttonHome.Text = "Back to Home";
            this.buttonHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpdate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonUpdate.Location = new System.Drawing.Point(441, 538);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(179, 55);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Update Profile";
            this.buttonUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.labelChangePassword);
            this.panel2.Controls.Add(this.textBoxPassword);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxEmail);
            this.panel2.Controls.Add(this.textBoxUsername);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtUsername);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(298, 168);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 330);
            this.panel2.TabIndex = 17;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Transparent;
            this.txtEmail.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.txtEmail.Location = new System.Drawing.Point(53, 91);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(56, 18);
            this.txtEmail.TabIndex = 19;
            this.txtEmail.Text = "Email:";
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Transparent;
            this.txtUsername.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.txtUsername.Location = new System.Drawing.Point(53, 58);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(99, 18);
            this.txtUsername.TabIndex = 18;
            this.txtUsername.Text = "Username: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(190, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 28);
            this.label3.TabIndex = 17;
            this.label3.Text = "Admin Profile Settings";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(217, 54);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(443, 26);
            this.textBoxUsername.TabIndex = 24;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(217, 87);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(443, 26);
            this.textBoxEmail.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(53, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 26;
            this.label1.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(217, 119);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(443, 26);
            this.textBoxPassword.TabIndex = 27;
            // 
            // labelChangePassword
            // 
            this.labelChangePassword.AutoSize = true;
            this.labelChangePassword.BackColor = System.Drawing.Color.MidnightBlue;
            this.labelChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChangePassword.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labelChangePassword.Location = new System.Drawing.Point(212, 283);
            this.labelChangePassword.Name = "labelChangePassword";
            this.labelChangePassword.Size = new System.Drawing.Size(259, 29);
            this.labelChangePassword.TabIndex = 28;
            this.labelChangePassword.Text = "Forgot your password?";
            // 
            // AdminProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 817);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonUpdate);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminProfileForm";
            this.Load += new System.EventHandler(this.AdminProfileForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelChangePassword;
    }
}
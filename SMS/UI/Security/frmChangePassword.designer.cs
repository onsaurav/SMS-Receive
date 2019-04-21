namespace SMS
{
    partial class frmChangePassword
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboUserName = new System.Windows.Forms.ComboBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGSM = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 53);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cboUserName);
            this.panel2.Controls.Add(this.txtNewPassword);
            this.panel2.Controls.Add(this.txtOldPassword);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblGSM);
            this.panel2.Controls.Add(this.lblContactPerson);
            this.panel2.Location = new System.Drawing.Point(-1, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 115);
            this.panel2.TabIndex = 0;
            // 
            // cboUserName
            // 
            this.cboUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.cboUserName.FormattingEnabled = true;
            this.cboUserName.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cboUserName.Location = new System.Drawing.Point(156, 26);
            this.cboUserName.Name = "cboUserName";
            this.cboUserName.Size = new System.Drawing.Size(214, 21);
            this.cboUserName.TabIndex = 0;
            this.cboUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboUserName_KeyDown);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.txtNewPassword.Location = new System.Drawing.Point(156, 69);
            this.txtNewPassword.MaxLength = 30;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(214, 20);
            this.txtNewPassword.TabIndex = 2;
            this.txtNewPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPassword_KeyDown);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.txtOldPassword.Location = new System.Drawing.Point(156, 48);
            this.txtOldPassword.MaxLength = 30;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(214, 20);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOldPassword_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(10, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "New Password";
            // 
            // lblGSM
            // 
            this.lblGSM.AutoSize = true;
            this.lblGSM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGSM.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblGSM.Location = new System.Drawing.Point(10, 45);
            this.lblGSM.Name = "lblGSM";
            this.lblGSM.Size = new System.Drawing.Size(94, 13);
            this.lblGSM.TabIndex = 34;
            this.lblGSM.Text = "Old Password";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactPerson.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblContactPerson.Location = new System.Drawing.Point(10, 26);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(78, 13);
            this.lblContactPerson.TabIndex = 33;
            this.lblContactPerson.Text = "User Name";
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.btnCancel);
            this.Panel3.Controls.Add(this.btnOk);
            this.Panel3.Location = new System.Drawing.Point(1, 170);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(397, 51);
            this.Panel3.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.Location = new System.Drawing.Point(201, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnOk.Location = new System.Drawing.Point(126, 14);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(398, 221);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboUserName;
        internal System.Windows.Forms.TextBox txtNewPassword;
        internal System.Windows.Forms.TextBox txtOldPassword;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label lblGSM;
        internal System.Windows.Forms.Label lblContactPerson;
        internal System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}
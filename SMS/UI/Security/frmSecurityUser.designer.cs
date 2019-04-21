namespace SMS
{
    partial class frmSecurityUser
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
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboLabel = new System.Windows.Forms.ComboBox();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboActive = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGSM = new System.Windows.Forms.Label();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.dgvSecurityUser = new System.Windows.Forms.DataGridView();
            this.UsrUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsrLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsrDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecurityUser)).BeginInit();
            this.Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 53);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 22);
            this.label1.TabIndex = 34;
            this.label1.Text = "SecurityUser Setup";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Controls.Add(this.cboLabel);
            this.panel2.Controls.Add(this.txtRePassword);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cboActive);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtEmailAddress);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtFullName);
            this.panel2.Controls.Add(this.txtUserName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblGSM);
            this.panel2.Controls.Add(this.lblContactPerson);
            this.panel2.Location = new System.Drawing.Point(-1, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 298);
            this.panel2.TabIndex = 0;
            // 
            // cboDepartment
            // 
            this.cboDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cboDepartment.Location = new System.Drawing.Point(156, 61);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(221, 21);
            this.cboDepartment.TabIndex = 0;
            this.cboDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDepartment_KeyDown_1);
            // 
            // cboLabel
            // 
            this.cboLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.cboLabel.FormattingEnabled = true;
            this.cboLabel.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cboLabel.Location = new System.Drawing.Point(156, 83);
            this.cboLabel.Name = "cboLabel";
            this.cboLabel.Size = new System.Drawing.Size(221, 21);
            this.cboLabel.TabIndex = 1;
            this.cboLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboLabel_KeyDown_1);
            // 
            // txtRePassword
            // 
            this.txtRePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.txtRePassword.Location = new System.Drawing.Point(156, 171);
            this.txtRePassword.MaxLength = 30;
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '*';
            this.txtRePassword.Size = new System.Drawing.Size(146, 20);
            this.txtRePassword.TabIndex = 5;
            this.txtRePassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRePassword_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Location = new System.Drawing.Point(14, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Password (Re Type)";
            // 
            // cboActive
            // 
            this.cboActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.cboActive.FormattingEnabled = true;
            this.cboActive.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cboActive.Location = new System.Drawing.Point(156, 214);
            this.cboActive.Name = "cboActive";
            this.cboActive.Size = new System.Drawing.Size(69, 21);
            this.cboActive.TabIndex = 7;
            this.cboActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboActive_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label7.Location = new System.Drawing.Point(14, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Email Address";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.txtEmailAddress.Location = new System.Drawing.Point(156, 192);
            this.txtEmailAddress.MaxLength = 30;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(221, 20);
            this.txtEmailAddress.TabIndex = 6;
            this.txtEmailAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailAddress_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(156, 149);
            this.txtPassword.MaxLength = 30;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(146, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.txtFullName.Location = new System.Drawing.Point(156, 127);
            this.txtFullName.MaxLength = 30;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(221, 20);
            this.txtFullName.TabIndex = 3;
            this.txtFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFullName_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.txtUserName.Location = new System.Drawing.Point(156, 105);
            this.txtUserName.MaxLength = 30;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(146, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(14, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Active";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(14, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(14, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Full Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(14, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "User Name";
            // 
            // lblGSM
            // 
            this.lblGSM.AutoSize = true;
            this.lblGSM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGSM.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblGSM.Location = new System.Drawing.Point(14, 83);
            this.lblGSM.Name = "lblGSM";
            this.lblGSM.Size = new System.Drawing.Size(76, 13);
            this.lblGSM.TabIndex = 34;
            this.lblGSM.Text = "User Level";
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.AutoSize = true;
            this.lblContactPerson.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactPerson.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblContactPerson.Location = new System.Drawing.Point(14, 64);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(125, 13);
            this.lblContactPerson.TabIndex = 33;
            this.lblContactPerson.Text = "Department Name";
            // 
            // dgvSecurityUser
            // 
            this.dgvSecurityUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecurityUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsrUserName,
            this.UsrLevel,
            this.UsrDepartment});
            this.dgvSecurityUser.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvSecurityUser.Location = new System.Drawing.Point(400, 53);
            this.dgvSecurityUser.Name = "dgvSecurityUser";
            this.dgvSecurityUser.ReadOnly = true;
            this.dgvSecurityUser.RowHeadersWidth = 4;
            this.dgvSecurityUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSecurityUser.Size = new System.Drawing.Size(466, 301);
            this.dgvSecurityUser.TabIndex = 2;
            this.dgvSecurityUser.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSecurityUser_RowEnter);
            // 
            // UsrUserName
            // 
            this.UsrUserName.DataPropertyName = "UsrUserName";
            this.UsrUserName.HeaderText = "User Name";
            this.UsrUserName.Name = "UsrUserName";
            this.UsrUserName.ReadOnly = true;
            this.UsrUserName.Width = 125;
            // 
            // UsrLevel
            // 
            this.UsrLevel.DataPropertyName = "UsrLevel";
            this.UsrLevel.HeaderText = "Level";
            this.UsrLevel.Name = "UsrLevel";
            this.UsrLevel.ReadOnly = true;
            this.UsrLevel.Width = 155;
            // 
            // UsrDepartment
            // 
            this.UsrDepartment.DataPropertyName = "UsrDepartment";
            this.UsrDepartment.HeaderText = "Department";
            this.UsrDepartment.Name = "UsrDepartment";
            this.UsrDepartment.ReadOnly = true;
            this.UsrDepartment.Width = 155;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.btnDelete);
            this.Panel3.Controls.Add(this.btnEdit);
            this.Panel3.Controls.Add(this.txtSearch);
            this.Panel3.Controls.Add(this.label6);
            this.Panel3.Controls.Add(this.btnSearch);
            this.Panel3.Controls.Add(this.btnClose);
            this.Panel3.Controls.Add(this.btnClear);
            this.Panel3.Controls.Add(this.btnAdd);
            this.Panel3.Location = new System.Drawing.Point(1, 353);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(863, 51);
            this.Panel3.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.Location = new System.Drawing.Point(168, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnEdit.Location = new System.Drawing.Point(92, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(526, 15);
            this.txtSearch.MaxLength = 30;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(418, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Search by User";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.Location = new System.Drawing.Point(778, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Location = new System.Drawing.Point(321, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClear.Location = new System.Drawing.Point(244, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.Location = new System.Drawing.Point(15, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmSecurityUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(866, 405);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.dgvSecurityUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmSecurityUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security User";
            this.Load += new System.EventHandler(this.frmSecurityUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecurityUser)).EndInit();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtEmailAddress;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtFullName;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label lblGSM;
        internal System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.DataGridView dgvSecurityUser;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboActive;
        internal System.Windows.Forms.TextBox txtRePassword;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsrUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsrLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsrDepartment;
    }
}
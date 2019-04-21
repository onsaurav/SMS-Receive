
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GsmComm.GsmCommunication;

namespace SMS
{
	/// <summary>
	/// Summary description for frmConnection.
	/// </summary>
	public class frmConnection : System.Windows.Forms.Form
    {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int port;
		private int baudRate;
        internal Panel panel1;
        internal Label label1;
        private PictureBox pictureBox1;
        internal Panel Panel3;
        internal Panel Panel4;
        private Label lblTimeout;
        private Label lblBaudRate;
        private ComboBox cboTimeout;
        private Label lblPort;
        private ComboBox cboPort;
        private ComboBox cboBaudRate;
        private Button btnCancel;
        private Button btnOK;
        private Button btnTest;
		private int timeout;

		public frmConnection()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cboTimeout = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panel3.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 48);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(56, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Connection Settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SMS.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.White;
            this.Panel3.Controls.Add(this.btnCancel);
            this.Panel3.Controls.Add(this.btnOK);
            this.Panel3.Controls.Add(this.btnTest);
            this.Panel3.Location = new System.Drawing.Point(0, 134);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(327, 48);
            this.Panel3.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(194, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(119, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.ForeColor = System.Drawing.Color.White;
            this.btnTest.Location = new System.Drawing.Point(44, 13);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "&Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.Panel4.Controls.Add(this.lblTimeout);
            this.Panel4.Controls.Add(this.lblBaudRate);
            this.Panel4.Controls.Add(this.cboTimeout);
            this.Panel4.Controls.Add(this.lblPort);
            this.Panel4.Controls.Add(this.cboPort);
            this.Panel4.Controls.Add(this.cboBaudRate);
            this.Panel4.Location = new System.Drawing.Point(0, 47);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(327, 86);
            this.Panel4.TabIndex = 0;
            // 
            // lblTimeout
            // 
            this.lblTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeout.ForeColor = System.Drawing.Color.White;
            this.lblTimeout.Location = new System.Drawing.Point(48, 55);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(100, 23);
            this.lblTimeout.TabIndex = 10;
            this.lblTimeout.Text = "Ti&meout (ms):";
            this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaudRate.ForeColor = System.Drawing.Color.White;
            this.lblBaudRate.Location = new System.Drawing.Point(50, 31);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(100, 23);
            this.lblBaudRate.TabIndex = 8;
            this.lblBaudRate.Text = "&Baud rate:";
            this.lblBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTimeout
            // 
            this.cboTimeout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTimeout.Location = new System.Drawing.Point(167, 57);
            this.cboTimeout.Name = "cboTimeout";
            this.cboTimeout.Size = new System.Drawing.Size(104, 21);
            this.cboTimeout.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.Color.White;
            this.lblPort.Location = new System.Drawing.Point(50, 7);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(88, 23);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "&COM-Port:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPort
            // 
            this.cboPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPort.Location = new System.Drawing.Point(167, 9);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(104, 21);
            this.cboPort.TabIndex = 0;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBaudRate.Location = new System.Drawing.Point(167, 33);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(104, 21);
            this.cboBaudRate.TabIndex = 1;
            // 
            // frmConnection
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(328, 182);
            this.Controls.Add(this.Panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection settings";
            this.Load += new System.EventHandler(this.frmConnection_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panel3.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public void SetData(int port, int baudRate, int timeout)
		{
			this.port = port;
			this.baudRate = baudRate;
			this.timeout = timeout;
		}

		public void GetData(out int port, out int baudRate, out int timeout)
		{
			port = this.port;
			baudRate = this.baudRate;
			timeout = this.timeout;
		}

		private bool EnterNewSettings()
		{
			int newPort;
			int newBaudRate;
			int newTimeout;

			try
			{
				newPort = int.Parse(cboPort.Text);
			}
			catch(Exception)
			{
				MessageBox.Show(this, "Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cboPort.Focus();
				return false;
			}

			try
			{
				newBaudRate = int.Parse(cboBaudRate.Text);
			}
			catch(Exception)
			{
				MessageBox.Show(this, "Invalid baud rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cboBaudRate.Focus();
				return false;
			}

			try
			{
				newTimeout = int.Parse(cboTimeout.Text);
			}
			catch(Exception)
			{
				MessageBox.Show(this, "Invalid timeout value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cboTimeout.Focus();
				return false;
			}

			SetData(newPort,newBaudRate,newTimeout);
			
			return true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!EnterNewSettings())
				DialogResult = DialogResult.None;
		}

		private void frmConnection_Load(object sender, System.EventArgs e)
		{
            //cboPort.Items.Add("1");
            //cboPort.Items.Add("2");
            //cboPort.Items.Add("3");
            //cboPort.Items.Add("4");

            for (int i = 1; i < 23; i++)
            {
                cboPort.Items.Add(i);
            }
            cboPort.Text = port.ToString();

			cboBaudRate.Items.Add("9600");
			cboBaudRate.Items.Add("19200");
			cboBaudRate.Items.Add("38400");
			cboBaudRate.Items.Add("57600");
			cboBaudRate.Items.Add("115200");
			cboBaudRate.Text = baudRate.ToString();

			cboTimeout.Items.Add("150");
			cboTimeout.Items.Add("300");
			cboTimeout.Items.Add("600");
			cboTimeout.Items.Add("900");
			cboTimeout.Items.Add("1200");
			cboTimeout.Items.Add("1500");
			cboTimeout.Items.Add("1800");
			cboTimeout.Items.Add("2000");
			cboTimeout.Text = timeout.ToString();
		}

		private void btnTest_Click(object sender, System.EventArgs e)
		{
			if (!EnterNewSettings())
				return;

			Cursor.Current = Cursors.WaitCursor;
			GsmCommMain comm = new GsmCommMain(port, baudRate, timeout);
			try
			{
				comm.Open();
				while (!comm.IsConnected())
				{
					Cursor.Current = Cursors.Default;
					if (MessageBox.Show(this, "No phone connected.", "Connection setup",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
					{
						comm.Close();
						return;
					}
					Cursor.Current = Cursors.WaitCursor;
				}

				comm.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, "Connection error: " + ex.Message, "Connection setup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			MessageBox.Show(this, "Successfully connected to the phone.", "Connection setup", MessageBoxButtons.OK, MessageBoxIcon.Information);			
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
	}
}

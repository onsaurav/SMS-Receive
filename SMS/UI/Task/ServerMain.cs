using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

using System.Data;
using System.Data.SqlClient;
using DBConnection;
using DBExecution;

using GsmComm.GsmCommunication;
using GsmComm.PduConverter;


using Utility;
using Entity.EntityCommonUtility;
using Entity.Security.SecurityUser;
using SMS;

using System.Threading;

namespace SMS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Label lbl_phone_status;
        private System.Windows.Forms.TextBox txtOutput;
	
		private delegate void SetTextCallback(string text);
        private CommSetting comm_settings = new CommSetting();
        private IContainer components;
        private System.Windows.Forms.TextBox txt_message_index;
        private System.Windows.Forms.Timer timer1;
        private DataTable dt = new DataTable();
        
        DataSet oDataSet;
        private CConnection m_oCConnectionToDB = new CConnection();
        CResult oCResult = new CResult();
        //private CommonMethod oCommonMethod = new CommonMethod();
        private CExecutionDB m_oCSQLCommandExecutor = new CExecutionDB();
        internal Panel panel1;
        internal Label label1;
        private PictureBox pictureBox1;
        internal Panel panel2;
        private Button btnCancel;
        private Button btnOK;
        private Button btnExport;
        private Button btnUser;
        private DataGridView dgvMessage;
        Common oCommon = new Common();


		public Form1()
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
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            this.lbl_phone_status = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txt_message_index = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvMessage = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_phone_status
            // 
            this.lbl_phone_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_phone_status.BackColor = System.Drawing.Color.White;
            this.lbl_phone_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_phone_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_phone_status.Location = new System.Drawing.Point(205, 560);
            this.lbl_phone_status.Name = "lbl_phone_status";
            this.lbl_phone_status.Size = new System.Drawing.Size(196, 23);
            this.lbl_phone_status.TabIndex = 54;
            this.lbl_phone_status.Text = "NO PHONE CONNECTED";
            this.lbl_phone_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_phone_status.UseMnemonic = false;
            // 
            // txtOutput
            // 
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(604, 396);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(55, 23);
            this.txtOutput.TabIndex = 55;
            // 
            // txt_message_index
            // 
            this.txt_message_index.Location = new System.Drawing.Point(618, 421);
            this.txt_message_index.Name = "txt_message_index";
            this.txt_message_index.Size = new System.Drawing.Size(40, 20);
            this.txt_message_index.TabIndex = 65;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 55);
            this.panel1.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(56, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Received SMS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SMS.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(5, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnUser);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Location = new System.Drawing.Point(0, 530);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 51);
            this.panel2.TabIndex = 67;
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUser.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(630, 16);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(75, 23);
            this.btnUser.TabIndex = 16;
            this.btnUser.Text = "New User";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnExport.Location = new System.Drawing.Point(546, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(778, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
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
            this.btnOK.Location = new System.Drawing.Point(704, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "Report";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvMessage
            // 
            this.dgvMessage.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.dgvMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessage.GridColor = System.Drawing.Color.CornflowerBlue;
            this.dgvMessage.Location = new System.Drawing.Point(0, 53);
            this.dgvMessage.Name = "dgvMessage";
            this.dgvMessage.RowHeadersWidth = 4;
            this.dgvMessage.Size = new System.Drawing.Size(865, 478);
            this.dgvMessage.TabIndex = 68;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(865, 581);
            this.Controls.Add(this.dgvMessage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lbl_phone_status);
            this.Controls.Add(this.txt_message_index);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmLogin());
		}

	
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// Prompt user for connection settings
			int port = GsmCommMain.DefaultPortNumber;
			int baudRate = 9600; // We Set 9600 as our Default Baud Rate
			int timeout = GsmCommMain.DefaultTimeout;

			frmConnection dlg = new frmConnection();
			dlg.StartPosition = FormStartPosition.CenterScreen;
			dlg.SetData(port, baudRate, timeout);
			
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				dlg.GetData(out port, out baudRate, out timeout);
				CommSetting.Comm_Port=port;
				CommSetting.Comm_BaudRate=baudRate;
				CommSetting.Comm_TimeOut=timeout;
			}
			else
			{
				Close();
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			CommSetting.comm = new GsmCommMain(port, baudRate, timeout);
			Cursor.Current = Cursors.Default;
			CommSetting.comm.PhoneConnected += new EventHandler(comm_PhoneConnected);
			CommSetting.comm.MessageReceived+=new MessageReceivedEventHandler(comm_MessageReceived);

			bool retry;
			do
			{
				retry = false;
				try
				{
					Cursor.Current = Cursors.WaitCursor;
					CommSetting.comm.Open();
					Cursor.Current = Cursors.Default;
				}
				catch(Exception)
				{
					Cursor.Current = Cursors.Default;
					if (MessageBox.Show(this, "Unable to open the port.", "Error",
						MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
						retry = true;
					else
					{
						Close();
						return;
					}
				}
			}
			while(retry);


            //dgvMessage.PreferredColumnWidth=100;
            //dt.Columns.Add("Index",typeof(int));
            //dt.Columns.Add("Sender",typeof(string));
            //dt.Columns.Add("Date", typeof(string));
            //dt.Columns.Add("Time",typeof(string));
            //dt.Columns.Add("Message",typeof(string));

            //dgvMessage.PreferredColumnWidth = 100;
            //dt.Columns.Add("MobileNo", typeof(string));
            //dt.Columns.Add("Date", typeof(string));
            //dt.Columns.Add("Time", typeof(string));
            //dt.Columns.Add("Message", typeof(string));            

            LoadSMS("");

            timer1.Interval = 2000;
            timer1.Enabled = true;

		}


		private delegate void ConnectedHandler(bool connected);
				
		private void OnPhoneConnectionChange(bool connected)
		{
			lbl_phone_status.Text="CONNECTED";
		}

		
		private void comm_MessageReceived(object sender, GsmComm.GsmCommunication.MessageReceivedEventArgs e)
		{
			MessageReceived();
		}

		private void comm_PhoneConnected(object sender, EventArgs e)
		{
			this.Invoke(new ConnectedHandler(OnPhoneConnectionChange), new object[] { true });
		}


		private string GetMessageStorage()
		{
			string storage = string.Empty;
			storage = PhoneStorageType.Sim;
			
			if (storage.Length == 0)
				throw new ApplicationException("Unknown message storage.");
			else
				return storage;
		}


		private void MessageReceived()
		{
			Cursor.Current = Cursors.WaitCursor;
			string storage = GetMessageStorage();

			DecodedShortMessage[] messages = CommSetting.comm.ReadMessages(PhoneMessageStatus.ReceivedUnread, storage);
			foreach(DecodedShortMessage message in messages)
			{
				Output(string.Format("Message status = {0}, Location = {1}/{2}",
					StatusToString(message.Status),	message.Storage, message.Index));
				ShowMessage(message.Data);
				Output("");
			}
			
			Output(string.Format("{0,9} messages read.", messages.Length.ToString()));
			Output("");
		}


		private string StatusToString(PhoneMessageStatus status)
		{
			// Map a message status to a string
			string ret;
			switch(status)
			{
				case PhoneMessageStatus.All:
					ret = "All";
					break;
				case PhoneMessageStatus.ReceivedRead:
					ret = "Read";
					break;
				case PhoneMessageStatus.ReceivedUnread:
					ret = "Unread";
					break;
				case PhoneMessageStatus.StoredSent:
					ret = "Sent";
					break;
				case PhoneMessageStatus.StoredUnsent:
					ret = "Unsent";
					break;
				default:
					ret = "Unknown (" + status.ToString() + ")";
					break;
			}
			return ret;
		}


        private void Output(string text)
		{
			if (this.txtOutput.InvokeRequired)
			{
				SetTextCallback stc = new SetTextCallback(Output);
				this.Invoke(stc, new object[] { text });
			}
			else
			{
				txtOutput.AppendText(text);
				txtOutput.AppendText("\r\n");
			}
		}


		private void ShowMessage(SmsPdu pdu)
		{
			if (pdu is SmsSubmitPdu)
			{
				// Stored (sent/unsent) message
				SmsSubmitPdu data = (SmsSubmitPdu)pdu;
				Output("SENT/UNSENT MESSAGE");
				Output("Recipient: " + data.DestinationAddress);
				Output("Message text: " + data.UserDataText);
				Output("-------------------------------------------------------------------");
				return;
			}
			if (pdu is SmsDeliverPdu)
			{
				// Received message
				SmsDeliverPdu data = (SmsDeliverPdu)pdu;
				Output("RECEIVED MESSAGE");
				Output("Sender: " + data.OriginatingAddress);
				Output("Sent: " + data.SCTimestamp.ToString());
				Output("Message text: " + data.UserDataText);
				Output("-------------------------------------------------------------------");
				return;
			}
			if (pdu is SmsStatusReportPdu)
			{
				// Status report
				SmsStatusReportPdu data = (SmsStatusReportPdu)pdu;
				Output("STATUS REPORT");
				Output("Recipient: " + data.RecipientAddress);
				Output("Status: " + data.Status.ToString());
				Output("Timestamp: " + data.DischargeTime.ToString());
				Output("Message ref: " + data.MessageReference.ToString());
				Output("-------------------------------------------------------------------");
				return;
			}
			Output("Unknown message type: " + pdu.GetType().ToString());
		}

		private void mnu_send_click(object sender, System.EventArgs e)
		{
            //Send send_sms=new Send();
            //send_sms.Show();
		}


		private void mnu_read_click(object sender, System.EventArgs e)
		{
            //Receive receice_sms=new Receive();
            //receice_sms.Show();
		}


		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// Clean up comm object
			if (CommSetting.comm != null)
			{
				// Unregister events
				CommSetting.comm.PhoneConnected -= new EventHandler(comm_PhoneConnected);
				CommSetting.comm.MessageReceived -= new MessageReceivedEventHandler(comm_MessageReceived);
				
				// Close connection to phone
				if (CommSetting.comm != null && CommSetting.comm.IsOpen())
					CommSetting.comm.Close();

				CommSetting.comm = null;
			}
		}

		private void mnudelete_Click(object sender, System.EventArgs e)
		{
            //Delete delete=new Delete();
            //delete.Show();
		}

        private void dgvMessage_Navigate(object sender, NavigateEventArgs ne)
        {

        }
        private void ReadMessage()
        {
            Cursor.Current = Cursors.WaitCursor;
            string storage = GetMessageStorage();

            try
            {
                // Read all SMS messages from the storage

                //DecodedShortMessage[] messages = CommSetting.comm.ReadMessages(PhoneMessageStatus.All, storage);
                DecodedShortMessage[] messages = CommSetting.comm.ReadMessages(PhoneMessageStatus.ReceivedUnread, storage);
                foreach (DecodedShortMessage message in messages)
                {
                    ShowMessage(message.Data, message.Index);                  

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;            
        }
        private void BindGrid(SmsPdu pdu, int index)
        {

            //DataRow dr = dt.NewRow();
            SmsDeliverPdu data = (SmsDeliverPdu)pdu;

            //dr[0] = index.ToString();
            //dr[1] = data.OriginatingAddress.ToString();
            //dr[2] = DateTime.Parse(data.SCTimestamp.ToString()).ToShortDateString();
            //dr[3] = DateTime.Parse(data.SCTimestamp.ToString()).ToLongTimeString();
            //dr[4] = data.UserDataText;
            //dt.Rows.Add(dr);
            //dgvMessage.DataSource = dt;

            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select * From ReceivedMessage Where MmrMobileNo = '" + data.OriginatingAddress.ToString() + "' And MmrDate = '" + DateTime.Parse(data.SCTimestamp.ToString()).ToShortDateString() + "' And MmrTime = '" + DateTime.Parse(data.SCTimestamp.ToString()).ToLongTimeString() + "'", oCommon.DBCon).Data;
            if (oDataSet.Tables[0].Rows.Count == 0)
            {
                SqlCommand oSqlCommand = new SqlCommand("insert into ReceivedMessage (MmrMobileNo,MmrDate,MmrTime,MmrMessage,MmrUser,MmrRemarks) values('" + data.OriginatingAddress.ToString() + "','" + DateTime.Parse(data.SCTimestamp.ToString()).ToShortDateString() + "','" + DateTime.Parse(data.SCTimestamp.ToString()).ToLongTimeString() + "','" + data.UserDataText + "','"+ oCommon.UserName +"','')", oCommon.DBCon);
                try
                {
                    int i = oSqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex) { }               
            }            
        }
        private void ShowMessage(SmsPdu pdu, int index)
        {
            if (pdu is SmsSubmitPdu)
            {
                // Stored (sent/unsent) message
                SmsSubmitPdu data = (SmsSubmitPdu)pdu;
                return;
            }
            if (pdu is SmsDeliverPdu)
            {
                // Received message
                SmsDeliverPdu data = (SmsDeliverPdu)pdu;

                BindGrid(pdu, index);

                return;
            }
            if (pdu is SmsStatusReportPdu)
            {
                // Status report
                SmsStatusReportPdu data = (SmsStatusReportPdu)pdu;
                return;
            }

        }
        //private string StatusToString(PhoneMessageStatus status)
        //{
        //    // Map a message status to a string
        //    string ret;
        //    switch (status)
        //    {
        //        case PhoneMessageStatus.All:
        //            ret = "All";
        //            break;
        //        case PhoneMessageStatus.ReceivedRead:
        //            ret = "Read";
        //            break;
        //        case PhoneMessageStatus.ReceivedUnread:
        //            ret = "Unread";
        //            break;
        //        case PhoneMessageStatus.StoredSent:
        //            ret = "Sent";
        //            break;
        //        case PhoneMessageStatus.StoredUnsent:
        //            ret = "Unsent";
        //            break;
        //        default:
        //            ret = "Unknown (" + status.ToString() + ")";
        //            break;
        //    }
        //    return ret;
        //}
        //private string GetMessageStorage()
        //{
        //    string storage = PhoneStorageType.Sim;
        //    return storage;
        //}
        private bool Confirmed()
        {
            return (MessageBox.Show(this, "Really?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes);
        }
        private void dgvMessage_MouseDown
            (object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
            //// Use the DataGrid control's HitTest method with the x and y properties.
            //myHitTest = dgvMessage.HitTest(e.X, e.Y);
            //txt_message_index.Text = dgvMessage[myHitTest.Row, 0].ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
            ReadMessage();
            string strSQL = "";
            strSQL = " And MmrDate >= '" + DateTime.Parse(DateTime.Now.ToShortDateString()).AddMonths(-1) + "' And MmrDate <= '" + DateTime.Now.ToShortDateString() + "'";
            LoadSMS(strSQL);
        }
        private void LoadSMS(string strSQL)
        {
            //DataRow dr = dt.NewRow();            
            //dr[0] = index.ToString();
            //dr[1] = data.OriginatingAddress.ToString();
            //dr[2] = DateTime.Parse(data.SCTimestamp.ToString()).ToShortDateString();
            //dr[3] = DateTime.Parse(data.SCTimestamp.ToString()).ToLongTimeString();
            //dr[4] = data.UserDataText;
            //dt.Rows.Add(dr);
            //dgvMessage.DataSource = dt;

            try
            {
                dgvMessage.DataSource = null;
                oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select MmrMobileNo As MobileNo, MmrDate As Date, MmrTime As Time, MmrMessage As Message From ReceivedMessage Where MmrMobileNo <> '' " + strSQL + " Order By MmrDate DESC", oCommon.DBCon).Data;
                if (oDataSet.Tables[0].Rows.Count != 0)
                {
                    dgvMessage.DataSource = oDataSet.Tables[0];
                    dgvMessage.Columns[0].Width = 100;
                    dgvMessage.Columns[0].DefaultCellStyle.BackColor = Color.RoyalBlue;
                    dgvMessage.Columns[0].DefaultCellStyle.ForeColor = Color.White;
                    dgvMessage.Columns[1].Width = 100;
                    dgvMessage.Columns[1].DefaultCellStyle.BackColor = Color.RoyalBlue;
                    dgvMessage.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                    dgvMessage.Columns[2].Width = 100;
                    dgvMessage.Columns[2].DefaultCellStyle.BackColor = Color.RoyalBlue;
                    dgvMessage.Columns[2].DefaultCellStyle.ForeColor = Color.White;
                    dgvMessage.Columns[3].Width = 540;
                    dgvMessage.Columns[3].DefaultCellStyle.BackColor = Color.RoyalBlue;
                    dgvMessage.Columns[3].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            catch (Exception ex) { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            frmSMSReport ofrmSMSReport = new frmSMSReport();
            ofrmSMSReport.Show();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            #region OLDCode
            ////////show a file save dialog and ensure the user selects
            ////////correct file to allow the export
            //////saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            //////if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //////{
            //////    if (!saveFileDialog1.FileName.Equals(String.Empty))
            //////    {
            //////        FileInfo f = new FileInfo(saveFileDialog1.FileName);
            //////        if (f.Extension.Equals(".xls"))
            //////        {
            //////            StartExport(saveFileDialog1.FileName);
            //////        }
            //////        else
            //////        {
            //////            MessageBox.Show("Invalid file type");
            //////        }
            //////    }
            //////    else
            //////    {
            //////        MessageBox.Show("You did pick a location to save file to");
            //////    }
            //////}
            #endregion     

#region Export to Excel
/// <summary>
/// Exports a passed datagridview to an Excel worksheet.
/// If captions is true, grid headers will appear in row 1.
/// Data will start in row 2.
/// </summary>
/// <param name="datagridview"></param>
/// <param name="captions"></param>
private void Export2Excel(DataGridView datagridview, bool captions)
{
object objApp_Late;
object objBook_Late;
object objBooks_Late;
object objSheets_Late;
object objSheet_Late;
object objRange_Late;
object[] Parameters;
string[] headers = new string[datagridview.ColumnCount-1];
string[] columns = new string[datagridview.ColumnCount-1];

int i = 0;
int c = 0;
for (c = 0; c < datagridview.ColumnCount - 1; c++)
{
headers[c] = datagridview.Rows[0].Cells[c].OwningColumn.Name.ToString();
i = c + 65;
columns[c] = Convert.ToString((char)i);
}

try
{
// Get the class type and instantiate Excel.
Type objClassType;
objClassType = Type.GetTypeFromProgID("Excel.Application");
objApp_Late = Activator.CreateInstance(objClassType);
//Get the workbooks collection.
objBooks_Late = objApp_Late.GetType().InvokeMember("Workbooks",
BindingFlags.GetProperty, null, objApp_Late, null);
//Add a new workbook.
objBook_Late = objBooks_Late.GetType().InvokeMember("Add",
BindingFlags.InvokeMethod, null, objBooks_Late, null);
//Get the worksheets collection.
objSheets_Late = objBook_Late.GetType().InvokeMember("Worksheets",
BindingFlags.GetProperty, null, objBook_Late, null);
//Get the first worksheet.
Parameters = new Object[1];
Parameters[0] = 1;
objSheet_Late = objSheets_Late.GetType().InvokeMember("Item",
BindingFlags.GetProperty, null, objSheets_Late, Parameters);

if (captions)
{
// Create the headers in the first row of the sheet
for (c = 0; c < datagridview.ColumnCount - 1; c++)
{
//Get a range object that contains cell.
Parameters = new Object[2];
Parameters[0] = columns[c] + "1";
Parameters[1] = Missing.Value;
objRange_Late = objSheet_Late.GetType().InvokeMember("Range",
BindingFlags.GetProperty, null, objSheet_Late, Parameters);
//Write Headers in cell.
Parameters = new Object[1];
Parameters[0] = headers[c];
objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty,
null, objRange_Late, Parameters);
}
}

// Now add the data from the grid to the sheet starting in row 2
for (i = 0; i < datagridview.RowCount; i++)
{
for (c = 0; c < datagridview.ColumnCount - 1; c++)
{
//Get a range object that contains cell.
Parameters = new Object[2];
Parameters[0] = columns[c] + Convert.ToString(i+2);
Parameters[1] = Missing.Value;
objRange_Late = objSheet_Late.GetType().InvokeMember("Range",
BindingFlags.GetProperty, null, objSheet_Late, Parameters);
//Write Headers in cell.
Parameters = new Object[1];
Parameters[0] = datagridview.Rows[i].Cells[headers[c]].Value.ToString();
objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty,
null, objRange_Late, Parameters);
}
}

//Return control of Excel to the user.
Parameters = new Object[1];
Parameters[0] = true;
objApp_Late.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
null, objApp_Late, Parameters);
objApp_Late.GetType().InvokeMember("UserControl", BindingFlags.SetProperty,
null, objApp_Late, Parameters);
}
catch (Exception theException)
{
String errorMessage;
errorMessage = "Error: ";
errorMessage = String.Concat(errorMessage, theException.Message);
errorMessage = String.Concat(errorMessage, " Line: ");
errorMessage = String.Concat(errorMessage, theException.Source);

MessageBox.Show(errorMessage, "Error");
}
}
#endregion
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmSecurityUser ofrmSecurityUser = new frmSecurityUser();
            ofrmSecurityUser.Show();
        }

        /*
        private void StartExport(String filepath)
        {
            btn2Excel.Enabled = false;
            btnUseTemplate.Enabled = false;
            //create a new background worker, to do the exporting
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.RunWorkerAsync(filepath);

            //create a new export2XLS object, providing DataView as a input parameter
            export2XLS = new export2Excel();
            export2XLS.prg += new export2Excel.ProgressHandler(export2XLS_prg);
        }
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            //get the Gridviews DataView
            DataView dv = _dataSet.Tables["customers"].DefaultView;
            //Pass the path and the sheet to use
            export2XLS.ExportToExcel(dv, (String)e.Argument, "newSheet1");
        }

        //Do a export to a new Excel document, with the use of a custom template
        private void btnUseTemplate_Click(object sender, EventArgs e)
        {
            //show a file save dialog and ensure the user selects
            //correct file to allow the export
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".xls"))
                    {
                        StartExportUseTemplate(saveFileDialog1.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location to save file to");
                }
            }
        }

        //Create a new excel document from a given template
        //@param filepath : the file to export to
        private void StartExportUseTemplate(String filepath)
        {
            btn2Excel.Enabled = false;
            btnUseTemplate.Enabled = false;
            //create a new background worker, to do the exporting
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWorkUseTemplate);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bg.RunWorkerAsync(filepath);

            //create a new export2XLS object, providing DataView as a input parameter
            export2XLS = new export2Excel();
            export2XLS.prg += new export2Excel.ProgressHandler(export2XLS_prg);
        }

        //Do the adding to custom template to create new excel document, work using the background worker
        private void bg_DoWorkUseTemplate(object sender, DoWorkEventArgs e)
        {
            //create some data to whack in the template
            String[,] templateValues =  {    { "task1", "CompletedBy1", "CompletedDate1" }, 
                                             { "task2", "CompletedBy2", "CompletedDate2" } 
                                        };

            //The template path to use
            Directory.SetCurrentDirectory(Application.StartupPath + @"..\..\..\");
            String templatePath = Directory.GetCurrentDirectory() + @"\TaskList.xlt";

            //Pass the template path and the test values and fill the template
            export2XLS.UseTemplate((String)e.Argument, templatePath, templateValues);
        }

        //Update the progress bar with the a value
        private void export2XLS_prg(object sender, ProgressEventArgs e)
        {
            //need to call InvokeRequired to check if thread need marshalling, to get the thread onto 
            //the same thread as the thread who owns the controls
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    progressBar1.Value = e.ProgressValue;
                }));
            }
            else
            {
                progressBar1.Value = e.ProgressValue;
            }
        }

        //show a message to the user when the background worker has finished
        //and re-enable the export buttons
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn2Excel.Enabled = true;
            btnUseTemplate.Enabled = true;
            MessageBox.Show("Finished");
        }    
         * */
	}
}

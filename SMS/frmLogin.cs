// Title          :   frmLogin
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   frmLogin [UI]
// Created        :   Kartik Biswas / Feb-08-2010
// Modified       :   Kartik Biswas

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DBConnection;
using DBExecution;

# region User Define refernece
using System.Data.SqlClient;
using DAL;
using Utility;
using Entity.EntityCommonUtility;
using SMS;

# endregion

namespace SMS
{
    public partial class frmLogin : Form
    {
        #region Member
        CResult oCResult = new CResult();
        Common oCommon = new Common();
        EntityCommon oEntityCommon = new EntityCommon();
        CommonMethod oCommonMethod = new CommonMethod();
        private CConnection m_oCConnectionToDB = new CConnection();
        # endregion
        #region Method
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            oCResult = oCommonMethod.CheckLoginUserSecurity(txtUserName.Text, txtPassword.Text);
            if (oCResult.IsSuccess == false)
            {
                MessageBox.Show(oCResult.Message, "Login ...", MessageBoxButtons.OK);
                txtUserName.Focus(); return;
            }
            else
            {
                MessageBox.Show("Welcome in Order Processing System", "Login ...", MessageBoxButtons.OK);
                this.Hide();
                oCommon.UserName = txtUserName.Text.Trim();
                oCommon.DBCon = m_oCConnectionToDB.GetDBConnection();
                Form1 oForm1 = new Form1();
                oForm1.Show();               
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();  //SendKeys.Send("{TAB}");
            }
        }
        #endregion

       
    }
}

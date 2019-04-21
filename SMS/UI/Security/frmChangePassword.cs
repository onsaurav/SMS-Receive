// Title          :   frmChangePassword
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   frmChangePassword [UI]
// Created        :   Rupal / Feb-11-2010
// Modified       :   

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

# region User Define refernece
using System.Data.SqlClient;
using DAL;
using DAL.Security.ChangePassword;
using Utility;
using Entity.EntityCommonUtility;
using SMS;
using DAL.CommonManiputionUtility;
using Entity.Security.SecurityUser;
# endregion

namespace SMS
{
    public partial class frmChangePassword : Form
    {

        # region Member
        ChangePassword_DAL oChangePassword_DAL = new ChangePassword_DAL();                         
        EntityCommon oEntityCommon = new EntityCommon();
        SecurityUser_Entity oSecurityUser_Entity = new SecurityUser_Entity();                
        CResult oCResult = new CResult();
        CommonMethod oCommonMethod = new CommonMethod();
        CommonManiputionUtility_DAL oCommonManiputionUtility_DAL = new CommonManiputionUtility_DAL();
        # endregion
        # region Method
        public frmChangePassword()
        {
            InitializeComponent();
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            oCommonManiputionUtility_DAL.Load_DropDownList(cboUserName, EntityCommon.DropDownName.User);
            ClearAllText();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboUserName.Text.Trim() == "" || txtOldPassword.Text.Trim() == "" || txtNewPassword.Text.Trim() == "")
            {
                MessageBox.Show("User Name Or Old Password or New Password is Empty", "Change Password ...", MessageBoxButtons.OK);
                return;
            }
            LoadObject();
            oCResult = oChangePassword_DAL.TakeObject(oSecurityUser_Entity, EntityCommon.Mode.dbzOk);
            MessageBox.Show(oCResult.Message, "Change Password ...");
            ClearAllText();
            cboUserName.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region SetFocus
        private void cboUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        private void txtOldPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        #endregion
        #endregion
        # region UserDefineFunction
        private bool ClearAllText()
            {     
                if (cboUserName.Items.Count > 0)
                {
                    cboUserName.SelectedIndex = 0;
                }
                txtNewPassword.Text = "";
                txtOldPassword.Text = "";
            return false; 
            }
        private bool  LoadObject() 
        {
            try
            {
                oSecurityUser_Entity.UserName  = cboUserName.Text.Trim();
                oSecurityUser_Entity.FullName = txtOldPassword.Text.Trim();
                oSecurityUser_Entity.Password = txtNewPassword.Text.Trim();                
                return true;
            }
            catch (Exception ex) { return false;}            
        }
        #endregion
    }
}

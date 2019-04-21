// Title          :   frmSecurityUser
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   frmSecurityUser [UI]
// Created        :   Rupal / Feb-09-2010
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
using DAL.Security.SecurityUser;
using Utility;
using Entity.EntityCommonUtility;
using Entity.Security.SecurityUser;
using SMS;

# endregion

namespace SMS
{
    public partial class frmSecurityUser : Form
    {
        # region Member
        SecurityUser_DAL oSecurityUser_DAL = new SecurityUser_DAL();                         
        EntityCommon oEntityCommon = new EntityCommon();                
        SecurityUser_Entity oSecurityUser_Entity = new SecurityUser_Entity();                
        CResult oCResult = new CResult();
        CommonMethod oCommonMethod = new CommonMethod();
        # endregion
        # region Method
        public frmSecurityUser()
        {
            InitializeComponent();
        }
        private void frmSecurityUser_Load(object sender, EventArgs e)
        {
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("Administration");
            cboDepartment.Items.Add("Gurments");
            cboDepartment.Items.Add("Accounts");
            cboDepartment.SelectedIndex = 0;

            cboLabel.Items.Clear();
            cboLabel.Items.Add("Administrator");
            cboLabel.Items.Add("Supervisor");
            cboLabel.Items.Add("Operator");
            cboLabel.SelectedIndex = 0;

            cboActive.Items.Clear();
            cboActive.Items.Add("Yes");
            cboActive.Items.Add("No");
            cboActive.SelectedIndex = 0;

            oCResult = oSecurityUser_DAL.LoadData(oSecurityUser_Entity, "");
            try
            {
                dgvSecurityUser.DataSource = oCResult.DataTableContainerSub;
            }
            catch (Exception ex) {}
            ClearAllText();
            cboDepartment.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllText();
        }        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckElement() == false) { return; }
            LoadObject();
            oCResult = oSecurityUser_DAL.TakeObject(oSecurityUser_Entity, EntityCommon.Mode.dbzAdd);
            if (oCResult.IsSuccess == true )
            {                
                dgvSecurityUser.DataSource = oCResult.DataTableContainerSub; 
                ClearAllText();             
            }
            MessageBox.Show(oCResult.Message, "Security User ...");
            cboDepartment.Focus();
        }        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to edit this record?", "OPS ...", MessageBoxButtons.YesNo) == DialogResult.No) { return; }
            if (CheckElement() == false) { return; }
            LoadObject();
            oCResult = oSecurityUser_DAL.TakeObject(oSecurityUser_Entity, EntityCommon.Mode.dbzEdit);
            if (oCResult.IsSuccess == true )
            {
                dgvSecurityUser.DataSource = oCResult.DataTableContainerSub;
                ClearAllText();
            }
            MessageBox.Show(oCResult.Message, "Security User ...");
        }       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detete this record?", "OPS ...", MessageBoxButtons.YesNo) == DialogResult.No) { return; }
            LoadObject();
            oCResult = oSecurityUser_DAL.TakeObject(oSecurityUser_Entity, EntityCommon.Mode.dbzDelete);
            if (oCResult.IsSuccess == true )
            {
                dgvSecurityUser.DataSource = oCResult.DataTableContainerSub;
                ClearAllText();
            }
            MessageBox.Show(oCResult.Message, "Security User ...");
        }        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            oCResult = oSecurityUser_DAL.LoadData(oSecurityUser_Entity, txtSearch.Text);
            try
            {
                dgvSecurityUser.DataSource = oCResult.DataTableContainerSub;
            }
            catch (Exception ex){}
        }
        #region SetFocus
        private void cboDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        private void cboLabel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }

        }
        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        private void cboActive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB} ");
            }
        }
        #endregion
        private void dgvSecurityUser_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSecurityUser.Rows.Count > 1 && e.RowIndex < (dgvSecurityUser.Rows.Count - 1))
            {
                ClearAllText();
                try
                {
                    oCResult = oSecurityUser_DAL.LoadData(dgvSecurityUser.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (oCResult.DataTableContainerSub.Rows.Count > 0)
                    {
                        cboDepartment.Text = oCResult.DataTableContainerSub.Rows[0]["UsrDepartment"].ToString();
                        cboLabel.Text = oCResult.DataTableContainerSub.Rows[0]["UsrLevel"].ToString();
                        txtUserName.Text = oCResult.DataTableContainerSub.Rows[0]["UsrUserName"].ToString();
                        txtFullName.Text = oCResult.DataTableContainerSub.Rows[0]["UsrFullName"].ToString();
                        txtPassword.Text = "";
                        txtPassword.Text = "";
                        txtEmailAddress.Text = oCResult.DataTableContainerSub.Rows[0]["UsrEmailAddress"].ToString();
                        if (oCResult.DataTableContainerSub.Rows[0]["UsrActive"].ToString()=="Y")
                        {
                            cboActive.Text = "Yes";
                        }
                        else
                        {
                            cboActive.Text = "No";
                        }
                    }
                }
                catch (Exception ex) { }
            }
        }
        #endregion
        # region UserDefineFunction
        private bool ClearAllText()
        {
            txtUserName.Text = "";
            txtFullName.Text = "";
            txtPassword.Text = "";
            txtEmailAddress.Text = "";
            txtRePassword.Text = "";
            if (cboActive.Items.Count > 0) {cboActive.SelectedIndex = 0; }
            if (cboLabel.Items.Count > 0) { cboLabel.SelectedIndex = 0; }
            if (cboDepartment.Items.Count > 0) { cboDepartment.SelectedIndex = 0; }
            return false;
        }
        private bool LoadObject()
        {
            try
            {
                oSecurityUser_Entity.Department = cboDepartment.Text;
                oSecurityUser_Entity.Level = cboLabel.Text;
                oSecurityUser_Entity.UserName = txtUserName.Text;
                oSecurityUser_Entity.FullName = txtFullName.Text;
                oSecurityUser_Entity.Password = txtPassword.Text;
                oSecurityUser_Entity.EmailAddress = txtEmailAddress.Text;
                if (cboActive.Text == "Yes")
                {
                    oSecurityUser_Entity.Active = "Y";
                }
                else
                {
                    oSecurityUser_Entity.Active = "N";
                }
                oSecurityUser_Entity.Date_Of_Entry = DateTime.Now;
                return true;
            }
            catch (Exception ex) { return false; }
        }
        private Boolean CheckElement()
        {
            if (txtUserName.Text.Trim() == "" )
            {
                MessageBox.Show("Sorry! UserName is Empty", "Security User ...", MessageBoxButtons.OK);
                return false;
            }
            if (txtPassword.Text.Trim() == ""  || txtRePassword.Text.Trim() =="" )
            {
                MessageBox.Show("Sorry! Password is Empty", "Security User ...", MessageBoxButtons.OK);
                return false;
            }
            if (cboLabel.Text.Trim() == "" || cboDepartment.Text.Trim() == "")
            {
                MessageBox.Show("Sorry! User Label or Department is Empty", "Security User ...", MessageBoxButtons.OK);
                return false;
            }
            if (String.Compare(txtPassword.Text.Trim(), txtRePassword.Text.Trim(), true) != 0) 
            {
                MessageBox.Show("Sorry! Password not matching ...", "Security User ...", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        #endregion  
        private void txtRePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){ SendKeys.Send("{TAB}"); }
        }

        private void cboDepartment_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{TAB}"); }
        }

        private void cboLabel_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{TAB}"); }
        }
    }
}

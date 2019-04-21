// Title          :   frmCollectionReport
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   frmCollectionReport [UI]
// Created        :   Rupal / Feb-17-2010
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
using Utility;
using SMS;
using SMS.Reports;
using DAL.CommonManiputionUtility;
using Entity.EntityCommonUtility;
# endregion

namespace SMS
{
    public partial class frmSMSReport : Form
    {
        CommonManiputionUtility_DAL oCommonManiputionUtility_DAL = new CommonManiputionUtility_DAL();
        public frmSMSReport()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCollectionReport_Load(object sender, EventArgs e)
        {
            oCommonManiputionUtility_DAL.Load_DropDownList(cboMobile, EntityCommon.DropDownName.MobileNo);
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            string strSelection = "";
            CrystalDecisions.CrystalReports.Engine.ReportClass ReportObject;

            if (chkMobile.Checked == false)
            {
                strSelection = strSelection + (strSelection == "" ? "" : " And ");
                strSelection = strSelection + "{ReceivedMessage.MmrMobileNo}='" + cboMobile.SelectedValue.ToString() + "'";
            }
            if (chkDate.Checked == false)
            {
                strSelection = strSelection + (strSelection == "" ? "" : " And ");
                strSelection = strSelection + "{ReceivedMessage.MmrMobileNo}='" + cboMobile.SelectedValue.ToString() + "'";
            }
            ReportObject = new SMSReport();
            CommonMethod.ShowReport(ReportObject, strSelection, "");        
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using Utility;
using DBExecution;
using Entity.EntityCommonUtility;

using System.Data.SqlClient;
using System.Data; 
using System.Windows.Forms;
 
namespace DAL.CommonManiputionUtility
{
    public class CommonManiputionUtility_DAL
    {
         #region Member
         CResult oCResult = new CResult();
         private CExecutionDB m_oCSQLCommandExecutor = new CExecutionDB();
         #endregion
         #region Method    
        
        public CResult Load_DropDownList(ComboBox OCombobox, EntityCommon.DropDownName oDropDownName)
        {
            DataSet oDataSet = new DataSet();
            DataTable oDataTable = new DataTable();
            switch (oDropDownName)
             {
                 case EntityCommon.DropDownName.GSM:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct GsmGSMName,GsmGSMId from GSM order by GsmGSMName");
                     break;
                 case EntityCommon.DropDownName.Measurement:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct MesMeasurementName,MesMeasurementId from Measurement order by MesMeasurementName");
                     break;
                 case EntityCommon.DropDownName.UnitType:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct untUnitName,untUnitID from UnitType order by untUnitName");
                     break;
                 case EntityCommon.DropDownName.Item:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct ItmItemName,ItmItemCode from Item order by ItmItemName");
                     break;
                 case EntityCommon.DropDownName.Buyer:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct BuyBuyerName,BuyBuyerID from Buyer where BuyType = 'Buyer' order by BuyBuyerName");
                     break;
                 case EntityCommon.DropDownName.Customer:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct BuyBuyerName,BuyBuyerID from Buyer where BuyType = 'Customer' order by BuyBuyerName");
                     break;
                 case EntityCommon.DropDownName.Supplier:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct SupSupplierName,SupSupplierID from Supplier order by SupSupplierName");
                     break;
                 case EntityCommon.DropDownName.Bank:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct BnkBankName,BnkBankID from Bank order by BnkBankName");
                     break;
                 case EntityCommon.DropDownName.ExportLC:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct EilLCNo,EilLCNo from ExportImportLC Where EilType='E' order by EilLCNo");
                     break;                
                 case EntityCommon.DropDownName.Style:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct StyStyleName,StyStyleId from Style order by StyStyleName");
                     break;                 
                 case EntityCommon.DropDownName.Order:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct PorOrderNo,PorOrderNo from PurchaseOrder order by PorOrderNo");
                     break;
                 case EntityCommon.DropDownName.Country:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct CntCountryName,CntCountryID from Country order by CntCountryName");
                     break;
                 case EntityCommon.DropDownName.Designation:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct DsgDesignationName,DsgDesignationID from Designation order by DsgDesignationName");
                     break;
                 case EntityCommon.DropDownName.JobNo:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct PinJobNo,PinJobNo from ProformaInvoice order by PinJobNo");
                     break;
                 case EntityCommon.DropDownName.User:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct UsrUserName,UsrUserName from SecurityUser order by UsrUserName");
                     break;
                 case EntityCommon.DropDownName.Order_INV:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct IisOrderNo,IisOrderNo from ItemIssue,ItemIssueDetail Where IisIssueNo = IidIssueNo order by IisOrderNo");
                     break;
                 case EntityCommon.DropDownName.ItemIssueOrderNo:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct IisOrderNo,IisOrderNo from ItemIssue  order by IisOrderNo");
                     break;
                 case EntityCommon.DropDownName.ProformaInvoiceOrderNo:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct PinOrderNo,PinOrderNo from ProformaInvoice  order by PinOrderNo");
                     break;
                 case EntityCommon.DropDownName.PurchaseOrderNo:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct PorOrderNo,PorOrderNo from PurchaseOrder  order by PorOrderNo");
                     break;
                 case EntityCommon.DropDownName.WorkOrderNo:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct WorOrderNo,WorOrderNo from WorkOrder  order by WorOrderNo");
                     break;
                 case EntityCommon.DropDownName.OinOrderNo:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct OinOrderNo,OinOrderNo from OrderInvoice  order by OinOrderNo");
                     break;                 
                 case EntityCommon.DropDownName.MreOrderNo:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct MreOrderNo,MreOrderNo from MaterialReceive  order by MreOrderNo");
                     break;
                 case EntityCommon.DropDownName.CltCollectionID:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct CltCollectionID,CltCollectionID from Collection  order by CltCollectionID");
                     break;
                 case EntityCommon.DropDownName.PmtPaymentID:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct PmtPaymentID,PmtPaymentID from Payment  order by PmtPaymentID");
                     break;
                 case EntityCommon.DropDownName.CollectionReportBuyerName:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  distinct BuyBuyerName,BuyBuyerID from Buyer ");
                     break;
                 case EntityCommon.DropDownName.PaymentReportSupplyerName:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  distinct SupSupplierName,SupSupplierID from Supplier ");
                     break;
                 case EntityCommon.DropDownName.BuyerReportBuyerName:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  distinct BuyBuyerName,BuyBuyerID from Buyer ");
                     break;
                 case EntityCommon.DropDownName.MobileNo:
                     oCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  distinct MmrMobileNo,MmrMobileNo from ReceivedMessage Order By MmrMobileNo");
                     break;
            }
            try 
            {
                OCombobox.DataSource = null;
                OCombobox.Items.Clear();
                OCombobox.DataSource = oCResult.DataTableContainerSub;
                OCombobox.DisplayMember = oCResult.DataTableContainerSub.Columns[0].ToString();
                OCombobox.ValueMember = oCResult.DataTableContainerSub.Columns[1].ToString();     
            }
            catch (Exception ex) { }
            return oCResult;
        }
        public CResult Load_DropDownList(ComboBox OCombobox, EntityCommon.DropDownName oDropDownName, string SQLString)
        {
            CResult oddlCResult = new CResult();
            DataSet oDataSet = new DataSet();
            DataTable oDataTable = new DataTable();
            switch (oDropDownName)
            {
                case EntityCommon.DropDownName.GSM_Item:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct GsmGSMName,GsmGSMId from GSM,Item Where ItmGSM = GsmGSMId And ItmItemCode = '"+ SQLString +"' order by GsmGSMName");
                    break;
                case EntityCommon.DropDownName.Measurement_Item:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct MesMeasurementName,MesMeasurementId from Measurement,Item Where ItmMeasurement = MesMeasurementId And ItmItemCode = '" + SQLString + "' order by MesMeasurementName");
                    break;
                case EntityCommon.DropDownName.UnitType_Item:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct untUnitName,untUnitID from UnitType,Item Where ItmUnitType = untUnitID And ItmItemCode = '" + SQLString + "' order by untUnitName");
                    break;
                case EntityCommon.DropDownName.DeliveryPlace:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct BdpPlaceName,BdpPlaceID from DeliveryPlace Where BdpBuyerID ='" + SQLString + "' Order by BdpPlaceName");
                    break;
                case EntityCommon.DropDownName.OrderStyle:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct StyStyleName,StyStyleId from OrderStyle,Style Where OrsStyleNo=StyStyleId " + SQLString + " order by StyStyleName");
                    break;
                case EntityCommon.DropDownName.GSM_PO:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct GsmGSMName,GsmGSMId from GSM,PurchaseOrderDetail,PurchaseOrder Where PorPurchaseOrderNo=PodPurchaseOrderNo And GsmGSMId=PodGSM " + SQLString + " order by GsmGSMName");
                    break;
                case EntityCommon.DropDownName.Measurement_PO:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct MesMeasurementName,MesMeasurementId from Measurement,PurchaseOrderDetail,PurchaseOrder Where PorPurchaseOrderNo=PodPurchaseOrderNo And MesMeasurementId=PodMeasurement " + SQLString + " order by MesMeasurementName");
                    break;
                case EntityCommon.DropDownName.UnitType_PO:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct untUnitName,untUnitID from UnitType,PurchaseOrderDetail,PurchaseOrder Where PorPurchaseOrderNo=PodPurchaseOrderNo And untUnitID=PodUnitType " + SQLString + " order by untUnitName");
                    break;
                case EntityCommon.DropDownName.Item_PO:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select Distinct ItmItemName,ItmItemCode from Item,PurchaseOrderDetail,PurchaseOrder Where PorPurchaseOrderNo=PodPurchaseOrderNo And ItmItemCode=PodItem " + SQLString + " order by ItmItemName");
                    break;                
                case EntityCommon.DropDownName.Order:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select PorOrderNo,PorOrderNo from PurchaseOrder Where PorApprove = 'Y'   " + SQLString + " order by PorOrderNo");
                    break;
                case EntityCommon.DropDownName.ReceiveOrder:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("SELECT     MaterialReceive.MreOrderNo, MaterialReceive.MreOrderNo  FROM MaterialReceive INNER JOIN MaterialReceiveDetail ON MaterialReceive.MreReceiveNo = MaterialReceiveDetail.MrdReceiveNo WHERE     (MaterialReceive.MreApprove = 'Y')  " + SQLString + "  GROUP BY MaterialReceive.MreOrderNo");
                    break;
                case EntityCommon.DropDownName.IisIssueNo:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  IisIssueNo,IisIssueNo from ItemIssue Where IisOrderNo ='" + SQLString + "' order by IisOrderNo");
                    break;
                case EntityCommon.DropDownName.PIInvoiceNo:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  PinInvoiceNo,PinInvoiceNo from ProformaInvoice Where PinOrderNo ='" + SQLString + "' order by PinOrderNo");
                    break;                
                case EntityCommon.DropDownName.OidInvoiceNo:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  OinInvoiceNo,OinInvoiceNo from OrderInvoice Where OinOrderNo ='" + SQLString + "' order by OinOrderNo");
                    break;
                case EntityCommon.DropDownName.MreReceiveNo:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  MreReceiveNo,MreReceiveNo from MaterialReceive Where MreOrderNo ='" + SQLString + "' order by MreOrderNo");
                    break;
                case EntityCommon.DropDownName.WorWorkOrderNo:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select  WorWorkOrderNo,WorWorkOrderNo from WorkOrder Where WorOrderNo ='" + SQLString + "' order by WorOrderNo");
                    break;
                case EntityCommon.DropDownName.CollRepCollectionId:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select CltCollectionID,CltCollectionID from Collection where CltBuyerID = '" + SQLString + "' Order By CltBuyerID");
                    break;
                case EntityCommon.DropDownName.PaymentReportPaymentId:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select PmtPaymentID,PmtPaymentID from Payment where PmtSupplierID = '" + SQLString + "' Order By PmtSupplierID");
                    break;
                case EntityCommon.DropDownName.PurchaseOrderSummary:
                    oddlCResult = m_oCSQLCommandExecutor.LoadDropDownList("Select PorPurchaseOrderNo,PorPurchaseOrderNo from PurchaseOrder where PorBuyerID = '" + SQLString + "' Order By PorBuyerID");
                    break;
            }
            try
            {
                OCombobox.DataSource = null;
                OCombobox.Items.Clear();
                OCombobox.DataSource = oddlCResult.DataTableContainerSub;
                OCombobox.DisplayMember = oddlCResult.DataTableContainerSub.Columns[0].ToString();
                OCombobox.ValueMember = oddlCResult.DataTableContainerSub.Columns[1].ToString();
            }
            catch (Exception ex) { }//MessageBox.Show(ex.ToString()); }
            return oddlCResult;
        }
        public string Auto_No(string PrefixString, string TableName, string TableFieldName)
        {
            return m_oCSQLCommandExecutor.GenerateAutoID(PrefixString, TableName, TableFieldName);
        }
        public string Auto_No_WithYear(string PrefixString, string TableName, string TableFieldName, string CompanyAndLocation)
        {
            PrefixString = PrefixString + '-' + CompanyAndLocation + DateTime.Now.Year + '-'; 
            return m_oCSQLCommandExecutor.GenerateAutoID(PrefixString, TableName, TableFieldName);
        }
        public string Auto_No_WithYear(string PrefixString, string TableName, string TableFieldName)
        {
            PrefixString = PrefixString + '-' + DateTime.Now.Year + '-'; 
            return m_oCSQLCommandExecutor.GenerateAutoID(PrefixString, TableName, TableFieldName);
        }
        public string EncripPassword(string strPassword)
        {
            int l;
            int pass1;
            int ctr = 1;            
            string passnew = "";
            pass1 = int.Parse(strPassword.Length.ToString()) - 1;
            ctr = 0;
            do
            {
                char k = Convert.ToChar(strPassword.Substring(ctr, 1));
                l = Convert.ToInt16(k) + 17;
                passnew = passnew.ToString() + (char)l;
                ctr = ctr + 1;
            }
            while (ctr <= pass1);
            return passnew;
        }
        #endregion
    }
}

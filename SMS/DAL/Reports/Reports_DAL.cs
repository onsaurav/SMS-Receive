// Title          :   Reports_DAL
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   Reports_DAL [DAL for Reports]
// Created        :   Kartik Biswas / Feb-14-2010
// Modified       :   Kartik Biswas

using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DBConnection;
using DBExecution;

using Utility;
using Entity.EntityCommonUtility;
using SMS;
namespace DAL.Reports.Reports
{
    public class Reports_DAL
    {
        #region Member
        DataSet oDataSet;
        SqlCommand oSqlCommand;
        Common oCommon = new Common();
        CResult oCResult = new CResult();
        private CommonMethod oCommonMethod = new CommonMethod();
        private CConnection m_oCConnectionToDB = new CConnection();
        private CExecutionDB m_oCSQLCommandExecutor = new CExecutionDB();
        #endregion
        #region Method
        public CResult BuyerLedger(string StrBuyer, DateTime DateFrom, DateTime DateTo, string strType)
        {
            int i = 0; int j = 0;
            double Amount = 0;
            oCResult = new CResult();
            oSqlCommand = new SqlCommand("Delete From TmpLedger Where TmpType = '" + strType + "' And TmpUser = '" + oCommon.UserName + "'", oCommon.DBCon);
            i = oSqlCommand.ExecuteNonQuery();
            if (i > -1) { }
            else
            {
                oCResult.IsSuccess = false;
                oCResult.Message = "Unable to delete from temporary table ...";
                return oCResult;
            }
            
            #region Opening Balance
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT SUM(ItemIssueDetail.IidTotal) AS T FROM ItemIssue INNER JOIN ItemIssueDetail ON ItemIssue.IisIssueNo = ItemIssueDetail.IidIssueNo WHERE (ItemIssue.IisBuyerID = '"+ StrBuyer +"') AND (ItemIssue.IisDate < '" + DateFrom.Date.AddDays(-1).ToShortDateString() + "')", oCommon.DBCon).Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                Amount = double.Parse(oDataSet.Tables[0].Rows[0][0].ToString() == "" ? "0" : oDataSet.Tables[0].Rows[0][0].ToString());
            }
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT SUM(CltCollectedAmount) AS T FROM Collection WHERE (CltBuyerID = 'B') AND (CltDate < '" +  DateFrom.Date.AddDays(-1).ToShortDateString() + "')", oCommon.DBCon).Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                Amount = Amount - double.Parse(oDataSet.Tables[0].Rows[0][0].ToString() == "" ? "0" : oDataSet.Tables[0].Rows[0][0].ToString());
            }
            oSqlCommand = new SqlCommand("Insert Into TmpLedger (TmpBuyerId, TmpSupplierId, TmpDate, TmpTime, TmpReferrence, TmpRemarks, TmpDr, TmpCr, TmpUser, TmpType, TmpSlNo) Values ('" + StrBuyer + "', '', '" + DateFrom.ToShortDateString() + "','00:00:00 AM', 'Opening', '', '" + Amount + "', 0, '" + oCommon.UserName + "', '" + strType + "', 0)", oCommon.DBCon);

            i = oSqlCommand.ExecuteNonQuery();
            if (i > -1) { }
            #endregion
            
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT IisIssueNo,IisDate,IisTime,SUM(ItemIssueDetail.IidTotal) AS T FROM ItemIssue INNER JOIN ItemIssueDetail ON ItemIssue.IisIssueNo = ItemIssueDetail.IidIssueNo WHERE (ItemIssue.IisBuyerID = '" + StrBuyer + "') AND (ItemIssue.IisDate >= '" + DateFrom.ToShortDateString() + "')AND (ItemIssue.IisDate <= '" + DateTo.ToShortDateString() + "') Group by IisIssueNo,IisDate,IisTime", oCommon.DBCon).Data;
            for (j = 0; j < oDataSet.Tables[0].Rows.Count; j++)
            {
                Amount = 0; Amount = double.Parse(oDataSet.Tables[0].Rows[j]["T"].ToString() == "" ? "0" : oDataSet.Tables[0].Rows[j]["T"].ToString());
                oSqlCommand = new SqlCommand("Insert Into TmpLedger (TmpBuyerId, TmpSupplierId, TmpDate, TmpTime, TmpReferrence, TmpRemarks, TmpDr, TmpCr, TmpUser, TmpType, TmpSlNo) Values ('" + StrBuyer + "', '', '" + DateTime.Parse(oDataSet.Tables[0].Rows[j]["IisDate"].ToString()).ToShortDateString() + "','" + oDataSet.Tables[0].Rows[j]["IisTime"].ToString() + "', '" + oDataSet.Tables[0].Rows[j]["IisIssueNo"].ToString() + "', '', '" + Amount + "', 0, '" + oCommon.UserName + "', '" + strType + "', 0)", oCommon.DBCon);
                i = oSqlCommand.ExecuteNonQuery();
                if (i > -1) { }
            }
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT CltCollectionID,CltDate,CltTime,CltCollectedAmount As T FROM Collection WHERE (CltBuyerID = '" + StrBuyer + "') AND (CltDate >= '" + DateFrom.ToShortDateString() + "') AND (CltDate <= '" + DateTo.ToShortDateString() + "')", oCommon.DBCon).Data;
            for (j = 0; j < oDataSet.Tables[0].Rows.Count; j++)
            {
                Amount = 0; Amount = double.Parse(oDataSet.Tables[0].Rows[j]["T"].ToString() == "" ? "0" : oDataSet.Tables[0].Rows[j]["T"].ToString());
                oSqlCommand = new SqlCommand("Insert Into TmpLedger (TmpBuyerId, TmpSupplierId, TmpDate, TmpTime, TmpReferrence, TmpRemarks, TmpDr, TmpCr, TmpUser, TmpType, TmpSlNo) Values ('" + StrBuyer + "', '', '" + DateTime.Parse(oDataSet.Tables[0].Rows[j]["CltDate"].ToString()).ToShortDateString() + "','" + oDataSet.Tables[0].Rows[j]["CltTime"].ToString() + "', '" + oDataSet.Tables[0].Rows[j]["CltCollectionID"].ToString() + "', '', 0, '" + Amount + "', '" + oCommon.UserName + "', '" + strType + "', 0)", oCommon.DBCon);
                i = oSqlCommand.ExecuteNonQuery();
                if (i > -1) { }
            }
            return oCResult;
        }
        public CResult SupplierLedger(string StrSupplier, DateTime DateFrom, DateTime DateTo, string strType)
        {
            int i = 0; int j = 0;
            double Amount = 0;
            oCResult = new CResult();
            oSqlCommand = new SqlCommand("Delete From TmpLedger Where TmpType = '" + strType + "' And TmpUser = '" + oCommon.UserName + "'", oCommon.DBCon);
            i = oSqlCommand.ExecuteNonQuery();
            if (i > -1) { }
            else
            {
                oCResult.IsSuccess = false;
                oCResult.Message = "Unable to delete from temporary table ...";
                return oCResult;
            }
            
            #region Opening Balance   
         
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT SUM(MrdTotal) AS T FROM MaterialReceive INNER JOIN MaterialReceiveDetail ON MaterialReceive.MreReceiveNo = MaterialReceiveDetail.MrdReceiveNo WHERE (MrdSupplierId = '" + StrSupplier + "') AND (MaterialReceive.MreDate < '" + DateFrom.Date.AddDays(-1).ToShortDateString() + "')", oCommon.DBCon).Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                Amount = double.Parse(oDataSet.Tables[0].Rows[0][0].ToString() == "" ? "0" : oDataSet.Tables[0].Rows[0][0].ToString());
            }
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT sum(PmtPaidAmount) As T FROM Payment WHERE (PmtSupplierID = '" + StrSupplier + "') AND (PmtDate < '" + DateFrom.Date.AddDays(-1).ToShortDateString() + "')", oCommon.DBCon).Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                Amount = Amount - double.Parse(oDataSet.Tables[0].Rows[0][0].ToString() == "" ? "0" : oDataSet.Tables[0].Rows[0][0].ToString());
            }
            oSqlCommand = new SqlCommand("Insert Into TmpLedger (TmpBuyerId, TmpSupplierId, TmpDate, TmpTime, TmpReferrence, TmpRemarks, TmpDr, TmpCr, TmpUser, TmpType, TmpSlNo) Values ('','" + StrSupplier + "',  '" + DateFrom.ToShortDateString() + "','00:00:00 AM', 'Opening', '', '" + Amount + "', 0, '" + oCommon.UserName + "', '" + strType + "', 0)", oCommon.DBCon);

            i = oSqlCommand.ExecuteNonQuery();
            if (i > -1) { }

            #endregion
            
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT MreReceiveNo,MreDate,MreTime,SUM(MrdTotal) AS T FROM MaterialReceive INNER JOIN MaterialReceiveDetail ON MaterialReceive.MreReceiveNo = MaterialReceiveDetail.MrdReceiveNo WHERE (MrdSupplierId= '" + StrSupplier + "') AND (MaterialReceive.MreDate >= '" + DateFrom.ToShortDateString() + "') AND (MaterialReceive.MreDate <= '" + DateTo.ToShortDateString() + "') Group by MreReceiveNo,MreDate,MreTime", oCommon.DBCon).Data;
            for (j = 0; j < oDataSet.Tables[0].Rows.Count; j++)
            {
                Amount = 0; Amount = double.Parse(oDataSet.Tables[0].Rows[j]["T"].ToString() == "" ? "0" : oDataSet.Tables[0].Rows[j]["T"].ToString());
                oSqlCommand = new SqlCommand("Insert Into TmpLedger (TmpBuyerId, TmpSupplierId, TmpDate, TmpTime, TmpReferrence, TmpRemarks, TmpDr, TmpCr, TmpUser, TmpType, TmpSlNo) Values ('','" + StrSupplier + "',  '" + DateTime.Parse(oDataSet.Tables[0].Rows[j]["MreDate"].ToString()).ToShortDateString() + "','" + oDataSet.Tables[0].Rows[j]["MreTime"].ToString() + "', '" + oDataSet.Tables[0].Rows[j]["MreReceiveNo"].ToString() + "', '', '" + Amount + "', 0, '" + oCommon.UserName + "', '" + strType + "', 0)", oCommon.DBCon);
                i = oSqlCommand.ExecuteNonQuery();
                if (i > -1) { }
            }
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT PmtPaymentID,PmtDate,PmtTime,PmtPaidAmount As T FROM Payment WHERE (PmtSupplierID = '" + StrSupplier + "') AND (PmtDate >= '" + DateFrom.ToShortDateString() + "')  AND (PmtDate <= '" + DateTo.ToShortDateString() + "')", oCommon.DBCon).Data;
            for (j = 0; j < oDataSet.Tables[0].Rows.Count; j++)
            {
                Amount = 0; Amount = double.Parse(oDataSet.Tables[0].Rows[j]["T"].ToString() == "" ? "0" : oDataSet.Tables[0].Rows[j]["T"].ToString());
                oSqlCommand = new SqlCommand("Insert Into TmpLedger (TmpBuyerId, TmpSupplierId, TmpDate, TmpTime, TmpReferrence, TmpRemarks, TmpDr, TmpCr, TmpUser, TmpType, TmpSlNo) Values ('','" + StrSupplier + "',  '" + DateTime.Parse(oDataSet.Tables[0].Rows[j]["PmtDate"].ToString()).ToShortDateString() + "','" + oDataSet.Tables[0].Rows[j]["PmtTime"].ToString() + "', '" + oDataSet.Tables[0].Rows[j]["PmtPaymentID"].ToString() + "', '',0, '" + Amount + "',  '" + oCommon.UserName + "', '" + strType + "', 0)", oCommon.DBCon);
                i = oSqlCommand.ExecuteNonQuery();
                if (i > -1) { }
            }
            return oCResult;
        }
        public CResult OrderLedger(string StrOrder, string strType)
        {
            double Amount = 0;
            int i = 0; int j = 0;            
            oCResult = new CResult();

            oSqlCommand = new SqlCommand("Delete From tmpOrder Where UserName = '" + oCommon.UserName + "'", oCommon.DBCon);
            i = oSqlCommand.ExecuteNonQuery();
            if (i > -1) { }
            else
            {
                oCResult.IsSuccess = false;
                oCResult.Message = "Unable to delete from temporary table ...";
                return oCResult;
            }

            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT  PorOrderNo, PurchaseOrder.PorDate, PurchaseOrder.PorTime, PurchaseOrderDetail.PodItem, PurchaseOrderDetail.PodStyle, PurchaseOrderDetail.PodMeasurement, PurchaseOrderDetail.PodQuantity,PodGSM, PurchaseOrderDetail.PodUnitType FROM  PurchaseOrder INNER JOIN  PurchaseOrderDetail ON PurchaseOrder.PorPurchaseOrderNo = PurchaseOrderDetail.PodPurchaseOrderNo WHERE     (PurchaseOrder.PorOrderNo = '" + StrOrder + "')", oCommon.DBCon).Data;
            for (j = 0; j < oDataSet.Tables[0].Rows.Count; j++)
            {
                oSqlCommand = new SqlCommand("INSERT INTO tmpOrder(OrderNo, tmpDate, tmpTime, Item, Style, Measurement, GSM, UnitType, PurchaseQuantity, ReceiveQuantity, IssueQuantity,UserName)VALUES " +
                                             "('" + oDataSet.Tables[0].Rows[0]["PorOrderNo"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["PorDate"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["PorTime"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["PodItem"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["PodStyle"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["PodMeasurement"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["PodGSM"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["PodUnitType"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["PodQuantity"].ToString() + "' , 0 ,0,'" + oCommon.UserName + "')", oCommon.DBCon);
                i = oSqlCommand.ExecuteNonQuery();
                if (i > -1)
                { 
                }
            }
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT     MaterialReceive.MreOrderNo, MaterialReceive.MreDate, MaterialReceive.MreTime, MaterialReceiveDetail.MrdItem, MaterialReceiveDetail.MrdStyle,MaterialReceiveDetail.MrdMeasurement, MaterialReceiveDetail.MrdUnitType, MaterialReceiveDetail.MrdGSM, MaterialReceiveDetail.MrdQuantity FROM         MaterialReceive INNER JOIN MaterialReceiveDetail ON MaterialReceive.MreReceiveNo = MaterialReceiveDetail.MrdReceiveNo WHERE     (MaterialReceive.MreOrderNo = '" + StrOrder + "')", oCommon.DBCon).Data;
            for (j = 0; j < oDataSet.Tables[0].Rows.Count; j++)
            {
                oSqlCommand = new SqlCommand("INSERT INTO tmpOrder(OrderNo, tmpDate, tmpTime, Item, Style, Measurement, GSM, UnitType, PurchaseQuantity, ReceiveQuantity, IssueQuantity,UserName)VALUES " +
                                             "('" + oDataSet.Tables[0].Rows[0]["MreOrderNo"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["MreDate"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["MreTime"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["MrdItem"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["MrdStyle"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["MrdMeasurement"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["MrdGSM"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["MrdUnitType"].ToString() + "'  , 0, '" + oDataSet.Tables[0].Rows[0]["MrdQuantity"].ToString() + "' ,0,'" + oCommon.UserName + "')", oCommon.DBCon);
                i = oSqlCommand.ExecuteNonQuery();
                if (i > -1) { }
            }
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT     ItemIssue.IisOrderNo, ItemIssue.IisDate, ItemIssue.IisTime, ItemIssueDetail.IidItem, ItemIssueDetail.IidStyle, ItemIssueDetail.IidMeasurement, ItemIssueDetail.IidUnitType, ItemIssueDetail.IidGSM, ItemIssueDetail.IidQuantity FROM  ItemIssue INNER JOIN  ItemIssueDetail ON ItemIssue.IisIssueNo = ItemIssueDetail.IidIssueNo WHERE     (ItemIssue.IisOrderNo = '" + StrOrder + "')", oCommon.DBCon).Data;
            for (j = 0; j < oDataSet.Tables[0].Rows.Count; j++)
            {
                oSqlCommand = new SqlCommand("INSERT INTO tmpOrder(OrderNo, tmpDate, tmpTime, Item, Style, Measurement, GSM, UnitType, PurchaseQuantity, ReceiveQuantity, IssueQuantity,UserName)VALUES " +
                                             "('" + oDataSet.Tables[0].Rows[0]["IisOrderNo"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["IisDate"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["IisTime"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["IidItem"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["IidStyle"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["IidMeasurement"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["IidGSM"].ToString() + "' , '" + oDataSet.Tables[0].Rows[0]["IidUnitType"].ToString() + "'  ,0, 0, '" + oDataSet.Tables[0].Rows[0]["IidQuantity"].ToString() + "','" + oCommon.UserName + "' )", oCommon.DBCon);
                i = oSqlCommand.ExecuteNonQuery();
                if (i > -1) { }
            }
            return oCResult;
        }
        public CResult BillWiseCollection(string StrOrder)
        {
            double Amount = 0;            
            int i = 0; int j = 0;
            oCResult = new CResult();
            DataSet oNewDataset = new DataSet();

            oSqlCommand = new SqlCommand("Delete From TmpBillCollection Where TmpUser = '" + oCommon.UserName + "'", oCommon.DBCon);
            i = oSqlCommand.ExecuteNonQuery();
            if (i > -1) { }
            else
            {
                oCResult.IsSuccess = false;
                oCResult.Message = "Unable to delete from temporary table ...";
                return oCResult;
            }

            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT OinBuyerID, OinOrderNo, OinExtDate, SUM(OidQuantity * OidPrice) AS T FROM OrderInvoice INNER JOIN OrderInvoiceDetail ON OinInvoiceNo = OidInvoiceNo "+ StrOrder +" GROUP BY OinBuyerID,OinOrderNo,OinExtDate Order By OinOrderNo", oCommon.DBCon).Data;
            for (j = 0; j < oDataSet.Tables[0].Rows.Count; j++)
            {
                Amount = 0;
                oNewDataset = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("SELECT SUM(CltCollectedAmount) As T FROM Collection WHERE (CltInvoiceNo = '" + oDataSet.Tables[0].Rows[j]["OinOrderNo"].ToString() + "')", oCommon.DBCon).Data;
                if (oNewDataset.Tables[0].Rows.Count > 0)
                {
                    Amount = double.Parse(oNewDataset.Tables[0].Rows[0][0].ToString() == "" ? "0" : oNewDataset.Tables[0].Rows[0][0].ToString());
                }
                oSqlCommand = new SqlCommand("INSERT INTO TmpBillCollection (TmpOrder, TmpBuyer, TmpExtDate, TmpBill, TmpCollection, TmpUser) Values ('" + oDataSet.Tables[0].Rows[j]["OinOrderNo"].ToString() + "', '" + oDataSet.Tables[0].Rows[j]["OinBuyerID"].ToString() + "', '" + oDataSet.Tables[0].Rows[j]["OinExtDate"].ToString() + "', '" + oDataSet.Tables[0].Rows[j]["T"].ToString() + "', '"+ Amount +"', '"+ oCommon.UserName +"')", oCommon.DBCon);
                i = oSqlCommand.ExecuteNonQuery();                
            }
            return oCResult;
        }
        #endregion
    }
}

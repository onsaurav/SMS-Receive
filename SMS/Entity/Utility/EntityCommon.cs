using System;
using System.Collections.Generic;
using System.Text;
namespace Entity.EntityCommonUtility
{
    public class EntityCommon
    {
        public enum Mode
        {
            dbzAdd,
            dbzEdit,
            dbzDelete,
            dbzOk,
            dbzReply,
            dbzClose,
            dbzSave
         }
        public enum ApprovalOrCancelOrActive
        {
            Y,
            N,
            C,
            A            
        }
        public enum DropDownName
        {
            Bank,
            Buyer,
            BuyerReportBuyerName,
            Country,
            Customer,
            CltCollectionID,
            CollectionReportBuyerName,
            CollRepCollectionId,
            Designation,
            DeliveryPlace,
            ExportLC,
            GSM,
            GSM_Item,
            GSM_PO,
            Item,
            Item_PO,
            IisIssueNo,
            ItemIssueOrderNo,
            JobNo,
            Measurement,
            Measurement_Item,
            Measurement_PO, 
            MreReceiveNo,
            MreOrderNo,
            Order,
            Order_INV,
            OrderStyle,
            OinOrderNo,
            OidInvoiceNo,
            PIInvoiceNo,
            ProformaInvoiceOrderNo,
            PurchaseOrderNo,
            PmtPaymentID,
            PaymentReportPaymentId,
            PaymentReportSupplyerName,
            PurchaseOrderSummary,
            ReceiveOrder,
            Style,
            Supplier,
            UnitType,
            UnitType_Item,
            UnitType_PO,
            User,
            WorkOrderNo,
            WorWorkOrderNo,
            MobileNo
        }
        public enum ReportName
        {
            Level,
            Security,
            grading,
            Department
        }
            #region Method
            public string RandString(int strLen) 
            {
                int xChar ;
                string strRandomNumber="";
                Random oRandom= new Random() ;
                while( strLen != 0)
                    {
                        xChar = oRandom.Next() * 255;
                        if( IsAlphaNumeric(xChar) == true)
                        {
                            strRandomNumber = strRandomNumber + xChar.ToString();
                            strLen = strLen - 1;
                        }
                    }
                    return strRandomNumber;
            }
            private bool IsAlphaNumeric(int CharCode )
            {
                if (CharCode >= 65 && CharCode <= 90) 
                {
                    return true;
                }
                else if (CharCode >= 97 && CharCode <= 122) 
                {
                    return  true;
                }
                else if (CharCode >= 48 && CharCode <= 57) 
                {
                    return  true;
                }
                else
                {
                    return  false;
                }
            }        
            #endregion
    }
}

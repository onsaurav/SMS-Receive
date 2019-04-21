/****************************************
 * Project: GCCommon.Utilities  
 * Class:   CResult
 * Author:  NH
 * Version: 1.0 
 * Created: 01/28/2007 11:19:07
 * 
 * Copyright Year: 2007  
 ****************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data; 
using System.Data.SqlClient; 

namespace Utility
{
    /// <summary>
    /// Description of CResult
    /// </summary>
    
    [Serializable]
   public class CResult
    {
        #region Members
        private bool isSuccess;
        private string message;
        private bool isSuccessMaster;
        private string messageMaster;
        private object data;
        private static DataTable oDatatable;
        private static DataTable oDatatableForDropDownList;
        private DataTable oDatatableSub;
        private DataTable oDatatableExt;
        private DataSet oDataSet;
        private int m_iDecision;
        private string DateFrom;
        private string DateTo;
        private List<string> ListValue =new List<string>()  ;
        private string []Myarr;
        private SqlDataReader oSqlDataReader;
        #endregion
        #region Properties
        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }       
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public bool IsSuccessMaster
        {
            get { return isSuccessMaster; }
            set { isSuccessMaster = value; }
        }
        public string MessageMaster
        {
            get { return messageMaster; }
            set { messageMaster = value; }
        }       
        public int Decision
        {
            get { return m_iDecision; }
            set { m_iDecision = value; }
        }
        public object Data
        { 
            get { return data; }
            set { data = value; }
        }
        public static DataTable DataTableContainer
        {
            get { return oDatatable; }
            set { oDatatable = value; }
        }
        public DataTable DataTableContainerSub
        {
            get { return oDatatableSub; }
            set { oDatatableSub = value; }
        }
        public DataTable DataTableContainerExt
        {
            get { return oDatatableExt ; }
            set { oDatatableExt = value; }
        }
        public DataSet DataSetValue
        {
            get { return oDataSet; }
            set { oDataSet = value; }
        }
        public static DataTable DataTableContainerForDropDownList
        {
            get { return oDatatableForDropDownList; }
            set { oDatatableForDropDownList = value; }
        }
        public  List<string> List_Value 
        {
            get { return ListValue; }
            set { ListValue = value; }
        }
        public string []My_arr
        {
            get { return Myarr; }
            set { Myarr = value; }
        }
        public string Date_From
        {
            get { return DateFrom; }
            set { DateFrom = value; }
        }
        public string Date_To
        {
            get { return DateTo; }
            set { DateTo = value; }
        }
        public  SqlDataReader DataReader
        {
            get { return oSqlDataReader; }
            set { oSqlDataReader = value; }
        }
        #endregion
        #region Constructors
        public CResult()
        {        
        }
        #endregion
    }
}

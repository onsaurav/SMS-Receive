using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

using DBConnection;
using DBExecution;

namespace DBExecution
{
    class CExecutionDB
    {
        #region Member
        private CExecutionDB oCExecutionDB ;
        private SqlConnection oSqlConnection ;
        private CConnection m_oCConnectionToDB ;
        private DataSet oDataSet;
         CResult oCResult=new CResult ();
        #endregion
        #region method
        public CResult DataReaderQueryRequest(string sSql, SqlConnection oSqlConnection)
        {
            SqlCommand sqlComm = new SqlCommand(sSql, oSqlConnection);
            SqlDataReader oSqlDataReader = sqlComm.ExecuteReader();
            oCResult.Data = oSqlDataReader; 
            return oCResult;
        }
        public CResult DataReaderQueryRequest(string sSql )
        {
            oSqlConnection = new SqlConnection();
            m_oCConnectionToDB = new CConnection();
            oSqlConnection = m_oCConnectionToDB.GetDBConnection();

            SqlCommand sqlComm = new SqlCommand(sSql, oSqlConnection);
            SqlDataReader oSqlDataReader = sqlComm.ExecuteReader();
            oCResult.Data = oSqlDataReader;

            return oCResult;
        }
        public CResult DataAdapterQueryRequest(string sSql, SqlConnection oSqlConnection)
       {
           oDataSet = new DataSet();
            
           SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSql, oSqlConnection);
            try
            {
                oSqlDataAdapter.Fill(oDataSet, "Common");
                oCResult.IsSuccess = true;
                oCResult.Message = "Successfull";
                oCResult.Data = oDataSet;

            }
            catch (Exception ex)
            {
                
                oCResult.IsSuccess = false;
                oCResult.Message = ex.ToString();
            }
            return oCResult;
        }
        public CResult DataAdapterQueryRequest(string sSql, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            oDataSet = new DataSet();

            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSql, oSqlConnection);
            try
            {
                oSqlDataAdapter.SelectCommand.Transaction = oSqlTransaction;
                oSqlDataAdapter.Fill(oDataSet, "Common");
                oCResult.IsSuccess = true;
                oCResult.Message = "Successfull";
                oCResult.Data = oDataSet;

            }
            catch (Exception ex)
            {
                oCResult.IsSuccess = false;
                oCResult.Message = ex.ToString();
            }
            return oCResult;
        }
        public CResult DataAdapterQueryRequest(string sSql)
        {
            m_oCConnectionToDB = new CConnection();
            oSqlConnection = new SqlConnection();
            oDataSet = new DataSet();
            oSqlConnection = m_oCConnectionToDB.GetDBConnection();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSql, oSqlConnection);
            try
            {
                oSqlDataAdapter.Fill(oDataSet, "Common");
                oCResult.IsSuccess = true;
                oCResult.Message = "Successfull";
                oCResult.Data = oDataSet;
            }
            catch (Exception ex)
            {
                oCResult.IsSuccess = false;
                oCResult.Message = ex.ToString();
            }
            return oCResult;
        }
        //Load Grid Auto
        public DataTable LoadTable(DataSet oDataSet)
        {
            #region member
            DataRow oDataRow;
            DataColumn oDataColumn = new DataColumn();
            DataTable oDataTable = new DataTable();
            int iColumn;
            int iRows;
            #endregion
            try
            {
                if (oDataSet != null)
                {
                    if (oDataSet.Tables[0].Rows.Count > 0)
                    {
                        for (iColumn = 0; iColumn <= oDataSet.Tables[0].Columns.Count - 1; iColumn++)
                        {
                            oDataTable.Columns.Add(new DataColumn(oDataSet.Tables[0].Columns[iColumn].ColumnName.ToString(), System.Type.GetType(oDataSet.Tables[0].Columns[iColumn].DataType.ToString())));
                        }
                        for (iRows = 0; iRows <= oDataSet.Tables[0].Rows.Count - 1; iRows++)
                        {
                            oDataRow = oDataTable.NewRow();
                            for (iColumn = 0; iColumn <= oDataSet.Tables[0].Columns.Count - 1; iColumn++)
                            {
                                oDataRow[iColumn] = oDataSet.Tables[0].Rows[iRows][iColumn];
                            }
                            oDataTable.Rows.Add(oDataRow);
                        }
                    }
                }
                return oDataTable;
            }
            catch (Exception ex)
            {
                oCResult.Message = ex.Message; 
                return oDataTable;
            }
            
        }
        //Load Grid Auto
        public CResult  LoadArr(DataSet oDataSet)
        {
            #region member
 
                //int iColumn;
                int iRows;
            #endregion
            try
            {
                if (oDataSet != null)
                {
                    if (oDataSet.Tables[0].Rows.Count > 0)
                    {
                        oCResult.My_arr = new string[oDataSet.Tables[0].Rows.Count];
                        for (iRows = 0; iRows <= oDataSet.Tables[0].Rows.Count - 1; iRows++)
                        {
                            oCResult.My_arr[iRows] = oDataSet.Tables[0].Rows[iRows][0].ToString(); 
                            //for (iColumn = 0; iColumn <= oDataSet.Tables[0].Columns.Count - 1; iColumn++)
                            //{
                            //    oDataRow[iColumn] = oDataSet.Tables[0].Rows[iRows][iColumn];
                            //}
                         }
                    }
                }
                return oCResult;
            }
            catch (Exception ex)
            {
                oCResult.Message = ex.Message; 
                return oCResult;
            }

        }
        public DataTable LoadTable(DataSet oDataSet,bool  DropDownList)
        {

            #region member
            DataRow oDataRow;
            DataColumn oDataColumn = new DataColumn();
            DataTable oDataTable = new DataTable();
            int iColumn;
            int iRows;
            #endregion
            if (oDataSet != null)
            {
                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    for (iColumn = 0; iColumn <= oDataSet.Tables[0].Columns.Count - 1; iColumn++)
                    {
                        oDataTable.Columns.Add(new DataColumn(oDataSet.Tables[0].Columns[iColumn].ColumnName.ToString(), System.Type.GetType(oDataSet.Tables[0].Columns[iColumn].DataType.ToString())));
                    }
                    if (DropDownList == true)
                    {
                        for (iRows = 0; iRows <= 0; iRows++)
                        {
                            oDataRow = oDataTable.NewRow();
                            for (iColumn = 0; iColumn <= oDataSet.Tables[0].Columns.Count - 1; iColumn++)
                            {
                                oDataRow[iColumn] = "";
                            }
                            oDataTable.Rows.Add(oDataRow);
                        }
                    }
                    for (iRows = 0; iRows <= oDataSet.Tables[0].Rows.Count-1 ; iRows++)
                    {
                        oDataRow = oDataTable.NewRow();
                        for (iColumn = 0; iColumn <= oDataSet.Tables[0].Columns.Count - 1; iColumn++)
                        {
                            oDataRow[iColumn] = oDataSet.Tables[0].Rows[iRows ][iColumn];
                        }
                        oDataTable.Rows.Add(oDataRow);
                    }
                }
            }
            return oDataTable;
        }
        public DataTable LoadTableSpecial(DataSet oDataSet, bool DropDownList,string PorC)
        {

            #region member
            DataRow oDataRow;
            DataColumn oDataColumn = new DataColumn();
            DataTable oDataTable = new DataTable();
            int iColumn;
            int iRows;
            #endregion
            if (oDataSet != null)
            {
                for (iColumn = 0; iColumn <= oDataSet.Tables[0].Columns.Count - 1; iColumn++)
                {
                    oDataTable.Columns.Add(new DataColumn(oDataSet.Tables[0].Columns[iColumn].ColumnName.ToString(), System.Type.GetType(oDataSet.Tables[0].Columns[iColumn].DataType.ToString())));
                }
                if (DropDownList == true)
                {
                    for (iRows = 0; iRows <= 0; iRows++)
                    {
                        oDataRow = oDataTable.NewRow();
                        for (iColumn = 0; iColumn <= 1; iColumn++)
                        {
                            oDataRow[iColumn] = "";
                        }
                        oDataTable.Rows.Add(oDataRow);
                        oDataRow = oDataTable.NewRow();
                        for (iColumn = 0; iColumn <= 1; iColumn++)
                        {
                            if (PorC == "C")
                            {
                                oDataRow[iColumn] = "Previous Sales";
                            }
                            else
                            {
                                oDataRow[iColumn] = "Previous Purchase";
                            }
                        }
                        oDataTable.Rows.Add(oDataRow);
                        if (PorC == "C")
                        {
                            oDataRow = oDataTable.NewRow();
                            for (iColumn = 0; iColumn <= 1; iColumn++)
                            {
                                //if (PorC == "C")
                                //{
                                oDataRow[iColumn] = "Sales Advance";
                                //}
                                //else
                                //{
                                //    oDataRow[iColumn] = "Purchase Advance";
                                //}
                            }
                            oDataTable.Rows.Add(oDataRow);
                        }
                    }
                }
                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                   
                    
                    for (iRows = 0; iRows <= oDataSet.Tables[0].Rows.Count - 1; iRows++)
                    {
                        oDataRow = oDataTable.NewRow();
                        for (iColumn = 0; iColumn <= oDataSet.Tables[0].Columns.Count - 1; iColumn++)
                        {
                            oDataRow[iColumn] = oDataSet.Tables[0].Rows[iRows][iColumn];
                        }
                        oDataTable.Rows.Add(oDataRow);
                    }
                }
            }
            return oDataTable;
        }
        public string GenerateAutoID(string  PrefixString, string TableName , string TableFieldName)
        {
            double ICount;
            oDataSet = new DataSet(); 
            oCResult = SQLResult("Select " + TableFieldName + " from " + TableName + " where " + TableFieldName + " like '%" + PrefixString + "%'  order by right(" + TableFieldName + ",5)");
            oDataSet=(DataSet)oCResult.Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                ICount = int.Parse(oDataSet.Tables[0].Rows[oDataSet.Tables[0].Rows.Count - 1][0].ToString().Substring(PrefixString.Length, 5)) + 1;
                PrefixString = PrefixString + ICount.ToString("00000");
            }
            else
            {
                PrefixString = PrefixString + "00001";
            }

            return  PrefixString;

        }
        public string GenerateAutoID(string PrefixString, string TableName, string TableFieldName,int StringLength)
        {
            double ICount;
            oDataSet = new DataSet();
            oCResult = SQLResult("Select " + TableFieldName + " from " + TableName + " where " + TableFieldName + " like '%" + PrefixString + "%'  order by right(" + TableFieldName + ","+StringLength +")");
            oDataSet = (DataSet)oCResult.Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                ICount = int.Parse(oDataSet.Tables[0].Rows[oDataSet.Tables[0].Rows.Count - 1][0].ToString().Substring(PrefixString.Length, StringLength)) + 1;
                PrefixString = PrefixString + ICount.ToString().PadLeft(StringLength,'0') ;
            }
            else
            {
                ICount = 1;
                PrefixString = PrefixString + ICount.ToString().PadLeft(StringLength,'0');
            }

            return PrefixString;

        }
        public string GenerateAutoID(string PrefixString, string TableName, string TableFieldName, int StringLength,string AdditionalWhere)
        {
            double ICount;
            oDataSet = new DataSet();
            oCResult = SQLResult("Select " + TableFieldName + " from " + TableName + " where " + TableFieldName + " like '%" + PrefixString + "%' and "+ AdditionalWhere +"order by right(" + TableFieldName + "," + StringLength + ")");
            oDataSet = (DataSet)oCResult.Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                ICount = int.Parse(oDataSet.Tables[0].Rows[oDataSet.Tables[0].Rows.Count - 1][0].ToString().Substring(PrefixString.Length, StringLength)) + 1;
                PrefixString = PrefixString + ICount.ToString().PadLeft(StringLength, '0');
            }
            else
            {
                ICount = 1;
                PrefixString = PrefixString + ICount.ToString().PadLeft(StringLength, '0');
            }

            return PrefixString;

        }
        public string GenerateAutoID(string PrefixString, string TableName, string TableFieldName, int StringLength, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            double ICount;
            oDataSet = new DataSet();
            oCResult = SQLResult("Select " + TableFieldName + " from " + TableName + " where " + TableFieldName + " like '%" + PrefixString + "%'  order by right(" + TableFieldName + "," + StringLength + ")",oSqlConnection,oSqlTransaction);
            oDataSet = (DataSet)oCResult.Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                ICount = int.Parse(oDataSet.Tables[0].Rows[oDataSet.Tables[0].Rows.Count - 1][0].ToString().Substring(PrefixString.Length, StringLength)) + 1;
                PrefixString = PrefixString + ICount.ToString().PadLeft(StringLength, '0');
            }
            else
            {
                ICount = 1;
                PrefixString = PrefixString + ICount.ToString().PadLeft(StringLength, '0');
            }

            return PrefixString;

        }
        public CResult SQLResult(string strSQLString)
        {
            oCExecutionDB = new CExecutionDB();
            oCResult = oCExecutionDB.DataAdapterQueryRequest(strSQLString);
            return oCResult;
        }
        public CResult SQLResult(string strSQLString, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            oCExecutionDB = new CExecutionDB();
            oCResult = oCExecutionDB.DataAdapterQueryRequest(strSQLString, oSqlConnection, oSqlTransaction);
            return oCResult;
        }

        public CResult CheckDuplicate(string SQL, SqlConnection CConnectionDB)
        {

            DataSet oDataSet = (DataSet)DataAdapterQueryRequest(SQL, CConnectionDB).Data;
            if (oDataSet.Tables[0].Rows.Count != 0)
            {
                oCResult.Message = "Duplicale...";
                oCResult.IsSuccess = false;
                return oCResult;
            }
            else
            {
                oCResult.IsSuccess = true;
            }
            return oCResult;
        }
        public CResult CheckDuplicate(string SQL, SqlConnection CConnectionDB, SqlTransaction oSqlTransaction)
        {

            DataSet oDataSet = (DataSet)DataAdapterQueryRequest(SQL, CConnectionDB, oSqlTransaction).Data;

            if (oDataSet.Tables[0].Rows.Count != 0)
            {
                oCResult.Message = "Duplicate...";
                oCResult.IsSuccess = false;
                return oCResult;
            }
            else
            {
                oCResult.IsSuccess = true;
            }
            return oCResult;
        }
        #region "LoadDropDownList Manipulation"
        public CResult LoadDropDownList(string strSQl)
        {
            oCResult = new CResult();
            try
            {
                DataTable oDataTable = new DataTable();
                oCExecutionDB = new CExecutionDB();
                oCResult = oCExecutionDB.DataAdapterQueryRequest(strSQl);
                oDataTable = ((DataSet)oCResult.Data).Tables[0];
                oCResult.DataTableContainerSub = oDataTable;
            }
            catch (Exception ex) { }
            return oCResult;
        }
        public CResult LoadDropDownListSpecial(string strSQl, string PorC)
        {
            oCExecutionDB = new CExecutionDB();
            oCResult = oCExecutionDB.DataAdapterQueryRequest(strSQl);
            CResult.DataTableContainerForDropDownList = this.LoadTableSpecial((DataSet)oCResult.Data, true, PorC);
            return oCResult;
        }        
        #endregion
        public string EncripPassword(string strPassword)
        {
            int pass1;
            int ctr = 1;
            int l;
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

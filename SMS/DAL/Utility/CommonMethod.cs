using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBConnection;
using DBExecution;
using Utility;
using SMS;

namespace DAL
{
    public class CommonMethod
    {
        #region member
        SqlCommand oSqlCommand;
        SqlConnection m_oSqlConnection;
        CExecutionDB oCExecutionDB = new CExecutionDB();
        private CConnection m_oCConnectionToDB = new CConnection();
        private CExecutionDB m_oCSQLCommandExecutor = new CExecutionDB();
        CResult oCResult = new CResult();        
        DataSet oDataSet = new DataSet();   
        #endregion
        # region method
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public CResult CheckLoginUserSecurity(string strUser, string strPass)
        {
            oDataSet = new DataSet();
            oCResult = new CResult();
            m_oSqlConnection = m_oCConnectionToDB.GetDBConnection();
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select * from SecurityUser Where UsrUserName ='" + strUser + "' And UsrPassword = '" + m_oCSQLCommandExecutor.EncripPassword(strPass) + "'", m_oSqlConnection).Data;
            if (oDataSet.Tables[0].Rows.Count == 0)
            {
                oCResult.IsSuccess = false;
                oCResult.Message = "Sorry! You are not a valid user.";
            }
            else
            {
                oCResult.IsSuccess = true;
            }
            return oCResult;
        }
        public string GenerateAutoID(string PrefixString, string TableName, string TableFieldName)
        {
            double ICount;
            oDataSet = new DataSet();
            oCResult = SQLResult("Select " + TableFieldName + " from " + TableName + " where " + TableFieldName + " like '%" + PrefixString + "%'  order by right(" + TableFieldName + ",5)");
            oDataSet = (DataSet)oCResult.Data;
            if (oDataSet.Tables[0].Rows.Count > 0)
            {
                ICount = int.Parse(oDataSet.Tables[0].Rows[oDataSet.Tables[0].Rows.Count - 1][0].ToString().Substring(PrefixString.Length, 5)) + 1;
                PrefixString = PrefixString + ICount.ToString("00000");
            }
            else
            {
                PrefixString = PrefixString + "00001";
            }
            return PrefixString;
        }
        public CResult SQLResult(string strSQLString)
        {
            oCExecutionDB = new CExecutionDB();
            oCResult = oCExecutionDB.DataAdapterQueryRequest(strSQLString);
            return oCResult;
        }
        static public Boolean ShowReport(CrystalDecisions.CrystalReports.Engine.ReportClass ReportName, string SelectedFormaula, string strFormulafields)
        {
            try
            {
                frmReportViewer obRReportViewer = new frmReportViewer();
                obRReportViewer.crvReportViewer.ReportSource = ReportName;
                ReportName.RecordSelectionFormula = SelectedFormaula;
                obRReportViewer.Show();
                return true;
            }
            catch
            { return false; }

        }
        #endregion
    }
}

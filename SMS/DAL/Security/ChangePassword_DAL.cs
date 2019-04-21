// Title          :   ChangePassword_DAL
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   ChangePassword_DAL [DAL for ChangePassword]
// Created        :   Rupal / Feb-11-2010
// Modified       :    
using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DBConnection;
using DBExecution;

using Utility;
using Entity.EntityCommonUtility;
using Entity.Security.SecurityUser;
using SMS;
namespace DAL.Security.ChangePassword
{
   public class ChangePassword_DAL
    {
        #region Member
        DataSet oDataSet;
        private CConnection m_oCConnectionToDB = new CConnection();
        CResult oCResult = new CResult();
        private CommonMethod oCommonMethod = new CommonMethod();
        private CExecutionDB m_oCSQLCommandExecutor = new CExecutionDB();
        Common oCommon = new Common();
        #endregion
        #region method
        public CResult TakeObject(SecurityUser_Entity oSecurityUser_Entity, EntityCommon.Mode Mode)
        {
            if (EntityCommon.Mode.dbzOk == Mode)
            {
                oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select * from SecurityUser where UsrUserName = '" + oSecurityUser_Entity.UserName + "' And UsrPassword = '" + m_oCSQLCommandExecutor.EncripPassword(oSecurityUser_Entity.FullName) + "'", oCommon.DBCon).Data;
                if (oDataSet.Tables[0].Rows.Count > 0)
                {
                    SqlCommand oSqlCommand = new SqlCommand("Update SecurityUser Set UsrPassword = '" + m_oCSQLCommandExecutor.EncripPassword(oSecurityUser_Entity.Password) + "' Where UsrUserName = '" + oSecurityUser_Entity.UserName + "' And UsrPassword = '" + m_oCSQLCommandExecutor.EncripPassword(oSecurityUser_Entity.FullName) + "'", oCommon.DBCon);
                    int i = oSqlCommand.ExecuteNonQuery();
                    if (i > -1)
                    {
                        oCResult.IsSuccess = true;
                        oCResult.Message = "Successfull";                        
                    }
                }
                else
                {
                    oCResult.IsSuccess = false;
                    oCResult.Message = "User Name or password is wrong.";
                }
            }
            return oCResult;
        }        
        #endregion
    }
}

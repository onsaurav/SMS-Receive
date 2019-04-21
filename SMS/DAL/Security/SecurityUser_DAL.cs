// Title          :   SecurityUser_DAL
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   SecurityUser_DAL [DAL for SecurityUser]
// Created        :   Rupal / Feb-09-2010
// Modified       :    

using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DBConnection;
using DBExecution;

using DAL;
using Utility;
using Entity.EntityCommonUtility;
using Entity.Security.SecurityUser;
using SMS;

namespace DAL.Security.SecurityUser
{
   public class SecurityUser_DAL
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
            if (EntityCommon.Mode.dbzAdd == Mode)
            {
                oCResult = m_oCSQLCommandExecutor.CheckDuplicate("Select * from SecurityUser where UsrUserName = '" + oSecurityUser_Entity.UserName + "' And UsrPassword = '" + m_oCSQLCommandExecutor.EncripPassword(oSecurityUser_Entity.Password) + "')", oCommon.DBCon);
                if (oCResult.IsSuccess != false)
                {
                    SqlCommand oSqlCommand = new SqlCommand("insert into SecurityUser(UsrDepartment,UsrLevel,UsrUserName,UsrFullName,UsrPassword,UsrEmailAddress,UsrActive,DateOfEntry) values('" + oSecurityUser_Entity.Department + "','" + oSecurityUser_Entity.Level + "','" + oSecurityUser_Entity.UserName + "','" + oSecurityUser_Entity.FullName + "','" + m_oCSQLCommandExecutor.EncripPassword(oSecurityUser_Entity.Password) + "','" + oSecurityUser_Entity.EmailAddress + "','" + oSecurityUser_Entity.Active + "','" + DateTime.Now.ToShortDateString() + "')", oCommon.DBCon);
                    try
                    {
                        int i = oSqlCommand.ExecuteNonQuery();
                        if (i > -1)
                        {
                            oCResult.IsSuccess = true;
                            oCResult.Message = "Successfull";
                            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select UsrDepartment,UsrLevel,UsrUserName from SecurityUser order by UsrUserName", oCommon.DBCon).Data;
                            oCResult.DataTableContainerSub = m_oCSQLCommandExecutor.LoadTable(oDataSet);
                        }
                    }
                    catch (Exception ex)
                    {
                        oCResult.IsSuccess = false;
                        oCResult.Message = ex.ToString();
                    }
                }
            }
            if (EntityCommon.Mode.dbzEdit == Mode)
            {
                oCResult = m_oCSQLCommandExecutor.CheckDuplicate("Select * from SecurityUser where UsrUserName = '" + oSecurityUser_Entity.UserName + "' And UsrPassword = '" + m_oCSQLCommandExecutor.EncripPassword(oSecurityUser_Entity.Password) + "'", oCommon.DBCon);
                if (oCResult.IsSuccess == false)
                {
                    SqlCommand oSqlCommand = new SqlCommand("update SecurityUser set UsrDepartment='" + oSecurityUser_Entity.Department + "',UsrLevel='" + oSecurityUser_Entity.Level + "',UsrFullName='" + oSecurityUser_Entity.FullName + "',UsrPassword='" + m_oCSQLCommandExecutor.EncripPassword(oSecurityUser_Entity.Password) + "',UsrEmailAddress='" + oSecurityUser_Entity.EmailAddress + "',UsrActive='" + oSecurityUser_Entity.Active + "',DateOfEntry='" + DateTime.Now.ToShortDateString() + "' where UsrUserName = '" + oSecurityUser_Entity.UserName + "'", oCommon.DBCon);
                        try
                        {
                            int i = oSqlCommand.ExecuteNonQuery();
                            if (i > -1)
                            {
                                oCResult.IsSuccess = true;
                                oCResult.Message = "Successfull";
                                oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select UsrDepartment,UsrLevel,UsrUserName from SecurityUser order by UsrUserName", oCommon.DBCon).Data;
                                oCResult.DataTableContainerSub = m_oCSQLCommandExecutor.LoadTable(oDataSet);
                            }
                        }
                        catch (Exception ex)
                        {
                            oCResult.IsSuccess = false;
                            oCResult.Message = ex.ToString();
                        }                    
                }
                else
                {
                    oCResult.IsSuccess = false;
                    oCResult.Message = "Id not found.";
                }
            }
            if (EntityCommon.Mode.dbzDelete == Mode)
            {
                oCResult = m_oCSQLCommandExecutor.CheckDuplicate("Select * from SecurityUser where UsrUserName = '" + oSecurityUser_Entity.UserName + "' And UsrPassword = '" + m_oCSQLCommandExecutor.EncripPassword(oSecurityUser_Entity.Password) + "'", oCommon.DBCon);
                if (oCResult.IsSuccess == false)
                {
                    SqlCommand oSqlCommand = new SqlCommand("Delete from SecurityUser where UsrUserName = '" + oSecurityUser_Entity.UserName + "'", oCommon.DBCon);
                    try
                    {
                        int i = oSqlCommand.ExecuteNonQuery();
                        if (i > -1)
                        {
                            oCResult.IsSuccess = true;
                            oCResult.Message = "Successfull";
                            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select UsrDepartment,UsrLevel,UsrUserName from SecurityUser order by UsrUserName", oCommon.DBCon).Data;
                            oCResult.DataTableContainerSub = m_oCSQLCommandExecutor.LoadTable(oDataSet);
                        }
                    }
                    catch (Exception ex)
                    {
                        oCResult.IsSuccess = false;
                        oCResult.Message = ex.ToString();
                    }
                }
                else
                {
                    oCResult.IsSuccess = false;
                    oCResult.Message = "Id not found.";
                }
            }
            return oCResult;
        }
        public CResult LoadData(SecurityUser_Entity oSecurityUser_Entity, string strCR)
        {
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select UsrUserName,UsrDepartment,UsrLevel from SecurityUser Where  UsrUserName Like'%" + strCR + "%' order by UsrUserName", oCommon.DBCon).Data;
            oCResult.DataTableContainerSub = m_oCSQLCommandExecutor.LoadTable(oDataSet);
            return oCResult;
        }
        public CResult LoadData(string strCR)
        {
            oDataSet = (DataSet)m_oCSQLCommandExecutor.DataAdapterQueryRequest("Select * from SecurityUser Where  UsrUserName = '" + strCR + "' order by UsrUserName", oCommon.DBCon).Data;
            oCResult.DataTableContainerSub = m_oCSQLCommandExecutor.LoadTable(oDataSet);
            return oCResult;
        }
        #endregion
    }
}

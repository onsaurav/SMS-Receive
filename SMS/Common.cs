// Title          :   Common
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   Common // Static Class for global Variables
// Created        :   Kartik Biswas / Feb-11-2010
// Modified       :   Kartik Biswas

using System;
using System.Collections.Generic;
using System.Text;

using Utility;
using DBExecution;
using DBConnection;
using Entity.EntityCommonUtility;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SMS
{
    public class Common
    {
        #region Member
        public static string strUser;
        public static SqlConnection m_oSqlConnection;
        #endregion
        #region Method
        public string UserName
        {
            get { return strUser; }
            set { strUser = value; }
        }
        public SqlConnection DBCon
        {
            get { return m_oSqlConnection; }
            set { m_oSqlConnection = value; }
        }   
        #endregion
    }
}

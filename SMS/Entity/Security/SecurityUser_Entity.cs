// Title          :   SecurityUser_Entity
// Author         :   CEO/Databiz Inc
// URL            :   www.databizsoftware.com
// Description    :   SecurityUser_Entity [Entity for SecurityUser Setup]
// Created        :   Rupal / Feb-07-2010
// Modified       :  

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Security.SecurityUser
{
   public class SecurityUser_Entity
    {
        #region Member
        private string UsrDepartment;
        private string UsrLevel;
        private string UsrUserName;
        private string UsrFullName;
        private string UsrPassword;
        private string UsrEmailAddress;
        private string UsrActive;
        private DateTime DateOfEntry;
        #endregion
        #region Method
        public string Department
       {
           get { return UsrDepartment; }
           set { UsrDepartment = value; }
       }
        public string Level
       {
           get { return UsrLevel; }
           set { UsrLevel = value; }
       }
        public string UserName
       {
           get { return UsrUserName; }
           set { UsrUserName = value; }
       }
        public string FullName
       {
           get { return UsrFullName; }
           set { UsrFullName = value; }
       }
        public string Password
       {
           get { return UsrPassword; }
           set { UsrPassword = value; }
       }
        public string EmailAddress
       {
           get { return UsrEmailAddress; }
           set { UsrEmailAddress = value; }
       }
        public string Active
       {
           get { return UsrActive; }
           set { UsrActive = value; }
       }
        public DateTime Date_Of_Entry
       {
           get { return DateOfEntry; }
           set { DateOfEntry = value; }
       }
        #endregion
    }
}

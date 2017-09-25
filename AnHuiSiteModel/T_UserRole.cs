using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_UserRole
    public class T_UserRole
    {

        /// <summary>
        /// Id
        /// </summary>		
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserId
        /// </summary>		
        private string _userid;
        public string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// RoleId
        /// </summary>		
        private string _roleid;
        public string RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

    }
}


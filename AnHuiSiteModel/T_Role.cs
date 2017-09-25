using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_Role
    public class T_Role
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
        /// ParentId
        /// </summary>		
        private string _parentid;
        public string ParentId
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// RoleName
        /// </summary>		
        private string _rolename;
        public string RoleName
        {
            get { return _rolename; }
            set { _rolename = value; }
        }
    }
}


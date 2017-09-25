using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_AuthInfo
    public class T_AuthInfo
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
        /// RoleId
        /// </summary>		
        private string _roleid;
        public string RoleId
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        /// <summary>
        /// MenuId
        /// </summary>		
        private string _menuid;
        public string MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }
        /// <summary>
        /// IsAdd
        /// </summary>		
        private bool _isadd;
        public bool IsAdd
        {
            get { return _isadd; }
            set { _isadd = value; }
        }
        /// <summary>
        /// IsEdit
        /// </summary>		
        private bool _isedit;
        public bool IsEdit
        {
            get { return _isedit; }
            set { _isedit = value; }
        }
        /// <summary>
        /// IsDelete
        /// </summary>		
        private bool _isdelete;
        public bool IsDelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }

        /// <summary>
        /// IsCheck
        /// </summary>		
        private bool _ischeck;
        public bool IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
        }
        /// <summary>
        /// 0：对应角色
        /// 1：对应用户
        /// </summary>		
        private int _type;
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

    }
}


using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_User
    public class T_User
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
        /// UserName
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// UserPwd
        /// </summary>		
        private string _userpwd;
        public string UserPwd
        {
            get { return _userpwd; }
            set { _userpwd = value; }
        }
        /// <summary>
        /// DisplayName
        /// </summary>		
        private string _displayname;
        public string DisplayName
        {
            get { return _displayname; }
            set { _displayname = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// ModifyTime
        /// </summary>		
        private DateTime _modifytime;
        public DateTime ModifyTime
        {
            get { return _modifytime; }
            set { _modifytime = value; }
        }

        public T_User()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }
    }
}


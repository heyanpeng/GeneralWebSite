using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_ContentType
    public class T_ContentType
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
        /// TypeName
        /// </summary>		
        private string _typename;
        public string TypeName
        {
            get { return _typename; }
            set { _typename = value; }
        }
        /// <summary>
        /// PageName
        /// </summary>		
        private string _pagename;
        public string PageName
        {
            get { return _pagename; }
            set { _pagename = value; }
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

    }
}


using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_Ad
    public class T_Ad
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// MenuId
        /// </summary>		
        private int _menuid;
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }
        /// <summary>
        /// PicAddress
        /// </summary>		
        private string _picaddress;
        public string PicAddress
        {
            get { return _picaddress; }
            set { _picaddress = value; }
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


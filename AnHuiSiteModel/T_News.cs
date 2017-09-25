using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_News
    public class T_News
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
        /// MenuId
        /// </summary>		
        private string _T_M_Id;
        public string T_M_Id
        {
            get { return _T_M_Id; }
            set { _T_M_Id = value; }
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
        /// Title
        /// </summary>		
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// Content
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// ScanAmount
        /// </summary>		
        private int _scanamount;
        public int ScanAmount
        {
            get { return _scanamount; }
            set { _scanamount = value; }
        }
        /// <summary>
        /// IsTop
        /// </summary>		
        private int _istop;
        public int IsTop
        {
            get { return _istop; }
            set { _istop = value; }
        }
        /// <summary>
        /// IsHot
        /// </summary>		
        private int _ishot;
        public int IsHot
        {
            get { return _ishot; }
            set { _ishot = value; }
        }
        /// <summary>
        /// IsNew
        /// </summary>		
        private int _isnew;
        public int IsNew
        {
            get { return _isnew; }
            set { _isnew = value; }
        }
        /// <summary>
        /// IsCheck
        /// </summary>		
        private int _isCheck;
        public int IsCheck
        {
            get { return _isCheck; }
            set { _isCheck = value; }
        }
        /// <summary>
        /// UId
        /// </summary>		
        private string _uid;
        public string UId
        {
            get { return _uid; }
            set { _uid = value; }
        }


        private string _source;
        public string Source
        {
            get { return _source; }
            set { _source = value; }
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

        public T_News()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }

    }
}


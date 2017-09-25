using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_MultiMedia
    public class T_MultiMedia
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
        /// T_M_Id
        /// </summary>		
        private string _newsid;
        public string NewsId
        {
            get { return _newsid; }
            set { _newsid = value; }
        }
        /// <summary>
        /// MediaAddress
        /// </summary>		
        private string _mediaaddress;
        public string MediaAddress
        {
            get { return _mediaaddress; }
            set { _mediaaddress = value; }
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
        /// <summary>
        /// Visibility
        /// </summary>		
        private bool _visibility;
        public bool Visibility
        {
            get { return _visibility; }
            set { _visibility = value; }
        }        
        public T_MultiMedia()
        {
            _createtime = DateTime.Now;
            _modifytime = DateTime.Now;
            _scanamount = 0;
        }
    }
}


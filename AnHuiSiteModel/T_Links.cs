using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace AnHuiSiteModel{
	 	//T_Links
		public class T_Links
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
        private string _t_m_id;
        public string T_M_Id
        {
            get { return _t_m_id; }
            set { _t_m_id = value; }
        }
        /// <summary>
        /// LinkText
        /// </summary>		
        private string _linktext;
        public string LinkText
        {
            get { return _linktext; }
            set { _linktext = value; }
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
        /// UrlAddress
        /// </summary>		
        private string _urladdress;
        public string UrlAddress
        {
            get { return _urladdress; }
            set { _urladdress = value; }
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
        /// <summary>
        /// SortIndex
        /// </summary>		
        private int _sortindex;
        public int SortIndex
        {
            get { return _sortindex; }
            set { _sortindex = value; }
        }
        /// <summary>
        /// Target
        /// </summary>		
        private string _target;
        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }        

        public T_Links()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }
	}
}


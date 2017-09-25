using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace AnHuiSiteModel{
	 	//T_Files
		public class T_Files
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
        /// FileName
        /// </summary>		
        private string _filename;
        public string FileName
        {
            get { return _filename; }
            set { _filename = value; }
        }
        /// <summary>
        /// FileAddress
        /// </summary>		
        private string _fileaddress;
        public string FileAddress
        {
            get { return _fileaddress; }
            set { _fileaddress = value; }
        }
        /// <summary>
        /// DAmount
        /// </summary>		
        private int _damount;
        public int DAmount
        {
            get { return _damount; }
            set { _damount = value; }
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


        public T_Files()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }
	}
}


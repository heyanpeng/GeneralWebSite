using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_Messages
    public class T_Messages
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
        /// UserName
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// Email
        /// </summary>		
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// PhoneNum
        /// </summary>		
        private string _phonenum;
        public string PhoneNum
        {
            get { return _phonenum; }
            set { _phonenum = value; }
        }
        /// <summary>
        /// Subject
        /// </summary>		
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
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
        /// CreateTime
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
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
        /// <summary>
        /// ReplyContent
        /// </summary>		
        private string _replycontent;
        public string ReplyContent
        {
            get { return _replycontent; }
            set { _replycontent = value; }
        }
        /// <summary>
        /// ReplyTime
        /// </summary>		
        private DateTime _replytime;
        public DateTime ReplyTime
        {
            get { return _replytime; }
            set { _replytime = value; }
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
        /// IsSolve
        /// </summary>		
        private bool _issolve;
        public bool IsSolve
        {
            get { return _issolve; }
            set { _issolve = value; }
        }

    }
}


using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_VoteItem
    public class T_VoteItem
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
        /// 调查内容
        /// </summary>		
        private string _voteid;
        public string VoteId
        {
            get { return _voteid; }
            set { _voteid = value; }
        }
        /// <summary>
        /// 选项内容
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// 投票人次
        /// </summary>		
        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}


using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_Vote
    public class T_Vote
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
        private string _question;
        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }
        /// <summary>
        /// 状态 1：自动根据时间计算 2：未开启 3：进行中 4：已结束 5：关闭
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>		
        private DateTime _begindatetime;
        public DateTime BeginDateTime
        {
            get { return _begindatetime; }
            set { _begindatetime = value; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>		
        private DateTime _enddatetime;
        public DateTime EndDateTime
        {
            get { return _enddatetime; }
            set { _enddatetime = value; }
        }
        /// <summary>
        /// 是否可以多选
        /// </summary>		
        private int _ismultiselect;
        public int IsMultiSelect
        {
            get { return _ismultiselect; }
            set { _ismultiselect = value; }
        }
        /// <summary>
        /// 是否公开调查结果
        /// </summary>		
        private int _ispublic;
        public int IsPublic
        {
            get { return _ispublic; }
            set { _ispublic = value; }
        }
        /// <summary>
        /// 发布人Id
        /// </summary>		
        private string _uid;
        public string UId
        {
            get { return _uid; }
            set { _uid = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        private DateTime _createtime;
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>		
        private DateTime _modifytime;
        public DateTime ModifyTime
        {
            get { return _modifytime; }
            set { _modifytime = value; }
        }
        /// <summary>
        /// 是否限制ip
        /// </summary>		
        private int _islimitip;
        public int IsLimitIP
        {
            get { return _islimitip; }
            set { _islimitip = value; }
        }
        /// <summary>
        /// 投票时段
        /// </summary>		
        private int _islimittime;
        public int IsLimitTime
        {
            get { return _islimittime; }
            set { _islimittime = value; }
        }

    }
}


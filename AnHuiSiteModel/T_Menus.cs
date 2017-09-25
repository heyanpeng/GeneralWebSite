using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_Menus
    public class T_Menus
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
        /// TypeId
        /// </summary>		
        private string _typeid;
        public string TypeId
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        /// <summary>
        /// Level
        /// </summary>		
        private int _level;
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        /// <summary>
        /// ParentId
        /// </summary>		
        private string _parentid;
        public string ParentId
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// MenuName
        /// </summary>		
        private string _menuname;
        public string MenuName
        {
            get { return _menuname; }
            set { _menuname = value; }
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
        /// Visibility
        /// </summary>		
        private bool _visibility;
        public bool Visibility
        {
            get { return _visibility; }
            set { _visibility = value; }
        }
        /// <summary>
        /// LinkSrc
        /// </summary>		
        private string _linksrc;
        public string LinkSrc
        {
            get { return _linksrc; }
            set { _linksrc = value; }
        }
        /// <summary>
        /// EnableLinkSrc
        /// </summary>		
        private bool _enablelinksrc;
        public bool EnableLinkSrc
        {
            get { return _enablelinksrc; }
            set { _enablelinksrc = value; }
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
        /// IsMainNav
        /// </summary>		
        private bool _ismainnav;
        public bool IsMainNav
        {
            get { return _ismainnav; }
            set { _ismainnav = value; }
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

        private string _menuUrl;
        public string MenuUrl
        {
            get { return _menuUrl; }
            set { _menuUrl = value; }
        }

        private string _cssClass;
        public string CssClass
        {
            get { return _cssClass; }
            set { _cssClass = value; }
        }

        public T_Menus()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
        }
    }
}


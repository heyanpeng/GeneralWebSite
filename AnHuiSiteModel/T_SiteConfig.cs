using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace AnHuiSiteModel
{
    //T_SiteConfig
    public class T_SiteConfig
    {

        /// <summary>
        /// SiteName
        /// </summary>		
        private string _sitename;
        public string SiteName
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        /// <summary>
        /// Copyright
        /// </summary>		
        private string _copyright;
        public string Copyright
        {
            get { return _copyright; }
            set { _copyright = value; }
        }
        /// <summary>
        /// LogoUrl
        /// </summary>		
        private string _logourl;
        public string LogoUrl
        {
            get { return _logourl; }
            set { _logourl = value; }
        }
        /// <summary>
        /// SiteTitle
        /// </summary>		
        private string _sitetitle;
        public string SiteTitle
        {
            get { return _sitetitle; }
            set { _sitetitle = value; }
        }
        /// <summary>
        /// Meta_Keywords
        /// </summary>		
        private string _meta_keywords;
        public string Meta_Keywords
        {
            get { return _meta_keywords; }
            set { _meta_keywords = value; }
        }
        /// <summary>
        /// Meta_Description
        /// </summary>		
        private string _meta_description;
        public string Meta_Description
        {
            get { return _meta_description; }
            set { _meta_description = value; }
        }
        /// <summary>
        /// EnableWebSite
        /// </summary>		
        private bool _enablewebsite;
        public bool EnableWebSite
        {
            get { return _enablewebsite; }
            set { _enablewebsite = value; }
        }
        /// <summary>
        /// Version
        /// </summary>		
        private string _version;
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

    }
}


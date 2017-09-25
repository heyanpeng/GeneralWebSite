using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindSiteConfig();
        }
        /// <summary>
        /// 绑定系统参数
        /// </summary>
        private void BindSiteConfig()
        {
            T_SiteConfigManager _siteConfigManager = new T_SiteConfigManager();
            T_SiteConfig siteConfig = _siteConfigManager.GetModel();
            litSiteName.Text = siteConfig.SiteName;
            litSiteTitle.Text = siteConfig.SiteTitle;
        }
    }
}
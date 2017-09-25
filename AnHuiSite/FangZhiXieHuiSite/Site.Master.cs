using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite
{
    public partial class Site : System.Web.UI.MasterPage
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_LinksManager linksManager = new T_LinksManager();
        public T_SiteConfig siteConfig;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindSiteConfig();
            if (!IsPostBack)
            {
                BindNav();

                BindLink();
            }
        }
        /// <summary>
        /// 绑定导航
        /// </summary>
        private void BindNav()
        {
            T_ContentTypeManager contentTypeManager = new T_ContentTypeManager();
            var nvadt = menuManager.GetList("Level = 1 and Visibility = 1 and IsMainNav = 1 order by sortindex desc").Tables[0];
            foreach (DataRow item in nvadt.Rows)
            {
                var EnableLinkSrc = bool.Parse(item["EnableLinkSrc"].ToString());
                if (!EnableLinkSrc)
                {
                    var Id = item["Id"].ToString();
                    var TypeId = item["TypeId"].ToString();
                    T_ContentType contentType = contentTypeManager.GetModel(TypeId);
                    var linkSrc = contentType.PageName + "?Id=" + Id;
                    item["LinkSrc"] = linkSrc;
                }
            }
            rptNav.DataSource = nvadt;
            rptNav.DataBind();
        }



        /// <summary>
        /// 友情链接
        /// </summary>
        protected void BindLink()
        {
            rptLink.DataSource = linksManager.GetList(8, "T_M_Id = '2de9dfee7514475aad3683fd46e80a24' and Visibility = 1", "SortIndex desc").Tables[0];
            rptLink.DataBind();
        }

        /// <summary>
        /// 绑定网站信息
        /// </summary>
        protected void BindSiteConfig()
        {
            T_SiteConfigManager siteConfigManager = new T_SiteConfigManager();
            siteConfig = siteConfigManager.GetModel();
            if (!siteConfig.EnableWebSite)
            {
                Response.Redirect("404.html");
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKeyWord.Text.Trim()))
                Response.Redirect("List.aspx?key=" + txtKeyWord.Text.Trim());
        }

        /// <summary>
        /// 返回当前页面导航栏CSS
        /// </summary>
        /// <param name="pLinkSrc"></param>
        /// <returns></returns>
        public string GetCurNavClass(string pLinkSrc)
        {
            object id = Request.QueryString["Id"];
            if (id != null)
            {
                if (pLinkSrc.Contains(id.ToString()))
                {
                    return "navullicurrent";
                }
            }
            return string.Empty;
        }
    }
}
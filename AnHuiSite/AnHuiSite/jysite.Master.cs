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
    public partial class jysite : System.Web.UI.MasterPage
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_NewsManager newsManager = new T_NewsManager();
        T_LinksManager linksManager = new T_LinksManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindSiteConfig();
            if (!IsPostBack)
            {
                BindMenu();
                BindFriendLink();
                object value = Request.QueryString["Id"];
                if (value != null)
                {
                    int id = 0;
                    //if (int.TryParse(value.ToString(), out id))
                    //BindContent(id);
                }
            }
        }

        void BindFriendLink()
        {
            T_LinksManager _linkManager = new T_LinksManager();
            rptFriendLink.DataSource = linksManager.GetList(6, "T_M_Id = '91c16a62ae00496cb45a9c6a10404b66' and Visibility = 1", "SortIndex desc").Tables[0];
            rptFriendLink.DataBind();
        }

        #region 绑定菜单
        void BindMenu()
        {
            rptMenu.ItemDataBound += rptMenu_ItemDataBound;
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
            rptMenu.DataSource = nvadt;
            rptMenu.DataBind();
        }
        void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rptMenuChild") as Repeater;//找到里层的repeater对象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                string parentId = rowv["Id"].ToString(); //获取填充子类的id 
                DataTable dt = menuManager.GetList("ParentId = '" + parentId + "' and Level = 2 and Visibility = 1 and IsMainNav = 1 order by sortindex desc").Tables[0];
                T_ContentTypeManager contentTypeManager = new T_ContentTypeManager();
                foreach (DataRow item in dt.Rows)
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
                rep.DataSource = dt;
                rep.DataBind();
            }
        }
        #endregion

        public T_SiteConfig siteConfig;
        /// <summary>
        /// 绑定系统配置
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
    }
}
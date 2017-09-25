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
    public partial class _static : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_StaticPageManager staticPageManager = new T_StaticPageManager();
        T_LinksManager linksManager = new T_LinksManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindSiteConfig();
            if (!IsPostBack)
            {
                BindMenu();
                BindYQLJ();
                object value = Request.QueryString["Id"];
                if (value != null)
                {
                    string id = value.ToString();
                    BindContent(id);
                }
            }
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

        /// <summary>
        /// 绑定友情链接
        /// </summary>
        protected void BindYQLJ()
        {
            T_LinksManager _linkManager = new T_LinksManager();
            rptFriendLink.DataSource = linksManager.GetList(6, "T_M_Id = '91c16a62ae00496cb45a9c6a10404b66' and Visibility = 1", "SortIndex desc").Tables[0];
            rptFriendLink.DataBind();
        }

        void BindContent(string id)
        {
            DataSet ds = staticPageManager.GetList("T_M_Id='" + id + "'");
            T_StaticPage model = new T_StaticPage();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.T_M_Id = ds.Tables[0].Rows[0]["T_M_Id"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Visibility"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Visibility"].ToString() == "1") || (ds.Tables[0].Rows[0]["Visibility"].ToString().ToLower() == "true"))
                    {
                        model.Visibility = true;
                    }
                    else
                    {
                        model.Visibility = false;
                    }
                }
            }
            else
            {
                return;
            }
            if (model == null)
                return;
            litStaticContent.Text = HttpUtility.HtmlDecode(model.Content);
            T_Menus _T_Menus = menuManager.GetModel(model.T_M_Id.ToString());
            if (_T_Menus != null)
                litTitleNav.Text = _T_Menus.MenuName;
        }
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
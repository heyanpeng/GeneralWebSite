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
    public partial class file : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_FilesManager filesManager = new T_FilesManager();
        T_LinksManager linksManager = new T_LinksManager();
        bool isParent;
        string fileId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindSiteConfig();
            object value = Request.QueryString["Id"];
            if (value != null)
            {
                fileId = value.ToString();
            }
            if (!IsPostBack)
            {
                BindMenu();
                BindFriendLink();
                if (value != null)
                {
                    T_Menus menu = menuManager.GetModel(value.ToString());
                    if (menu == null)
                        return;
                    litTitleNav.Text = menu.MenuName;
                    litTitle.Text = menu.MenuName;
                    isParent = menu.ParentId == string.Empty;
                    if (!isParent)
                        litChildTitle.Text = menuManager.GetModel(menu.ParentId).MenuName;
                    else
                        litChildTitle.Text = menu.MenuName;
                    BindList(value.ToString(), menu.ParentId == string.Empty);
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

        /// <summary>
        /// 绑定文件列表
        /// </summary>
        void BindList(string id, bool isParent = false)
        {
            DataTable childsDt = new DataTable();
            if (isParent)
            {
                childsDt = menuManager.GetList(20, "ParentId = '" + id + "' and Visibility=1", "SortIndex desc").Tables[0];
            }
            else
            {
                childsDt = menuManager.GetList(20, "Id in (select id from T_Menus where ParentId = ( select ParentId from T_Menus where id ='" + id + "')) and Visibility=1", "SortIndex desc").Tables[0];
            }
            T_ContentTypeManager contentTypeManager = new T_ContentTypeManager();
            foreach (DataRow item in childsDt.Rows)
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
            rptChilds.DataSource = childsDt;
            rptChilds.DataBind();

            if (!isParent)
                rptFilesList.DataSource = filesManager.GetList(50, "T_M_Id = '" + id + "' and Visibility=1", "CreateTime desc");
            else
                rptFilesList.DataSource = filesManager.GetList(50, "T_M_Id in (select id from T_Menus where parentid =  '" + id + "') and Visibility=1",
                    "CreateTime desc");
            rptFilesList.DataBind();

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

        public string GetCurrentTdClass(string aid)
        {
            if (aid == fileId)
                return "CurrentTdChild";
            else
                return string.Empty;
        }
        public string GetCurrentAClass(string aid)
        {
            if (aid == fileId)
                return "CurrentAChild";
            else
                return string.Empty;
        }
    }
}
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
    public partial class message : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_MessagesManager messagesManager = new T_MessagesManager();
        T_LinksManager linksManager = new T_LinksManager();
        string id = string.Empty;
        bool isParent;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindSiteConfig();
            object value = Request.QueryString["Id"];
            if (value != null)
            {
                id = value.ToString();
            }
            if (!IsPostBack)
            {
                BindMenu();
                BindYQLJ();
                T_Menus menu = menuManager.GetModel(id.ToString());
                if (menu == null)
                    return;

                litTitleNav.Text = menu.MenuName;
                messageid.Text = id;

                isParent = menu.ParentId == string.Empty;
                if (!isParent)
                    litChildTitle.Text = menuManager.GetModel(menu.ParentId).MenuName;
                else
                    litChildTitle.Text = menu.MenuName;
                BindList();
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

        void BindList()
        {
            rptChilds.DataSource = menuManager.GetList(20, "TypeId = 'f14dd27ed6284ecbbc1299283b3858d5' and Level = 2", "SortIndex desc");
            rptChilds.DataBind();

            //指定数据源
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(keyword.Value.Trim()))
                dt = messagesManager.GetList(1000, "T_M_Id = '" + id + "' and Visibility = 1 and IsSolve = 1", "ReplyTime desc").Tables[0];
            else
                dt = messagesManager.GetList(1000, "MenuId = " + id + " and Subject like '%" + keyword.Value.Trim() + "%' or Content like '%" + keyword.Value.Trim() + "%' and Visibility = 1 and IsSolve = 1", "ReplyTime desc").Tables[0];
            if (dt.Rows.Count == 0)
            {
                lbtnLasePage.Visible = false;
                lbtnFirstPage.Visible = false;
                lbtnPrePage.Visible = false;
                lbtnNextPage.Visible = false;
                return;
            }
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 5;
            pds.CurrentPageIndex = Convert.ToInt32(lblCount.Text.ToString()) - 1;
            lblPageCount.Text = pds.PageCount.ToString();
            rptMessageList.DataSource = pds;
            //如果大于当前页
            if (pds.PageCount != 1)
            {
                //如果大于当前页
                if (pds.CurrentPageIndex >= 1)
                {
                    lbtnPrePage.Enabled = true;
                    lbtnNextPage.Enabled = true;
                }

                //如果是最后一页，让下一页按钮不起作用
                if (pds.CurrentPageIndex == pds.PageCount - 1)
                {
                    lbtnFirstPage.Enabled = true;
                    lbtnNextPage.Enabled = false;
                    lbtnPrePage.Enabled = true;
                    lbtnLasePage.Enabled = false;
                }

                //如果是第一页
                if (pds.CurrentPageIndex == 0)
                {
                    lbtnLasePage.Enabled = true;
                    lbtnFirstPage.Enabled = false;
                    lbtnPrePage.Enabled = false;
                    lbtnNextPage.Enabled = true;
                }
            }
            else
            {
                lbtnLasePage.Enabled = false;
                lbtnFirstPage.Enabled = false;
                lbtnPrePage.Enabled = false;
                lbtnNextPage.Enabled = false;
            }
            rptMessageList.DataBind();

        }

        protected void lbtnPage_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            if (lbtn.Text == "首页")
                lblCount.Text = "1";
            else if (lbtn.Text == "上一页")
                lblCount.Text = (Convert.ToInt32(lblCount.Text.ToString()) - 1).ToString();
            else if (lbtn.Text == "下一页")
                lblCount.Text = (Convert.ToInt32(lblCount.Text.ToString()) + 1).ToString();
            else if (lbtn.Text == "尾页")
                lblCount.Text = lblPageCount.Text;
            BindList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        public string GetCurrentTdClass(string aid)
        {
            if (aid == id.ToString())
                return "CurrentTdChild";
            else
                return string.Empty;
        }
        public string GetCurrentAClass(string aid)
        {
            if (aid == id.ToString())
                return "CurrentAChild";
            else
                return string.Empty;
        }

        /// <summary>
        /// 绑定友情链接
        /// </summary>
        protected void BindYQLJ()
        {
            T_LinksManager _linkManager = new T_LinksManager();
            rptFriendLink.DataSource = linksManager.GetList(6, "T_M_Id = '91c16a62ae00496cb45a9c6a10404b66' and Visibility = 1", "SortIndex desc").Tables[0];
            rptFriendLink.DataBind();
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
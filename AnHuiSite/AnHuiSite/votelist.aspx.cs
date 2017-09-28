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
    public partial class votelist : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_NewsManager newsManager = new T_NewsManager();
        T_LinksManager linksManager = new T_LinksManager();

        T_VoteManager voteManager = new T_VoteManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindSiteConfig();
            if (!IsPostBack)
            {
                BindMenu();
                BindFriendLink();
                object value = Request.QueryString["Id"];
                object keyword = Request.QueryString["keyword"];
                if (value != null)
                {
                    string id = value.ToString();
                    lblId.Text = id.ToString();
                    T_Menus menu = menuManager.GetModel(id);
                    if (menu == null)
                        return;
                    newsid.Text = id.ToString();
                    litTitleNav.Text = menu.MenuName;
                    litTitle.Text = menu.MenuName;
                    lblParent.Text = menu.Level == 1 ? "0" : "1";
                    DataTable rptChildsdt = new DataTable();
                    if ((lblParent.Text == "1") && menuManager.GetModel(id).ParentId != string.Empty)
                    {
                        litChildTitle.Text = menuManager.GetModel(menu.ParentId).MenuName;
                        lblWh.Text = "Status!=5 and T_M_Id = '" + lblId.Text + "'";
                        lblOrderBy.Text = "EndDateTime desc";
                        anp.RecordCount = newsManager.GetList("T_M_Id = '" + lblId.Text + "' order by CreateTime desc").Tables[0].Rows.Count;
                        rptChildsdt = menuManager.GetList("Id in (select id from T_Menus where ParentId = ( select parentid from T_Menus where id ='" + lblId.Text + "')) Order by SortIndex desc").Tables[0];
                    }
                    else
                    {
                        litChildTitle.Text = menu.MenuName;
                        lblWh.Text = "Status!=5 and T_M_Id in (select id from T_Menus where parentid =  '" + lblId.Text + "')";
                        lblOrderBy.Text = "EndDateTime desc";
                        anp.RecordCount = newsManager.GetList("T_M_Id in (select id from T_Menus where parentid =  '" + lblId.Text + "') order by CreateTime desc").Tables[0].Rows.Count;
                        rptChildsdt = menuManager.GetList("Id in (select id from T_Menus where ParentId = ( select id from T_Menus where id ='" + lblId.Text + "')) Order by SortIndex desc").Tables[0];
                    }

                    T_ContentTypeManager contentTypeManager = new T_ContentTypeManager();
                    foreach (DataRow item in rptChildsdt.Rows)
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
                    rptChilds.DataSource = rptChildsdt;
                    rptChilds.DataBind();
                    BindList();
                }
                else if (keyword != null)
                {
                    BindList();
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

        public string GetCurrentTdClass(string aid)
        {
            if (aid == lblId.Text)
                return "CurrentTdChild";
            else
                return string.Empty;
        }
        public string GetCurrentAClass(string aid)
        {
            if (aid == lblId.Text)
                return "CurrentAChild";
            else
                return string.Empty;
        }
        public string GetParentNav(string menuId)
        {
            if ((lblParent.Text == "1") || menuManager.GetModel(lblId.Text).ParentId == string.Empty)
            {
                T_Menus menu = menuManager.GetModel(menuId);
                return "<a style='color:gray;' href='list.aspx?Id=" + menu.Id + "'>[" + menu.MenuName + "]</a>";
            }
            return string.Empty;
        }
        void BindList()
        {
            object keyword = Request.QueryString["keyword"];
            if (keyword != null)
            {
                anp.RecordCount = voteManager.GetList("Title like '%" + keyword + "%'").Tables[0].Rows.Count;
                int pagesize = anp.PageSize;
                int pageindex = anp.CurrentPageIndex;
                rptVoteList.DataSource = voteManager.GetListByPage("Title like '%" + keyword + "%'", "CreateTime desc", (pageindex - 1) * pagesize + 1, pagesize * pageindex);
                rptVoteList.DataBind();
            }
            else
            {
                int pagesize = anp.PageSize;
                int pageindex = anp.CurrentPageIndex;
                rptVoteList.DataSource = voteManager.GetListByPage(lblWh.Text, lblOrderBy.Text, (pageindex - 1) * pagesize + 1, pagesize * pageindex);
                rptVoteList.DataBind();
            }
        }
        protected void anp_PageChanged(object sender, EventArgs e)
        {
            BindList();
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

        public string ReturnUrl(int pStatus, DateTime pBeginDateTime, DateTime pEndDateTime)
        {
            if (pStatus == 1)
            {
                if (pBeginDateTime > DateTime.Now)
                {
                    pStatus = 1;
                }
                if (pBeginDateTime <= DateTime.Now && DateTime.Now <= pEndDateTime)
                {
                    pStatus = 3;
                }
                if (pEndDateTime < DateTime.Now)
                {
                    pStatus = 4;
                }
            }
            string statusStr = string.Empty;
            //状态 1：自动根据时间计算 2：未开启 3：进行中 4：已结束 5：关闭
            switch (pStatus)
            {
                case 2:
                    {
                        statusStr = "javascript:void(0);";
                        break;
                    }
                case 3:
                    {
                        statusStr = "votecontent.aspx";
                        break;
                    }
                case 4:
                    {
                        statusStr = "voteresult.aspx";
                        break;
                    }
                case 5:
                    {
                        statusStr = "#";
                        break;
                    }
            }
            return statusStr;
        }

        public string ReturnStatus(int pStatus, DateTime pBeginDateTime, DateTime pEndDateTime)
        {
            if (pStatus == 1)
            {
                if (pBeginDateTime > DateTime.Now)
                {
                    pStatus = 2;
                }
                if (pBeginDateTime <= DateTime.Now && DateTime.Now <= pEndDateTime)
                {
                    pStatus = 3;
                }
                if (pEndDateTime < DateTime.Now)
                {
                    pStatus = 4;
                }
            }
            string statusStr = string.Empty;
            //状态 1：自动根据时间计算 2：未开启 3：进行中 4：已结束 5：关闭
            switch (pStatus)
            {
                case 2:
                    {
                        statusStr = "<label style='color:green;'>未开启<label>";
                        break;
                    }
                case 3:
                    {
                        statusStr = "<label style='color:red;'>进行中<label>";
                        break;
                    }
                case 4:
                    {
                        statusStr = "<label style='color:gray;'>已结束<label>";
                        break;
                    }
                case 5:
                    {
                        statusStr = "<label>关闭<label>";
                        break;
                    }
            }
            return statusStr;
        }
    }
}
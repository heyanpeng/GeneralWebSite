using AnHuiSiteBLL;
using AnHuiSiteModel;
using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public Dictionary<string, List<T_Menus>> ChildMenuDic = new Dictionary<string, List<T_Menus>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                T_User user = Session["User"] as T_User;
                litUserName.Text = user.DisplayName;
                BindMenus();
                BindSiteConfig();
            }
        }
        public int TodayNews = 0;
        public int UnCheckCityNews = 0;
        public int TodayMessage = 0;
        public int UnCheckMessage = 0;
        public string panelAdminStatus;
        public string menuVisible = "none";
        /// <summary>
        /// 绑定系统新闻留言状态 
        /// </summary>
        private void BindMessageStatus()
        {
            T_NewsManager newsManager = new T_NewsManager();
            DataSet dsNews = newsManager.GetList("createtime >= '" + (new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)) + "'");
            TodayNews = dsNews.Tables[0].Rows.Count;
            dsNews = newsManager.GetList("MenuId in (SELECT [Id] FROM [T_Menus] where ParentId = 23) and IsCheck = 0");
            UnCheckCityNews = dsNews.Tables[0].Rows.Count;

            T_MessagesManager messagesManager = new T_MessagesManager();
            DataSet dsMessage = messagesManager.GetList("createtime >= '" + (new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)) + "'");
            TodayMessage = dsMessage.Tables[0].Rows.Count;
            dsMessage = messagesManager.GetList("ReplyTime = ''");
            UnCheckMessage = dsMessage.Tables[0].Rows.Count;
        }

        private void BindMenus()
        {
            T_User user = Session["User"] as T_User;
            string wh = "T_Menus.Id in(select distinct(T_AuthInfo.MenuId) from T_AuthInfo where RoleId in (select T_UserRole.RoleId from T_User left join T_UserRole on T_User.Id = T_UserRole.UserId where T_User.Id='" + user.Id + "')) and Level=1 order by T_Menus.SortIndex desc";
            T_MenusManager menusManager = new T_MenusManager();
            var data = menusManager.GetModelList(wh);
            data.ForEach(m =>
            {
                ModifyProperty(m, 1);
            });
            rptMenus.DataSource = data;
            rptMenus.DataBind();
        }
        protected void rptMenus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater subRepeat = (Repeater)e.Item.FindControl("rptSubMenus");
                if (subRepeat != null)
                {
                    var id = ((T_Menus)e.Item.DataItem).Id;
                    T_MenusManager menusManager = new T_MenusManager();
                    T_User user = Session["User"] as T_User;
                    string wh = "T_Menus.Id in(select distinct(T_AuthInfo.MenuId) from T_AuthInfo where RoleId in (select T_UserRole.RoleId from T_User left join T_UserRole on T_User.Id = T_UserRole.UserId where T_User.Id='" + user.Id + "')) and ParentId = '" + id + "' order by T_Menus.SortIndex desc";
                    var data = menusManager.GetModelList(wh);
                    data.ForEach(m =>
                    {
                        ModifyProperty(m, 2);
                    });

                    subRepeat.DataSource = data;
                    subRepeat.DataBind();
                }
            }
        }

        protected void rptSubMenus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater subRepeat = (Repeater)e.Item.FindControl("rptThirdMenus");
                if (subRepeat != null)
                {
                    var id = ((T_Menus)e.Item.DataItem).Id;
                    if (ChildMenuDic.ContainsKey(id))
                    {
                        var data = ChildMenuDic[id];
                        data.ForEach(m =>
                        {
                            ModifyProperty(m, 3);
                        });
                        subRepeat.DataSource = data;
                        subRepeat.DataBind();
                    }
                }
            }
        }

        private void ModifyProperty(T_Menus menu, int level)
        {
            if (level == 1)
            {
                GenerateUrl(menu);
            }
            if (level == 2)
            {
                T_MenusManager menusManager = new T_MenusManager();
                T_User user = Session["User"] as T_User;
                string wh = "T_Menus.Id in(select distinct(T_AuthInfo.MenuId) from T_AuthInfo where RoleId in (select T_UserRole.RoleId from T_User left join T_UserRole on T_User.Id = T_UserRole.UserId where T_User.Id='" + user.Id + "')) and ParentId = '" + menu.Id + "' order by T_Menus.SortIndex desc";
                var childMenus = menusManager.GetModelList(wh);
                if (childMenus != null && childMenus.Count > 0)
                {
                    ChildMenuDic[menu.Id] = childMenus;
                    menu.MenuUrl = "#";
                    menu.CssClass = "dropdown-toggle";
                }
                else
                {
                    GenerateUrl(menu);
                }
            }
            else
            {
                GenerateUrl(menu);
            }
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
        private static void GenerateUrl(T_Menus menu)
        {
            switch (menu.TypeId)
            {
                case "225e8b1d75d34f7d97ca410166c8b742"://后台内置菜单
                    menu.MenuUrl = menu.LinkSrc;
                    break;
                case "c44d9940d94c4687bb2e4bc4be1d8b41"://新闻
                    menu.MenuUrl = "NewsManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "bbf038d270cd4e218459d02082f05adc"://图片新闻
                    menu.MenuUrl = "NewsManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "26f6e85409ba4096beb7ebfadceaeeb4"://视频多媒体
                    menu.MenuUrl = "NewsManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "750aaf8a27a84301b6cd2e7250b44b4c"://音频多媒体
                    break;
                case "b5f7b2e2adad494682698e882d88934d"://静态页面
                    menu.MenuUrl = "StaticPageManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "58626cda02a24fd49429427f2bd317e0"://文字友情链接
                    menu.MenuUrl = "LinksManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "4b82810de7db467699cf45c1ab357a28"://图片友情链接
                    menu.MenuUrl = "LinksManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "f14dd27ed6284ecbbc1299283b3858d5"://消息
                    menu.MenuUrl = "MessagesManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "52bb1a89cebe4be4a741241b2050d59b"://文件
                    menu.MenuUrl = "FileManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "e663f37bee9c478cb9dcce6d00f842c4"://广告
                    break;
                case "dad4469e96c24175bec133935bafa6a3"://图库
                    menu.MenuUrl = "NewsManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                case "b2ee9236d5914caabfe052d79e74e6c9"://投票
                    menu.MenuUrl = "VoteManager.aspx?mId=" + menu.Id + "&mName=" + menu.MenuName + "&tId=" + menu.TypeId;
                    break;
                default:
                    break;
            }
        }
    }
}
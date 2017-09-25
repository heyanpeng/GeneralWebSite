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
    public partial class videodetail : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_NewsManager newsManager = new T_NewsManager();
        T_LinksManager linksManager = new T_LinksManager();
        public string PicAddress = string.Empty;
        public string multiMediaPicAddress = string.Empty;
        public string multiMediaSrc = string.Empty;
        public string mediaType = string.Empty;
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
                    BindContent(value.ToString());
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

        private void BindContent(string id)
        {
            T_News newsEntity = newsManager.GetModel(id);
            if (newsEntity == null)
                return;
            newsManager.UpdateScanAmount(newsEntity.Id);
            litTitle.Text = newsEntity.Title;
            litCreateDate.Text = newsEntity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            litComeFrome.Text = newsEntity.Source;
            litScanAmount.Text = newsEntity.ScanAmount.ToString();
            if (newsEntity.CreateTime < (new DateTime(2015, 7, 22, 0, 0, 0)))
                litContent.Text = HttpUtility.HtmlDecode(newsEntity.Content).Replace("/UploadFile/", "UploadFile/");
            else
                litContent.Text = HttpUtility.HtmlDecode(newsEntity.Content);
            T_User user = (new T_UserManager()).GetModel(newsEntity.UId);
            if (user != null)
                litUId.Text = (new T_UserManager()).GetModel(newsEntity.UId).DisplayName;
            PicAddress = newsEntity.PicAddress;
            InitMedia(newsEntity);
        }
        private void InitMedia(T_News newsEntity)
        {
            DataTable dsMedia = new T_MultiMediaManage().GetList(1, "NewsId='" + newsEntity.Id + "'", "ID desc").Tables[0];
            if (dsMedia != null && dsMedia.Rows.Count > 0)
            {
                multiMediaSrc = Request.Url.Authority + "/AHAdmin/Uploads/Video/" + dsMedia.Rows[0]["MediaAddress"].ToString();
                multiMediaPicAddress = newsManager.GetModel(dsMedia.Rows[0]["NewsId"].ToString()).PicAddress;
                mediaType = System.IO.Path.GetExtension(multiMediaSrc);
            }
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
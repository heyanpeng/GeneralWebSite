using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace AnHuiSite
{
    public partial class _default : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_NewsManager newsManager = new T_NewsManager();
        T_FilesManager filesManager = new T_FilesManager();
        T_LinksManager linksManager = new T_LinksManager();
        public string multiMediaPicAddress = string.Empty;
        public string multiMediaSrc = string.Empty;
        public string mediaType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindSiteConfig();
            if (!IsPostBack)
            {
                BindMenu();
                BindTPXW();
                BindTZGG();
                BindLDJH();
                InitMedia();
                BindXDSS();
                BindLYDT();
                BindWJXZ();
                BindYHSW();
                BindYQLJ();
            }
        }

        /// <summary>
        /// 绑定图片新闻
        /// </summary>
        protected void BindTPXW()
        {
            DataTable dtZXYW = newsManager.GetList(8, "T_M_Id = '4aed673013ef4d2391816baa80469345' and IsCheck = 1", "IsTop desc,CreateTime desc").Tables[0];

            rptZuiXinYaoWenWord.DataSource = dtZXYW;
            rptZuiXinYaoWenWord.DataBind();

            DataTable dtSXXW = newsManager.GetList(8, "T_M_Id in(select Id from t_menus where parentid = '4badd77399034ce0b3e283eb572ca985') and IsCheck = 1", "IsTop desc,CreateTime desc").Tables[0];

            rptShiXianXinWen.DataSource = dtSXXW;
            rptShiXianXinWen.DataBind();

            foreach (DataRow dr in dtSXXW.Rows)
            {
                dtZXYW.Rows.Add(dr.ItemArray);
            }

            DataTable zxywpicword = ToDataTable(dtZXYW.Select("PicAddress is not null"));

            rptZuiXinYaoWenPic.DataSource = zxywpicword;
            rptZuiXinYaoWenPic.DataBind();

            rptZuiXinYaoWenPicIndex.DataSource = zxywpicword;
            rptZuiXinYaoWenPicIndex.DataBind();

            rptZuiXinYaoWenPicWord.DataSource = zxywpicword;
            rptZuiXinYaoWenPicWord.DataBind();


        }

        private DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone(); // 复制DataRow的表结构
            foreach (DataRow row in rows)
            {

                tmp.ImportRow(row); // 将DataRow添加到DataTable中
            }
            return tmp;
        }

        /// <summary>
        /// 通知公告
        /// </summary>
        protected void BindTZGG()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id = '6bfc4f2f3a3d4404b3cdfcd619ebce07' and IsCheck = 1", "IsTop desc,CreateTime desc").Tables[0];
            rptTZGG.DataSource = dt;
            rptTZGG.DataBind();
        }

        /// <summary>
        /// 领导讲话
        /// </summary>
        protected void BindLDJH()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id = 'a85221f43911420896d4be66879e3b7a' and IsCheck = 1", "IsTop desc,CreateTime desc").Tables[0];
            rptLDJH.DataSource = dt;
            rptLDJH.DataBind();
        }

        /// <summary>
        /// 绑定首页视频新闻
        /// </summary>
        protected void InitMedia()
        {
            DataTable dsMedia = new T_MultiMediaManage().GetList(1, "NewsId in (select id from T_News where PicAddress <> '' and IsCheck = 1)", "CreateTime desc").Tables[0];
            if (dsMedia != null && dsMedia.Rows.Count > 0)
            {
                multiMediaSrc = Request.Url.Authority + "/AHAdmin/Uploads/Video/" + dsMedia.Rows[0]["MediaAddress"].ToString();
                multiMediaPicAddress = newsManager.GetModel(dsMedia.Rows[0]["NewsId"].ToString()).PicAddress;
                mediaType = System.IO.Path.GetExtension(multiMediaSrc);
            }
        }


        /// <summary>
        /// 兄弟省市
        /// </summary>
        protected void BindXDSS()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id = '1d3fde6772614bb7883a347a551defcc' and IsCheck = 1", "IsTop desc,CreateTime desc").Tables[0];
            rptXDSS.DataSource = dt;
            rptXDSS.DataBind();
        }

        /// <summary>
        /// 林业动态
        /// </summary>
        protected void BindLYDT()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id = 'a5c7462fbcff45599193c849910c7faf' and IsCheck = 1", "IsTop desc,CreateTime desc").Tables[0];
            rptLYDT.DataSource = dt;
            rptLYDT.DataBind();
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        protected void BindWJXZ()
        {
            DataTable dt = filesManager.GetList(8, "T_M_Id = '6322447e140a4df499f06b5f0bcfa62c' and Visibility = 1", "CreateTime desc").Tables[0];
            rptWJXZ.DataSource = dt;
            rptWJXZ.DataBind();
        }

        /// <summary>
        /// 有害生物
        /// </summary>
        protected void BindYHSW()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id = '53a37542ad2b4f33bd4bfbebb35634c8' and IsCheck = 1", "IsTop desc,CreateTime desc").Tables[0];
            rptYHSW.DataSource = dt;
            rptYHSW.DataBind();
        }

        /// <summary>
        /// 绑定友情链接
        /// </summary>
        protected void BindYQLJ()
        {
            T_LinksManager _linkManager = new T_LinksManager();
            rptFriendLink.DataSource = linksManager.GetList(6, "T_M_Id = '91c16a62ae00496cb45a9c6a10404b66' and Visibility = 1", "SortIndex desc").Tables[0];
            rptFriendLink.DataBind();

            rptFriendLinkDDL1.DataSource = linksManager.GetList(0, "T_M_Id = 'b0dfa24678c64a9ba8194af11ab077f2' and Visibility = 1", "SortIndex desc").Tables[0];
            rptFriendLinkDDL1.DataValueField = "UrlAddress";
            rptFriendLinkDDL1.DataTextField = "LinkText";
            rptFriendLinkDDL1.DataBind();

            rptFriendLinkDDL2.DataSource = linksManager.GetList(0, "T_M_Id = '576a70ab82494f5383ab250773258768' and Visibility = 1", "SortIndex desc").Tables[0];
            rptFriendLinkDDL2.DataValueField = "UrlAddress";
            rptFriendLinkDDL2.DataTextField = "LinkText";
            rptFriendLinkDDL2.DataBind();

            rptFriendLinkDDL3.DataSource = linksManager.GetList(0, "T_M_Id = 'd67aaa8033cc4cc287cd1fd06d9509ab' and Visibility = 1", "SortIndex desc").Tables[0];
            rptFriendLinkDDL3.DataValueField = "UrlAddress";
            rptFriendLinkDDL3.DataTextField = "LinkText";
            rptFriendLinkDDL3.DataBind();

            rptFriendLinkDDL4.DataSource = linksManager.GetList(0, "T_M_Id = 'f88ed5833dde47489cd1dd96e7bbb8f1' and Visibility = 1", "SortIndex desc").Tables[0];
            rptFriendLinkDDL4.DataValueField = "UrlAddress";
            rptFriendLinkDDL4.DataTextField = "LinkText";
            rptFriendLinkDDL4.DataBind();
        }


        public T_SiteConfig siteConfig;
        /// <summary>
        /// 系统配置
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

        #region 绑定菜单
        /// <summary>
        /// 菜单
        /// </summary>
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

        public string GetShortDate(string date)
        {
            DateTime dt = new DateTime();
            DateTime.TryParse(date, out dt);
            return dt.ToString("MM/dd");
        }
        public static string RemoveHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        public string HtmlDecode(string txt)
        {
            return HttpUtility.HtmlDecode(txt);
        }
        /// <summary>
        /// 搜索
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = Request.Form["Text1"];

            if (!string.IsNullOrEmpty(keyword))
                Response.Redirect("list.aspx?keyword=" + keyword);
        }

        protected void rptFriendLinkDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            if (!string.IsNullOrEmpty(ddl.SelectedItem.Value))
                Response.Redirect(ddl.SelectedItem.Value);
        }
    }
}
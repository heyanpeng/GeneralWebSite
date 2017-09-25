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
                BindYQLJ();
            }
            BindMenu();
            BindBanner();
            BindTPXW();
            BindZCFG();
            BindLDJH();
            BindGZDT();
            BindTZGG();
            BindLYKJ();
            BindLYCP();
            BindZWGK();
            BindWSHD();
            BindYHSW();
            BindZTZL();
            BindBSFW();
            InitMedia();
        }

        /// <summary>
        /// 绑定首页视频新闻
        /// </summary>
        private void InitMedia()
        {
            DataTable dsMedia = new T_MultiMediaManage().GetList(1, "NewsId in (select id from T_News where PicAddress <> '' and IsCheck = 1)", "ModifyTime desc").Tables[0];
            if (dsMedia != null && dsMedia.Rows.Count > 0)
            {
                multiMediaSrc = Request.Url.Authority + "/jysite/AHAdmin/Uploads/Video/" + dsMedia.Rows[0]["MediaAddress"].ToString();
                multiMediaPicAddress = newsManager.GetModel(dsMedia.Rows[0]["NewsId"].ToString()).PicAddress;
                mediaType = System.IO.Path.GetExtension(multiMediaSrc);
            }
        }

        /// <summary>
        /// 绑定图片新闻
        /// </summary>
        protected void BindTPXW()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id = '550dec3af2774641aa3c90462ec42ad4'", "IsTop desc,ModifyTime desc").Tables[0];
            rptTPXWPic.DataSource = dt;
            rptTPXWPic.DataBind();

            rptTPXWWord.DataSource = dt;
            rptTPXWWord.DataBind();
        }

        /// <summary>
        /// 绑定政策法规
        /// </summary>
        protected void BindZCFG()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id in(select id from T_Menus where parentid = 'e6c7a4c66bfc4912863d0ffefe613afa')", "IsTop desc,ModifyTime desc").Tables[0];
            rptZCFG.DataSource = dt;
            rptZCFG.DataBind();
        }

        /// <summary>
        /// 绑定领导讲话
        /// </summary>
        protected void BindLDJH()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id in(select id from T_Menus where parentid = 'c079654360e7438e87aca6c4ac38c0d9')", "IsTop desc,ModifyTime desc").Tables[0];
            rptLDJH.DataSource = dt;
            rptLDJH.DataBind();
        }

        /// <summary>
        /// 绑定工作动态
        /// </summary>
        protected void BindGZDT()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id in(select id from T_Menus where parentid = 'a153f60de0ce4a5b84beb3721e48e75f')", "IsTop desc,ModifyTime desc").Tables[0];
            rptGZDT.DataSource = dt;
            rptGZDT.DataBind();
        }

        /// <summary>
        /// 绑定通知公告
        /// </summary>
        protected void BindTZGG()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id in(select id from T_Menus where parentid = 'b4f00cfdaead496e901127398d9a0799')", "IsTop desc,ModifyTime desc").Tables[0];
            rptTZGG.DataSource = dt;
            rptTZGG.DataBind();
        }

        /// <summary>
        /// 绑定林业科技
        /// </summary>
        protected void BindLYKJ()
        {
            //DataTable dt = newsManager.GetList(8, "T_M_Id = 'b051d046e89143fa9c263aa99ce9bce3'", "IsTop desc,ModifyTime desc").Tables[0];
            //rptLYKJ.DataSource = dt;
            //rptLYKJ.DataBind();
        }

        /// <summary>
        /// 绑定林业产品
        /// </summary>
        protected void BindLYCP()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id in(select id from T_Menus where parentid = '0bf376ce084047c784bc6d05a9c795e9')", "IsTop desc,ModifyTime desc").Tables[0];
            rptLYCP.DataSource = dt;
            rptLYCP.DataBind();
        }

        public T_Menus menuZDWJ;//制度文件
        public T_Menus menuGKZN;//公开指南
        public T_Menus menuGKML;//公开目录
        public T_Menus menuYSQGK;//依申请公开
        public T_Menus menuNDBG;//年度报告
        public T_Menus menuSSBF;//实施办法
        /// <summary>
        /// 绑定政务公开
        /// </summary>
        protected void BindZWGK()
        {
            T_MenusManager menuManager = new T_MenusManager();
            menuZDWJ = menuManager.GetModel("ce425d4c80264a3ea7e9aea628581567");
            menuZDWJ.LinkSrc = GetUrlByTypeId(menuZDWJ);

            menuGKZN = menuManager.GetModel("d7a07bd1079e4d179f973411fb7c15d5");
            menuGKZN.LinkSrc = GetUrlByTypeId(menuGKZN);

            menuGKML = menuManager.GetModel("aaeccba3125044a496e40ba0c7777d29");
            menuGKML.LinkSrc = GetUrlByTypeId(menuGKML);

            menuYSQGK = menuManager.GetModel("71f4df2e1b67482a8bcb8ac7f28e54ad");
            menuYSQGK.LinkSrc = GetUrlByTypeId(menuYSQGK);

            menuNDBG = menuManager.GetModel("4143fa2741be43768a598c518a831b38");
            menuNDBG.LinkSrc = GetUrlByTypeId(menuNDBG);

            menuSSBF = menuManager.GetModel("9ad835bc036d4d23b28eda04fe2c0942");
            menuSSBF.LinkSrc = GetUrlByTypeId(menuSSBF);
        }

        protected string GetUrlByTypeId(T_Menus pT_Menus)
        {
            if (menuZDWJ == null)
                return string.Empty;
            if (!pT_Menus.EnableLinkSrc)
            {
                T_ContentTypeManager contentTypeManager = new T_ContentTypeManager();
                T_ContentType contentType = contentTypeManager.GetModel(pT_Menus.TypeId);
                var linkSrc = contentType.PageName + "?Id=" + pT_Menus.Id;
                return linkSrc;
            }
            return pT_Menus.LinkSrc;
        }

        public T_Menus menuJZXX;//局长信箱
        public T_Menus menuDCZJ;//调查征集
        public T_Menus menuZWZX;//政务咨询
        /// <summary>
        /// 绑定网上互动
        /// </summary>
        protected void BindWSHD()
        {
            menuJZXX = menuManager.GetModel("d07a7c74374d4cd0ba927cc84913e05f");
            menuJZXX.LinkSrc = GetUrlByTypeId(menuJZXX);
            menuDCZJ = menuManager.GetModel("47ee57c1da1b4a4fb8f60968fdc75b3b");
            menuDCZJ.LinkSrc = GetUrlByTypeId(menuDCZJ);
            menuZWZX = menuManager.GetModel("45e261b20eb14c35b0e8350491bbb68b");
            menuZWZX.LinkSrc = GetUrlByTypeId(menuZWZX);
        }


        public DataTable ztzlDt;
        /// <summary>
        /// 绑定专题专栏
        /// </summary>
        protected void BindZTZL()
        {
            T_LinksManager _linkManager = new T_LinksManager();
            ztzlDt = _linkManager.GetList(4, "T_M_Id = '1ef1626a76cd4c69bcfe8666443ada0d' and Visibility = 1", "SortIndex desc").Tables[0];
            int addCount = 4 - ztzlDt.Rows.Count;
            for (int i = 0; i < addCount; i++)
            {
                ztzlDt.Rows.Add();
            }
        }


        public T_Menus menuBSZN;//办事指南
        public T_Menus menuWSBS;//网上办事
        /// <summary>
        /// 绑定办事服务
        /// </summary>
        protected void BindBSFW()
        {
            menuBSZN = menuManager.GetModel("1a0b1c97d3314d3e84f4f49966e8baff");
            menuBSZN.LinkSrc = GetUrlByTypeId(menuBSZN);
            menuWSBS = menuManager.GetModel("fa259cffa30f4d30bb996f08fbea5fbd");
            menuWSBS.LinkSrc = GetUrlByTypeId(menuWSBS);
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

        /// <summary>
        /// 绑定有害生物
        /// </summary>
        protected void BindYHSW()
        {
            DataTable dt = newsManager.GetList(8, "T_M_Id = '3c99ffda63844fc5b982b530ff9e7295'", "IsTop desc,ModifyTime desc").Tables[0];
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
        /// 绑定横幅
        /// </summary>
        public void BindBanner()
        {
            T_LinksManager _linkManager = new T_LinksManager();
            rptBanner.DataSource = linksManager.GetList(0, "T_M_Id = 'cd71fdde2b074c6d8855d974a8676669' and Visibility = 1", "SortIndex desc").Tables[0];
            rptBanner.DataBind();
        }

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

        //protected void rptFriendLinkDDL1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rptFriendLinkDDL1.SelectedItem == null)
        //        return;
        //    if (!string.IsNullOrEmpty(rptFriendLinkDDL1.SelectedItem.Value))
        //        Response.Redirect(rptFriendLinkDDL1.SelectedItem.Value);
        //}
        //protected void rptFriendLinkDDL2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rptFriendLinkDDL2.SelectedItem == null)
        //        return;
        //    if (!string.IsNullOrEmpty(rptFriendLinkDDL2.SelectedItem.Value))
        //        Response.Redirect(rptFriendLinkDDL2.SelectedItem.Value);
        //}
        //protected void rptFriendLinkDDL3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rptFriendLinkDDL3.SelectedItem == null)
        //        return;
        //    if (!string.IsNullOrEmpty(rptFriendLinkDDL3.SelectedItem.Value))
        //        Response.Redirect(rptFriendLinkDDL3.SelectedItem.Value);
        //}
        //protected void rptFriendLinkDDL4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rptFriendLinkDDL4.SelectedItem == null)
        //        return;
        //    if (!string.IsNullOrEmpty(rptFriendLinkDDL4.SelectedItem.Value))
        //        Response.Redirect(rptFriendLinkDDL4.SelectedItem.Value);
        //}
    }
}
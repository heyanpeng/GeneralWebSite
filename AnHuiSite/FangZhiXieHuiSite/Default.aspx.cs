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
    public partial class Default : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_NewsManager newsManager = new T_NewsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNewsBanner();

                BindAbout();

                BindNewsDynamic();

                BindNewsPromote();

                BindNewsCommunicate();

                BindNewsIndustry();

                BindMembers();
            }
        }

        /// <summary>
        /// Banner新闻
        /// </summary>
        protected void BindNewsBanner()
        {
            DataTable dt = newsManager.GetList(5, "T_M_Id = '6068a1db401a4af18ef2470ddac0d85a' and IsCheck=1", "IsTop desc,ModifyTime desc").Tables[0];

            rptNewsBannerImg.DataSource = dt;
            rptNewsBannerImg.DataBind();

            rptNewsBannerWord.DataSource = dt;
            rptNewsBannerWord.DataBind();
        }

        /// <summary>
        /// 关于协会
        /// </summary>
        protected void BindAbout()
        {
            T_ContentTypeManager contentTypeManager = new T_ContentTypeManager();
            var aboutdt = menuManager.GetList("Level = 2 and Visibility = 1 and IsMainNav = 0 and ParentId = 'e10f9c6642d142c6a01a55ee0ae40d2f' order by sortindex desc").Tables[0];
            foreach (DataRow item in aboutdt.Rows)
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
            rptAbout.DataSource = aboutdt;
            rptAbout.DataBind();
        }

        /// <summary>
        /// 协会动态
        /// </summary>
        protected void BindNewsDynamic()
        {
            DataTable dt = newsManager.GetList(9, "T_M_Id = 'a7e585f521e948a09fcf23360fc85775' and IsCheck=1", "IsTop desc,ModifyTime desc").Tables[0];
            rptNewsDynamic.DataSource = dt;
            rptNewsDynamic.DataBind();
        }

        /// <summary>
        /// 技术推广
        /// </summary>
        protected void BindNewsPromote()
        {
            DataTable dt = newsManager.GetList(9, "T_M_Id = '60a8e26113414f18a1d3aae1b0d65bcd' and IsCheck=1", "IsTop desc,ModifyTime desc").Tables[0];
            rptNewsPromote.DataSource = dt;
            rptNewsPromote.DataBind();
        }

        /// <summary>
        /// 经验交流
        /// </summary>
        protected void BindNewsCommunicate()
        {
            DataTable dt = newsManager.GetList(9, "T_M_Id = 'a9b6ac0838a043a28dcdc610226872bc' and IsCheck=1", "IsTop desc,ModifyTime desc").Tables[0];
            rptNewsCommunicate.DataSource = dt;
            rptNewsCommunicate.DataBind();
        }

        /// <summary>
        /// 行业新闻
        /// </summary>
        protected void BindNewsIndustry()
        {
            DataTable dt = newsManager.GetList(9, "T_M_Id = 'db6e5b8e707e415e9864403fabf282d2' and IsCheck=1", "IsTop desc,ModifyTime desc").Tables[0];
            rptNewsIndustry.DataSource = dt;
            rptNewsIndustry.DataBind();
        }

        /// <summary>
        /// 绑定会员风采
        /// </summary>
        protected void BindMembers()
        {
            DataTable dt = newsManager.GetList(9, "T_M_Id = '312cecf611964b41a3eb1409b7043064' and IsCheck=1", "IsTop desc,ModifyTime desc").Tables[0];
            rptMembers.DataSource = dt;
            rptMembers.DataBind();
        }
    }
}
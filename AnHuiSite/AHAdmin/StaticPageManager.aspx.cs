using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class StaticPageManager : System.Web.UI.Page
    {
        public string mName;
        public string uId;
        public string displayName;
        public string mId;
        public string tId;
        public T_StaticPage staticPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            T_User user = Session["User"] as T_User;
            if (user != null)
            {
                uId = user.Id.ToString();
                displayName = user.DisplayName;
            }

            mId = Request.QueryString["mId"];
            mName = Request.QueryString["mName"];
            tId = Request.QueryString["tId"];

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(mId))
                {
                    T_StaticPageManager manager = new T_StaticPageManager();
                    staticPage = manager.GetModelList("T_M_Id='" + mId + "'").FirstOrDefault();
                    if (staticPage == null)
                    {
                        staticPage = new T_StaticPage();
                    }
                    else
                    {
                        staticPage.Content = HttpUtility.HtmlDecode(staticPage.Content);
                    }
                }
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class ContentRouter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tId = int.Parse(Request.QueryString["tId"]);
            var mId = Request.QueryString["mId"];
            var mName = Request.QueryString["mName"];

            if (!IsPostBack)
            {
                string url = string.Empty;
                //新闻
                switch (tId)
                {
                    case 1:
                    case 2:
                        url = "NewsManager.aspx?mId=" + mId + "&mName=" + mName + "&tId=" + tId;
                        break;
                    default:
                        break;
                }

                Server.Execute(url);
            }
        }
    }
}
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
    public partial class EditLinks : System.Web.UI.Page
    {
        public string mName;
        public string uId;
        public string displayName;
        public string mId;
        public string tId;
        public T_Links links;

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
            string id = Request.QueryString["Id"];

            if (!IsPostBack)
            {
                T_LinksManager manager = new T_LinksManager();
                links = manager.GetModel(id);
                if (links == null)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "editLinks", "<script>showErrorDialog('获取的链接信息为空');</script>");
                    return;
                }
            }
        }
    }
}
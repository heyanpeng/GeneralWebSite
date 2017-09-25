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
    public partial class EditMessages : System.Web.UI.Page
    {
        public string mId;
        public string mName;
        public string uId;
        public string displayName;
        public string tId;
        public T_Messages messages;
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
                T_MessagesManager messagesManager = new T_MessagesManager();
                messages = messagesManager.GetModel(id);
                if (messages == null)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "editNews", "<script>showErrorDialog('获取的留言为空');</script>");
                    return;
                }
            }
        }
    }
}
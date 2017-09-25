using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class EditNews : System.Web.UI.Page
    {
        public string mId;
        public string mName;
        public string uId;
        public string displayName;
        public string tId;
        public T_News news;
        public string thisvideoSrc;

        protected void Page_Load(object sender, EventArgs e)
        {
            T_User user = Session["User"] as T_User;
            if (user != null)
            {
                uId = user.Id.ToString();
                displayName = user.DisplayName;
                //plCheck.Visible = string.IsNullOrEmpty(user.District);
            }
            //mId = Request.QueryString["mId"];
            mName = Request.QueryString["mName"];
            tId = Request.QueryString["tId"];

            string id = Request.QueryString["Id"];
            if (!IsPostBack)
            {
                T_NewsManager newsManager = new T_NewsManager();
                news = newsManager.GetModel(id);
                if (news == null)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "editNews", "<script>showErrorDialog('获取的新闻为空');</script>");
                    return;
                }
                mId = news.T_M_Id.ToString();//类型
                news.Content = news.Content.Replace("\"", "\'");
                //news.Content = news.Content.Replace("\\", "\\\\");

                DataSet ds = new T_MultiMediaManage().GetList("NewsId='" + news.Id + "'");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    thisvideoSrc = new T_MultiMediaManage().GetList("NewsId='" + news.Id + "'").Tables[0].Rows[0]["MediaAddress"].ToString();
                }
            }
        }
    }
}
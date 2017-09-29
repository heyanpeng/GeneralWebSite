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
    public partial class EditVote : System.Web.UI.Page
    {
        public string mId;
        public string mName;
        public string uId;
        public string displayName;
        public string tId;
        public T_Vote vote;
        public string thisvideoSrc;
        public string voteItemListStr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            T_User user = Session["User"] as T_User;
            if (user != null)
            {
                uId = user.Id.ToString();
                displayName = user.DisplayName;
            }
            //mId = Request.QueryString["mId"];
            mName = Request.QueryString["mName"];
            tId = Request.QueryString["tId"];

            string id = Request.QueryString["Id"];
            if (!IsPostBack)
            {
                T_VoteManager voteManager = new T_VoteManager();
                vote = voteManager.GetModel(id);
                if (vote == null)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "editVote", "<script>showErrorDialog('获取的数据为空');</script>");
                    return;
                }
                mId = vote.T_M_Id.ToString();//类型
                T_VoteItemManager voteItemManager = new T_VoteItemManager();
                DataTable dt = voteItemManager.GetList(100, "voteid = '" + vote.Id + "'","sortindex asc").Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    voteItemListStr += item["Content"].ToString().Trim() + "\n";
                }
            }
        }
    }
}
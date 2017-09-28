using AnHuiSiteBLL;
using AnHuiSiteModel;
using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class VoteManager : System.Web.UI.Page
    {
        public string mName;
        public string uId;
        public string displayName;
        public string mId;
        public string tId;
        public string isAdd;
        public string isCheck;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                isCheck = Request.QueryString["isCheck"];
            }
            catch (Exception)
            {
                Response.Redirect("Logout.aspx");
            }
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(mId))
                {
                    AuthControl(uId, mId);
                    BindVote();
                }
            }
        }

        private void BindVote()
        {
            T_VoteManager voteManager = new T_VoteManager();

            T_NewsManager newsManager = new T_NewsManager();
            List<AnHuiSiteModel.T_Vote> data = null;
            if (isCheck == null)
            {
                AuthControl(uId, mId);
            }
            if (isCheck == "true")
            {
                data = voteManager.GetModelList(100000, "T_M_Id='" + mId + "'", "EndDateTime desc");
            }
            else if (isCheck == "false")
            {
                data = voteManager.GetModelList(100000, "T_M_Id='" + mId + "' and UId = '" + uId + "'", "EndDateTime desc");
            }
            gridContent.DataSource = data;
            gridContent.DataKeyNames = new string[] { "Id" };
            gridContent.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gridContent.DataKeys[e.RowIndex].Values[0].ToString();
            T_NewsManager newsManager = new T_NewsManager();
            newsManager.Delete(id);
            BindVote();
        }

        protected void gridContent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var vote = e.Row.DataItem as T_Vote;
                var cbIsPublic = e.Row.Cells[6].FindControl("colIsPublic") as HtmlInputCheckBox;
                if (cbIsPublic != null)
                {
                    cbIsPublic.Checked = Convert.ToBoolean(vote.IsPublic);
                }
            }
        }

        protected void gridContent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridContent.PageIndex = e.NewPageIndex;
            BindVote();
        }

        /// <summary>
        /// 页面权限判断
        /// </summary>
        protected void AuthControl(string pUserId, string pMenuId)
        {
            T_AuthInfoManager authInfoManager = new T_AuthInfoManager();
            string wh = "RoleId in (select RoleId from T_UserRole where UserId = '" + pUserId + "') and MenuId = '" + pMenuId + "'";
            DataTable authInfoDt = authInfoManager.GetList(wh).Tables[0];
            if (authInfoDt.Rows.Count > 0)
            {
                gridContent.Columns[0].Visible = authInfoDt.Select("IsEdit=true").Length > 0;
                gridContent.Columns[1].Visible = authInfoDt.Select("IsDelete=true").Length > 0;
                isAdd = authInfoDt.Select("IsAdd=true").Length > 0 ? "true" : "false";
                isCheck = authInfoDt.Select("IsCheck=true").Length > 0 ? "true" : "false";
            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
        }


        public string ReturnStatus(int pStatus, DateTime pBeginDateTime, DateTime pEndDateTime)
        {
            if (pStatus == 1)
            {
                if (pBeginDateTime > DateTime.Today)
                {
                    pStatus = 1;
                }
                if (pBeginDateTime <= DateTime.Today && DateTime.Today <= pEndDateTime)
                {
                    pStatus = 3;
                }
                if (pEndDateTime < DateTime.Today)
                {
                    pStatus = 4;
                }
            }
            string statusStr = string.Empty;
            //状态 1：自动根据时间计算 2：未开启 3：进行中 4：已结束 5：关闭
            switch (pStatus)
            {
                case 2:
                    {
                        statusStr = "<label style='color:green;'>未开启<label>";
                        break;
                    }
                case 3:
                    {
                        statusStr = "<label style='color:red;'>进行中<label>";
                        break;
                    }
                case 4:
                    {
                        statusStr = "<label style='color:gray;'>已结束<label>";
                        break;
                    }
                case 5:
                    {
                        statusStr = "<label>关闭<label>";
                        break;
                    }
            }
            return statusStr;
        }
    }
}
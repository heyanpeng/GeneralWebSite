using AnHuiSiteBLL;
using AnHuiSiteModel;
using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class LinksManager : System.Web.UI.Page
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
                    AuthControl(uId, mId);
                    BindLinks();
                }
            }
        }

        private void BindLinks()
        {
            T_LinksManager manager = new T_LinksManager();
            List<AnHuiSiteModel.T_Links> data = null;
            if (isCheck == null)
            {
                AuthControl(uId, mId);
            }
            if (isCheck == "true")
            {
                data = manager.GetModelList(100, "T_M_Id='" + mId + "'", "SortIndex desc");
            }
            else
            {
                data = manager.GetModelList(100, "T_M_Id='" + mId + "' and UId = '" + uId + "'", "SortIndex desc");
            }
            gridContent.DataSource = data;
            gridContent.DataKeyNames = new string[] { "Id" };
            gridContent.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gridContent.DataKeys[e.RowIndex].Values[0].ToString();
            T_LinksManager manager = new T_LinksManager();
            manager.Delete(id);
            BindLinks();

        }

        protected void gridContent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridContent.PageIndex = e.NewPageIndex;
            BindLinks();
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
    }
}
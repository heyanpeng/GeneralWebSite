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
    public partial class NewsManager : System.Web.UI.Page
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
                    BindNews();
                }
            }
        }

        private void BindNews()
        {
            T_NewsManager newsManager = new T_NewsManager();
            List<AnHuiSiteModel.T_News> data = null;
            if (isCheck == null)
            {
                AuthControl(uId, mId);
            }
            if (isCheck == "true")
            {
                data = newsManager.GetModelList(100, "T_M_Id='" + mId + "'", "IsTop desc,CreateTime desc");
            }
            else if (isCheck == "false")
            {
                data = newsManager.GetModelList(100, "T_M_Id='" + mId + "' and UId = '" + uId + "'", "IsTop desc,CreateTime desc");
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
            BindNews();
        }

        protected void gridContent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var news = e.Row.DataItem as T_News;
                var cbTop = e.Row.Cells[6].FindControl("colTop") as HtmlInputCheckBox;
                if (cbTop != null)
                {
                    cbTop.Checked = Convert.ToBoolean(news.IsTop);
                }

                var cbNew = e.Row.Cells[7].FindControl("colNew") as HtmlInputCheckBox;
                if (cbNew != null)
                {
                    cbNew.Checked = Convert.ToBoolean(news.IsNew);
                }

                //var cbHot = e.Row.Cells[8].FindControl("colHot") as HtmlInputCheckBox;
                var cbHot = e.Row.Cells[8].FindControl("colHot") as CheckBox;
                if (cbHot != null)
                {
                    cbHot.Checked = Convert.ToBoolean(news.IsHot);
                }
                var colCheck = e.Row.Cells[9].FindControl("colCheck") as HtmlInputCheckBox;
                if (colCheck != null)
                {
                    colCheck.Checked = Convert.ToBoolean(news.IsCheck);
                }
            }
        }

        protected void gridContent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridContent.PageIndex = e.NewPageIndex;
            BindNews();
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
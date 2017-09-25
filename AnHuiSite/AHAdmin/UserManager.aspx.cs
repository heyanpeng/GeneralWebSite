using AnHuiSiteBLL;
using AnHuiSiteModel;
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
    public partial class UserManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            T_UserManager userManager = new T_UserManager();
            //var data = GetUsers();
            var data = userManager.GetAllList().Tables[0];
            gridUsers.DataSource = data;
            gridUsers.DataKeyNames = new string[] { "Id" };
            gridUsers.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridUsers.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridUsers.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gridUsers.DataKeys[e.RowIndex].Values[0].ToString();
            string newPwd = ((HtmlInputPassword)gridUsers.Rows[e.RowIndex].FindControl("txtPwd")).Value;
            string displayName = ((TextBox)(gridUsers.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();

            T_UserManager userManager = new T_UserManager();

            T_User _T_User = userManager.GetModel(id);
            _T_User.UserPwd = newPwd;
            _T_User.DisplayName = displayName;
            _T_User.ModifyTime = DateTime.Now;

            if (userManager.Update(_T_User))
            {
                gridUsers.EditIndex = -1;
                BindGrid();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gridUsers.DataKeys[e.RowIndex].Values[0].ToString();

            T_UserManager userManager = new T_UserManager();
            if (userManager.Delete(id))
            {
                BindGrid();
            }

        }
    }
}
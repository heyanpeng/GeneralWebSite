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
    public partial class RoleManager : System.Web.UI.Page
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
            T_RoleManager roleManager = new T_RoleManager();
            var data = roleManager.GetAllList().Tables[0];
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

            string roleName = ((TextBox)(gridUsers.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();

            T_RoleManager roleManager = new T_RoleManager();

            T_Role role = roleManager.GetModel(id);
            role.RoleName = roleName;
            if (roleManager.Update(role))
            {
                gridUsers.EditIndex = -1;
                BindGrid();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gridUsers.DataKeys[e.RowIndex].Values[0].ToString();
            T_RoleManager roleManager = new T_RoleManager();
            if (roleManager.Delete(id))
            {
                BindGrid();
            }

        }
    }
}
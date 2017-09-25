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
    public partial class RoleMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["RoleId"]))
                {
                    string roleId = Request.QueryString["RoleId"].ToString();

                    T_RoleManager roleManager = new T_RoleManager();

                    T_Role role = roleManager.GetModel(roleId);

                    litRole.Text = role.RoleName;

                    hfRoleId.Value = roleId;
                }
                BindGrid();
            }
        }

        private void BindGrid()
        {
            T_UserManager userManager = new T_UserManager();
            T_UserRoleManager _userRoleManager = new T_UserRoleManager();
            var data = userManager.GetAllList().Tables[0];
            data.Columns.Add("Value");
            foreach (DataRow item in data.Rows)
            {
                var userId = item["Id"].ToString();
                if (_userRoleManager.Exists(userId, hfRoleId.Value))
                {
                    item["Value"] = "checked = 'Checked'";
                }
                else
                {
                    item["Value"] = "";
                }
            }
            gridUsers.DataSource = data;
            gridUsers.DataKeyNames = new string[] { "Id" };
            gridUsers.DataBind();
        }
    }
}
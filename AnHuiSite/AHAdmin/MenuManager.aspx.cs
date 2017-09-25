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
    public partial class MenuManager : System.Web.UI.Page
    {
        string gvUniqueID = String.Empty;
        int gvEditIndex = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            var data = GetTopMenus();
            gridMenus.DataSource = data;
            gridMenus.DataKeyNames = new string[] { "Id" };
            gridMenus.DataBind();

            var id = hdRowIndex.Value;
            if (id != "-1")
            {
                ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>ExpandGrid('" + id + "');</script>");
            }
        }

        //private void BindChild()
        //{
        //    T_MenusManager userManager = new T_MenusManager();
        //    gvInnerItem.DataSource = userManager.GetList(2); ;
        //    gvInnerItem.DataBind();
        //}

        //绑定嵌套的Gridview列表

        protected void gridMenus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var innerGridView = (GridView)e.Row.FindControl("gvInnerItem");
                if (innerGridView != null)
                {
                    if (innerGridView.UniqueID == gvUniqueID)
                    {
                        innerGridView.EditIndex = gvEditIndex;
                    }

                    string id = gridMenus.DataKeys[e.Row.RowIndex].Value.ToString();
                    T_MenusManager menusManager = new T_MenusManager();
                    innerGridView.DataSource = menusManager.GetListByID(id); ;
                    innerGridView.DataKeyNames = new string[] { "Id" };
                    innerGridView.DataBind();
                }
            }
        }

        public DataTable GetTopMenus()
        {
            T_MenusManager userManager = new T_MenusManager();
            return userManager.GetDetailList().Tables[0];
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView.ID == gridMenus.ID)
            {
                gridMenus.EditIndex = -1;
            }
            else
            {
                gvEditIndex = -1;
                gvUniqueID = gridView.UniqueID;
            }

            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView.ID == gridMenus.ID)
            {
                gridMenus.EditIndex = e.NewEditIndex;
            }
            else
            {
                gvEditIndex = e.NewEditIndex;
                gvUniqueID = gridView.UniqueID;
            }

            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var gridView = sender as GridView;
            string id = gridView.DataKeys[e.RowIndex].Values[0].ToString();
            T_MenusManager menuManager = new T_MenusManager();
            T_Menus _T_Menus = menuManager.GetModel(id);
            if (gridView.ID == gridMenus.ID)
            {
                _T_Menus.MenuName = ((TextBox)(gridView.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
                _T_Menus.SortIndex = int.Parse(((TextBox)(gridView.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim());
                _T_Menus.Visibility = bool.Parse(((TextBox)(gridView.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim());
                _T_Menus.LinkSrc = ((TextBox)(gridView.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
                _T_Menus.EnableLinkSrc = bool.Parse(((TextBox)(gridView.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim());
                _T_Menus.IsMainNav = bool.Parse(((TextBox)(gridView.Rows[e.RowIndex].Cells[10].Controls[0])).Text.ToString().Trim());
                _T_Menus.PicAddress = ((TextBox)(gridView.Rows[e.RowIndex].Cells[11].Controls[0])).Text.ToString().Trim();
            }
            else
            {
                gvUniqueID = gridView.UniqueID;
                gvEditIndex = -1;
                _T_Menus.MenuName = ((TextBox)(gridView.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
                _T_Menus.SortIndex = int.Parse(((TextBox)(gridView.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim());
                _T_Menus.Visibility = bool.Parse(((TextBox)(gridView.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim());
                _T_Menus.LinkSrc = ((TextBox)(gridView.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
                _T_Menus.EnableLinkSrc = bool.Parse(((TextBox)(gridView.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim());
                _T_Menus.IsMainNav = bool.Parse(((TextBox)(gridView.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim());
                _T_Menus.PicAddress = ((TextBox)(gridView.Rows[e.RowIndex].Cells[10].Controls[0])).Text.ToString().Trim();
            }
            _T_Menus.ModifyTime = DateTime.Now;
            if (menuManager.Update(_T_Menus))
            {
                gridView.EditIndex = -1;
                BindGrid();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var gridView = sender as GridView;
            gvUniqueID = gridView.UniqueID;
            gvEditIndex = e.RowIndex;

            string id = gridView.DataKeys[e.RowIndex].Values[0].ToString();
            T_MenusManager menuManager = new T_MenusManager();
            if (menuManager.Delete(id))
            {
                BindGrid();
            }
        }
    }
}
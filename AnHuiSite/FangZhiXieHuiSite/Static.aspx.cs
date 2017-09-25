using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite
{
    public partial class Static : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_StaticPageManager staticPageManager = new T_StaticPageManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object value = Request.QueryString["Id"];
                if (value != null)
                {
                    BindContent(value.ToString());
                }
            }
        }
        protected void BindContent(string id)
        {
            DataSet ds = staticPageManager.GetList("T_M_Id='" + id + "'");
            T_StaticPage model = new T_StaticPage();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                model.T_M_Id = ds.Tables[0].Rows[0]["T_M_Id"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Visibility"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Visibility"].ToString() == "1") || (ds.Tables[0].Rows[0]["Visibility"].ToString().ToLower() == "true"))
                    {
                        model.Visibility = true;
                    }
                    else
                    {
                        model.Visibility = false;
                    }
                }
            }
            if (model == null)
                return;
            T_Menus _T_Menus = menuManager.GetModel(model.T_M_Id.ToString());
            if (_T_Menus != null)
                litNav.Text = _T_Menus.MenuName;
            if (model.Visibility)
                litStaticContent.Text = HttpUtility.HtmlDecode(model.Content).Replace("<img src=\"", "<img src=\"../ahadmin/").Replace("<img src=\"ahadmin/http://", "<img src=\"http://");
        }
    }
}
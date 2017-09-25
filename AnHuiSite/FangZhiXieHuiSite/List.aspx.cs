using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite
{
    public partial class List : System.Web.UI.Page
    {
        T_MenusManager menuManager = new T_MenusManager();
        T_NewsManager newsManager = new T_NewsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object key = Request.QueryString["key"];
                if (key != null)
                {
                    litNav.Text = "关键字 \"" + key + "\"";
                    lblWh.Text = "IsCheck = 1 and Title like '%" + key + "%'";
                    lblOrderBy.Text = "CreateTime desc";
                    anp.RecordCount = newsManager.GetList(lblWh.Text + " order by IsTop desc,CreateTime desc").Tables[0].Rows.Count;
                    BindList();
                }
                else
                {
                    object value = Request.QueryString["Id"];
                    if (value != null)
                    {
                        string id = value.ToString();
                        T_Menus menu = menuManager.GetModel(id);
                        if (menu != null)
                        {
                            litNav.Text = menu.MenuName;
                            lblId.Text = id.ToString();
                            lblWh.Text = "IsCheck = 1 and T_M_Id = '" + lblId.Text + "'";
                            lblOrderBy.Text = "CreateTime desc";
                            anp.RecordCount = newsManager.GetList(lblWh.Text + " order by IsTop desc,CreateTime desc").Tables[0].Rows.Count;
                            BindList();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        protected void BindList()
        {
            int pagesize = anp.PageSize;
            int pageindex = anp.CurrentPageIndex;
            rptList.DataSource = newsManager.GetListByPage(lblWh.Text, lblOrderBy.Text, (pageindex - 1) * pagesize + 1, pagesize * pageindex);
            rptList.DataBind();
        }

        protected void anp_PageChanged(object sender, EventArgs e)
        {
            BindList();
        }
    }
}
using AnHuiSiteBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite
{
    public partial class Message : System.Web.UI.Page
    {
        T_MessagesManager messagesManager = new T_MessagesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMessage();
            }
        }
        protected void BindMessage()
        {

            //指定数据源
            DataTable dt = new DataTable();
            dt = messagesManager.GetList(10, "T_M_Id = 'dd0f27e8cc134570a3c4294b7278d866' and Visibility = 1 and IsSolve = 1", "ReplyTime desc").Tables[0];
            if (dt.Rows.Count == 0)
            {
                lbtnLasePage.Visible = false;
                lbtnFirstPage.Visible = false;
                lbtnPrePage.Visible = false;
                lbtnNextPage.Visible = false;
                return;
            }
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 5;
            pds.CurrentPageIndex = Convert.ToInt32(lblCount.Text.ToString()) - 1;
            lblPageCount.Text = pds.PageCount.ToString();
            rptMessageList.DataSource = pds;
            //如果大于当前页
            if (pds.PageCount != 1)
            {
                //如果大于当前页
                if (pds.CurrentPageIndex >= 1)
                {
                    lbtnPrePage.Enabled = true;
                    lbtnNextPage.Enabled = true;
                }

                //如果是最后一页，让下一页按钮不起作用
                if (pds.CurrentPageIndex == pds.PageCount - 1)
                {
                    lbtnFirstPage.Enabled = true;
                    lbtnNextPage.Enabled = false;
                    lbtnPrePage.Enabled = true;
                    lbtnLasePage.Enabled = false;
                }

                //如果是第一页
                if (pds.CurrentPageIndex == 0)
                {
                    lbtnLasePage.Enabled = true;
                    lbtnFirstPage.Enabled = false;
                    lbtnPrePage.Enabled = false;
                    lbtnNextPage.Enabled = true;
                }
            }
            else
            {
                lbtnLasePage.Enabled = false;
                lbtnFirstPage.Enabled = false;
                lbtnPrePage.Enabled = false;
                lbtnNextPage.Enabled = false;
            }
            rptMessageList.DataBind();
        }


        protected void lbtnPage_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            if (lbtn.Text == "首页")
                lblCount.Text = "1";
            else if (lbtn.Text == "上一页")
                lblCount.Text = (Convert.ToInt32(lblCount.Text.ToString()) - 1).ToString();
            else if (lbtn.Text == "下一页")
                lblCount.Text = (Convert.ToInt32(lblCount.Text.ToString()) + 1).ToString();
            else if (lbtn.Text == "尾页")
                lblCount.Text = lblPageCount.Text;
            BindMessage();
        }
    }
}
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
    public partial class votecontent : System.Web.UI.Page
    {
        T_VoteManager voteManager = new T_VoteManager();
        T_VoteItemManager voteItemManager = new T_VoteItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object value = Request.QueryString["Id"];
                if (value != null)
                {
                    string id = value.ToString();
                    BindContent(id);
                }
            }
        }

        void BindContent(string id)
        {
            T_Vote voteEntity = voteManager.GetModel(id);
            List<T_VoteItem> voteItemList = voteItemManager.GetModelList("VoteId = '" + voteEntity.Id + "'");
            if (voteEntity == null)
                return;
            litTitle.Text = voteEntity.Question.ToString();
            litCreateDate.Text = voteEntity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            //投票项目列表
            DataSet voteItemDs = voteItemManager.GetList(100,"voteid = '" + voteEntity.Id+"'","sortindex asc");
            if (voteItemDs.Tables[0].Rows.Count == 0)
            {
                hlViewResult.Visible = false;
                btnSubmit.Visible = false;
                return;
            }
            answerrbl.DataSource = voteItemDs.Tables[0];
            answerrbl.DataTextField = "content";
            answerrbl.DataValueField = "id";
            answerrbl.DataBind();
            //绑定查看结果链接
            hlViewResult.NavigateUrl = "voteresult.aspx?id=" + voteEntity.Id;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectValue = answerrbl.SelectedValue;
            T_VoteItem voteItem = voteItemManager.GetModel(selectValue);
            if (voteItem != null)
            {
                voteItem.Count += 1;
                voteItemManager.Update(voteItem);
                Response.Redirect(hlViewResult.NavigateUrl);
            }
        }
    }
}
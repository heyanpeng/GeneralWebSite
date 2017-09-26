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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectValue = answerrbl.SelectedValue;
        }
    }
}
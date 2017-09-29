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
    public partial class voteresult : System.Web.UI.Page
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
            DataTable voteItemDt = voteItemManager.GetList(100,"voteid = '" + voteEntity.Id+"'","sortindex asc").Tables[0];
            if (voteItemDt.Rows.Count == 0)
                return;
            voteItemDt.Columns.Add("width");
            float totalCount = float.Parse(voteItemDt.Compute("sum(count)", "").ToString());
            for (int i = 0; i < voteItemDt.Rows.Count; i++)
            {
                DataRow dr = voteItemDt.Rows[i];
                if (totalCount != 0)
                {
                    dr["width"] = (float.Parse(dr["count"].ToString()) / totalCount) * 390;
                }
                else
                {
                    dr["width"] = 0;
                }
            }

            rptVoteItemList.DataSource = voteItemDt;
            rptVoteItemList.DataBind();
        }
    }
}
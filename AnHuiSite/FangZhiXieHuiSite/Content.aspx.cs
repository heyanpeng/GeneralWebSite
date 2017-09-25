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
    public partial class Content : System.Web.UI.Page
    {
        T_NewsManager newsManager = new T_NewsManager();
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
            T_News newsEntity = newsManager.GetModel(id);
            if (newsEntity == null || newsEntity.IsCheck != 1)
            {
                return;
            }
            if (newsEntity == null)
                return;
            else
            {
                if (newsEntity.IsCheck == 0)
                {
                    return;
                }
            }
            newsManager.UpdateScanAmount(newsEntity.Id);
            litTitle.Text = newsEntity.Title;
            litCreateDate.Text = newsEntity.CreateTime.ToString("yyyy-MM-dd");
            litComeFrome.Text = newsEntity.Source;
            litScanAmount.Text = newsEntity.ScanAmount.ToString();
            if (!string.IsNullOrEmpty(newsEntity.PicAddress) && newsEntity.T_M_Id != "312cecf611964b41a3eb1409b7043064"
                && newsEntity.T_M_Id != "60a8e26113414f18a1d3aae1b0d65bcd")
            {
                img.ImageUrl = "../ahadmin/" + newsEntity.PicAddress.ToString();
                img.Visible = true;
            }
            else
            {
                img.Visible = false;
            }
            litContent.Text = HttpUtility.HtmlDecode(newsEntity.Content).Replace("<img src=\"", "<img src=\"../ahadmin/").Replace("<img src=\"ahadmin/http://", "<img src=http://").Replace("href=\"assets/", "href=\"../ahadmin/assets/");
            T_User user = (new T_UserManager()).GetModel(newsEntity.UId);
            if (user != null)
                litUId.Text = (new T_UserManager()).GetModel(newsEntity.UId).DisplayName;
        }
    }
}
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
    public partial class content : System.Web.UI.Page
    {
        T_NewsManager newsManager = new T_NewsManager();
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
            T_News newsEntity = newsManager.GetModel(id);
            if (newsEntity == null)
                return;
            newsManager.UpdateScanAmount(newsEntity.Id);
            litTitle.Text = newsEntity.Title;
            litCreateDate.Text = newsEntity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            litComeFrome.Text = newsEntity.Source;
            litScanAmount.Text = newsEntity.ScanAmount.ToString();
            litContent.Text = HttpUtility.HtmlDecode(newsEntity.Content);
            if (!string.IsNullOrEmpty(newsEntity.PicAddress))
            {
                img.ImageUrl = "../ahadmin/" + newsEntity.PicAddress.ToString();
            }
            else
            {
                img.Visible = false;
            }
            litContent.Text = HttpUtility.HtmlDecode(newsEntity.Content).Replace("<img src=\"", "<img src=\"../ahadmin/").Replace("href=\"assets/ueditor/net/upload/file",
                "href=\"../ahadmin/assets/ueditor/net/upload/file").Replace("src=\"assets/ueditor/net/upload/image/", "src=\"../ahadmin/assets/ueditor/net/upload/image/");
            T_User user = (new T_UserManager()).GetModel(newsEntity.UId);
            if (user != null)
                litUId.Text = (new T_UserManager()).GetModel(newsEntity.UId).DisplayName;
        }
    }
}
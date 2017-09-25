using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class Index : System.Web.UI.Page
    {
        public int HistoryNewsCount = 0;
        public int TodayNewsCount = 0;
        public int HistoryRegionCount = 0;
        public int TodayRegionCount = 0;
        public int HistoryMessageCount = 0;
        public int TodayMessageCount = 0;
        public int HistoryFilesCount = 0;
        public int TodayFilesCount = 0;
        public int ScanAmount = 0;
        public int FileDAmount = 0;

        public string MessageData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSiteConfig();
                //BindStatistic();
                //BindMessagesStatistic();
            }
        }
        /// <summary>
        /// 绑定系统参数
        /// </summary>
        private void BindSiteConfig()
        {
            T_SiteConfigManager _siteConfigManager = new T_SiteConfigManager();
            T_SiteConfig siteConfig = _siteConfigManager.GetModel();
            litSiteName.Text = siteConfig.SiteName;
            litVersion.Text = siteConfig.Version;
        }
        private void BindStatistic()
        {
            var dt = StatisticsManager.GetStatistics();
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                    HistoryNewsCount = int.Parse(dt.Rows[0][0].ToString());
                else
                    HistoryNewsCount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[1][0].ToString()))
                    TodayNewsCount = int.Parse(dt.Rows[1][0].ToString());
                else
                    TodayNewsCount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[2][0].ToString()))
                    HistoryRegionCount = int.Parse(dt.Rows[2][0].ToString());
                else
                    HistoryRegionCount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[3][0].ToString()))
                    TodayRegionCount = int.Parse(dt.Rows[3][0].ToString());
                else
                    TodayRegionCount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[4][0].ToString()))
                    HistoryMessageCount = int.Parse(dt.Rows[4][0].ToString());
                else
                    HistoryMessageCount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[5][0].ToString()))
                    TodayMessageCount = int.Parse(dt.Rows[5][0].ToString());
                else
                    TodayMessageCount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[6][0].ToString()))
                    HistoryFilesCount = int.Parse(dt.Rows[6][0].ToString());
                else
                    HistoryFilesCount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[7][0].ToString()))
                    TodayFilesCount = int.Parse(dt.Rows[7][0].ToString());
                else
                    TodayFilesCount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[8][0].ToString()))
                    ScanAmount = int.Parse(dt.Rows[8][0].ToString());
                else
                    ScanAmount = 0;
                if (!string.IsNullOrEmpty(dt.Rows[9][0].ToString()))
                    FileDAmount = int.Parse(dt.Rows[9][0].ToString());
                else
                    FileDAmount = 0;
            }
        }

        private void BindMessagesStatistic()
        {
            var data = StatisticsManager.GetMessageStatistics();
            MessageData = data;
            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "bindMessage", "<script>drawMessageChart('" + data + "');</script>");
        }
    }
}
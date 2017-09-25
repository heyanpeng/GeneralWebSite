using AnHuiSite.AHAdmin.Utilities;
using AnHuiSiteBLL;
using AnHuiSiteModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AnHuiSite.AHAdmin.handlers
{
    /// <summary>
    /// News 的摘要说明
    /// </summary>
    public class News : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();

            try
            {
                var action = context.Request["oper"].ToString();

                //string filePath = SaveFile(context, msg);
                string filePath = FileHelper.SaveUpImage(context, "inputImg", msg);
                if (action == "add")
                {
                    SaveNews(context, filePath);
                }
                else if (action == "edit")
                {
                    UpdateNews(context, filePath);
                }

            }
            catch (Exception ex)
            {
                msg.Result = false;
                msg.Error = ex.Message;
            }
            string result = JsonConvert.SerializeObject(msg);
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        private static void SaveNews(HttpContext context, string filePath)
        {
            T_News news = GenerateModel(context, filePath);
            string uId = context.Request["uId"].ToString();
            news.UId = uId;
            T_NewsManager newsManager = new T_NewsManager();
            if (newsManager.Add(news) > 0)
            {
                if (context.Request["videoSrc"] != null)
                {
                    T_MultiMediaManage multiMediaManage = new T_MultiMediaManage();
                    T_MultiMedia multiMedia = new T_MultiMedia();
                    multiMedia.Id = Guid.NewGuid().ToString("N");
                    multiMedia.NewsId = news.Id;
                    multiMedia.MediaAddress = context.Request["videoSrc"].ToString();
                    multiMedia.ScanAmount = 0;
                    multiMedia.ModifyTime = DateTime.Now;
                    multiMedia.CreateTime = DateTime.Now;
                    multiMedia.Visibility = true;
                    multiMediaManage.Add(multiMedia);
                }
            }
        }

        private static void UpdateNews(HttpContext context, string filePath)
        {
            T_News news = GenerateModel(context, filePath);
            string id = context.Request["id"].ToString();
            news.Id = id;
            news.ModifyTime = DateTime.Now;
            T_NewsManager newsManager = new T_NewsManager();
            newsManager.Update(news);

            T_MultiMediaManage multiMediaManage = new T_MultiMediaManage();
            DataSet ds = multiMediaManage.GetList("NewsId = '" + news.Id + "'");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                T_MultiMedia multiMedia = new T_MultiMedia();
                multiMedia.Id = ds.Tables[0].Rows[0]["Id"].ToString();
                multiMedia.NewsId = news.Id;
                multiMedia.MediaAddress = context.Request["videoSrc"].ToString();
                multiMedia.ModifyTime = DateTime.Now;
                multiMediaManage.Update(multiMedia);
            }
        }

        private static T_News GenerateModel(HttpContext context, string filePath)
        {
            string mId = context.Request["mId"].ToString();
            string title = context.Request["title"].ToString();
            int scanAmount = int.Parse(context.Request["scanAmount"].ToString());
            string source = context.Request["source"].ToString();
            string content = context.Request["content"].ToString();
            int isHot = Convert.ToInt32(bool.Parse(context.Request["isHot"].ToString()));
            int isTop = Convert.ToInt32(bool.Parse(context.Request["isTop"].ToString()));
            int isNew = Convert.ToInt32(bool.Parse(context.Request["isNew"].ToString()));
            int isCheck = Convert.ToInt32(bool.Parse(context.Request["isCheck"].ToString()));

            T_News news = new T_News();
            news.Id = Guid.NewGuid().ToString("N");
            news.Title = title;
            news.ScanAmount = scanAmount;
            news.Source = source;
            news.T_M_Id = mId;
            news.IsHot = isHot;
            news.IsTop = isTop;
            news.IsNew = isNew;
            news.IsCheck = isCheck;
            if (!string.IsNullOrEmpty(filePath))
            {
                news.PicAddress = filePath;
            }
            news.Content = content;
            return news;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
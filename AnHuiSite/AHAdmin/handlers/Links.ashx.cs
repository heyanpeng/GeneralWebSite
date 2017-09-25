using AnHuiSite.AHAdmin.Utilities;
using AnHuiSiteBLL;
using AnHuiSiteModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnHuiSite.AHAdmin.handlers
{
    /// <summary>
    /// Links 的摘要说明
    /// </summary>
    public class Links : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();

            try
            {
                var action = context.Request["oper"].ToString();

                string filePath = FileHelper.SaveUpImage(context, "inputImg", msg);
                if (action == "add")
                {
                    SaveLinks(context, filePath);
                }
                else if (action == "edit")
                {
                    UpdateLinks(context, filePath);
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

        private static void SaveLinks(HttpContext context, string filePath)
        {
            T_Links links = GenerateModel(context, filePath);
            links.Id = Guid.NewGuid().ToString("N");
            T_LinksManager manager = new T_LinksManager();
            manager.Add(links);
        }

        private static void UpdateLinks(HttpContext context, string filePath)
        {
            T_Links links = GenerateModel(context, filePath);
            string id = context.Request["id"].ToString();
            links.Id = id;
            links.ModifyTime = DateTime.Now;
            T_LinksManager manager = new T_LinksManager();
            manager.Update(links);
        }

        private static T_Links GenerateModel(HttpContext context, string filePath)
        {
            string mId = context.Request["mId"].ToString();
            string linkText = context.Request["linkText"].ToString();
            string linkUrl = context.Request["linkUrl"].ToString();

            bool Visibility = int.Parse(context.Request["Visibility"].ToString()) > 0;
            int SortIndex = int.Parse(context.Request["SortIndex"].ToString());
            string Target = context.Request["Target"].ToString();

            T_Links links = new T_Links();
            links.T_M_Id = mId;
            links.LinkText = linkText;
            links.Visibility = Visibility;
            links.SortIndex = SortIndex;
            links.Target = Target;

            if (!string.IsNullOrEmpty(filePath))
            {
                links.PicAddress = filePath;
            }
            links.UrlAddress = linkUrl;

            return links;
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
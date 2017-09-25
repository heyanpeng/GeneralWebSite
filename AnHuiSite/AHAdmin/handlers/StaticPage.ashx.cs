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
    /// StaticPage 的摘要说明
    /// </summary>
    public class StaticPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();
            try
            {
                var action = context.Request["oper"].ToString();
                string mId = context.Request["mId"].ToString();
                string content = context.Request["content"].ToString();
                string Visibility = context.Request["Visibility"].ToString();

                T_StaticPage staticPage = new T_StaticPage();
                staticPage.Id = Guid.NewGuid().ToString("N");
                staticPage.T_M_Id = mId;
                staticPage.Content = HttpUtility.HtmlEncode(content);
                staticPage.Visibility = bool.Parse(Visibility);

                T_StaticPageManager manager = new T_StaticPageManager();
                if (action == "add")
                {
                    manager.Add(staticPage);
                }
                else if (action == "edit")
                {
                    if (manager.DeleteByMenuId(mId))
                    {
                        if (manager.Add(staticPage) < 1)
                        {
                            msg.Result = false;
                            msg.Error = "更新失败";
                        }
                    }

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
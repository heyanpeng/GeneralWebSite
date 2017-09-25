using AnHuiSiteBLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnHuiSite.AHAdmin.handlers
{
    /// <summary>
    /// ContentTypes 的摘要说明
    /// </summary>
    public class ContentTypes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();
            try
            {
                var action = context.Request["oper"].ToString();
                if (action == "LoadAll")
                {
                    T_ContentTypeManager manager = new T_ContentTypeManager();
                    msg.Data = JsonConvert.SerializeObject(manager.GetModelList(""));
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
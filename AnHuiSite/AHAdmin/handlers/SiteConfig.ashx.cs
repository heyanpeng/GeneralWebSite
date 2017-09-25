using AnHuiSiteBLL;
using AnHuiSiteModel;
using Maticsoft.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AnHuiSite.AHAdmin.handlers
{
    /// <summary>
    /// SiteConfig 的摘要说明
    /// </summary>
    public class SiteConfig : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();

            try
            {
                T_SiteConfigManager siteConfigManager = new T_SiteConfigManager();
                var action = context.Request["oper"].ToString();
                if (action == "GetSiteConfig")
                {
                    T_SiteConfig siteConfig = siteConfigManager.GetModel();
                    msg.Data = JsonConvert.SerializeObject(siteConfig);
                }
                else if (action == "UpdateSiteConfig")
                {
                    T_SiteConfig siteConfig = new T_SiteConfig();
                    siteConfig.SiteName = context.Request["SiteName"].ToString();
                    siteConfig.Copyright = context.Request["Copyright"].ToString();
                    siteConfig.LogoUrl = context.Request["LogoUrl"].ToString();
                    siteConfig.SiteTitle = context.Request["SiteTitle"].ToString();
                    siteConfig.Meta_Keywords = context.Request["Meta_Keywords"].ToString();
                    siteConfig.Meta_Description = context.Request["Meta_Description"].ToString();
                    try
                    {
                        siteConfig.EnableWebSite = int.Parse(context.Request["EnableWebSite"].ToString()) > 0;
                    }
                    catch (Exception)
                    {
                        siteConfig.EnableWebSite = false;
                    }
                    siteConfig.Version = context.Request["Version"].ToString();
                    siteConfigManager.Update(siteConfig);
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
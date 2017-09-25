using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AnHuiSite
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //if (!this.Request.Url.ToString().Contains("ahadmin/") && !this.Request.Url.ToString().Contains("NeatUpload/Progress.aspx"))
            //{
            //    //遍历Post参数，隐藏域除外
            //    foreach (string i in this.Request.Form)
            //    {
            //        if (i != "__VIEWSTATE" && Common.SqlFilter(this.Request.Form[i].ToString()))
            //        {
            //            //this.Response.End();
            //            this.Response.Redirect("default.aspx");
            //        }
            //    }
            //    //遍历Get参数。
            //    foreach (string i in this.Request.QueryString)
            //    {
            //        if (Common.SqlFilter(this.Request.QueryString[i].ToString()))
            //        {
            //            //this.Response.End();
            //            this.Response.Redirect("default.aspx");
            //        }
            //    }
            //}
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
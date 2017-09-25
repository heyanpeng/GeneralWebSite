using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Xml;

namespace AnHuiSite.AHAdmin.Handlers
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = string.Empty;
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "Login":
                    LoginSystem(context);
                    break;
                case "Logout":
                    LogoutSystem(context);
                    break;
            }

        }
        /// <summary>
        /// 登录
        /// </summary>
        void LoginSystem(HttpContext context)
        {
            try
            {
                StreamReader reader = new StreamReader(context.Request.InputStream);
                string json = HttpUtility.UrlDecode(reader.ReadToEnd());
                NameValueCollection collection = HttpUtility.ParseQueryString(json);
                string name = collection["username"];
                string password = collection["password"];
                string isEncrypt = collection["isencrypt"];
                T_UserManager _T_UserManage = new T_UserManager();
                T_User user = new T_User();
                string sqlWh = "UserName='" + name + "'";
                user = _T_UserManage.GetModelList(sqlWh).FirstOrDefault();
                if (user == null)
                {
                    context.Response.Write("NoExists");
                }
                else if (user.UserPwd == password)
                {
                    context.Session["User"] = user;
                    string url = "index.aspx";
                    context.Response.Write(url);
                }
                else
                {
                    context.Response.Write("false");
                }
            }
            catch (Exception)
            {
                context.Response.Write("false");
            }
        }
        /// <summary>
        /// 登出
        /// </summary>
        void LogoutSystem(HttpContext context)
        {
            context.Session.Clear();
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
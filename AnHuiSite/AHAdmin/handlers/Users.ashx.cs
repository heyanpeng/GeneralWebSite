using AnHuiSiteBLL;
using AnHuiSiteModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AnHuiSite.AHAdmin.handlers
{
    /// <summary>
    /// Users 的摘要说明
    /// </summary>
    public class Users : IHttpHandler, IRequiresSessionState
    {
        T_UserManager userManager = new T_UserManager();
        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();

            try
            {
                var action = context.Request["oper"].ToString();
                if (action == "add")
                {
                    string userName = context.Request["userName"].ToString();

                    DataSet ds = userManager.GetList("UserName = '" + userName + "'");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        msg.Result = false;
                        msg.Error = "用户名已存在";
                    }
                    else
                    {
                        string pwd = context.Request["passWord"].ToString();
                        string displayName = context.Request["displayName"].ToString();
                        AddUser(userName, pwd, displayName);
                    }
                }
                else if (action == "ModifyPwd")
                {
                    string pwdOld = context.Request["pwdOld"].ToString();
                    T_User user = context.Session["User"] as T_User;
                    if (user.UserPwd != pwdOld)
                    {
                        msg.Result = false;
                        msg.Error = "原密码错误";
                    }
                    else
                    {
                        string pwd1 = context.Request["pwd1"].ToString();
                        string displayName = context.Request["displayName"].ToString();
                        user.UserPwd = pwd1;
                        user.DisplayName = displayName;
                        user.ModifyTime = DateTime.Now;
                        ModifyPwd(user);
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

        public void AddUser(string userName, string pwd, string displayName)
        {
            T_User user = new T_User();
            user.Id = Guid.NewGuid().ToString("N");
            user.UserName = userName;
            user.UserPwd = pwd;
            user.DisplayName = displayName;
            userManager.Add(user);
        }
        public void ModifyPwd(T_User user)
        {
            userManager.Update(user);
        }
        public List<T_User> GetUsers()
        {
            T_UserManager userManager = new T_UserManager();
            return userManager.GetModelList(string.Empty);
        }

        private bool Delete(string uId)
        {
            T_UserManager userManager = new T_UserManager();
            return userManager.Delete(uId);
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
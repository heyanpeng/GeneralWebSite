using AnHuiSiteBLL;
using AnHuiSiteModel;
using Maticsoft.BLL;
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
    public class Role : IHttpHandler, IRequiresSessionState
    {
        T_RoleManager roleManager = new T_RoleManager();
        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();

            try
            {
                var action = context.Request["oper"].ToString();
                if (action == "add")
                {
                    string roleName = context.Request["roleName"].ToString();

                    DataSet ds = roleManager.GetList("RoleName = '" + roleName + "'");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        msg.Result = false;
                        msg.Error = "角色名称已存在";
                    }
                    else
                    {
                        AddRole(roleName);
                    }
                }
                else if (action == "UpdateAuth")
                {
                    string roleId = context.Request["roleId"].ToString();
                    string level = context.Request["level"].ToString();
                    string Option = context.Request["Option"].ToString();
                    bool Value = bool.Parse(context.Request["Value"].ToString());
                    string MenuId = context.Request["MenuId"].ToString();

                    T_AuthInfoManager _authInfoManager = new T_AuthInfoManager();

                    T_AuthInfo _authInfo = _authInfoManager.GetModel(roleId, MenuId);

                    if (_authInfo != null)//存在记录
                    {
                        if (Option == "manage")
                        {
                            if (!Value)
                            {
                                _authInfoManager.Delete(_authInfo.Id);
                            }
                        }
                        else
                        {
                            if (Option == "add")
                            {
                                _authInfo.IsAdd = Value;
                            }
                            else if (Option == "delete")
                            {
                                _authInfo.IsDelete = Value;
                            }
                            else if (Option == "edit")
                            {
                                _authInfo.IsEdit = Value;
                            }
                            else if (Option == "check")
                            {
                                _authInfo.IsCheck = Value;
                            }
                            _authInfoManager.Update(_authInfo);
                        }
                    }
                    else//不存在记录
                    {
                        _authInfo = new T_AuthInfo();
                        _authInfo.Id = Guid.NewGuid().ToString("N");
                        _authInfo.RoleId = roleId;
                        _authInfo.MenuId = MenuId;
                        _authInfo.Type = 0;
                        if (Option == "manage")
                        {
                            if (Value)
                            {
                                _authInfo.IsAdd = false;
                                _authInfo.IsDelete = false;
                                _authInfo.IsEdit = false;
                                _authInfo.IsCheck = false;
                                _authInfoManager.Add(_authInfo);
                            }
                        }
                    }
                }
                else if (action == "UpdateRoleMembers")
                {
                    string userId = context.Request["userId"].ToString();
                    string roleId = context.Request["roleId"].ToString();
                    bool value = bool.Parse(context.Request["value"].ToString());

                    T_UserRoleManager _userRoleManage = new T_UserRoleManager();
                    if (value)
                    {
                        if (!_userRoleManage.Exists(userId, roleId))
                        {
                            T_UserRole _userRole = new T_UserRole();
                            _userRole.Id = Guid.NewGuid().ToString("N");
                            _userRole.UserId = userId;
                            _userRole.RoleId = roleId;
                            _userRoleManage.Add(_userRole);
                        }
                    }
                    else
                    {
                        _userRoleManage.Delete(userId, roleId);
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

        public void AddRole(string roleName)
        {
            T_Role _T_Role = new T_Role();
            _T_Role.Id = Guid.NewGuid().ToString("N");
            _T_Role.ParentId = string.Empty;
            _T_Role.RoleName = roleName;
            roleManager.Add(_T_Role);
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
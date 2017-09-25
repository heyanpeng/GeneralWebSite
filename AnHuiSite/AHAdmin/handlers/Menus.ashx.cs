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
    /// Menus 的摘要说明
    /// </summary>
    public class Menus : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();
            try
            {
                T_MenusManager manager = new T_MenusManager();
                var action = context.Request["oper"].ToString();
                if (action == "LoadTopMenu")
                {
                    //int typeId = int.Parse(context.Request["typeId"].ToString());
                    msg.Data = JsonConvert.SerializeObject(manager.GetModelList(" Level=1 order by SortIndex desc"));
                }
                else if (action == "LoadMenu")
                {
                    int pId = int.Parse(context.Request["pId"].ToString());
                    int level = int.Parse(context.Request["level"].ToString());
                    msg.Data = JsonConvert.SerializeObject(manager.GetModelList("ParentId=" + pId + " and Level=" + level + " order by SortIndex desc"));
                }
                else if (action == "Add")
                {
                    string typeId = context.Request["typeId"].ToString();
                    string pMenuId = context.Request["parentMenuId"].ToString();
                    string menuName = context.Request["menuName"].ToString();
                    int sortIndex = int.Parse(context.Request["sortIndex"].ToString());

                    string PicAddress = context.Request["PicAddress"].ToString();
                    string LinkSrc = context.Request["LinkSrc"].ToString();
                    int pEnableLinkSrc;
                    int.TryParse(context.Request["EnableLinkSrc"].ToString(), out pEnableLinkSrc);
                    int pIsMainNav;
                    int.TryParse(context.Request["IsMainNav"].ToString(), out pIsMainNav);
                    int pVisibility;
                    int.TryParse(context.Request["Visibility"].ToString(), out pVisibility);

                    T_Menus menu = new T_Menus();
                    menu.Id = Guid.NewGuid().ToString("N");
                    menu.TypeId = typeId;
                    menu.ParentId = pMenuId;
                    menu.MenuName = menuName;
                    menu.SortIndex = sortIndex;
                    menu.PicAddress = PicAddress;
                    menu.LinkSrc = LinkSrc;
                    menu.EnableLinkSrc = pEnableLinkSrc > 0;
                    menu.IsMainNav = pIsMainNav > 0;
                    menu.Visibility = pVisibility > 0;

                    if (!string.IsNullOrEmpty(pMenuId))
                    {
                        menu.Level = 2;
                    }
                    else
                    {
                        menu.Level = 1;
                    }
                    manager.Add(menu);
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
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
    /// FilesHandler 的摘要说明
    /// </summary>
    public class FilesHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();

            try
            {
                var action = context.Request["oper"].ToString();

                string filePath = FileHelper.SaveUpFile(context, "inputFile", msg);
                if (action == "add")
                {
                    SaveFiles(context, filePath);
                }
                else if (action == "edit")
                {
                    UpdateFiles(context, filePath);
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

        private static void SaveFiles(HttpContext context, string filePath)
        {
            T_Files files = GenerateModel(context, filePath);
            T_FilesManager manager = new T_FilesManager();
            manager.Add(files);
        }

        private static void UpdateFiles(HttpContext context, string filePath)
        {
            T_Files files = GenerateModel(context, filePath);
            string id = context.Request["id"].ToString();
            files.Id = id;
            files.ModifyTime = DateTime.Now;
            T_FilesManager manager = new T_FilesManager();
            manager.Update(files);
        }

        private static T_Files GenerateModel(HttpContext context, string filePath)
        {
            string mId = context.Request["mId"].ToString();
            string fileName = context.Request["fileName"].ToString();
            int dAmount = int.Parse(context.Request["dAmount"].ToString());

            bool Visibility = bool.Parse(context.Request["Visibility"].ToString());


            T_Files links = new T_Files();
            links.Id = Guid.NewGuid().ToString("N");
            links.T_M_Id = mId;
            links.FileName = fileName;
            links.Visibility=Visibility;
            if (!string.IsNullOrEmpty(filePath))
            {
                links.FileAddress = filePath;
            }
            links.DAmount = dAmount;

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
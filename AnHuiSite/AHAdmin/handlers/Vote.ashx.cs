using AnHuiSiteBLL;
using AnHuiSiteModel;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Web;

namespace AnHuiSite.AHAdmin.handlers
{
    /// <summary>
    /// Vote 的摘要说明
    /// </summary>
    public class Vote : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();

            try
            {
                var action = context.Request["oper"].ToString();
                if (action == "add")
                {
                    SaveVote(context);
                }
                else if (action == "edit")
                {
                    UpdateVote(context);
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

        private static void SaveVote(HttpContext context)
        {
            T_Vote vote = GenerateModel(context);
            string uId = context.Request["uId"].ToString();
            vote.UId = uId;
            vote.ModifyTime = DateTime.Today;
            vote.CreateTime = DateTime.Today;
            T_VoteManager voteManager = new T_VoteManager();
            T_VoteItemManager voteItemManager = new T_VoteItemManager();
            voteManager.Add(vote);

            string voteItemList = context.Request["voteItemList"].ToString();
            string[] voteItemLines = voteItemList.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < voteItemLines.Length; i++)
            {
                string item = voteItemLines[i];
                T_VoteItem voteitem = new T_VoteItem();
                voteitem.Id = Guid.NewGuid().ToString("N");
                voteitem.VoteId = vote.Id;
                voteitem.Content = item;
                voteitem.Count = 0;
                voteitem.SortIndex = (i + 1);
                voteItemManager.Add(voteitem);
            }
        }

        private static void UpdateVote(HttpContext context)
        {
            T_VoteManager voteManager = new T_VoteManager();
            T_VoteItemManager voteItemManager = new T_VoteItemManager();

            T_Vote vote = GenerateModel(context);
            string id = context.Request["id"].ToString();
            vote.Id = id;
            vote.ModifyTime = DateTime.Now;
            vote.CreateTime = voteManager.GetModel(vote.Id).CreateTime;
            voteManager.Update(vote);

            DataTable voteItemDt = voteItemManager.GetList(100, "voteid = '" + vote.Id + "'", "sortindex asc").Tables[0];
            foreach (DataRow item in voteItemDt.Rows)
            {
                voteItemManager.Delete(item["id"].ToString());
            }

            string voteItemList = context.Request["voteItemList"].ToString();
            string[] voteItemLines = voteItemList.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < voteItemLines.Length; i++)
            {
                string item = voteItemLines[i].ToString().Trim();
                T_VoteItem voteitem = new T_VoteItem();
                voteitem.Id = Guid.NewGuid().ToString("N");
                voteitem.VoteId = vote.Id;
                voteitem.Content = item;
                voteitem.Count = 0;
                voteitem.SortIndex = (i + 1);
                voteItemManager.Add(voteitem);
            }
        }

        private static T_Vote GenerateModel(HttpContext context)
        {
            string tId = context.Request["tId"].ToString();
            string mId = context.Request["mId"].ToString();
            string uId = context.Request["uId"].ToString();
            string question = context.Request["question"].ToString();
            int isPublic = Convert.ToInt32(bool.Parse(context.Request["isPublic"].ToString()) ? 1 : 0);
            int status = Convert.ToInt32(context.Request["status"].ToString());
            DateTime beginDateTime = Convert.ToDateTime(context.Request["beginDateTime"].ToString());
            DateTime endDateTime = Convert.ToDateTime(context.Request["endDateTime"].ToString());

            T_Vote vote = new T_Vote();
            vote.Id = Guid.NewGuid().ToString("N");
            vote.Question = question;
            vote.UId = uId;
            vote.Status = status;
            vote.T_M_Id = mId;
            vote.IsPublic = isPublic;
            vote.BeginDateTime = beginDateTime;
            vote.EndDateTime = endDateTime;
            vote.IsLimitIP = 0;
            vote.IsLimitTime = 0;
            vote.IsMultiSelect = 0;
            return vote;
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
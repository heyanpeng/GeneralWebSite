using AnHuiSiteBLL;
using AnHuiSiteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.SessionState;

namespace AnHuiSite.AHAdmin.handlers
{
    /// <summary>
    /// Message 的摘要说明
    /// </summary>
    public class Message : IHttpHandler, IRequiresSessionState
    {
        T_MessagesManager messagesManager = new T_MessagesManager();
        public void ProcessRequest(HttpContext context)
        {
            string action = string.Empty;
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "AddMessage":
                    AddMessage(context);
                    break;
                case "ReplayMessage":
                    ReplayMessage(context);
                    break;
                case "GetValidateCode":
                    CreateCheckCodeImage(context);
                    break;
            }
        }
        /// <summary>
        /// 添加消息
        /// </summary>
        void AddMessage(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();
            try
            {
                string validateCode = context.Request["validateCode"].ToString();
                if (validateCode != context.Session["CheckCode"].ToString())
                {
                    msg.Result = false;
                    msg.Data = "验证码错误";
                }
                else
                {
                    string name = context.Request["name"].ToString();
                    string email = context.Request["email"].ToString();
                    string tel = context.Request["tel"].ToString();
                    string topic = context.Request["topic"].ToString();
                    string content = context.Request["content"].ToString();
                    string t_m_id = context.Request["t_m_id"].ToString();
                    T_Messages message = new T_Messages();
                    message.Id = Guid.NewGuid().ToString("N");
                    message.UserName = name;
                    message.Email = email;
                    message.PhoneNum = tel;
                    message.Subject = topic;
                    message.Content = content;
                    message.T_M_Id = t_m_id;
                    message.CreateTime = DateTime.Now;
                    message.IsSolve = false;
                    message.ReplyTime = new DateTime(2000, 1, 1, 0, 0, 0);
                    if (messagesManager.Add(message) <= 0)
                    {
                        msg.Result = false;
                        msg.Error = "留言失败";
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
        void ReplayMessage(HttpContext context)
        {
            ResponseMsg msg = new ResponseMsg();
            try
            {
                string ReplyContent = context.Request["ReplyContent"].ToString();
                string uId = context.Request["uId"].ToString();
                string id = context.Request["id"].ToString();
                string Visibility = context.Request["Visibility"].ToString();
                string IsSolve = context.Request["IsSolve"].ToString();
                T_Messages message = messagesManager.GetModel(id);
                message.ReplyContent = ReplyContent;
                message.UId = uId;
                message.Id = id;
                message.ReplyTime = DateTime.Now;
                message.Visibility = bool.Parse(Visibility);
                message.IsSolve = bool.Parse(IsSolve);
                if (!messagesManager.Update(message))
                {
                    msg.Result = false;
                    msg.Error = "回复失败";
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
        private void CreateCheckCodeImage(HttpContext context)
        {
            string checkCode = GenerateCheckCode();
            //设置输出流图片格式
            context.Response.ContentType = "image/gif";
            Bitmap image = new Bitmap((int)Math.Ceiling((checkCode.Length * 12.5 + 2)), 22);
            Graphics g = Graphics.FromImage(image);
            //生成随机生成器
            Random random = new Random();
            //清空图片背景色
            g.Clear(Color.White);
            //画图片的背景噪音线
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.GreenYellow), x1, y1, x2, y2);
            }
            Font font = new System.Drawing.Font("Verdana", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(checkCode, font, brush, 2, 2);
            //画图片的前景噪音点
            for (int i = 0; i < 80; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //画图片的边框线
            g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 1, image.Height - 1);
            image.Save(context.Response.OutputStream, ImageFormat.Gif);
            context.Session["CheckCode"] = checkCode;
            context.Response.End();
        }
        private string GenerateCheckCode()
        {
            int number;
            char code;
            string checkCode = String.Empty;
            System.Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                number = random.Next();
                code = (char)('0' + (char)(number % 10));
                checkCode += code.ToString();
            }
            return checkCode;
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
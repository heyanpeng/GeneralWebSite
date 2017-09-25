using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AnHuiSite.AHAdmin.handlers
{
    /// <summary>
    /// CityNews 的摘要说明
    /// </summary>
    public class CityNews : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = string.Empty;
            action = context.Request["Action"].ToString();
            switch (action)
            {
                case "AddCityNews":
                    //AddMessage(context);
                    break;
                case "GetValidateCode":
                    CreateCheckCodeImage(context);
                    break;
            }
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
            context.Session["CityCheckCode"] = checkCode;
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
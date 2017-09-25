using AnHuiSiteBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AnHuiSite
{
    public class Common
    {
        public static string SubStr(string sString, int nLeng)
        {
            if (sString.Length <= nLeng)
            {
                return sString;
            }
            string sNewStr = sString.Substring(0, nLeng);
            sNewStr = sNewStr + "...";
            return sNewStr;
        }
        public static string SubStr(string sString, int nLeng, bool ishot, bool isnew)
        {
            if (sString.Length <= nLeng)
            {
                return sString;
            }
            if (!ishot)
                nLeng += 2;
            if (!isnew)
                nLeng += 2;
            if (sString.Length <= nLeng)
            {
                return sString;
            }
            string sNewStr = sString.Substring(0, nLeng);
            sNewStr = sNewStr + "...";
            return sNewStr;
        }
        public static string RemoveHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        public static string GetMenuLinkSrc(string id, string type)
        {
            string menuUrl = string.Empty;
            if (type == "1" || type == "2")
                menuUrl = "list.aspx?Id=" + id;
            else if (type == "5")
                menuUrl = "static.aspx?Id=" + id;
            else if (type == "6" || type == "7")
            {
                T_LinksManager linksManager = new T_LinksManager();
                DataTable dtLinks = linksManager.GetList("MenuId = " + id).Tables[0];
                if (dtLinks != null && dtLinks.Rows.Count > 0)
                    menuUrl = dtLinks.Rows[0]["UrlAddress"].ToString();
            }
            else if (type == "8")
                menuUrl = "message.aspx?Id=" + id;
            else if (type == "9")
                menuUrl = "file.aspx?Id=" + id;
            else if (type == "3")
                menuUrl = "videolist.aspx?Id=" + id;
            return menuUrl;
        }

        public static string GetShortDate(string date)
        {
            DateTime dt = new DateTime();
            DateTime.TryParse(date, out dt);
            return dt.ToString("MM/dd");
        }
        public static string GetLongDate(string date)
        {
            DateTime dt = new DateTime();
            DateTime.TryParse(date, out dt);
            return dt.ToString("yyyy/MM/dd");
        }

        /// <summary> 
        ///SQL注入过滤 
        /// </summary> 
        /// <param name="InText">要过滤的字符串 </param> 
        /// <returns>如果参数存在不安全字符，则返回true </returns> 
        public static bool SqlFilter(string InText)
        {
            string word = " and | exec | insert | select | delete | update | chr | mid | master | or | truncate | char | declare | join | cmd | < | > | \" | ' | % | ; | ( | ) | & | + | - ";
            if (InText == null)
                return false;
            foreach (string i in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1) || (InText.ToLower().IndexOf(i) > -1))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
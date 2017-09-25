using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AnHuiSite.AHAdmin.Utilities
{
    public class FileHelper
    {
        private static List<string> ImageTypes = new List<string>();
        private static List<string> FileTypes = new List<string>();

        static FileHelper()
        {
            ImageTypes.Add(".jpg");
            ImageTypes.Add(".bmp");
            ImageTypes.Add(".png");
            ImageTypes.Add(".jpeg");
            ImageTypes.Add(".gif");

            FileTypes.AddRange(new List<string>() {  ".png", ".jpg", ".jpeg", ".gif", ".bmp",
        ".flv", ".swf", ".mkv", ".avi", ".rm", ".rmvb", ".mpeg", ".mpg",
        ".ogg", ".ogv", ".mov", ".wmv", ".mp4", ".webm", ".mp3", ".wav", ".mid",
        ".rar", ".zip", ".tar", ".gz", ".7z", ".bz2", ".cab", ".iso",
        ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf", ".txt", ".md", ".xml"});
        }

        public static string SaveUpImage(HttpContext context, string fileControlId, ResponseMsg msg)
        {
            string filePath = string.Empty;
            var file = context.Request.Files[fileControlId];
            if (file != null)
            {
                string fileExt;
                if (!CheckImageType(file.FileName, out fileExt))
                {
                    msg.Result = false;
                    msg.Error = "图片格式不对";
                }
                else
                {
                    var folderPath = context.Server.MapPath("../Uploads/Images");
                    var fileName = context.Request["fileName"].ToString();
                    if (!SaveFile(file, folderPath, fileName))
                    {
                        msg.Result = false;
                        msg.Error = "保存图片失败";
                    }
                    filePath = "Uploads/Images/" + fileName;
                }
            }
            return filePath;
        }

        public static string SaveUpFile(HttpContext context, string fileControlId, ResponseMsg msg)
        {
            string filePath = string.Empty;
            var file = context.Request.Files[fileControlId];
            if (file != null)
            {
                string fileExt;
                if (!CheckFileType(file.FileName, out fileExt))
                {
                    msg.Result = false;
                    msg.Error = "上传文件格式不对";
                }
                else
                {
                    var folderPath = context.Server.MapPath("../Uploads/Files");
                    var fileName = context.Request["uploadFileName"].ToString();
                    if (!SaveFile(file, folderPath, fileName))
                    {
                        msg.Result = false;
                        msg.Error = "保存文件失败";
                    }
                    filePath = "Uploads/Files/" + fileName;
                }
            }
            return filePath;
        }


        public static bool SaveFile(HttpPostedFile file, string folderPath, string fileName)
        {
            bool result = false;
            if (file != null)
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                byte[] uploadFileBytes = new byte[file.ContentLength];

                try
                {
                    file.InputStream.Read(uploadFileBytes, 0, file.ContentLength);
                    string localPath = folderPath + "/" + fileName;
                    File.WriteAllBytes(localPath, uploadFileBytes);
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }


        public static bool CheckImageType(string filename, out string fileExt)
        {
            fileExt = Path.GetExtension(filename).ToLower();
            return ImageTypes.Select(x => x.ToLower()).Contains(fileExt);
        }

        public static bool CheckFileType(string filename, out string fileExt)
        {
            fileExt = Path.GetExtension(filename).ToLower();
            return FileTypes.Select(x => x.ToLower()).Contains(fileExt);
        }
    }
}
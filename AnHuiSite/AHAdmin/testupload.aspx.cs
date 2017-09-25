using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite.AHAdmin
{
    public partial class testupload : System.Web.UI.Page
    {
        public string fileinfo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["videoSrc"] != null)
                    fileinfo = Request.QueryString["videoSrc"].ToString();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (AttachFile.HasFile)
            {
                string filePath = "../AHAdmin/Uploads/Video/";//江油网站
                string FileName = this.AttachFile.FileName;//获取上传文件的文件名,包括后缀
                string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName;
                string SaveFileName = System.IO.Path.Combine(
                        System.Web.HttpContext.Current.Request.MapPath(filePath),
                        FileName);//合并两个路径为上传到服务器上的全路径
                AttachFile.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                string url = filePath + FileName;  //文件保存的路径
                float FileSize = (float)System.Math.Round((float)AttachFile.ContentLength / 1024000, 1); //获取文件大小并保留小数点后一位,单位是M
                //fileinfo = url + ";" + FileSize;
                fileinfo = FileName;
            }
        }
    }
}
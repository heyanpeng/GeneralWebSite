using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnHuiSite
{
    public partial class GUIDCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            txtGuid.Text = string.Empty;
            string guid = string.Empty;
            for (int i = 0; i < int.Parse(txtGuidCount.Text); i++)
            {
                guid = Guid.NewGuid().ToString("N");
                txtGuid.Text += guid + "\n";
            }
        }
    }
}
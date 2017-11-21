using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class file : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Files.Count > 0)
        {
            if (Request.Files["myfile"].ContentLength > 0)
            {
                string path = Server.MapPath("~/myupload") ;
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                string fileName = Request.Files["myfile"].FileName;
                if (System.IO.File.Exists(path + "\\" + fileName))
                {
                    System.IO.File.Delete(path + "\\" + fileName);
                }
                Request.Files["myfile"].SaveAs(path+"\\"+fileName);
                Label1.Text = "上传成功！";
            }
        }
    }
}
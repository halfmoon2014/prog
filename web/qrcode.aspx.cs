﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class qrcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string purl;
        purl = Request.UrlReferrer.ToString();
    }
}
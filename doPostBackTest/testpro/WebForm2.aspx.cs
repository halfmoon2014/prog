﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testpro
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("1");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Write("2");
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void clic_button(object sender, EventArgs e)
    {
        Response.Redirect("./connexion.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
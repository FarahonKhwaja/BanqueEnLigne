using System;
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

    protected void lb_clic_liens(object sender, CommandEventArgs e)
    {
        switch(e.CommandName)
        {
            case "bt_cpt_epargne":
                lb_modif.Text = "Sélection compte épargne";
                break;
            case "bt_cpt_courant":
                lb_modif.Text = "Sélection compte courant";
                break;
            case "bt_operation":
                lb_modif.Text = "Sélection opération";
                break;
            default:
                break;
        }
    }

    protected void clic_button(object sender, EventArgs e)
    {
        Response.Redirect("./accueil.aspx");
    }
}
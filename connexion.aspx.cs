using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class connexion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void tb_util_TextChanged(object sender, EventArgs e)
    {

    }

    protected void tb_mdp_TextChanged(object sender, EventArgs e)
    {

    }

    protected void bt_annul_Click(object sender, EventArgs e)
    {
        Response.Redirect("./accueil.aspx");
    }

    protected void bt_valid_Click(object sender, EventArgs e)
    {
        if (tb_util.Text == "Lulu")
        {
            if (tb_mdp.Text == "Lulu38000")
            {
                Session["utilisateurEnCours"] = tb_util.Text;
                Response.Redirect("./menu.aspx");
            }
            else
                Response.Redirect("./accueil.aspx");
        }
        else
            Response.Redirect("./accueil.aspx");
    }
}
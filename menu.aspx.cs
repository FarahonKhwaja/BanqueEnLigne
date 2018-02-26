using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if((Session["user"] == null))
        {
            Response.Redirect("./accueil.aspx");
        }
    }

    protected void lb_clic_liens(object sender, CommandEventArgs e)
    {
        switch(e.CommandName)
        {
            case "bt_cpt_epargne":
                lb_modif.Text = "Sélection compte épargne";
                using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
                {


                }
                break;
            case "bt_cpt_courant":
                lb_modif.Text = "Sélection compte courant";
                using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
                {
                    // ouverture
                    con.Open();
                    // ordre SQL
                    SqlCommand commande = new SqlCommand("SELECT COMPTE.NoCpt AS 'Numéro de compte', Sld AS 'Solde du compte' FROM COMPTE, CPT_COURANT WHERE COMPTE.NoCpt = CPT_COURANT.NoCpt", con);
                    
                    // exécution
                    SqlDataAdapter da = new SqlDataAdapter(commande);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridViewCompteCourant.DataSource = dt;
                    GridViewCompteCourant.DataBind();

                }
                break;
            case "bt_operation":
                lb_modif.Text = "Sélection opération";
                using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
                {


                }
                break;
            default:
                break;
        }
    }

    protected void clic_button(object sender, EventArgs e)
    {
        Session.Remove("user");
        Response.Redirect("./accueil.aspx");
    }
}
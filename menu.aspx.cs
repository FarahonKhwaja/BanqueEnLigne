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
        if (Session["NoCpt"] != null)
        {
            using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
            {
                // ouverture
                con.Open();
                // ordre SQL
                SqlCommand commande = new SqlCommand("SELECT Lib AS 'Libellé', DtOpe AS 'Date', TypO AS 'Type', Mnt AS 'Montant' FROM OPERATION WHERE NoCpt =" + Session["NoCpt"].ToString(), con);

                // exécution
                SqlDataAdapter da = new SqlDataAdapter(commande);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewCompteCourant.DataSource = dt;
                GridViewCompteCourant.DataBind();
                con.Close();
            }
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
                    using (SqlCommand cmd = new SqlCommand("SELECT CPT_EPARGNE.NoCpt AS 'Numéro du compte', Sld AS 'Solde', REPLACE(REPLACE(REPLACE(CPT_EPARGNE.Typ, 'LVA', 'Livret A'), 'LDDS', 'Livret de développement durable et solidaire'), 'LEP', 'Livret d epargne populaire') AS 'Type'" +
                                                           " FROM CPT_EPARGNE, UTILISATEUR, COMPTE" +
                                                           " WHERE CPT_EPARGNE.NoCpt = COMPTE.NoCpt" +
                                                           " AND COMPTE.NoCli = UTILISATEUR.NoCli" +
                                                           " AND UTILISATEUR.LOGIN = @login", con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@login", Session["user"]);
                        var count = cmd.ExecuteScalar();
                        System.Diagnostics.Debug.WriteLine(cmd.CommandText);
                        System.Diagnostics.Debug.WriteLine("nb lignes " + count + "user : " + Session["user"]);

                        if (count != null)
                        {
                            // exécution
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            GridViewCompteCourant.DataSource = dt;
                            GridViewCompteCourant.DataBind();
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("KO");
                        }
                    }
                    con.Close();
                }
                break;
            case "bt_cpt_courant":
                lb_modif.Text = "Sélection compte courant";
                using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT CPT_COURANT.NoCpt AS 'Numéro du compte', Sld AS 'Solde'" +
                                                           " FROM CPT_COURANT, UTILISATEUR, COMPTE" +
                                                           " WHERE CPT_COURANT.NoCpt = COMPTE.NoCpt" +
                                                           " AND COMPTE.NoCli = UTILISATEUR.NoCli" +
                                                           " AND UTILISATEUR.LOGIN = @login", con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@login", Session["user"]);
                        var count = cmd.ExecuteScalar();
                        System.Diagnostics.Debug.WriteLine("RQ : " + cmd.CommandText);
                        System.Diagnostics.Debug.WriteLine("nb lignes " + count + "user : " + Session["user"]);

                        if (count != null)
                        {
                            // exécution
                            SqlDataAdapter dataAdap = new SqlDataAdapter(cmd);
                            DataTable datatab = new DataTable();
                            dataAdap.Fill(datatab);
                            GridViewCompteCourant.DataSource = datatab;
                            GridViewCompteCourant.DataBind();
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("KO");
                        }
                    }
                    con.Close();
                }
                break;
            case "bt_operation":
                lb_modif.Text = "Sélection opération";
                Response.Redirect("./choix.aspx");
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
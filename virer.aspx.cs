using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class virer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            // ouverture
            con.Open();
            using (SqlCommand commande = new SqlCommand("SELECT NoCpt FROM COMPTE, UTILISATEUR WHERE UTILISATEUR.LOGIN = @login AND UTILISATEUR.NoCli = COMPTE.NoCli", con))
            {
                commande.Parameters.AddWithValue("@login", Session["user"]);
                // exécution
                SqlDataReader reader = commande.ExecuteReader();
                // lecture des lignes
                while (reader.Read())
                {
                    ddl_crediter.Items.Add(new ListItem(reader.GetDecimal(0).ToString()));
                    ddl_debiter.Items.Add(new ListItem(reader.GetDecimal(0).ToString()));
                }
                reader.Close();
            }
            con.Close();
        }
    }

    protected void bt_valider_Click(object sender, EventArgs e)
    {

        // connexion
        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            con.Open();

            try
            {
                SqlCommand macommande = new SqlCommand("VIRER", con);
                macommande.CommandType = CommandType.StoredProcedure;

                macommande.Parameters.AddWithValue("@pNoCptDeb", ddl_debiter.SelectedValue);
                macommande.Parameters.AddWithValue("@pNoCptCred", ddl_crediter.SelectedValue);
                macommande.Parameters.AddWithValue("@pMnt", tb_montant.Text);

                macommande.ExecuteNonQuery(); // INSERT, UPDATE, DELETE .... ; ExecuteQuery : Select  

                Response.Redirect("./menu.aspx");
            }
            catch (Exception ex)
            {
                lb_erreur.Visible = true;
                lb_erreur.ForeColor = System.Drawing.Color.Red;
                lb_erreur.Text = ex.Message.ToString();
            }

            con.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class credit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            // ordre SQL
            using (SqlCommand commande = new SqlCommand("SELECT NoCpt FROM COMPTE, UTILISATEUR WHERE UTILISATEUR.LOGIN = @login AND UTILISATEUR.NoCli = COMPTE.NoCli", con))
            {
                // ouverture
                con.Open();
                // param
                commande.Parameters.AddWithValue("@login", Session["user"]);
                // exécution
                SqlDataReader reader = commande.ExecuteReader();
                // lecture des lignes
                while (reader.Read())
                {
                    DropDownList2.Items.Add(new ListItem(reader.GetDecimal(0).ToString()));
                }
                reader.Close();
                // fermeture
                con.Close();
            }
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void tb1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void bt_valid_Click(object sender, EventArgs e)
    {
        // connexion
        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            con.Open();

            try
            {
                SqlCommand macommande = new SqlCommand("CREDITER", con);
                macommande.CommandType = CommandType.StoredProcedure;

                macommande.Parameters.AddWithValue("@pNoCpt", DropDownList2.SelectedValue);
                macommande.Parameters.AddWithValue("@pMnt", tb1.Text);

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
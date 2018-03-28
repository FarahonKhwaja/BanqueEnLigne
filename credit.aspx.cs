using System;
using System.Collections.Generic;
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
        Double value = 0.0;
        Double.TryParse(tb1.Text, out value);
        String cpt = DropDownList2.SelectedValue;
        Decimal noCli;

        if(value < 0)
        {
            System.Diagnostics.Debug.WriteLine("Le montant doit être positif");
            Response.Redirect("./credit.aspx");
        }
        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            con.Open();
            using (SqlCommand commande = new SqlCommand("SELECT NoCli FROM UTILISATEUR WHERE LOGIN = @login", con))
            {
                commande.Parameters.AddWithValue("@login", Session["user"]);
                noCli = (Decimal)commande.ExecuteScalar();
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO OPERATION(LIB, DtOpe, TypO, Mnt, NoCpt, NoCli) " +
                                            "VALUES ('crédit du compte n°" + cpt + "', SYSDATETIME(), 'C', " + value +
                                            "," + cpt + "," + noCli + ")", con);
            int nbLignes = 0;
            nbLignes = cmd.ExecuteNonQuery();
            cmd = new SqlCommand("SELECT Sld FROM COMPTE WHERE NoCpt = '" + cpt + "'", con);
            Decimal solde = (Decimal)cmd.ExecuteScalar();
            solde += Decimal.Parse(value.ToString());
            cmd = new SqlCommand("UPDATE COMPTE SET Sld = " + Double.Parse(solde.ToString()) + " WHERE NoCpt = '" + cpt + "'", con);
            System.Diagnostics.Debug.WriteLine("CMD : " + cmd.CommandText);
            try
            {
                nbLignes += cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                System.Diagnostics.Debug.WriteLine("SE : " + se.ToString());
            }
            System.Diagnostics.Debug.WriteLine("nb lignes : " + nbLignes);
            con.Close();
        }
        Response.Redirect("./menu.aspx");
    }
}
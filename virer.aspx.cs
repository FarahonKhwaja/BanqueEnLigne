using System;
using System.Collections.Generic;
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

        Double value = 0.0;
        Double.TryParse(tb_montant.Text, out value);
        String cpt = ddl_debiter.SelectedValue;
        Decimal noCli;

        //DEBITER
        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            con.Open();
            using (SqlCommand commande = new SqlCommand("SELECT NoCli FROM UTILISATEUR WHERE LOGIN = @login", con))
            {
                commande.Parameters.AddWithValue("@login", Session["user"]);
                noCli = (Decimal)commande.ExecuteScalar();
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO OPERATION(LIB, DtOpe, TypO, Mnt, NoCpt, NoCli) " +
                                            "VALUES ('débit du compte n°" + cpt + "', SYSDATETIME(), 'D', " + value +
                                            "," + cpt + "," + noCli + ")", con);
            int nbLignes = 0;
            nbLignes = cmd.ExecuteNonQuery();
            cmd = new SqlCommand("SELECT Sld FROM COMPTE WHERE NoCpt = '" + cpt + "'", con);
            Decimal solde = (Decimal)cmd.ExecuteScalar();

            solde -= (Decimal)value;
            cmd = new SqlCommand("UPDATE COMPTE SET Sld = '" + solde + "' WHERE NoCpt = " + cpt, con);
            System.Diagnostics.Debug.WriteLine("CMD : " + cmd);
            try
            {
                nbLignes = cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                System.Diagnostics.Debug.WriteLine("SE : " + se.ToString());
            }
            System.Diagnostics.Debug.WriteLine("nb lignes : " + nbLignes);
            con.Close();
        }

        //CREDITER
        value = 0.0;
        Double.TryParse(tb_montant.Text, out value);
        cpt = ddl_crediter.SelectedValue;
        noCli = 0;
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
            cmd = new SqlCommand("UPDATE COMPTE SET Sld = '" + (solde + (Decimal)value) + "' WHERE NoCpt = '" + cpt + "'", con);
            System.Diagnostics.Debug.WriteLine("CMD : " + cmd.ToString());
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
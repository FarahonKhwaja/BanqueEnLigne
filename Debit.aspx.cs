using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Debit : System.Web.UI.Page
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
                    DropDownList1.Items.Add(new ListItem(reader.GetDecimal(0).ToString()));
                reader.Close();
            }
            con.Close();
        }
    }
    protected void btValiderDebit_Click(object sender, EventArgs e)
    {
        Double value = 0.0;
        Double.TryParse(tbMontantDebit.Text, out value);
        String cpt = DropDownList1.SelectedValue;
        Decimal noCli;
        if (value > 0)
        {
            lb_erreur.Visible = true;
            lb_erreur.Text = "Le montant doit être négatif";
            lb_erreur.ForeColor = System.Drawing.Color.Red;
            System.Diagnostics.Debug.WriteLine("Le montant doit être négatif ");
            Response.Redirect("./Debit.aspx");
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
                                            "VALUES ('débit du compte n°" + cpt + "', SYSDATETIME(), 'D', " + value +
                                            "," + cpt + "," + noCli + ")", con);
            int nbLignes = 0;
            nbLignes = cmd.ExecuteNonQuery();
            cmd = new SqlCommand("SELECT Sld FROM COMPTE WHERE NoCpt = '" + cpt + "'", con);
            Decimal solde = (Decimal)cmd.ExecuteScalar();

            solde += (Decimal)value;
            cmd = new SqlCommand("UPDATE COMPTE SET Sld = " + Double.Parse(solde.ToString()) + " WHERE NoCpt = " + int.Parse(cpt), con);
            System.Diagnostics.Debug.WriteLine("CMD : " + cmd.CommandText);
            nbLignes = cmd.ExecuteNonQuery();
            System.Diagnostics.Debug.WriteLine("nb lignes : " + nbLignes);
            con.Close();
        }
        Response.Redirect("./menu.aspx");
    }
}
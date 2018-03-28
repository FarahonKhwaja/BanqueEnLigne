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
        Decimal noCliDeb = 0;
        Decimal noCliCre = 0;
        int nbLignes = 0;

        if (value < 0)
        {
            lb_erreur.Visible = true;
            lb_erreur.ForeColor = System.Drawing.Color.Red;
            lb_erreur.Text = "Le montant doit être positif";
            return;
        }


        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            con.Open();

            //CONTROLES SOLDE DU COMPTE
            //S'ASSURER QUE L'OPERATION EST POSSIBLE



            SqlTransaction trs = con.BeginTransaction();
            SqlCommand com = con.CreateCommand();
            com.Transaction = trs;
            try
            {
                //débiter
                com.CommandText = "SELECT NoCli FROM UTILISATEUR WHERE LOGIN = '" + Session["user"] + "'";
                noCliDeb = (Decimal)com.ExecuteScalar();
                com.CommandText = "INSERT INTO OPERATION(LIB, DtOpe, TypO, Mnt, NoCpt, NoCli) " +
                                                "VALUES ('débit du compte n°" + cpt + "', SYSDATETIME(), 'D', " + value +
                                                "," + cpt + "," + noCliDeb + ")";
                nbLignes = com.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("[DEBIT] INSERT : " + nbLignes);
                com.CommandText = "SELECT Sld FROM COMPTE WHERE NoCpt = '" + cpt + "'";
                Decimal solde = (Decimal)com.ExecuteScalar();
                System.Diagnostics.Debug.WriteLine("[DEBIT] SOLDE : " + solde);
                Decimal soldeDeb = solde - ((Decimal)value * -1);
                com.CommandText = "UPDATE COMPTE SET Sld = " + Double.Parse(solde.ToString()) + " WHERE NoCpt = " + cpt;
                System.Diagnostics.Debug.WriteLine("COM : " + com.CommandText);
                nbLignes = com.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("[DEBIT] UDPDATE : " + nbLignes);

                //créditer
                cpt = ddl_crediter.SelectedValue;
                com.CommandText = "SELECT NoCli FROM UTILISATEUR WHERE LOGIN = '" + Session["user"] + "'";
                noCliCre = (Decimal)com.ExecuteScalar();
                com.CommandText = "INSERT INTO OPERATION(LIB, DtOpe, TypO, Mnt, NoCpt, NoCli) " +
                                       "VALUES ('crédit du compte n°" + cpt + "', SYSDATETIME(), 'C', " + value +
                                       "," + cpt + "," + noCliCre + ")";
                nbLignes = com.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("[CREDIT] INSERT : " + nbLignes);
                com.CommandText = "SELECT Sld FROM COMPTE WHERE NoCpt = '" + cpt + "'";
                solde = (Decimal)com.ExecuteScalar();
                System.Diagnostics.Debug.WriteLine("[CREDIT] SOLDE : " + nbLignes);
                solde += (Decimal)value;
                com.CommandText = "UPDATE COMPTE SET Sld = " + Double.Parse(solde.ToString()) + " WHERE NoCpt = '" + cpt + "'";
                nbLignes = com.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("[CREDIT] UPDATE : " + nbLignes);

                trs.Commit();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("exception : " + ex.Message);
                lb_erreur.Visible = true;
                lb_erreur.Text = ex.Message;
                try
                {
                    trs.Rollback();
                }
                catch (Exception rollbackex)
                {
                    lb_erreur.Text = rollbackex.Message;
                    System.Diagnostics.Debug.WriteLine("rollback exception : " + ex.Message);
                }
            }

            con.Close();
        }

        Response.Redirect("./menu.aspx");
    }
}
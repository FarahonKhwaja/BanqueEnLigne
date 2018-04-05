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
        String cptDeb = ddl_debiter.SelectedValue;
        String cptCre = ddl_crediter.SelectedValue;
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
        System.Diagnostics.Debug.WriteLine("[ALL] Montant : " + value);
        System.Diagnostics.Debug.WriteLine("[CREDIT] Cpt Crédit : " + cptCre);
        System.Diagnostics.Debug.WriteLine("[DEBIT] Cpt Débit : " + cptDeb);


        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            con.Open();
            SqlTransaction trs = con.BeginTransaction();
            SqlCommand com = con.CreateCommand();
            com.Transaction = trs;
            try
            {
                com.CommandText = "SELECT DecAuto FROM CPT_COURANT WHERE NoCpt = '" + cptDeb + "'";
                System.Diagnostics.Debug.WriteLine("[DEBIT] COM DECOUVERT : " + com.CommandText);
                Decimal decAutoDeb = (Decimal)com.ExecuteScalar();
                System.Diagnostics.Debug.WriteLine("[DEBIT] Découvert autorisé : " + decAutoDeb);

                //solde du compte à débiter
                com.CommandText = "SELECT Sld FROM COMPTE WHERE NoCpt = '" + cptDeb + "'";
                Decimal solde = (Decimal)com.ExecuteScalar();
                System.Diagnostics.Debug.WriteLine("[DEBIT] SOLDE : " + solde);

                //CONTROLES DEBIT
                if (decAutoDeb != -1)
                { //le compte à débiter est un compte courant
                    if ((solde - (Decimal)value) < (decAutoDeb * -1 ))
                    {
                        //ERREUR : le découvert autorisé est dépassé
                        lb_erreur.Visible = true;
                        lb_erreur.ForeColor = System.Drawing.Color.Red;
                        lb_erreur.Text = "Le découvert autorisé est dépassé";
                        throw new Exception("Le découvert autorisé est dépassé");
                    }

                }
                else
                { //le compte à débiter est un compte épargne
                    //aucun contrôle
                }

                //solde du compte à créditer
                com.CommandText = "SELECT Sld FROM COMPTE WHERE NoCpt = '" + cptCre + "'";
                Decimal soldeCre = (Decimal)com.ExecuteScalar();
                System.Diagnostics.Debug.WriteLine("[CREDIT] SOLDE : " + soldeCre);
                //CONTROLES CREDIT
                com.CommandText = "SELECT plaf FROM CPT_EPARGNE WHERE NoCpt = '" + cptCre + "'";
                Decimal plafCred = (Decimal)com.ExecuteScalar();
                System.Diagnostics.Debug.WriteLine("[CREDIT] PLAFOND : " + plafCred);
                if(plafCred != -1)
                { //le compte à créditer est un compte épargne
                    if ((soldeCre + (Decimal)value) > plafCred)
                    {
                        //ERREUR : plafond dépassé
                        lb_erreur.Visible = true;
                        lb_erreur.ForeColor = System.Drawing.Color.Red;
                        lb_erreur.Text = "Le plafond du compte à créditer est dépassé";
                        throw new Exception("Le plafond du compte à créditer est dépassé");
                    }
                }


                //débiter
                com.CommandText = "SELECT NoCli FROM UTILISATEUR WHERE LOGIN = '" + Session["user"] + "'";
                noCliDeb = (Decimal)com.ExecuteScalar();


                


                com.CommandText = "INSERT INTO OPERATION(LIB, DtOpe, TypO, Mnt, NoCpt, NoCli) " +
                                                "VALUES ('débit du compte n°" + cptDeb + "', SYSDATETIME(), 'D', -" + value +
                                                "," + cptDeb + "," + noCliDeb + ")";
                nbLignes = com.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("[DEBIT] INSERT : " + nbLignes);
                //* -1 car valeur positive saisie, et ici on a besoin du négatif
                Decimal soldeDeb = solde - ((Decimal)value * -1);
                com.CommandText = "UPDATE COMPTE SET Sld = " + Double.Parse(solde.ToString()) + " WHERE NoCpt = " + cptDeb;
                nbLignes = com.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("[DEBIT] UDPDATE : " + nbLignes);

                //créditer
                com.CommandText = "SELECT NoCli FROM UTILISATEUR WHERE LOGIN = '" + Session["user"] + "'";
                noCliCre = (Decimal)com.ExecuteScalar();
                com.CommandText = "INSERT INTO OPERATION(LIB, DtOpe, TypO, Mnt, NoCpt, NoCli) " +
                                       "VALUES ('crédit du compte n°" + cptCre + "', SYSDATETIME(), 'C', " + value +
                                       "," + cptCre + "," + noCliCre + ")";
                nbLignes = com.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("[CREDIT] INSERT : " + nbLignes);
                com.CommandText = "SELECT Sld FROM COMPTE WHERE NoCpt = '" + cptCre + "'";
                solde = (Decimal)com.ExecuteScalar();
                System.Diagnostics.Debug.WriteLine("[CREDIT] SOLDE : " + nbLignes);
                solde += (Decimal)value;
                com.CommandText = "UPDATE COMPTE SET Sld = " + Double.Parse(solde.ToString()) + " WHERE NoCpt = '" + cptCre + "'";
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
                return;
            }

            con.Close();
        }

        Response.Redirect("./menu.aspx");
    }
}
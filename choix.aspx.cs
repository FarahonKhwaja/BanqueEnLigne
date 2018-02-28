using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class choix : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            // ouverture
            con.Open();
            // ordre SQL
            SqlCommand commande = new SqlCommand("SELECT NoCpt FROM COMPTE", con);

            // exécution
            SqlDataReader reader = commande.ExecuteReader();
            // lecture des lignes
            while (reader.Read())
                DropDownList1.Items.Add(new ListItem(reader.GetDecimal(0).ToString()));
            reader.Close();
            // fermeture
            con.Close();
        }

    }

    protected void bt_valid_Click(object sender, EventArgs e)
    {
        Session["NoCpt"] = DropDownList1.SelectedValue;
        Response.Redirect("./menu.aspx");
    }
}
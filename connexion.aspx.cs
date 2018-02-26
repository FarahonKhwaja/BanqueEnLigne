using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class connexion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Session["user"] = tb_util.Text;
            Session["passwd"] = tb_mdp.Text;
        }
    }

    protected void tb_util_TextChanged(object sender, EventArgs e)
    {

    }

    protected void tb_mdp_TextChanged(object sender, EventArgs e)
    {

    }

    protected void bt_annul_Click(object sender, EventArgs e)
    {
        Response.Redirect("./accueil.aspx");
    }

    protected void bt_valid_Click(object sender, EventArgs e)
    {
        /*
        https://stackoverflow.com/questions/1054022/best-way-to-store-password-in-database
        https://stackoverflow.com/questions/4717789/in-a-using-block-is-a-sqlconnection-closed-on-return-or-exception
        https://stackoverflow.com/questions/15631602/how-to-set-sql-server-connection-string
        https://www.developpez.net/forums/anocode.php?id=b4319d18e687445ae582f8c36121a722
        https://stackoverflow.com/questions/23185990/sqlcommand-with-using-statement
        https://stackoverflow.com/questions/28705515/check-login-credentials-from-a-database
        */

        PassManager pm = new PassManager();
        String encryptedPass = pm.EncryptData(tb_mdp.Text);
        System.Diagnostics.Debug.WriteLine("Encrypted Pass : " + encryptedPass);

        using (SqlConnection con = new SqlConnection(Global.DatabaseConnexion))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM UTILISATEUR WHERE LOGIN = @login AND PASSWD = @mdp", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@login", tb_util.Text);
                cmd.Parameters.AddWithValue("@mdp", encryptedPass);
                var count = cmd.ExecuteScalar();

                System.Diagnostics.Debug.WriteLine(count);

                // si le couple login/pass existe dans la base, on créer deux variables sessions et on redirige vers le menu
                if (count != null)
                {
                    System.Diagnostics.Debug.WriteLine("OK");
                    Session["user"] = tb_util.Text;
                    Session["passwd"] = tb_mdp.Text;
                    Response.Redirect("./menu.aspx");
                } else
                {
                    System.Diagnostics.Debug.WriteLine("KO");
                    Response.Redirect("./accueil.aspx");
                }
            }
        }



        /*
        if (this.IsPostBack)
        {
            if ((tb_util.Text == "user") && (tb_mdp.Text == "passwd")){
                Session["user"] = tb_util.Text;
                Session["passwd"] = tb_mdp.Text;
                Response.Redirect("./menu.aspx");
            } else {
                Response.Redirect("./accueil.aspx");
            }
        }
        */

    }
}
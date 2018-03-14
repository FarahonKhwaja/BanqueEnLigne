using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Global
/// </summary>
public class Global
{

    //static string databaseConnexion = "Data Source = LAPTOP-OD5VHO5I\\SQLEXPRESS; Initial Catalog = bd1; User ID = lucas; Password = azert170794";
    static string databaseConnexion = "Data Source=DESKTOP-PHQ3VJQ\\MSSQLSERVER2;Initial Catalog=db1;Persist Security Info=True;User ID=kawa;Password=kawa";
    public static string DatabaseConnexion
    {
        get
        {
            return databaseConnexion;
        }
        set
        {
            databaseConnexion = value;
        }
    }
}
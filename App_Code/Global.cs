using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Global
/// </summary>
public class Global
{

    static string databaseConnexion = "Data Source = LAPTOP-OD5VHO5I\\SQLEXPRESS; Initial Catalog = bd1; User ID = lucas; Password = azert170794";

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
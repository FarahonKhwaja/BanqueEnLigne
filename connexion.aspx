<%@ Page Language="C#" AutoEventWireup="true" CodeFile="connexion.aspx.cs" Inherits="connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Vente en Ligne sur le Web</title>
    <style type="text/css" media="all">
        @import "./style.css";
        .style1
        {
        height: 69px;
        width: 311px;
        top: 406px;
        left: 16px;
        position: absolute;
        margin-left: 117px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="conteneur">
            <!-- ENTETE DE LA PAGE -->
            <div id="divtitre">
                <img alt="Logo de la banque" src="Picsou.jpg" width="120" height="50" />
                <asp:Label ID="Titre" runat="server" Text="Banque Commerciale" />
            </div>
            <!-- CONTENU DE LA PAGE -->
            <div id="contenu">
                <hr />
                <asp:Label ID="Label1" runat="server" Text="Authentification" Font-Size="Medium" style="z-index: 1; left: 30px; top: 120px; position: absolute"></asp:Label>
                <br /><br /><br /><br /><br />
                <asp:Label ID="lb_util" runat="server" Text="Utilisateur"></asp:Label><asp:TextBox ID="tb_util" runat="server" AutoPostBack="true" OnTextChanged="tb_util_TextChanged"></asp:TextBox><br /><br />
                <asp:Label ID="lb_mdp" runat="server" Text="Mot de passe"></asp:Label><asp:TextBox ID="tb_mdp" runat="server" AutoPostBack="true" OnTextChanged="tb_mdp_TextChanged"></asp:TextBox><br /><br />

                <asp:Button ID="bt_annul" runat="server" Text="Annuler" OnClick="bt_annul_Click" />  <asp:Button ID="bt_valid" runat="server" Text="Valider" OnClick="bt_valid_Click" />

            </div>
            <!-- PIED DE LA PAGE -->
            <div id="pied">
                <hr />
                <asp:Label ID="LabelPied" runat="server" Text="Site r&eacute;alis&eacute; par O. Teste" TabIndex="20" /> 
            </div>
        </div>
    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="choix.aspx.cs" Inherits="choix" %>

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
        <div id="conteneur">
            <!-- ENTETE DE LA PAGE -->
            <div id="divtitre">
                <img alt="Logo de la banque" src="Picsou.jpg" width="120" height="50" />
                <asp:Label ID="Titre" runat="server" Text="Banque Commerciale" />
                </div>
            <!-- CONTENU DE LA PAGE -->
            <div id="contenu">
                <hr />
                <asp:Label ID="NomPage" runat="server" Text="Opérations" Font-Size="Medium" style="z-index: 1; top: 120px; position: absolute"></asp:Label>
                <br />
                <br />
                <br /><br /><br />
                 <form id="form1" runat="server">
                    Merci de sélectionner le numéro du compte du client puis de valider<br />
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><br />
                    <asp:Button ID="bt_valid" runat="server" Text="Valider" OnClick="bt_valid_Click" />
                </form>
            </div>
            <!-- PIED DE LA PAGE -->
            <div id="pied">
                <hr />
                <asp:Label ID="LabelPied" runat="server" Text="Site r&eacute;alis&eacute; par O. Teste" TabIndex="20" /> 
            </div>
        </div>
</body>
</html>
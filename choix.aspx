<%@ Page Language="C#" AutoEventWireup="true" CodeFile="choix.aspx.cs" Inherits="choix" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Vente en Ligne sur le Web</title>
    <style type="text/css" media="all">
        @import "./style.css";
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div id="conteneur">
            <!-- ENTETE DE LA PAGE -->
            <div id="divtitre">
                <img alt="Logo de la banque" src="Picsou.jpg" width="120" height="50" />
                <asp:Label ID="Label2" runat="server" Text="Banque Commerciale" />
            </div>
            <!-- CONTENU DE LA PAGE -->
            <div id="contenu">
                <hr />
				<div id="padding">
					<asp:Label ID="Label3" runat="server" Text="Opérations" Font-Size="Medium"></asp:Label>
					<br /><br />
					Merci de sélectionner le numéro de votre compte puis de valider
					<br /><br />
					<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    <br /><br />
					<asp:Button ID="Button2" runat="server" Text="Valider" OnClick="bt_valid_Click" />
				</div>
            </div>
            <!-- PIED DE LA PAGE -->
            <div id="pied">
                <hr />
                <asp:Label ID="Label4" runat="server" Text="Site r&eacute;alis&eacute; par O. Teste" TabIndex="20" /> 
            </div>
		 </div>
    </form>
</body>
</html>


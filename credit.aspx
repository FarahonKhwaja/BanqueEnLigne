<%@ Page Language="C#" AutoEventWireup="true" CodeFile="credit.aspx.cs" Inherits="credit" %>


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
					<asp:Label ID="Label3" runat="server" Text="Créditer" Font-Size="Medium"></asp:Label>
					<br /><br />
					Compte à créditer : <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
					<br /><br />
					Montant à créditer : <asp:TextBox id="tb1" runat="server" OnTextChanged="tb1_TextChanged" />
                    <br /><br />
					<asp:Button ID="Button2" runat="server" Text="Valider" OnClick="bt_valid_Click" style="height: 26px" />
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

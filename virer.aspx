<%@ Page Language="C#" AutoEventWireup="true" CodeFile="virer.aspx.cs" Inherits="virer" %>
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
					<asp:Label ID="Label3" runat="server" Text="Virer" Font-Size="Medium"></asp:Label>
					<br />
                    <br />
                    <asp:Label ID="lb_erreur" runat="server" Visible="False"></asp:Label>
                    <br />
                    <br />
                    Choisissez un compte à débiter : <asp:DropDownList ID="ddl_debiter" runat="server"></asp:DropDownList>
					<br /><br />
					Choisissez un compte à créditer : <asp:DropDownList ID="ddl_crediter" runat="server"></asp:DropDownList>
					<br /><br />
					Montant à créditer : <asp:TextBox ID="tb_montant" runat="server"></asp:TextBox>
                    <br /><br />
					<asp:Button ID="bt_valider" runat="server" OnClick="bt_valider_Click" Text="Valider" style="height: 26px" />
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
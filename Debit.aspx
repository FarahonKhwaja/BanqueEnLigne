<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Debit.aspx.cs" Inherits="Debit" %>


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
					<asp:Label ID="Label3" runat="server" Text="Débiter" Font-Size="Medium"></asp:Label>                    
                    <br />
					<br />
					Compte à débiter : <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="130px"></asp:DropDownList>
					<br /><br />
					Montant à débiter : <asp:TextBox ID="tbMontantDebit" runat="server"></asp:TextBox>
                    <br /><br />
                    <asp:Button ID="Button1" runat="server" OnClick="btValiderDebit_Click" Text="Valider" style="height: 26px"  />
                    <br /><br />
                    <asp:Label ID="lb_erreur" runat="server" Visible="False"></asp:Label>
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
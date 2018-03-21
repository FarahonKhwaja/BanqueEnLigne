<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="_Default" %>
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
				<asp:Button ID="Button1" runat="server" OnClick="clic_button" Text="Déconnexion" style="z-index: 1; left: 616px; top: 26px; position: absolute" />
            </div>
            <!-- CONTENU DE LA PAGE -->
            <div id="contenu">
                <hr />
				<div id="padding">
					<asp:Label ID="Label3" runat="server" Text="Menu Principal" Font-Size="Medium"></asp:Label>
					<br /><br />
					Bonjour <%:Session["user"]%>
					<br /><br />
					<asp:LinkButton ID="lb_compte_courant" runat="server" OnCommand="lb_clic_liens" CommandName="bt_cpt_courant">Compte courant</asp:LinkButton> 
					<asp:Label ID="lb_modif" runat="server" Text=""></asp:Label>
					<br /><br />
					<asp:LinkButton ID="lb_compte_epargne" runat="server" OnCommand="lb_clic_liens" CommandName="bt_cpt_epargne">Compte épargne</asp:LinkButton>
					<br /><br />
					<asp:LinkButton ID="lb_ope" runat="server" OnCommand="lb_clic_liens" CommandName="bt_operation">Opération</asp:LinkButton>
				    <br />
                    <br />
                    <asp:LinkButton ID="lb_deb" runat="server" OnCommand="lb_clic_liens" CommandName="bt_debit">Débiter</asp:LinkButton><br />
                    <br />
                    <asp:LinkButton ID="lb_cred" runat="server" OnCommand="lb_clic_liens" CommandName="bt_credit">Créditer</asp:LinkButton><br />
                    <br />
                    <asp:LinkButton ID="lb_vir" runat="server" OnCommand="lb_clic_liens" CommandName="bt_virer">Effectuer <br />un virement</asp:LinkButton><br />
                    </div>
                <div style="clear:both"></div>
                <div>
                    <asp:GridView ID="GridViewCompteCourant" runat="server" style="z-index: 1; left: 207px; top: 202px; position: absolute"></asp:GridView>
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

















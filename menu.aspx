<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="_Default" %>

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
                <asp:Button ID="Button1" runat="server" OnClick="clic_button" Text="Déconnexion" style="z-index: 1; left: 616px; top: 26px; position: absolute" />
            </div>
            <!-- CONTENU DE LA PAGE -->
            <div id="contenu">
                <hr />
                <asp:Label ID="Label1" runat="server" Text="Menu Principal" Font-Size="Medium" style="z-index: 1; left: 119px; position: absolute"></asp:Label>
                &nbsp;
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:LinkButton ID="lb_compte_courant" runat="server" OnCommand="lb_clic_liens" CommandName="bt_cpt_courant">Compte courant</asp:LinkButton> 
                <asp:Label ID="lb_modif" runat="server" Text="Sélection"></asp:Label>
                <br />
                <asp:LinkButton ID="lb_compte_epargne" runat="server" OnCommand="lb_clic_liens" CommandName="bt_cpt_epargne">Compte épargne</asp:LinkButton>
                <br />
                <asp:LinkButton ID="lb_ope" runat="server" OnCommand="lb_clic_liens" CommandName="bt_operation">Opération</asp:LinkButton>
                </div>
            <!-- PIED DE LA PAGE -->
            <div id="pied">
                <hr />
                <asp:Label ID="LabelPied" runat="server" Text="Site r&eacute;alis&eacute; par Lucas & Phil" TabIndex="20" /> 
            </div>
        </div>
    </form>
</body>
</html>

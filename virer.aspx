<%@ Page Language="C#" AutoEventWireup="true" CodeFile="virer.aspx.cs" Inherits="virer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Choisissez un compte à débiter :
            <br />
            <asp:DropDownList ID="ddl_debiter" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Choisissez un compte à créditer :<br />
            <asp:DropDownList ID="ddl_crediter" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Choisissez le montant :
            <br />
            <asp:TextBox ID="tb_montant" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="bt_valider" runat="server" OnClick="bt_valider_Click" Text="Valider" />
        </div>
    </form>
</body>
</html>

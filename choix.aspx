<%@ Page Language="C#" AutoEventWireup="true" CodeFile="choix.aspx.cs" Inherits="choix" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Merci de sélectionner le numéro du compte du client puis de valider<br />
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><br />
        <asp:Button ID="bt_valid" runat="server" Text="Valider" OnClick="bt_valid_Click" />
    </form>
</body>
</html>

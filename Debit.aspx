<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Debit.aspx.cs" Inherits="Debit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Compte à débiter :<br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="130px">
            </asp:DropDownList>
            <br />
            <br />
            Montant :
            <br />
            <asp:TextBox ID="tbMontantDebit" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btValiderDebit" runat="server" OnClick="btValiderDebit_Click" Text="Valider" />
        </div>
    </form>
</body>
</html>

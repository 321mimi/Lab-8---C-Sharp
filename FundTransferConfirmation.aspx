<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferConfirmation.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body>
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server" style="width:50%">
      <fieldset>
      <legend class="LargeDistinct">Review and Complete</legend>
        <h3>Transferer</h3>
        Name: <asp:Label ID="transferor" runat="server"></asp:Label><br />
        Account: <asp:Label ID="accountFrom" runat="server"></asp:Label><br />
        Amount: <asp:Label ID="amount" runat="server"></asp:Label><br />
        <h3>Transferee</h3>
        Name: <asp:Label ID="transferee" runat="server"></asp:Label><br />
        Account: <asp:Label ID="accountTo" runat="server"></asp:Label><br /><br />
        <asp:Button ID="back" runat="server" CssClass="button" Text="&lt; Back" OnClick="Confirmation_back_Click" style="float:left"/>
        <asp:Button ID="complete" runat="server" CssClass="button" Text="Complete" OnClick="Confirmation_complete_Click" style="float:right"/>
    </fieldset>
    </form>
</body>
</html>
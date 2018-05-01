<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferResult.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">

    <p>Thank you for using Online fund transfer service.</p>

    <p>Amount: <asp:Label ID="amount" runat="server"></asp:Label> has been transferred</p>

    <h2>From</h2>
    Name: <asp:Label ID="transferor" runat="server"></asp:Label><br />
    Account: <asp:Label ID="accountFrom" runat="server"></asp:Label><br />
        
    <h2>To</h2>
    Name: <asp:Label ID="transferee" runat="server"></asp:Label><br />
    Account: <asp:Label ID="accountTo" runat="server"></asp:Label><br /><br />

    <asp:Button ID="new" runat="server" CssClass="button" Text="Start A New Transfer" OnClick="New_Click" style="width:auto"/>
        
    </form>
</body>
</html>

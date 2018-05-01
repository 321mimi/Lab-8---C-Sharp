<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferTo.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server" style="width:50%">
      <fieldset>
      <legend class="LargeDistinct">Transferee</legend>
        <asp:RequiredFieldValidator ID="required_transferee" runat="server"
            ValidationGroup="group"
                ErrorMessage="Must select one."
                CssClass="error" ControlToValidate="transferee" 
                InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <asp:DropDownList ID="transferee" runat="server" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="Transferee_changed">
           <asp:ListItem Selected="True" Value="-1">Select Transferee...</asp:ListItem>
        </asp:DropDownList><br /><br />

        To Account: <br />
        <asp:RadioButtonList ID="accountType" runat="server">
            <asp:ListItem Value="Checking"></asp:ListItem>
            <asp:ListItem Value="Saving"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="required_accountType" runat="server"
            ValidationGroup="group"
            ControlToValidate="accountType" CssClass="error"
                Display="Dynamic">Must select an account!</asp:RequiredFieldValidator><br /><br />

        <asp:Button ID="back" runat="server" CssClass="button" Text="&lt; Back" OnClick="To_back_Click" style="float:left"/>
        <asp:Button ID="next" runat="server" CssClass="button" Text="Next &gt;" OnClick="To_next_Click" ValidationGroup="group" style="float:right"/>
          </fieldset>
    </form>
</body>
</html>

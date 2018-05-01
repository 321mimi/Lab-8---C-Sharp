<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferFrom.aspx.cs" Inherits="FundTransferFrom" %>

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
      <legend class="LargeDistinct">Transfer From</legend>
        <asp:RequiredFieldValidator ID="required_transferor" runat="server" 
                ErrorMessage="Must select one."
                CssClass="error" ControlToValidate="transferor" 
                InitialValue="-1" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <asp:DropDownList ID="transferor" runat="server" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="Transferor_changed">
           <asp:ListItem Selected="True" Value="-1">Select Transferor ...</asp:ListItem>
        </asp:DropDownList><br /><br />

        From Account:<br /><br />
        <asp:RadioButtonList ID="accountType" runat="server">
            <asp:ListItem Value="Checking"></asp:ListItem>
            <asp:ListItem Value="Saving"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="required_accountType" runat="server"
            ControlToValidate="accountType" CssClass="error"
            Display="Dynamic">Must select an account!</asp:RequiredFieldValidator><br /><br />
        
        Amount: <asp:TextBox ID="amount" runat="server" CssClass="input"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="required_amount" runat="server"
            ControlToValidate="amount" CssClass="error"
                Display="Dynamic">Can not be blank!</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="range_amount" runat="server" ControlToValidate="amount"
                Type="Double" ErrorMessage="Must be greater than 0." 
                MaximumValue="99999999999"
                MinimumValue="1" Display="Dynamic" CssClass="error"></asp:RangeValidator><br />
        
        <asp:Label ID="validateAmount" runat="server" CssClass="error" Visible="False"></asp:Label><br />
            <asp:Button ID="next" runat="server" CssClass="button" Text="Next &gt;" OnClick="From_next_Click" style="float:right"/>
        </fieldset>
    </form>
</body>
</html>

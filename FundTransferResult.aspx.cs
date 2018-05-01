using System;

public partial class FundTransfer : System.Web.UI.Page
{
    // On Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        // Transferor
        Customer selectedTransferor = (Customer)Session["selectedTransferor"];
        transferor.Text = selectedTransferor.ToString();

        // From Account Type
        string fromAccount = (string)Session["fromAccount"];
        // Checking
        if (fromAccount == "Checking")
        {
            accountFrom.Text = selectedTransferor.Checking.ToString();
        // Saving
        } else
        {
            accountFrom.Text = selectedTransferor.Saving.ToString();
        }

        // Amount
        double thisAmount = (double)Session["amount"];
        amount.Text = "&#36;" + thisAmount.ToString();

        // Transferee
        Customer selectedTransferee = (Customer)Session["selectedTransferee"];
        transferee.Text = selectedTransferee.ToString();

        // To Account Type
        string toAccount = (string)Session["toAccount"];
        // Checking
        if (toAccount == "Checking")
        {
            accountTo.Text = selectedTransferee.Checking.ToString();
        // Saving
        } else
        {
            accountTo.Text = selectedTransferee.Saving.ToString();
        }
    }

    // User Clicked New
    protected void New_Click(object sender, System.EventArgs e)
    {
        // Clear Sessions
        Session.Remove("selectedTransferee");
        Session.Remove("selectedTransferor");
        Session.Remove("amount");
        Session.Remove("fromAccount");
        Session.Remove("toAccount");

        // Starting Page
        Response.Redirect("/FundTransferFrom.aspx");
    }
}
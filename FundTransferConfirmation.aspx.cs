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
        // Checking
        if ((string)Session["fromAccount"] == "Checking")
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
        // Checking
        string toAccount = (string)Session["toAccount"];
        if (toAccount == "Checking")
        {
            accountTo.Text = selectedTransferee.Checking.ToString();
        // Saving
        } else
        {
            accountTo.Text = selectedTransferee.Saving.ToString();
        }
    }

    // User Clicked Next 
    protected void Confirmation_complete_Click(object sender, System.EventArgs e)
    {
        // Variables
        Customer selectedTransferor = (Customer)Session["selectedTransferor"];
        Customer selectedTransferee = (Customer)Session["selectedTransferee"];
        string toAccount = (string)Session["toAccount"];
        string fromAccount = (string)Session["fromAccount"];
        double amount = (double)Session["amount"];
        
        // TransferTransaction
        TransferTransaction transfer = new TransferTransaction(amount);

        // From Account
        // Checking
        if (fromAccount == "Checking")
        {
            transfer.FromAccount = selectedTransferor.Checking;
        // Saving
        } else
        {
            transfer.FromAccount = selectedTransferor.Saving;
        }

        // To Account
        // Checking
        if (toAccount == "Checking")
        {
            transfer.ToAccount = selectedTransferee.Checking;
        // Saving
        } else
        {
            transfer.ToAccount = selectedTransferee.Saving;
        }
        
        // Execute Transfer
        transfer.Execute();

        // Next Page
        Response.Redirect("/FundTransferResult.aspx");
    }

    // User Clicked Back
    protected void Confirmation_back_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("/FundTransferTo.aspx");
    }
}
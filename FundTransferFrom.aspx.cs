using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class FundTransferFrom : System.Web.UI.Page
{
    // Customer List
    List<Customer> customers = Customer.GetAllCustomers();

    // On Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            // List transferors
            for (int i = 0; i < Customer.GetAllCustomers().Count; i++)
            {
                transferor.Items.Add(new ListItem(customers[i].ToString(), customers[i].Id.ToString()));
            }
            // Back --> Selected Transferor
            if (Session["selectedTransferor"] != null)
            {
                transferor.SelectedValue = ((Customer)Session["selectedTransferor"]).Id.ToString();
                Transferor_changed(sender, e);
            }
            // Back --> Selected Transferor Account
            if (Session["fromAccount"] != null)
            {
                accountType.SelectedValue = (string)Session["fromAccount"];
            }
            // Back --> Entered Amount
            if (Session["amount"] != null)
            {
                amount.Text = ((double)Session["amount"]).ToString();
            }
        }
    }

    // Transferor Changed
    protected void Transferor_changed(object sender, EventArgs e)
    {
        if (transferor.SelectedValue != "-1")
        {
            // Get The Transferor
            Customer selectedTranferor = Customer.GetCustomerById(int.Parse(transferor.SelectedValue));
            Session["selectedTransferor"] = selectedTranferor;

            // Display Checking Balance
            accountType.Items[0].Text = selectedTranferor.Checking.ToString();

            // Display Saving Balance
            accountType.Items[1].Text = selectedTranferor.Saving.ToString();
        }
    }

    // User Clicked Next
    protected void From_next_Click(object sender, System.EventArgs e)
    {
        // Get Transferor
        Customer selectedTransferor = (Customer)Session["selectedTransferor"];

        // Get Amount
        double finalAmount = double.Parse(amount.Text);
        Session["amount"] = finalAmount;

        // Get Account Type
        string account = accountType.SelectedValue;
        Session["fromAccount"] = account;

        // Validate
        // Insufficient Fund
        if ((selectedTransferor.Checking.Balance < finalAmount && account == "Checking") || (selectedTransferor.Saving.Balance < finalAmount && account == "Saving"))
        {
            validateAmount.Visible = true;
            validateAmount.Text = (TransactionResult.INSUFFICIENT_FUND).ToString();
        // Exceed Max Withdraw Amount
        } else if (selectedTransferor.Status == CustomerStatus.REGULAR && finalAmount > 300 && account == "Checking")
        {
            validateAmount.Visible = true;
            validateAmount.Text = (TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT).ToString();
        } else
        {
            // Next Page
            Response.Redirect("/FundTransferTo.aspx");
        }
    }
}
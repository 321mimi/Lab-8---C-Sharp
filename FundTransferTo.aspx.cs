using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    // Customer List
    List<Customer> customers = Customer.GetAllCustomers();

    // On Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            // Transferor
            Customer selectedTransferor = (Customer)Session["selectedTransferor"];

            // List Transferees
            for (int i = 0; i < Customer.GetAllCustomers().Count; i++)
            {
                // But do not include transferor
                if (customers[i].Id != selectedTransferor.Id)
                {
                    transferee.Items.Add(new ListItem(customers[i].ToString(), customers[i].Id.ToString()));
                }
            }
            // Back --> Selected Transferee
            if (Session["selectedTransferee"] != null)
            {
                transferee.SelectedValue = ((Customer)Session["selectedTransferee"]).Id.ToString();
                Transferee_changed(sender, e);
            }
            // Back --> Selected Transferee Account
            if (Session["toAccount"] != null)
            {
                accountType.SelectedValue = (string)Session["toAccount"];
            }
        }
    }

    // Transferee Changed
    protected void Transferee_changed(object sender, EventArgs e)
    {
        if (transferee.SelectedValue != "-1")
        {
            // Get The Transferee
            Customer selectedTransferee = Customer.GetCustomerById(int.Parse(transferee.SelectedValue));
            Session["selectedTransferee"] = selectedTransferee;

            // Display Checking Balance
            accountType.Items[0].Text = selectedTransferee.Checking.ToString();

            // Display Saving Balance
            accountType.Items[1].Text = selectedTransferee.Saving.ToString();
        }
    }

    // User Clicked Next 
    protected void To_next_Click(object sender, System.EventArgs e)
    {
        // Transferee Account Session
        Session["toAccount"] = accountType.SelectedValue;

        // Next Page
        Response.Redirect("/FundTransferConfirmation.aspx");
    }

    // User Clicked Back
    protected void To_back_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("/FundTransferFrom.aspx");
    }
}
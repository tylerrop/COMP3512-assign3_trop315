using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;

using Content.Business;

/// <summary>
/// Lists all existing customers within the front-end repeater.
/// </summary>
public partial class CustomerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                Boolean access = false;

        //IF USER IS LOGGED IN
        if (User.Identity.IsAuthenticated)
        {
            //CHECKS TO SEE IF THEY HAVE ACCESSS
            foreach(string role in Roles.GetRolesForUser() )
            {
                if(role.Equals("administrator"))
                    access = true;
            }

            //NO ACCESS
            if(!access)
                Response.Redirect("Default.aspx");
        }
        //IF USER IS NOT LOGGED IN
        else
        {
            Response.Redirect("login.aspx");
        }

        //THEY HAVE ACCESS
        if (access)
        {
            if (!IsPostBack)
            {
                // Binds the front-end repeater to a customer collection containing all existing customers.
                CustomerCollection customers = new CustomerCollection();
                customers.FetchAll();

                customerList.DataSource = customers;
                customerList.DataBind();
            }
        }
    }
}
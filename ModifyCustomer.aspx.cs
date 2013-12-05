using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;

/// <summary>
/// Retrieves the parameters a single customer and modifies the database with new information.
/// </summary>
public partial class ModifyCustomer : System.Web.UI.Page
{
    public static CustomerCollection cc;

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
        if(access)
        {
            if (!IsPostBack)
            {
                int customerID = GetQueryString();

                //Fetch the customer information based on the ID in the query string.
                cc = new CustomerCollection();
                cc.FetchForId(customerID);

                singleCustomer.DataSource = cc;

                singleCustomer.DataBind();
            }
        }
    }

    protected void ModifyCustomer_OnClick(object sender, EventArgs e)
    {
        int customerID = GetQueryString();
        string userName;
        string pass;
        int state;
        string firstName;
        string lastName;
        string address;
        string city;
        string region;
        string country;
        string postal;
        string phone;
        string email;
        int privacy = Convert.ToInt32(cc[0].Privacy);

        //User Name
        if (newUsername.Text == "" && cc[0].UserName != null)
            userName = (string)cc[0].UserName;
        else
            userName = newUsername.Text;

        //Password
        if (newPass.Text == "" && cc[0].Pass != null)
            pass = (string)cc[0].Pass;
        else
            pass = newPass.Text;

        //State
        if (newState.Text == "" && cc[0].State != null)
            state = Convert.ToInt32(cc[0].State);
        else
            state = Convert.ToInt32(newState.Text);

        //First Name
        if (newFirst.Text == "" && cc[0].FirstName != null)
            firstName = (string)cc[0].FirstName;
        else
            firstName = newFirst.Text;

        //Last Name
        if (newLast.Text == "" && cc[0].LastName != null)
            lastName = (string)cc[0].LastName;
        else
            lastName = newLast.Text;

        //Address
        if (newAddress.Text == "" && cc[0].Address != null)
            address = (string)cc[0].Address;
        else
            address = newAddress.Text;

        //City
        if (newCity.Text == "" && cc[0].City != null)
            city = (string)cc[0].City;
        else
            city = newCity.Text;

        //Region
        if (newRegion.Text == "" && cc[0].Region != null)
            region = (string)cc[0].Region;
        else
            region = newRegion.Text;

        //Country
        if (newCountry.Text == "" && cc[0].Country != null)
            country = (string)cc[0].Country;
        else
            country = newCountry.Text;

        //Postal
        if (newPostal.Text == "" && cc[0].Postal != null)
            postal = (string)cc[0].Postal;
        else
            postal = newPostal.Text;

        //Phone
        if (newPhone.Text == "" && cc[0].Phone != null)
            phone = (string)cc[0].Phone;
        else
            phone = newPhone.Text;

        //Email
        if (newEmail.Text == "" && cc[0].Email != null)
            email = (string)cc[0].Email;
        else
            email = newEmail.Text;

        //Privacy
        if (Convert.ToInt32(newPrivacy.SelectedValue) == 1)
            privacy = 1;
        else if (Convert.ToInt32(newPrivacy.SelectedValue) == 2)
            privacy = 2;


        //Update Database
        cc.modifyCustomer(customerID, userName, pass, state, firstName, lastName, address, city, region, country, postal, phone, email, privacy);

        successMsg.Text = "User Modified";

        //Fetch the customer information based on the ID in the query string.
        cc = new CustomerCollection();
        cc.FetchForId(customerID);

        singleCustomer.DataSource = cc;

        singleCustomer.DataBind();

    }

    private int GetQueryString()
    {
        int customerID = 0;
        bool flag = Int32.TryParse(Request["id"], out customerID);

        return customerID;
    }
}
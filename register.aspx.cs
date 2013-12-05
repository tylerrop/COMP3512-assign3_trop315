using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //IF USER IS LOGGED IN
        if (User.Identity.IsAuthenticated)
        {
            CreateUserWizard1.Visible = false;
            ErrorMessage.Text = "You are already logged in";
        }
    }
}
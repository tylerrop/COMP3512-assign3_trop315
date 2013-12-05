using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;

public partial class ReviewInformation : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RemoveReview_OnClick(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        ReviewsCollection rc = new ReviewsCollection();

        //Get Review ID
        int id = Convert.ToInt32(btn.CommandArgument);

        //Remove Review
        rc.removeReview(id);

        Response.Redirect(Request.RawUrl);
    }
}
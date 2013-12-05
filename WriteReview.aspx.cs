using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;

/// <summary>
/// Takes in the input from the user and adds a review to the Reviews table
/// </summary>
public partial class WriteReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //IF USER IS NOT LOGGED IN
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("login.aspx");
        }
        //IF USER IS LOGGED IN
        else
        {
            if (!IsPostBack)
            {
                int artworkId = GetQueryString();

                ArtWorkCollection ac = new ArtWorkCollection();

                //Fetch the artwork information based on the artwork ID in the query string
                ac.FetchForId(artworkId);
                reviewTitle.DataSource = ac;

                reviewTitle.DataBind();
            }
        }

    }

    /// <summary>
    /// Writes a review to the review table
    /// </summary>
    protected void AddReview_OnClick(object sender, EventArgs e)
    {
        ReviewsCollection rc = new ReviewsCollection();
        Boolean alreadyReviewed = false;
        int rating;
        string comment;

        DateTime reviewDate = DateTime.Now;
        int artworkId = GetQueryString();
        string reviewer = User.Identity.Name.ToString();

        rc.FetchByArtWork(artworkId);

        foreach (Review r in rc)
        {
            if (r.Reviewer.Equals(reviewer))
                alreadyReviewed = true;
        }

        if (!alreadyReviewed)
        {
            //Set Rating
            if (ratingDropDown.SelectedItem != null)
                rating = Convert.ToInt32(ratingDropDown.SelectedItem.Value);
            else
                rating = 0;

            //Set Comment
            comment = reviewBox.Text;

            rc.addReview(artworkId, reviewer, reviewDate, rating, comment);

            message.Text = "The review was added";
        }
        else
        {
            message.Text = "You have already reviewed this work";
        }
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;
using Content.DataAccess;
using System.Data;

/// <summary>
/// This will load all the artwork information for a single artwork
/// </summary>
public partial class SingleArtwork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int artworkId = GetQueryString();

            ArtWorkCollection ac = new ArtWorkCollection();

            //Fetch the artwork information based on the artwork ID in the query string
            ac.FetchForId(artworkId);
            artWorkDetails.DataSource = ac;

            artWorkDetails.DataBind();

            //Load reviews
            ReviewsCollection rc = new ReviewsCollection();
            rc.FetchByArtWork(artworkId);
            reviews.DataSource = rc;
            reviews.DataBind();
        }
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}
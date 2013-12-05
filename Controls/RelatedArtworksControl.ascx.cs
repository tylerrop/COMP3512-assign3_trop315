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
/// This control will display the related artworks
/// </summary>
public partial class Controls_RelatedArtworksControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int artworkId = GetQueryString();

        //Fetch the realated artworks based on an artwork ID found in the query string
        ArtWorkCollection awc = new ArtWorkCollection();
        awc.FetchRelated(artworkId);

        relatedArtworkRepeater.DataSource = awc;
        relatedArtworkRepeater.DataBind();
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}
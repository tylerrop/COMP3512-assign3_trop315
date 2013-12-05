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
/// This control will display the related artists
/// </summary>
public partial class RelatedArtistsControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int artistId = GetQueryString();

        //Fetch the realated artists based on an artist ID found in the query string
        ArtistCollection ac = new ArtistCollection(false);
        ac.FetchRelatedArtists(artistId);

        relatedArtistsRepeater.DataSource = ac;
        relatedArtistsRepeater.DataBind();
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}
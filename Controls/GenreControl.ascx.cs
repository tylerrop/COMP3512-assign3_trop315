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
/// This control will get the genres of a specific artwork from an ID in the query string
/// </summary>
public partial class GenreControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int artworkId = GetQueryString();
        
        //Gets the genres of a specific artwork
        ArtWorkCollection ac = new ArtWorkCollection();
        ac.FetchForId(artworkId);
        genreData.DataSource = ac[0].Genres;

        genreData.DataBind();
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}
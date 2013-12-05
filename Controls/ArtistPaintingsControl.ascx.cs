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
/// This control will print the works of a specific artist
/// </summary>
public partial class ArtistPaintings : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int artistId = GetQueryString();

            //Gets the paintings of a specific artist
            ArtistCollection ac = new ArtistCollection(false);
            ac.FetchForId(artistId);

            //Binds the list of paintings to a repeater
            artDetails.DataSource = ac[0].Works;
            artDetails.DataBind();
        }
    }

    private int GetQueryString()
    {
        int artistId = 0;
        bool flag = Int32.TryParse(Request["id"], out artistId);

        return artistId;
    }
}
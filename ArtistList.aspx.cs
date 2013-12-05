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
/// This will show a list of all the artists
/// </summary>
public partial class ArtistList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //auto fill up the artist collection with all of the artists
            ArtistCollection ac = new ArtistCollection(true);

            artistList.DataSource = ac;

            artistList.DataBind();
        }
    }

}
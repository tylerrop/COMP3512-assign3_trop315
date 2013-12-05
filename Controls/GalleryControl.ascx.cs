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
/// This control will get the gallery information of a painting.
/// </summary>
public partial class GalleryControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int artworkId = GetQueryString();

            //Gets the gallery of a specific painting
            ArtWorkCollection ac = new ArtWorkCollection();
            ac.FetchForId(artworkId);
            galleryData.DataSource = ac[0].Gallery;

            galleryData.DataBind();
        }
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}
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
/// This control will show the related puchases of an artwork
/// </summary>
public partial class Controls_PurchasesControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int artworkId = GetQueryString();

        //Fetch the related purchases from an artwork ID found in the query string
        ArtWorkCollection awc = new ArtWorkCollection();
        awc.FetchRelatedPurchases(artworkId, 5);

        relatedPurchasesRepeater.DataSource = awc;
        relatedPurchasesRepeater.DataBind();
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}
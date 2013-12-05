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
/// This control will find the subjects of an artwork
/// </summary>
public partial class SubjectControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int artworkId = GetQueryString();

        ArtWorkCollection ac = new ArtWorkCollection();

        //Fetch the subjects based on an artwork ID found in the query string
        ac.FetchForId(artworkId);
        subjectData.DataSource = ac[0].Subjects;

        subjectData.DataBind();
    }

    private int GetQueryString()
    {
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}
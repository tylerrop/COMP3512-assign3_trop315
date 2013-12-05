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
/// This will load a list of all the genres
/// </summary>
public partial class GenreList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //auto fill up the collection with all of the artworks
            GenresCollection sc = new GenresCollection();

            sc.FetchGroupedGenres();

            genreList.DataSource = sc;

            genreList.DataBind();
        }
    }
}
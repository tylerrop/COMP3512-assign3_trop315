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
/// This will load all of the content in the master page
/// </summary>
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Dropdowns

            //Artist
            ArtistCollection ac = new ArtistCollection(false);
            ac.FetchMostSales(5);
            popArtists.DataSource = ac;
            popArtists.DataBind();

            //Genres
            GenresCollection gc = new GenresCollection();
            gc.FetchGroupedGenres();
            genreRepeater.DataSource = gc;
            genreRepeater.DataBind();

            //Subjects
            SubjectsCollection sc = new SubjectsCollection();
            sc.FetchGroupedSubjects();
            subjectRepeater.DataSource = sc;
            subjectRepeater.DataBind();
        }

    }

    /// <summary>
    /// This will create a query string for the simple search and redirect 
    /// to the advanced page so the sort control can display the search results
    /// </summary>
    protected void SimpleSearch_Click(object sender, EventArgs e)
    {

        string query = "AdvancedSearch.aspx";

        query += "?orderBy=notSet";
        query += "&orderType=ASC";

        if (navSearch.Text != "")
            query += "&simple=" + navSearch.Text;
        else
            query += "&simple=";

        Response.Redirect(query);
    }
}

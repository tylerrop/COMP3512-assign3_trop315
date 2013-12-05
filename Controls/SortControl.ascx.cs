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
/// This is a generic control that will sort the search results or genre and subject 
/// works based on what is found in the query string
/// </summary>
public partial class Controls_SortControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    /// <summary>
    /// This method will look in the query string and pull the appropriate data depending on what it finds
    /// </summary>
    public void BindData()
    {
        ArtistCollection ac = new ArtistCollection(false);
        ArtWorkCollection aw = new ArtWorkCollection();
        errorMessage.Text = "";

        //Filter Options
        string orderBy = Request.QueryString["orderBy"];
        string orderType = Request.QueryString["orderType"];
        int id = Convert.ToInt32(Request.QueryString["id"]);

        //Simple
        string simpleFliter = Request.QueryString["simple"];

        //Adv Artist
        string artistFilter = Request.QueryString["artist"];

        //Adv Artwork
        string title = Request.QueryString["title"];
        int yearStart = Convert.ToInt32(Request.QueryString["yearStart"]);
        int yearEnd = Convert.ToInt32(Request.QueryString["yearEnd"]);
        double costStart = Convert.ToDouble(Request.QueryString["costStart"]);
        double costEnd = Convert.ToDouble(Request.QueryString["costEnd"]);




        //SIMPLE SEARCH
        if (simpleFliter != null)
        {
            //Finds the artists matching the parameters
            ac.FetchLikeName(simpleFliter, orderBy, orderType);
            if (ac.Count != 0)
            {
                displaySearchArtists.DataSource = ac;
                displaySearchArtists.DataBind();
            }

            //Finds the works matching the parameters
            aw.FetchLikeTitle(simpleFliter, orderBy, orderType);
            if (aw.Count != 0)
            {
                displaySearchWorks.DataSource = aw;
                displaySearchWorks.DataBind();
            }

            //Error message if no results returned
            if (aw.Count == 0 && ac.Count == 0)
                errorMessage.Text = "No Results Found. Please Try Searching Again.";
        }
        //ARTIST SEARCH
        else if (artistFilter != null)
        {
            //Finds artists matching the search parameters
            ac.FetchLikeName(artistFilter, orderBy, orderType);
            if (ac.Count != 0)
            {

                displaySearchArtists.DataSource = ac;
                displaySearchArtists.DataBind();
            }
            else
                errorMessage.Text = "No Results Found. Please Try Searching Again.";
        }
        //ARTWORK SEARCH
        else if (title != null && yearStart != null && yearEnd != null && costStart != null && costEnd != null)
        {
            //Finds the artwork based on the search parameters
            aw.FetchLikeAdvanced(title, yearStart, yearEnd, costStart, costEnd, orderBy, orderType);

            if (aw.Count != 0)
            {
                displaySearchWorks.DataSource = aw;
                displaySearchWorks.DataBind();
            }
            else
                errorMessage.Text = "No Results Found. Please Try Searching Again.";
        }
        //GENRES
        else if (Request.QueryString["genre"] != null)
        {
            //Finds the works of a specific genre
            aw.FetchByGenre(id, orderBy, orderType);

            if (aw.Count != 0)
            {
                displayGenres.DataSource = aw;
                displayGenres.DataBind();
            }
            else
                errorMessage.Text = "No Results Found. Please Try Searching Again.";
        }
        //SUBJECTS
        else if (Request.QueryString["subject"] != null)
        {
            //Finds the works of a specific subject
            aw.FetchBySubject(id, orderBy, orderType);

            if (aw.Count != 0)
            {
                displaySubjects.DataSource = aw;
                displaySubjects.DataBind();
            }
            else
                errorMessage.Text = "No Results Found. Please Try Searching Again.";
        }
    }
}
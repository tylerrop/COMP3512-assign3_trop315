using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;

using Content.Business;
using Content.DataAccess;

/// <summary>
/// This will adjust visibility of search form controls and create a query string 
/// to run the search using those controls. The sort control on this page will handle
/// displaying the search results after information is put in the query string
/// </summary>
public partial class AdvancedSearch : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// This will hide and show artist or artwork advanced controls depending on what is selected
    /// </summary>
    protected void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        //the Artist radio is checked so the Artist text box is shown and the Artwork text boxes are hidden
        if (ArtistFilterButton.Checked)
        {
            //Adjust Visibility
            ArtistSearch.Visible = true;
            ArtworkTitle.Visible = false;
            ArtworkYearStart.Visible = false;
            ArtworkYearEnd.Visible = false;
            ArtworkCostStart.Visible = false;
            ArtworkCostEnd.Visible = false;
            searchSelect.Visible = false;
            ASCRadioButton.Visible = true;
            DESCRadioButton.Visible = true;

            //Clear advanced artwork search controls
            ArtworkTitle.Text = "";
            ArtworkYearStart.Text = "";
            ArtworkYearEnd.Text = "";
            ArtworkCostStart.Text = "";
            ArtworkCostEnd.Text = "";
        }

        //the description radio is checked so the Artist text box is hidden and the description text box shown
        else if (ArtworkFilterButton.Checked)
        {
            //Adjust Visibility
            ArtistSearch.Visible = false;
            searchSelect.Visible = true;
            ArtworkTitle.Visible = true;
            ArtworkYearStart.Visible = true;
            ArtworkYearEnd.Visible = true;
            ArtworkCostStart.Visible = true;
            ArtworkCostEnd.Visible = true;
            ASCRadioButton.Visible = true;
            DESCRadioButton.Visible = true;

            //Clear advanced artist search control
            ArtistSearch.Text = "";

        }
    }
    /// <summary>
    /// Adds all the users input to the query string and reloads the page so 
    /// the sort control can compleate the search
    /// </summary>
    public void FilterButtonPress(object sender, EventArgs e)
    {
        string query = "AdvancedSearch.aspx";


        //Send Filter options
        if (ArtistFilterButton.Checked)
            query += "?orderBy=" + "LastName";
        else if (ArtworkFilterButton.Checked)
            query += "?orderBy=" + searchSelect.SelectedItem.Value;

        if(ASCRadioButton.Checked)
            query += "&orderType=" + "ASC";
        else if (DESCRadioButton.Checked)
            query += "&orderType=" + "DESC";
        


        //Artist search selected
        if (ArtistFilterButton.Checked)
        {
            if (ArtistSearch.Text != "")
                query += "&artist=" + ArtistSearch.Text;
            else
                query += "&artist=";

        }

        //description search selected
        else if (ArtworkFilterButton.Checked)
        {
            //Title
            if (ArtworkTitle.Text != "")
                query += "&title=" + ArtworkTitle.Text;
            else
                query += "&title=";

            //Year Start
            if (ArtworkYearStart.Text != "")
                query += "&yearStart=" + ArtworkYearStart.Text;
            else
                query += "&yearStart=0";

            //Year End
            if (ArtworkYearEnd.Text != "")
                query += "&yearEnd=" + ArtworkYearEnd.Text;
            else
                query += "&yearEnd=1000000";

            //Cost Start
            if (ArtworkCostStart.Text != "")
                query += "&costStart=" + ArtworkCostStart.Text;
            else
                query += "&costStart=0";

            //Cost End
            if (ArtworkCostEnd.Text != "")
                query += "&costEnd=" + ArtworkCostEnd.Text;
            else
                query += "&costEnd=1000000";
 
        }

        Response.Redirect(query);
    }
}
     
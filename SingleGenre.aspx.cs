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
/// This will load all the genre information for a single genre
/// </summary>
public partial class SingleGenre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int genreId = GetQueryString();

            //Fetch the genre information based on the genre ID in the query string
            GenresCollection gc = new GenresCollection();

            gc.FetchForId(genreId);
            singleGenreGridView.DataSource = gc;

            singleGenreGridView.DataBind();
        }
    }

    /// <summary>
    /// This will create a query string form the sort controls and recall the page
    /// so the sort control can sort the genres
    /// </summary>
    public void FilterButtonPress(object sender, EventArgs e)
    {
        string query = "SingleGenre.aspx";

        query += "?orderBy=" + searchSelect.SelectedItem.Value;

        if (ASCRadioButton.Checked)
            query += "&orderType=" + "ASC";
        else if (DESCRadioButton.Checked)
            query += "&orderType=" + "DESC";

        query += "&genre=" + "1";

        query += "&id=" + GetQueryString();

        Response.Redirect(query);
    }


    private int GetQueryString()
    {
        int genreId = 0;
        bool flag = Int32.TryParse(Request["id"], out genreId);

        return genreId;
    }
}
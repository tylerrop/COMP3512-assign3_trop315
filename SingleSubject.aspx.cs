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
/// This will load all the subjects information for a single subject
/// </summary>
public partial class SingleSubject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int subjectId = GetQueryString();

            //Fetch the subject information based on the subject ID in the query string
            SubjectsCollection sc = new SubjectsCollection();

            sc.FetchForId(subjectId);
            singleSubjectGridView.DataSource = sc;

            singleSubjectGridView.DataBind();
        }
    }

    /// <summary>
    /// This will create a query string form the sort controls and recall the page
    /// so the sort control can sort the subjects
    /// </summary>
    public void FilterButtonPress(object sender, EventArgs e)
    {
        string query = "SingleSubject.aspx";

        query += "?orderBy=" + searchSelect.SelectedItem.Value;

        if (ASCRadioButton.Checked)
            query += "&orderType=" + "ASC";
        else if (DESCRadioButton.Checked)
            query += "&orderType=" + "DESC";

        query += "&subject=" + "1";

        query += "&id=" + GetQueryString();

        Response.Redirect(query);
    }

    private int GetQueryString()
    {
        int subjectId = 0;
        bool flag = Int32.TryParse(Request["id"], out subjectId);

        return subjectId;
    }
}
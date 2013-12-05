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
/// This will load a list of all the subjects
/// </summary>
public partial class SubjectList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //auto fill up the collection with all of the artworks
            SubjectsCollection sc = new SubjectsCollection();

            sc.FetchGroupedSubjects();

            subjectList.DataSource = sc;

            subjectList.DataBind();
        }
    }
}
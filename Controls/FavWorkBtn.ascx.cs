using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;

public partial class FavWorkBtn : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// This is an event handler for the artwork fav button that will 
    /// add the artwork to the favorites list
    /// </summary>
    protected void AddArtworkFav_OnClick(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);

        //Get ArtWork Info---------------------------
        int id = Convert.ToInt32(btn.CommandArgument);

        //Finds the artwork of the ID
        ArtWorkCollection aw = new ArtWorkCollection();
        aw.FetchForId(id);

        //Pulls information the create the favorite item
        string title = aw[0].Title;
        string imgFileName = aw[0].ImageFileName;

        //Creates the favorite item
        ArtWorkFavoriteItem artWorkItem = new ArtWorkFavoriteItem(id, title, imgFileName);

        //Creates the session
        List<ArtWorkFavoriteItem> favArtWorkList = (List<ArtWorkFavoriteItem>)HttpContext.Current.Session["favArtwork"];

        //IF THE SESSION DOSNT EXIST
        if (favArtWorkList == null)
        {
            //Creates a new list of favorite items
            favArtWorkList = new List<ArtWorkFavoriteItem>();
            //Adds the item
            favArtWorkList.Add(artWorkItem);
            //Puts the list in the faveorite list
            HttpContext.Current.Session["favArtwork"] = favArtWorkList;
        }
        //SESSION EXISTS
        else
        {
            //Boolean to see it the item already exists
            bool exists = false;

            //Searches the list to find a matching ID
            foreach (ArtWorkFavoriteItem item in favArtWorkList)
            {
                if (item.Id == artWorkItem.Id)
                    exists = true;
            }

            //Adds the item if it dosnt exist
            if (!exists)
                favArtWorkList.Add(artWorkItem);
        }
    }
}
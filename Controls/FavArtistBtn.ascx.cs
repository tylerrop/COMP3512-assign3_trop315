using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;

public partial class FavArtistBtn : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// This is an event handler fo the artist fav button that will 
    /// add the artists to the favorites list
    /// </summary>
    protected void AddArtistFav_OnClick(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);

        //Get ArtWork Info---------------------------
        int id = Convert.ToInt32(btn.CommandArgument);

        //Finds the artist of the ID
        ArtistCollection ac = new ArtistCollection(false);
        ac.FetchForId(id);

        //Pulls information the create the favorite item
        string first = ac[0].FirstName;
        string last = ac[0].LastName;

        //Creates the favorite item
        ArtistFavoriteItem artistItem = new ArtistFavoriteItem(id, first, last);

        //Creates the session
        List<ArtistFavoriteItem> favArtistList = (List<ArtistFavoriteItem>)HttpContext.Current.Session["favArtist"];

        //IF THE SESSION DOSNT EXIST
        if (favArtistList == null)
        {
            //Creates a new list of artist item
            favArtistList = new List<ArtistFavoriteItem>();
            //Adds the item
            favArtistList.Add(artistItem);
            //Puts the list in the faveorite list
            HttpContext.Current.Session["favArtist"] = favArtistList;
        }
        //SESSION EXISTS
        else
        {
            //Boolean to see it the item already exists
            bool exists = false;

            //Searches the list to find a matching ID
            foreach (ArtistFavoriteItem item in favArtistList)
            {
                if (item.Id == artistItem.Id)
                    exists = true;
            }

            //Adds the item if it dosnt exist
            if (!exists)
                favArtistList.Add(artistItem);
        }
    }
}
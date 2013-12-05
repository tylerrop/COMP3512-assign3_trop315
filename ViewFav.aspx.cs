using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;

/// <summary>
/// This will view all the items in the Favorites
/// </summary>
public partial class ViewFav : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        DisplayFav();    
    }

    /// <summary>
    /// This is an event handler for the remove button that removes an artwork favorite item
    /// </summary>
    protected void artwork_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        List<ArtWorkFavoriteItem> artworkFav = (List<ArtWorkFavoriteItem>)Session["favArtWork"];

        // check which command generated this event
        if (e.CommandName == "RemoveFavArtwork")
        {
            // retrieve the index of the row that generated the event
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int count = artworkGrid.DataKeys.Count;

            if (rowIndex < count)
            {

                // get the row's collection of data key values
                DataKey rowKeys = artworkGrid.DataKeys[rowIndex];

                // retrieve the id of product to remove from the data key values
                int idToRemove = (int)rowKeys.Values["Id"];

                // now remove product from cart

                // -- first retrieve cart from session
                List<ArtWorkFavoriteItem> artworkFavList = (List<ArtWorkFavoriteItem>)Session["favArtwork"];

                if (artworkFavList == null) return;

                // -- second find the product that has the product id to delete
                int indexToRemove = -1;
                int index = 0;
                foreach (ArtWorkFavoriteItem al in artworkFavList)
                {
                    if (al.Id == idToRemove)
                        indexToRemove = index;
                    index++;
                }

                // -- third remove item from collection
                artworkFavList.RemoveAt(indexToRemove);

                Session["artworkFav"] = artworkFavList;

                if (artworkFavList.Count == 0)
                    emptyArtworkMessage.Text = "Artwork favorites list is empty";


                // redisplay cart
                DisplayFav();
            }

        }
    }

    /// <summary>
    /// This is an event handler for the remove button that removes an artist favorite item
    /// </summary>
    protected void artist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // check which command generated this event
        if (e.CommandName == "RemoveFavArtist")
        {
            // retrieve the index of the row that generated the event
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int count = artistGrid.DataKeys.Count;

            if (rowIndex < count)
            {

                // get the row's collection of data key values
                DataKey rowKeys = artistGrid.DataKeys[rowIndex];

                // retrieve the id of product to remove from the data key values
                int idToRemove = (int)rowKeys.Values["Id"];

                // now remove product from cart

                // -- first retrieve cart from session
                List<ArtistFavoriteItem> artistFavList = (List<ArtistFavoriteItem>)Session["favArtist"];

                if (artistFavList == null) return;

                // -- second find the product that has the product id to delete
                int indexToRemove = -1;
                int index = 0;

                foreach (ArtistFavoriteItem al in artistFavList)
                {
                    if (al.Id == idToRemove)
                        indexToRemove = index;
                    index++;
                }

                // -- third remove item from collection

                artistFavList.RemoveAt(indexToRemove);

                Session["artistFav"] = artistFavList;

                if(artistFavList.Count == 0)
                    emptyArtistMessage.Text = "Artist favorites list is empty";

                // redisplay cart
                DisplayFav();
            }

        }
    }

    /// <summary>
    /// This will display the favorites 
    /// </summary>
    private void DisplayFav()
    {
        //Loads the artwork favorite session
        List<ArtWorkFavoriteItem> favListArtwork = (List<ArtWorkFavoriteItem>)Session["favArtwork"];

        //ARTWORK FAVORITE SESSION IS EMPTY
        if (favListArtwork == null)
            emptyArtworkMessage.Text = "Artwork favorites list is empty";

        //ARTWORK FAVORITE SESSION HAS DATA
        else
        {
            //Bind to the favorites list
            artworkGrid.DataSource = favListArtwork;
            artworkGrid.DataBind();
        }

        //IF THE ARTWORK FAVORITE LIST HAS NO ITEMS
        if (favListArtwork != null)
        {
            if (favListArtwork.Count == 0)
                emptyArtworkMessage.Text = "Artwork favorites list is empty";
        }

        //Loads the artwork artist session
        List<ArtistFavoriteItem> favListArtist = (List<ArtistFavoriteItem>)Session["favArtist"];

        //ARTIST FAVORITE SESSION IS EMPTY
        if (favListArtist == null)
            emptyArtistMessage.Text = "Artist favorites list is empty";

        //ARTIST FAVORITE SESSION HAS DATA
        else
        {
            //Bind to the favorites list
            artistGrid.DataSource = favListArtist;
            artistGrid.DataBind();
        }

        //IF THE ARTIST FAVORITE LIST HAS NO ITEMS
        if (favListArtist != null)
        {
            if (favListArtist.Count == 0)
                emptyArtistMessage.Text = "Artist favorites list is empty";
        }
    }
}


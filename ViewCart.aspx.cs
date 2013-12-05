using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;

/// <summary>
/// This will view all the items in the cart allowing the users to
/// remove or modify and item in the cart
/// </summary>
public partial class ViewCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DisplayCart();
    }

    /// <summary>
    /// Calls commands to remove or modify items
    /// </summary>
    protected void artwork_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        List<CartItem> artworkCart = (List<CartItem>)Session["cart"];

        // check which command generated this event
        if (e.CommandName == "RemoveCartItem")
        {
            RemoveItem(e);
        }
        else if (e.CommandName == "ModifyCartItem")
        {
            modifyItem(e);
        }
    }

    /// <summary>
    /// This will modify an item in the cart
    /// </summary>
    private void modifyItem(GridViewCommandEventArgs e)
    {
        // retrieve the index of the row that generated the event
        int rowIndex = Convert.ToInt32(e.CommandArgument);

        int count = artworkGrid.DataKeys.Count;

        if (rowIndex < count)
        {
            //Redirects to the AddToCart page to modify the item
            string modQuery = "AddToCart.aspx";

            // get the row's collection of data key values
            DataKey rowKeys = artworkGrid.DataKeys[rowIndex];

            // retrieve the id of product to remove from the data key values
            int idToRemove = (int)rowKeys.Values["Id"];

            // now remove product from cart

            // -- first retrieve cart from session
            List<CartItem> cartList = (List<CartItem>)Session["cart"];

            if (cartList == null) return;

            // -- second find the product that has the product id to delete
            int indexToRemove = -1;
            int index = 0;
            foreach (CartItem al in cartList)
            {
                if (al.Id == idToRemove)
                    indexToRemove = index;
                index++;
            }

            modQuery += "?remove=" + indexToRemove;
            modQuery += "&id=" + cartList[indexToRemove].Id;
            modQuery += "&matt=" + cartList[indexToRemove].MattID;
            modQuery += "&glass=" + cartList[indexToRemove].GlassID;
            modQuery += "&frame=" + cartList[indexToRemove].FramesID;

            Response.Redirect(modQuery);

        }
    }

    /// <summary>
    /// This removes an item in the cart
    /// </summary>
    private void RemoveItem(GridViewCommandEventArgs e)
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
            List<CartItem> cartList = (List<CartItem>)Session["cart"];

            if (cartList == null) return;

            // -- second find the product that has the product id to delete
            int indexToRemove = -1;
            int index = 0;
            foreach (CartItem al in cartList)
            {
                if (al.Id == idToRemove)
                    indexToRemove = index;
                index++;
            }

            // -- third remove item from collection
            cartList.RemoveAt(indexToRemove);

            Session["cart"] = cartList;

            if (cartList.Count == 0)
                emptyArtworkMessage.Text = "Your Cart is empty";


            // redisplay cart
            DisplayCart();
        }
    }

    /// <summary>
    /// This will display the cart 
    /// </summary>
    private void DisplayCart()
    {
        //Load the cart session
        List<CartItem> cartList = (List<CartItem>)Session["cart"];

        //CART IS EMPTY
        if (cartList == null)
        {
            //Display cart is empty message
            emptyArtworkMessage.Text = "Your Cart is empty";
            totalCostLabel.Text = "$0.00";
            CheckoutButton.Visible = false;
        }
        //CART HAS DATA
        else
        {
            CheckoutButton.Visible = true;

            //Bind to the cart
            artworkGrid.DataSource = cartList;
            artworkGrid.DataBind();

            //Calculate the total cost of all the items
            double totalCartCost = 0;
            foreach (CartItem i in cartList)
            {
                totalCartCost += i.TotalCost;
            }

            //Display Total Cost
            totalCostLabel.Text = "$" + totalCartCost.ToString() + ".00";

        }

        //IF THE CART HAS NO ITEMS
        if (cartList != null)
        {
            if (cartList.Count == 0)
            {
                //Display cart is empty message
                emptyArtworkMessage.Text = "Your Cart is empty";
                totalCostLabel.Text = "$0.00";
                CheckoutButton.Visible = false;
            }
        }
    }
}
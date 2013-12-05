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
/// This will get information on the frame, matt, and glass that the user wants to purchase.
/// it will create a cart item containing the painting and all its components that the user
/// wishes to buy. The cart item will be stored on a session that can be loaded on the cart 
/// page
/// </summary>
public partial class AddToCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MattCollection mattCol = new MattCollection();
        GlassCollection glassCol = new GlassCollection();
        FramesCollection frameCol = new FramesCollection();
        
        if (!IsPostBack)
        {
            //Get the selected artwork
            ArtWorkCollection aw = new ArtWorkCollection();
            aw.FetchForId(Convert.ToInt32(Request["id"]));
            selectedArtWork.DataSource = aw;
            selectedArtWork.DataBind();

            //Fill the Matt options
            mattCol = new MattCollection();
            mattCol.FetchAll();
            foreach (Matt m in mattCol)
            {
                ListItem item = new ListItem(m.Title, m.Id.ToString());
                mattList.Items.Add(item);
            }

            //Fill the Glass options
            glassCol = new GlassCollection();
            glassCol.FetchAll();
            foreach (Glass g in glassCol)
            {
                ListItem item = new ListItem(g.Title, g.Id.ToString());
                glassList.Items.Add(item);
            }

            //Fill the Frames options
            frameCol = new FramesCollection();
            frameCol.FetchAll();
            foreach (Frames f in frameCol)
            {
                ListItem item = new ListItem(f.Title, f.Id.ToString());
                frameList.Items.Add(item);
            }

            //IF MODIFY QUERY
            if (Request["remove"] != null)
            {
                //Get selected matt
                for (int i = 0; i < mattList.Items.Count; i++)
                {
                    if (mattList.Items[i].Value.Equals(Request["matt"]))
                    {
                        mattList.Items[i].Selected = true;
                    }
                }

                //Get selected glass
                for (int i = 0; i < glassList.Items.Count; i++)
                {
                    if (glassList.Items[i].Value.Equals(Request["glass"]))
                    {
                        glassList.Items[i].Selected = true;
                    }
                }

                //Get selected frame
                for (int i = 0; i < frameList.Items.Count; i++)
                {
                    if (frameList.Items[i].Value.Equals(Request["frame"]))
                    {
                        frameList.Items[i].Selected = true;
                    }
                }
            }
        }

        //Show the details of the selected matt
        mattCol = new MattCollection();
        mattCol.FetchForId(Convert.ToInt32(mattList.SelectedItem.Value));

        if (!mattCol[0].Title.Equals("[None]"))
        {
            mattPrice.Text = "25.00";

            mattColor.Visible = true;
            System.Drawing.Color color = (System.Drawing.Color)System.Drawing.ColorTranslator.FromHtml("#" + mattCol[0].ColorCode.ToString());
            mattColor.BackColor = color;
        }
        else
        {
            mattColor.Visible = false;
            mattPrice.Text = "0.00";
        }


        //Show the details of the selected glass
        glassCol = new GlassCollection();
        glassCol.FetchForId(Convert.ToInt32(glassList.SelectedItem.Value));

        glassPrice.Text = glassCol[0].Price.ToString() + ".00";
        glassDescription.Text = glassCol[0].Description.ToString();
            
        //Show the details of the selected Frame
        frameCol = new FramesCollection();
        frameCol.FetchForId(Convert.ToInt32(frameList.SelectedItem.Value));

        frameColor.Text = frameCol[0].Color.ToString();
        frameSyle.Text = frameCol[0].Syle.ToString();
        framePrice.Text = frameCol[0].Price.ToString() + ".00";
            

    }

    /// <summary>
    /// Creats an cart item from the users selection and adds it to the session
    /// </summary>
    protected void AddArtworkCart_OnClick(object sender, EventArgs e)
    {
        int id = 0;

        //Get ID
        if (Request["remove"] != null)
        {
            //Remove old item
            List<CartItem> oldList = (List<CartItem>)Session["cart"];
            oldList.RemoveAt(Convert.ToInt32(Request["remove"]));
        }

        id = Convert.ToInt32(Request["id"]);

        //Get ArtWork Info
        ArtWorkCollection aw = new ArtWorkCollection();
        aw.FetchForId(id);

        //Artwork Details
        string title = aw[0].Title;
        string imgFileName = aw[0].ImageFileName;
        int cost = aw[0].Msrp;

        //Component Details
        int mattID = Convert.ToInt32(mattList.SelectedItem.Value);
        int glassID = Convert.ToInt32(glassList.SelectedItem.Value);
        int frameID = Convert.ToInt32(frameList.SelectedItem.Value);

        //Create Cart Item
        CartItem cartItem = new CartItem(id, title, imgFileName, cost, mattID, glassID, frameID);

        //Loads the session
        List<CartItem> cartList = (List<CartItem>)Session["cart"];

        //The cart dosent exist
        if (cartList == null)
        {
            //Create a new cart
            cartList = new List<CartItem>();
            //Adds the item to the cart
            cartList.Add(cartItem);
            //Sets the cart to the session
            Session["cart"] = cartList;
        }
        //Cart does exist
        else
        {
            //Adds cart item to the cart
            cartList.Add(cartItem);
        }

        //Redirects to the single artwork page of the artwork added
        Response.Redirect("SingleArtwork.aspx?id=" + id);
    }
}
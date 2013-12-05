using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Content.Business;
using Content.DataAccess;
using System.Data;

/// <summary>
/// This is used as a cart item that contains all information it needs to display
/// in the cart. Calculations for the total cost of the item is done here
/// </summary>
public class CartItem
{
    private double _totalCost;

	private int _id;
    private string _title;
    private string _imageFileName;
    private double _cost;

    private int _mattID;
    private string _mattTitle;
    private string _mattColorCode;
    private double _mattPrice;

    private int _glassID;
    private string _glassTitle;
    private string _glassDescription;
    private double _glassPrice;

    private int _framesID;
    private string _framesTitle;
    private double _framesPrice;
    private string _framesColor;
    private string _framesSyle;



    public CartItem(int id, string title, string imageFileName, int cost, int mattID, int glassID, int framesID)
    {

        //Sets work information
        Id = id;
        Title = title;
        ImageFileName = imageFileName;
        PaintingCost = Convert.ToDouble(cost);

        //Sets matt information
        MattCollection mc = new MattCollection();
        MattID = mattID;
        mc.FetchForId(mattID);
        MattTitle = mc[0].Title;
        MattColorCode = mc[0].ColorCode;

        if(_mattTitle.Equals("[None]"))
            MattPrice = 0;
        else
            MattPrice = 25;

        //Sets glass information
        GlassCollection gc = new GlassCollection();
        GlassID = glassID;
        gc.FetchForId(glassID);
        GlassTitle = gc[0].Title;
        GlassDescription = gc[0].Description;
        GlassPrice = gc[0].Price;

        //Sets frame information
        FramesCollection fc = new FramesCollection();
        FramesID = framesID;
        fc.FetchForId(framesID);
        FramesTitle = fc[0].Title;
        FramesPrice = fc[0].Price;
        FramesColor = fc[0].Color;
        FramesSyle = fc[0].Syle;

        //Calculates the total cost of the item
        TotalCost = PaintingCost + FramesPrice + GlassPrice + MattPrice;
        
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }


    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string ImageFileName
    {
        get { return _imageFileName; }
        set { _imageFileName = value; }
    }

    public double PaintingCost
    {
        get { return _cost; }
        set 
        { 
            _cost = value;
            TotalCost = PaintingCost + FramesPrice + GlassPrice + MattPrice;
        }
    }

    public double TotalCost
    {
        get { return _totalCost; }
        set { _totalCost = value; }
    }

    public int MattID
    {
        get { return _mattID; }
        set { _mattID = value; }
    }

    public string MattTitle
    {
        get { return _mattTitle; }
        set { _mattTitle = value; }
    }

    public string MattColorCode
    {
        get { return _mattColorCode; }
        set { _mattColorCode = value; }
    }

    public double MattPrice
    {
        get { return _mattPrice; }
        set 
        { 
            _mattPrice = value;
            TotalCost = PaintingCost + FramesPrice + GlassPrice + MattPrice;
        }
    }

    public int GlassID
    {
        get { return _glassID; }
        set { _glassID = value; }
    }

    public string GlassTitle
    {
        get { return _glassTitle; }
        set { _glassTitle = value; }
    }

    public string GlassDescription
    {
        get { return _glassDescription; }
        set { _glassDescription = value; }
    }

    public double GlassPrice
    {
        get { return _glassPrice; }
        set 
        { 
            _glassPrice = value;
            TotalCost = PaintingCost + FramesPrice + GlassPrice + MattPrice;
        }
    }

    public int FramesID
    {
        get { return _framesID; }
        set { _framesID = value; }
    }

    public string FramesTitle
    {
        get { return _framesTitle; }
        set { _framesTitle = value; }
    }

    public double FramesPrice
    {
        get { return _framesPrice; }
        set 
        { 
            _framesPrice = value;
            TotalCost = PaintingCost + FramesPrice + GlassPrice + MattPrice;
        }
    }

    public string FramesColor
    {
        get { return _framesColor; }
        set { _framesColor = value; }
    }

    public string FramesSyle
    {
        get { return _framesSyle; }
        set { _framesSyle = value; }
    }


}
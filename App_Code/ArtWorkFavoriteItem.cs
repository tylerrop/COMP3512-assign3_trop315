using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This is used to create an artwork item that will be stored in the favorites list.
/// It will contain all information needed to display the artwork in the list
/// </summary>
public class ArtWorkFavoriteItem
{
    private int _id;
    private string _title;
    private string _imageFileName;

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
    public ArtWorkFavoriteItem(int id, string title, string imageFileName)
    {
        Id = id;
        Title = title;
        ImageFileName = imageFileName;
    }
}
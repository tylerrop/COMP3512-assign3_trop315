using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This is used to create an artist item that will be stored in the favorites list.
/// It will contain all information needed to display the artist in the list
/// </summary>
public class ArtistFavoriteItem
{
    private int _id;
    private string _firstName;
    private string _lastName;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
        
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public ArtistFavoriteItem(int id, string lastName, string firstName)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
    }
}

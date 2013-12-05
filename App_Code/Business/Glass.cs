using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{
/// <summary>
/// Summary description for Glass
/// </summary>
public class Glass : AbstractBusiness
{
	private string _title;
    private double _price;
    private string _description;

    private GlassDA _glassDA;

    /// <summary>
    /// Constructor
    /// </summary>
    public Glass()
    {
        _glassDA = new GlassDA();
        base.DataAccess = _glassDA;
    }

    #region override methods
    public override void PopulateDataMembersFromDataRow(DataRow row)
    {
        // set the data members to the data retrieved from the database table/query
        Id = (int)row["GlassID"];

        if (row["Title"] == DBNull.Value)
            Title = "";
        else
            Title = (string)row["Title"];

        if (row["Price"] == DBNull.Value)
            Price = 0;
        else
            Price = Convert.ToInt32(row["Price"]);

        if (row["Description"] == DBNull.Value)
            Description = "";
        else
            Description = (string)row["Description"];

        // since we are populating this object from data set its object variables
        IsNew = false;
        IsModified = false;
    }

    protected override void CheckIfSubClassStateIsValid()
    {
        //if (IsNew)
        //{
            // ensure this name doesn't already exist
            //DataTable dt = _genreDA.GetByName(LastName);
            //BusinessRules.Assert("LastNameExists", "Artist last name already exists", dt.Rows.Count > 0);
        //}
    }

    // not going to bother implementing these
    public override void Update()
    {
        //_artistDA.Update(Id, FirstName, LastName, ...);
    }
    public override void Insert()
    {
        //Id = _artistDA.Insert(FirstName, LastName,, ...);
    }
    public override void Delete()
    {
        //_artistDA.Delete(Id);
    }
    #endregion

    #region properties

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public double Price
    {
        get { return _price; }
        set { _price = value; }
            
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    #endregion

    #region methods
    /// <summary>
    /// Makes a clone (deep copy) of this object
    /// </summary>
    public Glass Clone()
    {
        Glass glass = new Glass();
        glass.Id = Id;
        glass.Title = Title;
        glass.Price = Price;
        glass.Description = Description;

        return glass;
    }

    #endregion
    }
}
using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;

namespace Content.Business
{
/// <summary>
/// Summary description for Gallery
/// </summary>
public class Gallery : AbstractBusiness 
{
        private string _galleryName;
        private string _galleryNativeName; 
        private string _galleryCity;
        private string _galleryCountry;
        private double _latitude;
        private double _longitude;
        private string _galleryWebSite;

        private GalleriesDA _galleriesDA;

        /// <summary>
        /// Constructor
        /// </summary>
        public Gallery()
        {
            _galleriesDA = new GalleriesDA();
            base.DataAccess = _galleriesDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["GalleryID"];

            if (row["GalleryName"] == DBNull.Value)
                GalleryName = "";
            else
                GalleryName = (string)row["GalleryName"];

            if (row["GalleryNativeName"] == DBNull.Value)
                GalleryNativeName = "";
            else
                GalleryNativeName = (string)row["GalleryNativeName"];

            if (row["GalleryCity"] == DBNull.Value)
                GalleryCity = "";
            else
                GalleryCity = (string)row["GalleryCity"];

            if (row["GalleryCountry"] == DBNull.Value)
                GalleryCountry = "";
            else
                GalleryCountry = (string)row["GalleryCountry"];

            if (row["Latitude"] == DBNull.Value)
                Latitude = 0;
            else
                Latitude = (double)row["Latitude"];

            if (row["Longitude"] == DBNull.Value)
                Longitude = 0;
            else
                Longitude = (double)row["Longitude"];

            if (row["GalleryWebSite"] == DBNull.Value)
                GalleryWebSite = "";
            else
                GalleryWebSite = (string)row["GalleryWebSite"];

            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }

        protected override void CheckIfSubClassStateIsValid()
        {

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

        public string GalleryName
        {
            get { return _galleryName; }
            set { _galleryName = value; }
        }
        public string GalleryNativeName
        {
            get { return _galleryNativeName; }
            set { _galleryNativeName = value; }
            
        }
        public string GalleryCity
        {
            get { return _galleryCity; }
            set { _galleryCity = value; }
        }
        public string GalleryCountry
        {
            get { return _galleryCountry; }
            set { _galleryCountry = value; }
        }
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        public string GalleryWebSite
        {
            get { return _galleryWebSite; }
            set { _galleryWebSite = value; }
        }

        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public Gallery Clone()
        {
            Gallery gallery = new Gallery();
            gallery.Id = Id;
            gallery.GalleryName = GalleryName;
            gallery.GalleryNativeName = GalleryNativeName;
            gallery.GalleryCity = GalleryCity;
            gallery.GalleryCountry = GalleryCountry;
            gallery.Latitude = Latitude;
            gallery.Longitude = Longitude;
            gallery.GalleryWebSite = GalleryWebSite;

            return gallery;
        }

        #endregion
	}
}

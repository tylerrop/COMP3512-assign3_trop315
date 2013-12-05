using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{

    /// <summary>
    /// Business object for Artist information
    /// </summary>
    public class ArtWork : AbstractBusiness
    {

        private string _title;
        private string _description;
        private int _yearOfWork;
        private string _ImageFileName;
        private int _width;
        private int _height;
        private string _medium;
        private string _originalHome;
        private int _cost;
        private int _msrp;
        private string _artWorkLink;
        private string _googleLink;
        private string _excerpt;
        private int _artWorkType;

        private Artist _theArtist = null;
        private GenresCollection _genres;
        private GalleryCollection _gallery;
        private SubjectsCollection _subjects;

        private ArtWorkDA _artworkDA;

        public ArtWork()
        {
            _artworkDA = new ArtWorkDA();
            base.DataAccess = _artworkDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["ArtWorkID"];

            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["Title"];

            if (row["Description"] == DBNull.Value)
                Description = "";
            else
                Description = (string)row["Description"];

            YearOfWork = Convert.ToInt32(row["YearOfWork"]);

            if (row["ImageFileName"] == DBNull.Value)
                ImageFileName = "";
            else
                ImageFileName = (string)row["ImageFileName"];


            if (row["Width"] == DBNull.Value)
                Width = 0;
            else
                Width = Convert.ToInt32(row["Width"]);

             if (row["Height"] == DBNull.Value)
                Height = 0;
            else
                Height = Convert.ToInt32(row["Height"]);

             if (row["Medium"] == DBNull.Value)
                Medium = "";
            else
                Medium = (string)row["Medium"];

             if (row["OriginalHome"] == DBNull.Value)
                OriginalHome = "";
            else
                OriginalHome = (string)row["OriginalHome"];

             if (row["Cost"] == DBNull.Value)
                Cost = 0;
            else
                Cost = Convert.ToInt32(row["Cost"]);

             if (row["MSRP"] == DBNull.Value)
                Msrp = 0;
            else
                Msrp = Convert.ToInt32(row["MSRP"]);

            if (row["ArtWorkLink"] == DBNull.Value)
                ArtWorkLink = "";
            else
                ArtWorkLink = (string)row["ArtWorkLink"];

            if (row["GoogleLink"] == DBNull.Value)
                GoogleLink = "";
            else
                GoogleLink = (string)row["GoogleLink"];

            if (row["Excerpt"] == DBNull.Value)
            Excerpt = "";
            else
            Excerpt = (string)row["Excerpt"];

            if (row["ArtWorkType"] == DBNull.Value)
                ArtWorkType = 0;
            else
                ArtWorkType = Convert.ToInt32(row["ArtWorkType"]);

            
            // construct the artist
            _theArtist = new Artist();
            int artistId = Convert.ToInt32(row["TheArtistID"]);
            _theArtist.Id = artistId;

            if (row["TheArtistFirstName"] == DBNull.Value)
                _theArtist.FirstName = "";
            else
                _theArtist.FirstName = (string)row["TheArtistFirstName"];

            if (row["TheArtistLastName"] == DBNull.Value)
                _theArtist.LastName = "";
            else
                _theArtist.LastName = (string)row["TheArtistLastName"];

            // etc the other ArtWork data


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

        public string Title
        {
            get { return _title; }
            set {
                if (_title != value)
                {
                    // just to show one example of how the business rules might work for the setters
                    _title = value;
                    BusinessRules.Assert("ArtWorkTitleEmpty", "Title cannot be empty", Title.Length == 0);
                    IsModified = true;
                }
            }
        }

        public string GoogleLink
        {
            get { return _googleLink; }
            set { _googleLink = value; }
        }

        public string ArtWorkLink
        {
            get { return _artWorkLink; }
            set { _artWorkLink = value; }
        }

        public int Msrp
        {
            get { return _msrp; }
            set { _msrp = value; }
        }

        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public string OriginalHome
        {
            get { return _originalHome; }
            set { _originalHome = value; }
        }

        public string Medium
        {
            get { return _medium; }
            set { _medium = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int YearOfWork
        {
            get { return _yearOfWork; }
            set { _yearOfWork = value; }
        }

        public string ImageFileName
        {
            get { return _ImageFileName; }
            set { _ImageFileName = value; }
        }

        public string Excerpt
        {
            get { return _excerpt; }
            set { _excerpt = value; }
        }

        public int ArtWorkType
        {
            get { return _artWorkType; }
            set { _artWorkType = value; }
        }

        public Artist TheArtist
        {
            get { return _theArtist; }
        }
        public int TheArtistId
        {
            get { return _theArtist.Id; }
        }
        public string ArtistFirstName
        {
            get { return _theArtist.FirstName; }
        }
        public string ArtistLastName
        {
            get { return _theArtist.LastName; }
        }

        public string AvgReview
        {
            get
            {
                //Get Average
                ReviewDA _reviewDA = new ReviewDA();
                string avg;

                DataTable dt = _reviewDA.getAverage(Id);

                if (dt != null)
                    avg = dt.Rows[0]["Average"].ToString();
                else
                    avg = "No Rating";

                return avg;
            }
        }

        public GalleryCollection Gallery
        {
            get
            {
                // if our collection is null, then we need to fill it
                if (_gallery == null)
                {
                    _gallery = new GalleryCollection();
                    _gallery.FetchForArtWork(Id);
                }
                return _gallery;
            }
        }

        public GenresCollection Genres
        {
            get
            {
                // if our collection is null, then we need to fill it
                if (_genres == null)
                {
                    _genres = new GenresCollection();
                    _genres.FetchForArtWork(Id);
                }
                return _genres;
            }
            
        }
        public SubjectsCollection Subjects
        {
            get
            {
                // if our collection is null, then we need to fill it
                if (_subjects == null)
                {
                    _subjects = new SubjectsCollection();
                    _subjects.FetchForArtWork(Id);
                }
                return _subjects;
            }
        }

        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public ArtWork Clone()
        {
            ArtWork aw = new ArtWork();
            aw.Id = Id;
            aw.Title = Title;
            aw.Description = Description;
            aw.YearOfWork = YearOfWork;
            //etc
            return aw;
        }
        #endregion
    }
}
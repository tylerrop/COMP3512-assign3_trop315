using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{

    /// <summary>
    /// Business object for Artist information
    /// </summary>
    public class Artist : AbstractBusiness
    {
        private string _firstName;
        private string _lastName;
        private string _nationality;
        private string _details;
        private int _yearOfDeath;
        private string _artistLink;
        private int _yearOfBirth;
        private ArtWorkCollection _works;   
        private ArtistDA _artistDA;

        /// <summary>
        /// Constructor
        /// </summary>
        public Artist()
        {
            _artistDA = new ArtistDA();
            base.DataAccess = _artistDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["ArtistID"];

            if (row["FirstName"] == DBNull.Value)
                FirstName = "";
            else
                FirstName = (string)row["FirstName"];

            if (row["LastName"] == DBNull.Value)
                LastName = "";
            else
                LastName = (string)row["LastName"];

            YearOfBirth = Convert.ToInt32(row["YearOfBirth"]);
            YearOfDeath = Convert.ToInt32(row["YearOfDeath"]);

            if (row["Nationality"] == DBNull.Value)
                Nationality = "";
            else
                Nationality = (string)row["Nationality"];

            if (row["Details"] == DBNull.Value)
                Details = "";
            else
                Details = (string)row["Details"];

            if (row["ArtistLink"] == DBNull.Value)
                ArtistLink = "";
            else
                ArtistLink = (string)row["ArtistLink"];


            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }

        protected override void CheckIfSubClassStateIsValid()
        {
            if (IsNew)
            {
                // ensure this name doesn't already exist
                DataTable dt = _artistDA.GetByName(LastName);
                BusinessRules.Assert("LastNameExists", "Artist last name already exists", dt.Rows.Count > 0);
            }
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

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set {
                if (_lastName != value)
                {
                    // just to show one example of how the business rules might work for the setters
                    _lastName = value;
                    BusinessRules.Assert("ArtistLastNameEmpty", "Artist name cannot be empty", LastName.Length == 0);
                    IsModified = true;
                } 
            }
        }
        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set { _yearOfBirth = value; }
        }
        public int YearOfDeath
        {
            get { return _yearOfDeath; }
            set { _yearOfDeath = value; }
        }
        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }
        public string ArtistLink
        {
            get { return _artistLink; }
            set { _artistLink = value; }
        }
        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
        public ArtWorkCollection Works
        {
            get { 
                if (_works == null)
                {
                    _works = new ArtWorkCollection();
                    _works.FetchForArtist(Id);
                }
                return _works; 
            }
        }

        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public Artist Clone()
        {
            Artist artist = new Artist();
            artist.Id = Id;
            artist.FirstName = FirstName;
            artist.LastName = LastName;
            artist.Nationality = Nationality;
            artist.YearOfBirth = YearOfBirth;
            artist.YearOfDeath = YearOfDeath;
            artist.Details = Details;
            artist.ArtistLink = ArtistLink;
            foreach (ArtWork w in artist.Works)
            {
                artist.AddArtWork(w.Clone());
            }
            return artist;
        }

        /// <summary>
        /// Adds an artwork to the artist's collection
        /// </summary>
        public void AddArtWork(ArtWork work)
        {
            _works.Add(work);
        }
        #endregion
    }
}
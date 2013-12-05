using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{
/// <summary>
/// Summary description for Genres
/// </summary>
public class Genres : AbstractBusiness
{
		private string _genreName;
        private int _era;
        private string _description;
        private string _link; 
        private GenresDA _genreDA;

        /// <summary>
        /// Constructor
        /// </summary>
        public Genres()
        {
            _genreDA = new GenresDA();
            base.DataAccess = _genreDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["GenreID"];

            if (row["GenreName"] == DBNull.Value)
                GenreName = "";
            else
                GenreName = (string)row["GenreName"];

            if (row["Era"] == DBNull.Value)
                Era = 0;
            else
                Era = Convert.ToInt32(row["Era"]);

            if (row["Description"] == DBNull.Value)
                Description = "";
            else
                Description = (string)row["Description"];

            if (row["Link"] == DBNull.Value)
                Link = "";
            else
                Link = (string)row["Link"];

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

        public string GenreName
        {
            get { return _genreName; }
            set { _genreName = value; }
        }
        public int Era
        {
            get { return _era; }
            set { _era = value; }
            
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public Genres Clone()
        {
            Genres genres = new Genres();
            genres.Id = Id;
            genres.GenreName = GenreName;
            genres.Era = Era;
            genres.Link = Link;
            genres.Description = Description;

            return genres;
        }

        #endregion
	}
}

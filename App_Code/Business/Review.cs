using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for Review
    /// </summary>
    public class Review : AbstractBusiness
    {
        private int _artWorkId;
        private string _reviewer; 
        private DateTime _reviewDate;
        private int _rating;
        private string _comment;
        private string _title;
        private string _imageFileName;

        private ReviewDA _reviewDA;

        /// <summary>
        /// Constructor
        /// </summary>
        public Review()
        {
            _reviewDA = new ReviewDA();
            base.DataAccess = _reviewDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["ReviewId"];

            if (row["ArtWorkId"] == DBNull.Value)
                ArtWorkId = 0;
            else
                ArtWorkId = Convert.ToInt32(row["ArtWorkId"]);

            if (row["Reviewer"] == DBNull.Value)
                Reviewer = "";
            else
                Reviewer = (string)row["Reviewer"];

            if (row["ReviewDate"] == DBNull.Value)
                ReviewDate = new DateTime();
            else
                ReviewDate = Convert.ToDateTime(row["ReviewDate"]);

            if (row["Rating"] == DBNull.Value)
                Rating = 0;
            else
                Rating = Convert.ToInt32(row["Rating"]);

            if (row["Comment"] == DBNull.Value)
                Comment = "";
            else
                Comment = (string)row["Comment"];

            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["Title"];

            if (row["ImageFileName"] == DBNull.Value)
                ImageFileName = "";
            else
                ImageFileName = (string)row["ImageFileName"];

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

        public int ArtWorkId
        {
            get { return _artWorkId; }
            set { _artWorkId = value; }
        }
        public string Reviewer
        {
            get { return _reviewer; }
            set { _reviewer = value; }
        }
        public DateTime ReviewDate
        {
            get { return _reviewDate; }
            set { _reviewDate = value; }
        }
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
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

        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public Review Clone()
        {
            Review review = new Review();
            review.ArtWorkId = Id;
            review.Comment = Comment;
            review.Reviewer = Reviewer;
            review.Rating = Rating;
            review.ReviewDate = ReviewDate;

            return review;
        }

        #endregion
    }
}
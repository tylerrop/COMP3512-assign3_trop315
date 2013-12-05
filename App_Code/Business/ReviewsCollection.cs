using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Web;

using System;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for ReviewsCollection
    /// </summary>
    public class ReviewsCollection : AbstractBusinessCollection<Review>
    {
        private ReviewDA _reviewDA = new ReviewDA();

        public ReviewsCollection() 
        {

        }

        #region properties

        #endregion

        #region methods
        /// <summary>
        /// Fetch the matt data
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _reviewDA.GetAllSorted(true);
            // population this collection from this data table
            populateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the review with a given id. This should normally create a collection
        /// with either 0 or 1 matt
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _reviewDA.GetById(id);
            populateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch a select amount of Reviews from the top of the table
        /// </summary>
        public void FetchTop(int number)
        {
            DataTable dt = _reviewDA.GetTop(number, true);
            populateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch the reviews of a specific work
        /// </summary>
        public void FetchByArtWork(int artworkId)
        {
            DataTable dt = _reviewDA.getByArtWork(artworkId);
            populateFromDataTable(dt);
        }

        /// <summary>
        /// Add a review from the taken in parameters
        /// </summary>
        public void addReview(int artWorkId, string reviewer, DateTime reviewDate, int rating, string comment)
        {
            _reviewDA.insertReview(artWorkId, reviewer, reviewDate, rating, comment);
        }

        /// <summary>
        /// Remove a Review using the reviewID
        /// </summary>
        public void removeReview(int reviewID)
        {
            _reviewDA.deleteReview(reviewID);
        }

        private void populateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Review a = new Review();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static ReviewsCollection GetAll()
        {
            ReviewsCollection list = new ReviewsCollection();

            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        public ReviewsCollection Clone()
        {
            ReviewsCollection clone = new ReviewsCollection();
            foreach (Review a in this)
            {
                clone.Add(a.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}
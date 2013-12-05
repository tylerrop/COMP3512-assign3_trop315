using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
/// <summary>
/// Summary description for ReviewDA
/// </summary>
    public class ReviewDA : AbstractDA
    {
        private const string fields = "ArtWorkReviews.ReviewId, "
                                    + "ArtWorkReviews.ArtWorkId, "
                                    + "ArtWorkReviews.Reviewer, "
                                    + "ArtWorkReviews.ReviewDate, "
                                    + "ArtWorkReviews.Rating, "
                                    + "ArtWorkReviews.Comment, "
                                    + "ArtWorks.Title, "
                                    + "ArtWorks.ImageFileName ";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM ArtWorkReviews";
                sql += " INNER JOIN ArtWorks ON ArtWorks.ArtWorkID = ArtWorkReviews.ArtWorkId";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "ArtWorkReviews.ReviewDate";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "ArtWorkReviews.ReviewId";
            }
        }

        /// <summary>
        /// Returns a table of the reviews of a specific artwork
        /// </summary>
        public DataTable getByArtWork(int artWorkId)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE ArtWorkReviews.ArtWorkId=@artWorkId";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@artWorkId", artWorkId, DbType.Int32)
            };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns the average rating of a specific painting
        /// </summary>
        public DataTable getAverage(int artWorkId)
        {
            // set up parameterized query statement
            string sql = "SELECT AVG(Rating) AS Average FROM ArtWorkReviews WHERE ArtWorkId=@artWorkId";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@artWorkId", artWorkId, DbType.Int32)
            };
            // return result
            return DataHelper.GetDataTable(sql, parameters);

        }

        /// <summary>
        /// Adds a review to the table using the values in the parameters
        /// </summary>
        public void insertReview(int artWorkId, string reviewer, DateTime reviewDate, int rating, string comment)
        {
            //Gets unique review ID
            int reviewId = getUniqueReviewID();

            // set up insert statement
            string sql = "INSERT INTO ArtWorkReviews (ReviewId, ArtWorkId, Reviewer, ReviewDate, Rating, Comment) "
                       + "VALUES (@reviewId, @artWorkId, @reviewer, @reviewDate, @rating, @comment)";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			    DataHelper.MakeParameter("@reviewId", reviewId),
                DataHelper.MakeParameter("@artWorkId", artWorkId),
                DataHelper.MakeParameter("@reviewer", reviewer),
                DataHelper.MakeParameter("@reviewDate", reviewDate, DbType.Date),
                DataHelper.MakeParameter("@rating", rating),
                DataHelper.MakeParameter("@comment", comment)
			};

            // Add to Table
            DataHelper.RunNonQuery(sql, parameters);
        }

        /// <summary>
        /// Removes a review to the table using the Review ID
        /// </summary>
        public void deleteReview(int reviewId)
        {

            // set up parameterized query statement
            string sql = "DELETE FROM ArtWorkReviews WHERE ReviewId=@reviewId";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			    DataHelper.MakeParameter("@reviewId", reviewId)
			};

            // Add to Table
            DataHelper.RunNonQuery(sql, parameters);
        }

        /// <summary>
        /// Finds a unique ID in the database
        /// </summary>
        public int getUniqueReviewID()
        {
            // Finds the max review ID
            string sql = "SELECT MAX(ReviewId) AS id FROM ArtWorkReviews";

            DataTable dt = DataHelper.GetDataTable(sql, null);

            // Returns the max ID plus 1
            return Convert.ToInt32(dt.Rows[0]["id"]) + 1;

        }
    }
}

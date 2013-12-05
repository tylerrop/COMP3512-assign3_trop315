using System;
using System.Data;
using System.Data.Common;


namespace Content.DataAccess
{
    /// <summary>
    /// Data Access Object for the ArtWorks table
    /// </summary>
    public class ArtWorkDA : AbstractDA
    {
        private const string fields = "ArtWorks.ArtWorkID, ArtWorks.ArtistID As TheArtistID, ArtWorks.Title, "
                                        + "Artists.LastName As TheArtistLastName, Artists.FirstName As TheArtistFirstName, ArtWorks.Description, "
                                        + "ArtWorks.YearOfWork, ArtWorks.Width, ArtWorks.Height, ArtWorks.Medium, "
                                        + "ArtWorks.OriginalHome, ArtWorks.Cost, ArtWorks.MSRP, ArtWorks.ImageFileName, "
                                        + "ArtWorks.ArtWorkLink, ArtWorks.GoogleLink, ArtWorks.Excerpt, ArtWorks.ArtWorkType";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM ArtWorks";
                sql += " INNER JOIN Artists ON ArtWorks.ArtistID = Artists.ArtistID";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "ArtWorks.Title";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "ArtWorks.ArtWorkID";
            }
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for this exact title.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetLikeTitle(string title, string orderBy, string orderType)
        {
            //Handles invalid order information by setting it to a default value
            if (orderBy == null || !orderBy.Equals("Title") && !orderBy.Equals("YearOfWork") && !orderBy.Equals("MSRP"))
                orderBy = "Title";

            //Handles invalid order information by setting it to a default value
            if (orderType == null || !orderType.Equals("ASC") && !orderType.Equals("DESC"))
                orderType = "ASC";

            // set up parameterized query statement
            string sql = SelectStatement + " WHERE Title LIKE @title";

            sql += " ORDER BY " + orderBy + " " + orderType;

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@title", "%" + title + "%", DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for artworks of a specific genre. Parameters are taken to handle ordering
        /// </summary>
        public DataTable GetByGenre(int genreID, string orderBy, string orderType)
        {
            //Handles invalid order information by setting it to a default value
            if (orderBy == null || !orderBy.Equals("Title") && !orderBy.Equals("YearOfWork") && !orderBy.Equals("MSRP"))
                orderBy = "Title";

            //Handles invalid order information by setting it to a default value
            if (orderType == null || !orderType.Equals("ASC") && !orderType.Equals("DESC"))
                orderType = "ASC";

            string sql = SelectStatement.Replace("FROM", "FROM Genres, ArtWorkGenres,");

            sql += " WHERE ArtWorks.ArtWorkID=ArtWorkGenres.ArtWorkID "
                                + "AND Genres.GenreID=ArtWorkGenres.GenreID "
                                + "AND Genres.GenreID=@id";

            sql += " ORDER BY " + orderBy + " " + orderType;

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", genreID, DbType.Int32)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for a specific subject
        /// </summary>
        public DataTable GetBySubject(int subjectID, string orderBy, string orderType)
        {
            //Handles invalid order information by setting it to a default value
            if (orderBy == null || !orderBy.Equals("Title") && !orderBy.Equals("YearOfWork") && !orderBy.Equals("MSRP"))
                orderBy = "Title";

            //Handles invalid order information by setting it to a default value
            if (orderType == null || !orderType.Equals("ASC") && !orderType.Equals("DESC"))
                orderType = "ASC";

            string sql = SelectStatement.Replace("FROM", "FROM Subjects, ArtWorkSubjects,");

            sql += " WHERE ArtWorks.ArtWorkID=ArtWorkSubjects.ArtWorkID "
                                + "AND Subjects.SubjectID=ArtWorkSubjects.SubjectID "
                                + "AND Subjects.SubjectID=@id";

            sql += " ORDER BY " + orderBy + " " + orderType;

            //set up parameterized query statement

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", subjectID, DbType.Int32)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for the specified artist.
        /// Note that this data set will contain either 0,1, or N rows of data.
        /// </summary>
        public DataTable GetByArtist(int artistId)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE ArtWorks.ArtistID=@artistid";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@artistid", artistId, DbType.Int32)
            };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info based on advanced parameters and order parameters
        /// </summary>
        public DataTable GetLikeAdvanced(string title, int yearStart, int yearEnd, double costStart, double costEnd, string orderBy, string orderType)
        {
            //Handles invalid order information by setting it to a default value
            if (orderBy == null || !orderBy.Equals("Title") && !orderBy.Equals("YearOfWork") && !orderBy.Equals("MSRP") )
                orderBy = "Title";

            //Handles invalid order information by setting it to a default value
            if (orderType == null || !orderType.Equals("ASC") && !orderType.Equals("DESC"))
                orderType = "ASC";

            // set up parameterized query statement
            string sql = SelectStatement + " WHERE ArtWorks.Title LIKE @title "
                                                + "AND (ArtWorks.YearOfWork >= @yearStart AND ArtWorks.YearOfWork <= @yearEnd) "
                                                + "AND (ArtWorks.Cost >= @costStart AND ArtWorks.Cost <= @costEnd)";
            sql += " ORDER BY " + orderBy + " " + orderType;


            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {

			   DataHelper.MakeParameter("@title", "%" + title + "%"),
			   DataHelper.MakeParameter("@yearStart", yearStart),
			   DataHelper.MakeParameter("@yearEnd", yearEnd),
			   DataHelper.MakeParameter("@costStart", costStart),
			   DataHelper.MakeParameter("@costEnd", costEnd)

			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for artwork related by genres and subjects
        /// </summary>
        public DataTable GetRelated(int artWorkID)
        {
            string sql = SelectStatement.Replace("FROM", "FROM ArtWorkGenres, Genres, ArtWorkSubjects, Subjects,");

            sql += " WHERE ArtWorks.ArtWorkID=ArtWorkGenres.ArtWorkID "
                    + "AND ArtWorkGenres.GenreID=Genres.GenreID "

                    + "AND ArtWorks.ArtWorkID=ArtWorkSubjects.ArtWorkID "
                    + "AND ArtWorkSubjects.SubjectID=Subjects.SubjectID "

                    + "AND ArtWorks.ArtWorkID <> @id "

                    + "AND ((Subjects.SubjectID in (SELECT ArtWorkSubjects.SubjectID FROM ArtWorkSubjects WHERE ArtWorkSubjects.ArtWorkID=@id))  "
                    + "OR (Genres.GenreID in (SELECT ArtWorkGenres.GenreID FROM ArtWorkGenres WHERE ArtWorkGenres.ArtWorkID=@id))) ";

            sql = sql.Replace("SELECT", "SELECT TOP " + 10);

            DbParameter[] parameters = new DbParameter[] {

			   DataHelper.MakeParameter("@id", artWorkID)

			};

            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for artwork that has been purchased by the same user
        /// </summary>
        public DataTable GetRelatedPurchases(int artWorkID, int num)
        {

            string sql = SelectStatement.Replace("SELECT", "SELECT TOP " + num);

            sql = sql.Replace("FROM ArtWorks", "FROM ((ArtWorks INNER JOIN OrderDetails ON ArtWorks.ArtWorkID = OrderDetails.ArtWorkID) INNER JOIN Orders ON OrderDetails.OrderID = Orders.OrderID)");

            sql += " WHERE ArtWorks.ArtWorkID=OrderDetails.ArtWorkID "
                    + "AND Orders.OrderID=OrderDetails.OrderID "
                    + "AND ArtWorks.ArtWorkID <> @id "
                    + "AND Orders.CustomerID "
                        + "IN (SELECT Orders.CustomerID FROM Orders, ArtWorks, OrderDetails "
                            + "WHERE OrderDetails.OrderID=Orders.OrderID AND ArtWorks.ArtWorkID=OrderDetails.ArtWorkID AND ArtWorks.ArtWorkID=@id)";

            DbParameter[] parameters = new DbParameter[] {

			   DataHelper.MakeParameter("@id", artWorkID)

			};
            
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for artwork that has sold the most
        /// </summary>
        public DataTable GetTopSellers(int num)
        {

            string sql = SelectStatement.Replace("SELECT", "SELECT TOP " + num);

            sql = sql.Replace("FROM", "FROM OrderDetails,");
            sql += " WHERE ArtWorks.ArtWorkID = OrderDetails.ArtWorkID";

            sql += " GROUP BY ArtWorks.ArtWorkID, ArtWorks.Title, ArtWorks.Description, ArtWorks.YearOfWork, "
                    + "ArtWorks.Width, ArtWorks.Height, ArtWorks.Medium, ArtWorks.OriginalHome, ArtWorks.Cost, "
                    + "ArtWorks.MSRP, ArtWorks.ImageFileName, ArtWorks.ArtWorkLink, ArtWorks.GoogleLink, "
                    + "ArtWorks.Excerpt, ArtWorks.ArtWorkType, ArtWorks.ArtistID, Artists.LastName, Artists.FirstName ";

            sql += "ORDER BY COUNT(OrderDetails.ArtWorkID) DESC";
             

            return DataHelper.GetDataTable(sql, null);
        }
    }
}
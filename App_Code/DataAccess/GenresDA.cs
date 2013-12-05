using System;
using System.Data;
using System.Data.Common;


namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for GenresDA
    /// </summary>
    public class GenresDA : AbstractDA
    {
        private const string fields = "Genres.GenreID, GenreName, Era, Genres.Description, Link";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM Genres";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "GenreName";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "GenreID";
            }
        }

        /// <summary>
        /// Returns a data table containing Genre table info for this exact genre name.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForGenreName(string name)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE GenreName=@name";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@name", name, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing Genre table info for a specific artwork
        /// </summary>
        public DataTable GetByArtWork(int artWorkID)
        {
            // set up parameterized query statement
            string sql = SelectStatement + ", ArtWorkGenres, ArtWorks "
                           + "WHERE ArtWorkGenres.GenreID = Genres.GenreID "
                           + "AND ArtWorks.ArtWorkID = ArtWorkGenres.ArtWorkID "
                           + "AND ArtWorks.ArtWorkID=@artWorkID "
                           + " GROUP BY " + fields + " ORDER BY " + OrderFields + " ASC";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@artWorkID", artWorkID, DbType.Int32)
            };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing Genre table info containing a list of all unique genres
        /// </summary>
        public DataTable GetGroupedByGenres()
        {
            // set up parameterized query statement
            string sql = SelectStatement + " GROUP BY " + fields + " ORDER BY " + OrderFields + " ASC";
            // return result
            return DataHelper.GetDataTable(sql, null);
        }
    }
}
using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for ArtistDA
    /// </summary>
    /// 

    public class ArtistDA : AbstractDA
    {
        private const string fields = "Artists.FirstName,Artists.LastName,Artists.Nationality,Artists.YearOfBirth,Artists.YearOfDeath,Artists.Details,Artists.ArtistLink";


        protected override string SelectStatement
        {
            get
            {
                return "SELECT " + KeyFieldName + "," + fields + " FROM Artists";
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "Artists.LastName";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "Artists.ArtistID";
            }
        }

        /// <summary>
        /// Returns a data table containing Artist table info for this exact name.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetByName(string name)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE LastName=@name";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@name", name, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing Artist table info that is similar to this title. Parameters are taken to handle ordering
        /// </summary>
        public DataTable GetLikeName(string name, string orderBy, string orderType)
        {
            //Defaults to order by lastname
            orderBy = "LastName";

            //Handles invalid order information by setting it to a default value
            if (orderType == null || !orderType.Equals("ASC") || !orderType.Equals("DESC"))
                orderType = "ASC";


            // set up parameterized query statement
            string sql = SelectStatement + " WHERE (LastName LIKE @name) "
                                                + "OR (FirstName LIKE @name) "
                                                + "OR ((FirstName + ' ' + LastName) LIKE @name) "
                                                + "OR ((LastName + ' ' + FirstName) LIKE @name) ";

            sql += " ORDER BY " + orderBy + " " + orderType;

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@name", "%" + name + "%", DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing Artist table info that contains all artists with the same Nationality/YearOfBirth
        /// </summary>
        public DataTable GetRelated(int artistID)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE (Artists.Nationality = (SELECT Nationality FROM Artists WHERE Artists.ArtistID=@artistID) AND Artists.ArtistID <> @artistID) "
                                                + "OR (Artists.YearOfBirth = (SELECT YearOfBirth FROM Artists WHERE Artists.ArtistID=@artistID) AND Artists.ArtistID <> @artistID)";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@artistID", artistID, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing Artist table info that contains the top artists based on sales
        /// </summary>
        public DataTable GetTopSellers(int num)
        {
            string sql = SelectStatement.Replace("SELECT", "SELECT TOP " + num);
            sql += ", ArtWorks, OrderDetails WHERE ArtWorks.ArtistID = Artists.ArtistID "
                                                + "AND OrderDetails.ArtWorkID = ArtWorks.ArtWorkID "
                                                + "GROUP BY Artists.ArtistID,Artists.FirstName,Artists.LastName,Artists.Nationality,Artists.YearOfBirth,Artists.YearOfDeath,Artists.Details,Artists.ArtistLink "
                                                + "ORDER BY COUNT(OrderDetails.ArtWorkID) DESC";

            return DataHelper.GetDataTable(sql, null);
        }
    }
}
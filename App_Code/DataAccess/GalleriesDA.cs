using System;
using System.Data;
using System.Data.Common;


namespace Content.DataAccess
{

    /// <summary>
    /// Summary description for GalleriesDA
    /// </summary>
    public class GalleriesDA : AbstractDA
    {
        private const string fields = "Galleries.GalleryID, Galleries.GalleryName, Galleries.GalleryNativeName, "
                                        + "Galleries.GalleryCity, Galleries.GalleryCountry, Galleries.Latitude, "
                                        + "Galleries.Longitude, Galleries.GalleryWebSite";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM Galleries";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "Galleries.GalleryName";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "Galleries.GalleryID";
            }
        }

        /// <summary>
        /// Returns a data table containing Gallery table info for this exact Gallery name.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForSubjectName(string name)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE SubjectName=@name";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@name", name, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing Gallery table info for galleries of a specific artwork
        /// </summary>
        public DataTable GetByArtWork(int artWorkID)
        {
            // set up parameterized query statement
            string sql = SelectStatement + ", ArtWorks "
                           + "WHERE ArtWorks.GalleryID = Galleries.GalleryID "
                           + "AND ArtWorks.ArtWorkID=@artWorkID "
                           + " GROUP BY " + fields + " ORDER BY " + OrderFields + " ASC";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@artWorkID", artWorkID, DbType.Int32)
            };

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
    }
}
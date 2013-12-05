using System;
using System.Data;
using System.Data.Common;


namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for GlassDA
    /// </summary>
    public class GlassDA : AbstractDA
    {
        private const string fields = "TypesGlass.GlassID, TypesGlass.Title, TypesGlass.Description, TypesGlass.Price";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM TypesGlass";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "TypesGlass.Title";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "TypesGlass.GlassID";
            }
        }

        /// <summary>
        /// Returns a data table containing glass table info for this exact glass Title.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForGlassName(string name)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE Title=@name";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@name", name, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
    }
}
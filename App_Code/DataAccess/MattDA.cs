using System;
using System.Data;
using System.Data.Common;


namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for MattDA
    /// </summary>
    public class MattDA : AbstractDA
    {
        private const string fields = "TypesMatt.MattID, TypesMatt.Title, TypesMatt.ColorCode";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM TypesMatt";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "TypesMatt.Title";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "TypesMatt.MattID";
            }
        }

        /// <summary>
        /// Returns a data table containing Matt table info for this exact matt Title.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForMattName(string name)
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
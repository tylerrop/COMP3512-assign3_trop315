using System;
using System.Data;
using System.Data.Common;


namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for FramesDA
    /// </summary>
    public class FramesDA : AbstractDA
    {
        private const string fields = "TypesFrames.FrameID, TypesFrames.Title, TypesFrames.Price, TypesFrames.Color, TypesFrames.Syle";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM TypesFrames";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "TypesFrames.Title";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "TypesFrames.FrameID";
            }
        }

        /// <summary>
        /// Returns a data table containing Frame table info for this exact glass Title.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForFrameName(string name)
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
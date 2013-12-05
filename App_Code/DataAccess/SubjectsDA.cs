using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for SubjectsDA
    /// </summary>
    public class SubjectsDA : AbstractDA
    {
        private const string fields = "Subjects.SubjectID, Subjects.SubjectName";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM Subjects";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "Subjects.SubjectName";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "Subjects.SubjectID";
            }
        }

        /// <summary>
        /// Returns a data table containing Subjects table info for this exact subject name.
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
        /// Returns a data table containing Subjects table info for a specific artwork
        /// </summary>
        public DataTable GetByArtWork(int artWorkID)
        {
            // set up parameterized query statement
            string sql = SelectStatement + ", ArtWorkSubjects, ArtWorks "
                           + "WHERE ArtWorkSubjects.SubjectID = Subjects.SubjectID "
                           + "AND ArtWorks.ArtWorkID = ArtWorkSubjects.ArtWorkID "
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
        /// Returns a data table containing Subjects table info for tall unique subjects
        /// </summary>
        public DataTable GetGroupedBySubjects()
        {
            // set up parameterized query statement
            string sql = SelectStatement + " GROUP BY " + fields + " ORDER BY " + OrderFields + " ASC";
            // return result
            return DataHelper.GetDataTable(sql, null);
        }
    }
}
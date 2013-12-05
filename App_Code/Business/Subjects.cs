using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Summary description for Subjects
    /// </summary>
    public class Subjects : AbstractBusiness
    {
		private string _subjectName;

        private SubjectsDA _subjectsDA;

        /// <summary>
        /// Constructor
        /// </summary>
        public Subjects()
        {
            _subjectsDA = new SubjectsDA();
            base.DataAccess = _subjectsDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["SubjectID"];

            if (row["SubjectName"] == DBNull.Value)
                SubjectName = "";
            else
                SubjectName = (string)row["SubjectName"];

            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }

        protected override void CheckIfSubClassStateIsValid()
        {
            //if (IsNew)
            //{
                // ensure this name doesn't already exist
                //DataTable dt = _genreDA.GetByName(LastName);
                //BusinessRules.Assert("LastNameExists", "Artist last name already exists", dt.Rows.Count > 0);
            //}
        }

        // not going to bother implementing these
        public override void Update()
        {
            //_artistDA.Update(Id, FirstName, LastName, ...);
        }
        public override void Insert()
        {
            //Id = _artistDA.Insert(FirstName, LastName,, ...);
        }
        public override void Delete()
        {
            //_artistDA.Delete(Id);
        }
        #endregion

        #region properties

        public string SubjectName
        {
            get { return _subjectName; }
            set { _subjectName = value; }
        }

        #endregion

        #region methods

        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public Subjects Clone()
        {
            Subjects subjects = new Subjects();
            subjects.Id = Id;
            subjects.SubjectName = SubjectName;

            return subjects;
        }

        #endregion
    }
}
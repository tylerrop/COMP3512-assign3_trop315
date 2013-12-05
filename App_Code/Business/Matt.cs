using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Summary description for Matt
    /// </summary>
    public class Matt : AbstractBusiness
    {
        private string _title;
        private string _colorCode;

        private MattDA _mattDA;

        /// <summary>
        /// Constructor
        /// </summary>
        public Matt()
        {
            _mattDA = new MattDA();
            base.DataAccess = _mattDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["MattID"];

            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["Title"];

            if (row["ColorCode"] == DBNull.Value)
                ColorCode = "";
            else
                ColorCode = (string)row["ColorCode"];

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

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public Matt Clone()
        {
            Matt matt = new Matt();
            matt.Id = Id;
            matt.Title = Title;
            matt.ColorCode = ColorCode;

            return matt;
        }

        #endregion
    }
}
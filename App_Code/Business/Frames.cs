using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Summary description for Frames
    /// </summary>
    public class Frames : AbstractBusiness
    {
        private string _title;
        private double _price;
        private string _color;
        private string _syle;

        private FramesDA _framesDA;

        /// <summary>
        /// Constructor
        /// </summary>
        public Frames()
        {
            _framesDA = new FramesDA();
            base.DataAccess = _framesDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["FrameID"];

            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["Title"];

            if (row["Price"] == DBNull.Value)
                Price = 0;
            else
                Price = Convert.ToInt32(row["Price"]);

            if (row["Color"] == DBNull.Value)
                Color = "";
            else
                Color = (string)row["Color"];

            if (row["Syle"] == DBNull.Value)
                Syle = "";
            else
                Syle = (string)row["Syle"];

            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }

        protected override void CheckIfSubClassStateIsValid()
        {

        }

        public override void Update()
        {
        }
        public override void Insert()
        {
        }
        public override void Delete()
        {
        }
        #endregion

        #region properties

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
            
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public string Syle
        {
            get { return _syle; }
            set { _syle = value; }
        }

        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public Frames Clone()
        {
            Frames frames = new Frames();
            frames.Id = Id;
            frames.Title = Title;
            frames.Price = Price;
            frames.Color = Color;
            frames.Syle = Syle;

            return frames;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for GlassCollection
    /// </summary>
    public class GlassCollection : AbstractBusinessCollection<Glass>    
    {
        private GlassDA _glassDA = new GlassDA();

        public GlassCollection() 
        {

        }

        #region properties

        #endregion

        #region methods

        /// <summary>
        /// Fetch the Glass data
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _glassDA.GetAllSorted(true);
            // population this collection from this data table
            populateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the glass with a given id. This should normally create a collection
        /// with either 0 or 1 glass
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _glassDA.GetById(id);
            populateFromDataTable(dt);
        }

        private void populateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Glass a = new Glass();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static FramesCollection GetAll()
        {
            FramesCollection list = new FramesCollection();

            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        public GlassCollection Clone()
        {
            GlassCollection clone = new GlassCollection();
            foreach (Glass a in this)
            {
                clone.Add(a.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}
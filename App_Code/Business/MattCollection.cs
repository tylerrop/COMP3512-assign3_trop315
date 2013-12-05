using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for MattCollection
    /// </summary>
    public class MattCollection : AbstractBusinessCollection<Matt>
    {
        
            private MattDA _mattDA = new MattDA();

            public MattCollection() 
            {

            }

            #region properties

            #endregion

            #region methods
            /// <summary>
            /// Fetch the matt data
            /// </summary>
            public void FetchAll()
            {
                DataTable dt = _mattDA.GetAllSorted(true);
                // population this collection from this data table
                populateFromDataTable(dt);
                _isNew = false;
            }

            /// <summary>
            /// Fetch all the matt with a given id. This should normally create a collection
            /// with either 0 or 1 matt
            /// </summary>
            public void FetchForId(int id)
            {
                DataTable dt = _mattDA.GetById(id);
                populateFromDataTable(dt);
            }


            private void populateFromDataTable(DataTable dt)
            {
                // population this collection from this data table
                foreach (DataRow row in dt.Rows)
                {
                    Matt a = new Matt();
                    a.PopulateDataMembersFromDataRow(row);
                    AddToCollection(a);
                }
            }

            /// <summary>
            /// Adapter method for ObjectDataSource
            /// </summary>
            /// <returns></returns>
            public static MattCollection GetAll()
            {
                MattCollection list = new MattCollection();

                return list;
            }

            /// <summary>
            /// Return a deep copy of this collection
            /// </summary>
            public MattCollection Clone()
            {
                MattCollection clone = new MattCollection();
                foreach (Matt a in this)
                {
                    clone.Add(a.Clone());
                }
                clone.IsModified = this.IsModified;
                return clone;
            }
            #endregion
    }
}
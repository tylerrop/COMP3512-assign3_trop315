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
    /// Summary description for SubjectsCollection
    /// </summary>
    public class SubjectsCollection : AbstractBusinessCollection<Subjects>
    {

        private SubjectsDA _subjectsDA = new SubjectsDA();

            public SubjectsCollection() 
            {

            }

            #region properties

            #endregion

            #region methods

            /// <summary>
            /// Fetch the Subjects data
            /// </summary>
            public void FetchAll()
            {
                DataTable dt = _subjectsDA.GetAllSorted(true);
                // population this collection from this data table
                populateFromDataTable(dt);
                _isNew = false;
            }

            /// <summary>
            /// Fetch all the subjects with a given id. This should normally create a collection
            /// with either 0 or 1 subjects. This way the single artist can be data binded to a data control.
            /// </summary>
            public void FetchForId(int id)
            {
                DataTable dt = _subjectsDA.GetById(id);
                populateFromDataTable(dt);
            }

            /// <summary>
            /// Fetch the subject of a specific artwork
            /// </summary>
            public void FetchForArtWork(int artWorkID)
            {
                DataTable dt = _subjectsDA.GetByArtWork(artWorkID);
                populateFromDataTable(dt);
            }

            /// <summary>
            /// Fetch all the unique subjects
            /// </summary>
            public void FetchGroupedSubjects()
            {
                DataTable dt = _subjectsDA.GetGroupedBySubjects();
                populateFromDataTable(dt);
            }
    

            private void populateFromDataTable(DataTable dt)
            {
                // population this collection from this data table
                foreach (DataRow row in dt.Rows)
                {
                    Subjects a = new Subjects();
                    a.PopulateDataMembersFromDataRow(row);
                    AddToCollection(a);
                }
            }

            /// <summary>
            /// Adapter method for ObjectDataSource
            /// </summary>
            /// <returns></returns>
            public static SubjectsCollection GetAll()
            {
                SubjectsCollection list = new SubjectsCollection();

                return list;
            }

            /// <summary>
            /// Return a deep copy of this collection
            /// </summary>
            public SubjectsCollection Clone()
            {
                SubjectsCollection clone = new SubjectsCollection();
                foreach (Subjects a in this)
                {
                    clone.Add(a.Clone());
                }
                clone.IsModified = this.IsModified;
                return clone;
            }
            #endregion
    }
}
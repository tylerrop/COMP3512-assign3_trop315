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
    /// Summary description for GenresCollection
    /// </summary>
    public class GenresCollection : AbstractBusinessCollection<Genres>
    {

            private GenresDA _genresDA = new GenresDA();

            public GenresCollection() 
            {

            }

            #region properties

            #endregion

            #region methods
            /// <summary>
            /// Fetch the Genres data
            /// </summary>
            public void FetchAll()
            {
                DataTable dt = _genresDA.GetAllSorted(true);
                // population this collection from this data table
                populateFromDataTable(dt);
                _isNew = false;
            }

            /// <summary>
            /// Fetch all the Genre with a given id. This should normally create a collection
            /// with either 0 or 1 Genre
            /// </summary>
            public void FetchForId(int id)
            {
                DataTable dt = _genresDA.GetById(id);
                populateFromDataTable(dt);
            }

            /// <summary>
            /// Fetch the Genre of a specific artwork
            /// </summary>
            public void FetchForArtWork(int artWorkID)
            {
                DataTable dt = _genresDA.GetByArtWork(artWorkID);
                populateFromDataTable(dt);
            }

            /// <summary>
            /// Fetch a list of unique genres
            /// </summary>
            public void FetchGroupedGenres()
            {
                DataTable dt = _genresDA.GetGroupedByGenres();
                populateFromDataTable(dt);
            }
    
            private void populateFromDataTable(DataTable dt)
            {
                // population this collection from this data table
                foreach (DataRow row in dt.Rows)
                {
                    Genres a = new Genres();
                    a.PopulateDataMembersFromDataRow(row);
                    AddToCollection(a);
                }
            }

            /// <summary>
            /// Adapter method for ObjectDataSource
            /// </summary>
            /// <returns></returns>
            public static GenresCollection GetAll()
            {
                GenresCollection list = new GenresCollection();

                return list;
            }

            /// <summary>
            /// Return a deep copy of this collection
            /// </summary>
            public GenresCollection Clone()
            {
                GenresCollection clone = new GenresCollection();
                foreach (Genres a in this)
                {
                    clone.Add(a.Clone());
                }
                clone.IsModified = this.IsModified;
                return clone;
            }
            #endregion
    }
}
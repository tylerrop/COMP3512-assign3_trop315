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
    /// Summary description for GalleryCollection
    /// </summary>
    public class GalleryCollection : AbstractBusinessCollection<Gallery>
    {

            private GalleriesDA _galleryDA = new GalleriesDA();

            public GalleryCollection() 
            {

            }

            #region properties

            #endregion

            #region methods

            /// <summary>
            /// Fetch the Gallery data
            /// </summary>
            public void FetchAll()
            {
                DataTable dt = _galleryDA.GetAllSorted(true);
                // population this collection from this data table
                populateFromDataTable(dt);
                _isNew = false;
            }
            /// <
            /// summary>
            /// Fetch all the Gallery with a given id. This should normally create a collection
            /// with either 0 or 1 Gallery
            /// </summary>
            public void FetchForId(int id)
            {
                DataTable dt = _galleryDA.GetById(id);
                populateFromDataTable(dt);
            }

            /// <summary>
            /// Fetch the gallery of a specific artist
            /// </summary>
            public void FetchForArtWork(int artWorkID)
            {
                DataTable dt = _galleryDA.GetByArtWork(artWorkID);
                populateFromDataTable(dt);
            }

            private void populateFromDataTable(DataTable dt)
            {
                // population this collection from this data table
                foreach (DataRow row in dt.Rows)
                {
                    Gallery a = new Gallery();
                    a.PopulateDataMembersFromDataRow(row);
                    AddToCollection(a);
                }
            }

            /// <summary>
            /// Adapter method for ObjectDataSource
            /// </summary>
            /// <returns></returns>
            public static GalleryCollection GetAll()
            {
                GalleryCollection list = new GalleryCollection();

                return list;
            }

            /// <summary>
            /// Return a deep copy of this collection
            /// </summary>
            public GalleryCollection Clone()
            {
                GalleryCollection clone = new GalleryCollection();
                foreach (Gallery a in this)
                {
                    clone.Add(a.Clone());
                }
                clone.IsModified = this.IsModified;
                return clone;
            }
            #endregion
    }
}
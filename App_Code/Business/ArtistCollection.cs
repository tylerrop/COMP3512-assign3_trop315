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
    /// Represents a collection of Artist objects.
    /// 
    /// Unlike the ArtWork collection, our collection of Artists is small enough that 
    /// we are going to keep the collection of all artists in cache memory since we 
    /// may likely access it so frequently
    /// </summary>
    public class ArtistCollection : AbstractBusinessCollection<Artist>
    {
        private const string CACHE_KEY_ALL = "AllArtists";
        private ArtistDA _artistDA = new ArtistDA();

        public ArtistCollection(bool preloadAll) 
        {
            if (preloadAll) FetchAll();
        }

        #region properties

        #endregion

        #region methods
        /// <summary>
        /// Fetch the Artist data
        /// </summary>
        public void FetchAll()
        {
            // first try to retrieve this from the cache
            DataTable dt = (DataTable)HttpContext.Current.Cache[CACHE_KEY_ALL];
            // if not in cache then get from database
            if (dt == null)
            {
                dt = _artistDA.GetAllSorted(true);
                // put this DataTable back in the cache
                HttpContext.Current.Cache[CACHE_KEY_ALL] = dt;
            }
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }
        /// <summary>
        /// Fetch all the artists with a given id. This should normally create a collection
        /// with either 0 or 1 artists. This way the single artist can be data binded to a data control.
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _artistDA.GetById(id);
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch the top X artists 
        /// </summary>
        public void FetchTop(int number)
        {
            DataTable dt = _artistDA.GetTop(number, true);
            PopulateFromDataTable(dt);
        }
        public void FetchMostSales(int num)
        {
            DataTable dt = _artistDA.GetTopSellers(num);
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the artists for a nationality
        /// </summary>
        public void FetchForNationality(string nationality)
        {
            // to do
        }
        /// <summary>
        /// Fetch the artists with the most art works
        /// </summary>
        public void FetchMostArtworks(int number)
        {
            // to do
        }
        public void FetchRelatedArtists(int artistID)
        {
            DataTable dt = _artistDA.GetRelated(artistID);
            PopulateFromDataTable(dt);
        }
        public void FetchLikeName(string artistName, string orderBy, string orderType)
        {
            DataTable dt = _artistDA.GetLikeName(artistName, orderBy, orderType);
            PopulateFromDataTable(dt);
        }
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Artist a = new Artist();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }


        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static ArtistCollection GetAll()
        {
            ArtistCollection list = new ArtistCollection(true);

            return list;
        }



        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        public ArtistCollection Clone()
        {
            ArtistCollection clone = new ArtistCollection(false);
            foreach (Artist a in this)
            {
                clone.Add(a.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}
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
    /// Represents a collection of ArtWork objects.
    /// 
    /// This collection is a bit unique in that we need to use it within an
    /// Artist (since each artist has its own artist collection) and use
    /// it byself, say for searches (in that case it contains all artworks)
    /// </summary>
    public class ArtWorkCollection : AbstractBusinessCollection<ArtWork>
    {
        private ArtWorkDA _artWorkDA = new ArtWorkDA();

        public ArtWorkCollection()
        {

        }

        #region properties

        #endregion

        #region methods

        /// <summary>
        /// Fetch all the Art work data
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _artWorkDA.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the art works with a given id. This should normally create a collection
        /// with either 0 or 1 art works. This way the single art work can be data binded to a data control.
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _artWorkDA.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch all the Art work for a given artist
        /// </summary>
        public void FetchForArtist(int artistId)
        {
            DataTable dt = _artWorkDA.GetByArtist(artistId);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the Artwork matching the work title. Parameters are taken to handle sorting
        /// </summary>
        public void FetchLikeTitle(string titleName, string orderBy, string orderType)
        {
            DataTable dt = _artWorkDA.GetLikeTitle(titleName, orderBy, orderType);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the Artwork matching advanced search parameters. Parameters are taken to handle sorting
        /// </summary>
        public void FetchLikeAdvanced(string title, int yearStart, int yearEnd, double costStart, double costEnd, string orderBy, string orderType)
        {
            DataTable dt = _artWorkDA.GetLikeAdvanced(title, yearStart, yearEnd, costStart, costEnd, orderBy, orderType);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the related artwork based on subject and genre information
        /// </summary>
        public void FetchRelated(int artWorkID)
        {
            DataTable dt = _artWorkDA.GetRelated(artWorkID);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the artworks that were purchased by a user that also bought this work
        /// </summary>
        public void FetchRelatedPurchases(int artWorkD, int num)
        {
            DataTable dt = _artWorkDA.GetRelatedPurchases(artWorkD, num);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the artworks of a specific genre
        /// </summary>
        public void FetchByGenre(int genreID, string orderBy, string orderType)
        {
            DataTable dt = _artWorkDA.GetByGenre(genreID, orderBy, orderType);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the artworks of a specific subject
        /// </summary>
        public void FetchBySubject(int subjectID, string orderBy, string orderType)
        {
            DataTable dt = _artWorkDA.GetBySubject(subjectID, orderBy, orderType);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch a select amount of artworks from the top of the table
        /// </summary>
        public void FetchTop(int number)
        {
            DataTable dt = _artWorkDA.GetTop(number, true);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch all the most frequently sold art works
        /// </summary>
        public void FetchMostSales(int num)
        {
            DataTable dt = _artWorkDA.GetTopSellers(num);
            PopulateFromDataTable(dt);
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                ArtWork a = new ArtWork();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static ArtWorkCollection GetAll()
        {
            ArtWorkCollection list = new ArtWorkCollection();
            list.FetchAll();

            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        public ArtWorkCollection Clone()
        {
            ArtWorkCollection clone = new ArtWorkCollection();
            foreach (ArtWork a in this)
            {
                clone.Add(a.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}
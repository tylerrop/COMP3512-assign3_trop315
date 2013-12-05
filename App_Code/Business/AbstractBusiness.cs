using System;
using System.Data;
using System.Collections.Generic;

using Content.DataAccess;

namespace Content.Business
{
   /// <summary>
   /// Repesents the base class for all business objects
   /// </summary>
   public abstract class AbstractBusiness
   {
      // data members
      #region data members
      protected const int DEFAULT_ID = 0;

      private int _id;
      private AbstractDA _dataAccess;

      // flags for whether object is new or has been modified
      private bool _isNew = true;
      private bool _isModified = false;
      private BusinessRuleManager _businessRules = new BusinessRuleManager();


      #endregion

      #region abstracts

      /// <summary>
      /// Given a data table with data, populate the business objects data members.
      /// 
      /// Implemented by each business object subclass
      /// </summary>
      /// <param name="table"></param>
      /// <returns></returns>
      public abstract void PopulateDataMembersFromDataRow(DataRow table);

      /// <summary>
      /// Each subclass will be responsible for checking if its
      /// own state (data members) has any broken business rules
      /// </summary>
      protected abstract void CheckIfSubClassStateIsValid();


      /// <summary>
      /// Update the content of the current business object
      /// </summary>
      public abstract void Update();

      /// <summary>
      /// Inserts the content of the current business object
      /// </summary>
      public abstract void Insert();

      /// <summary>
      /// Deletes the content of the current business object
      /// </summary>
      public abstract void Delete();
      #endregion

      #region public methods
      /// <summary>
      /// Saves the current business object
      /// </summary>
      public void Save()
      {
         if (IsValid)
         {
            if (IsModified)
            {
               if (IsNew)
                  Insert();
               else
                  Update();
            }
         }
      }
      /// <summary>
      /// Removes the current business object
      /// </summary>
      public void Remove()
      {
         Delete();
      }

      /// <summary>
      /// Fetches a business object's data
      /// </summary>
      public bool FetchById(int id)
      {
         DataTable table = DataAccess.GetById(id);

         // if the table has no data than load failed
         BusinessRules.Assert("FetchIdNotFound","Business Object with id=" + id + " was not found",table.Rows.Count == 0);
         if (! BusinessRules.AreNoBrokenRules)
            return false;

         PopulateDataMembersFromDataRow(table.Rows[0]);
         IsNew = false;
         IsModified = false;

         // make sure loaded data is valid according to business rules
         return IsValid;
      }
      #endregion

      #region protected properties
      /// <summary>
      /// The manager for the business rules for this object
      /// </summary>
      protected BusinessRuleManager BusinessRules
      {
         get { return _businessRules; }
      }

      /// <summary>
      /// The data access class used by this business object
      /// </summary>
      protected AbstractDA DataAccess
      {
         get { return _dataAccess; }
         set { _dataAccess = value; }
      }

      /// <summary>
      /// Has the business object been modified since last save
      /// </summary>
      protected bool IsModified
      {
         get { return _isModified; }
         set { _isModified = value; }
      }

      /// <summary>
      /// Is this business object new or does it contain 
      /// data that exists in database
      /// </summary>
      public bool IsNew
      {
         get { return _isNew; }
         set { _isNew = value; }
      }
      #endregion

      #region public properties

      /// <summary>
      /// The id of the business object
      /// </summary>
      public int Id
      {
         get { return _id; }
         set {
            if (_id != value)
            {
               _id = value;
               IsModified = true;
            }
         }
      }

      /// <summary>
      /// Is the business object valid
      /// </summary>
      public bool IsValid
      {
         get
         {
            BusinessRules.Assert("IdNotLessZero","Id can not be less than zero",Id < 0);
            CheckIfSubClassStateIsValid();
            return BusinessRules.AreNoBrokenRules;
         }
      }
      #endregion
   }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Web;

using System;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for CustomerCollection
    /// </summary>
    public class CustomerCollection : AbstractBusinessCollection<Customer>
    {
        private CustomerDA _customerDA = new CustomerDA();

        public CustomerCollection() 
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
            DataTable dt = _customerDA.GetAllSorted(true);
            // population this collection from this data table
            populateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the Customers with a given id. This should normally create a collection
        /// with either 0 or 1 matt
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _customerDA.GetById(id);
            populateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch a select amount of Customers from the top of the table
        /// </summary>
        public void FetchTop(int number)
        {
            DataTable dt = _customerDA.GetTop(number, true);
            populateFromDataTable(dt);
        }

        /// <summary>
        /// Add a Customer from the taken in parameters
        /// </summary>
        public void modifyCustomer(int customerID, string userName, string pass, int state, string firstName,
                                   string lastName, string address, string city, string region, string country,
                                   string postal, string phone, string email, int privacy)
        {
            _customerDA.modifyCustomers(customerID, firstName, lastName, address, city, region, country, postal, phone, email, privacy);
            _customerDA.modifyCustomerLogon(customerID, userName, pass, state);
        }

        /// <summary>
        /// Remove a Customer using the customerID
        /// </summary>
        public void removeCustomer(int customerID)
        {
            _customerDA.deleteCustomer(customerID);
        }

        private void populateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Customer a = new Customer();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static CustomerCollection GetAll()
        {
            CustomerCollection list = new CustomerCollection();

            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        public CustomerCollection Clone()
        {
            CustomerCollection clone = new CustomerCollection();
            foreach (Customer a in this)
            {
                clone.Add(a.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}
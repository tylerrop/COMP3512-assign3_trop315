using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for Customer
    /// </summary>
    public class Customer : AbstractBusiness
    {
        private int _customerID;
        private string _userName; 
        private string _pass;
        private int _state;
        private DateTime _dateJoined;
        private DateTime _dateLastModified;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _city;
        private string _region;
        private string _country;
        private string _postal;
        private string _phone;
        private string _email;
        private string _privacy;

        private CustomerDA _customerDA;

        /// <summary>
        /// Constructor
        /// </summary>
        public Customer()
        {
            _customerDA = new CustomerDA();
            base.DataAccess = _customerDA;
        }

        #region override methods
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            Id = (int)row["CustomerID"];

            if (row["UserName"] == DBNull.Value)
                UserName = "";
            else
                UserName = (string)row["UserName"];

            if (row["Pass"] == DBNull.Value)
                Pass = "";
            else
                Pass = (string)row["Pass"];

            if (row["State"] == DBNull.Value)
                State = 0;
            else
                State = Convert.ToInt32(row["State"]);

            if (row["DateJoined"] == DBNull.Value)
                DateJoined = new DateTime();
            else
                DateJoined = Convert.ToDateTime(row["DateJoined"]);

            if (row["DateLastModified"] == DBNull.Value)
                DateLastModified = new DateTime();
            else
                DateLastModified = Convert.ToDateTime(row["DateLastModified"]);

            if (row["FirstName"] == DBNull.Value)
                FirstName = "";
            else
                FirstName = (string)row["FirstName"];

            if (row["LastName"] == DBNull.Value)
                LastName = "";
            else
                LastName = (string)row["LastName"];

            if (row["Address"] == DBNull.Value)
                Address = "";
            else
                Address = (string)row["Address"];

            if (row["City"] == DBNull.Value)
                City = "";
            else
                City = (string)row["City"];

            if (row["Region"] == DBNull.Value)
                Region = "";
            else
                Region = (string)row["Region"];

            if (row["Country"] == DBNull.Value)
                Country = "";
            else
                Country = (string)row["Country"];

            if (row["Postal"] == DBNull.Value)
                Postal = "";
            else
                Postal = (string)row["Postal"];

            if (row["Phone"] == DBNull.Value)
                Phone = "";
            else
                Phone = (string)row["Phone"];

            if (row["Email"] == DBNull.Value)
                Email = "";
            else
                Email = (string)row["Email"];

            if (row["Privacy"] == DBNull.Value)
                Privacy = "";
            else
                Privacy = (string)row["Privacy"];

            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }

        protected override void CheckIfSubClassStateIsValid()
        {

        }

        // not going to bother implementing these
        public override void Update()
        {
            //_artistDA.Update(Id, FirstName, LastName, ...);
        }
        public override void Insert()
        {
            //Id = _artistDA.Insert(FirstName, LastName,, ...);
        }
        public override void Delete()
        {
            //_artistDA.Delete(Id);
        }
        #endregion

        #region properties

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }     
        }
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        public DateTime DateJoined
        {
            get { return _dateJoined; }
            set { _dateJoined = value; }
        }
        public DateTime DateLastModified
        {
            get { return _dateLastModified; }
            set { _dateLastModified = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Postal
        {
            get { return _postal; }
            set { _postal = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Privacy
        {
            get { return _privacy; }
            set { _privacy = value; }
        }


        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public Customer Clone()
        {
            Customer customer = new Customer();
            customer.Address = Address;
            customer.City = City;
            customer.Country = Country;
            customer.DateJoined = DateJoined;
            customer.DateLastModified = DateLastModified;
            customer.Email = Email;
            customer.FirstName = FirstName;
            customer.Id = Id;
            customer.LastName = LastName;
            customer.Pass = Pass;
            customer.Phone = Phone;
            customer.Postal = Postal;
            customer.Privacy = Privacy;
            customer.Region = Region;
            customer.State = State;
            customer.UserName = UserName;

            return customer;
        }

        #endregion
    }
}
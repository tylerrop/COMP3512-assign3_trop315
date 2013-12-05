using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for CustomerDA
    /// </summary>
    public class CustomerDA : AbstractDA
    {
        private const string fields = "CustomerLogon.CustomerID, "
                                            + "CustomerLogon.UserName, "
                                            + "CustomerLogon.Pass, "
                                            + "CustomerLogon.State, "
                                            + "CustomerLogon.DateJoined, "
                                            + "CustomerLogon.DateLastModified, "
                                            + "Customers.FirstName, "
                                            + "Customers.LastName, "
                                            + "Customers.Address, "
                                            + "Customers.City,"
                                            + "Customers.Region,"
                                            + "Customers.Country,"
                                            + "Customers.Postal,"
                                            + "Customers.Phone,"
                                            + "Customers.Email,"
                                            + "Customers.Privacy";

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM CustomerLogon";
                sql += " INNER JOIN Customers ON CustomerLogon.CustomerID = Customers.CustomerID";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "Customers.LastName";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "CustomerLogon.CustomerID";
            }
        }

        /// <summary>
        /// Modify athe customers table with the parameters
        /// </summary>
        public void modifyCustomerLogon(int customerID, string userName, string pass, int state)
        {
            DateTime dateLastModified = DateTime.Now;

            // set up insert statement
            string sql = "UPDATE CustomerLogon SET UserName=@userName, Pass=@pass, State=@state, DateLastModified=@dateLastModified "
                                          + "WHERE CustomerID=@customerID";

            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@userName", userName),
                DataHelper.MakeParameter("@pass", pass),
                DataHelper.MakeParameter("@state", state),
                DataHelper.MakeParameter("@dateLastModified", dateLastModified.Date, DbType.Date),
                DataHelper.MakeParameter("@customerID", customerID)
            };

            // Add to Table
            DataHelper.RunNonQuery(sql, parameters);
        }

        /// <summary>
        /// Modify athe customers table with the parameters
        /// </summary>
        public void modifyCustomers(int customerID, string firstName, string lastName, string address, string city, string region, 
                                    string country, string postal, string phone, string email, int privacy)
        {


            // set up insert statement
            string sql = "UPDATE Customers SET FirstName=@firstName, LastName=@lastName, Address=@address, City=@city, Region=@region, Country=@country, Postal=@postal, Phone=@phone, Email=@email, Privacy=@privacy "
                                          + "WHERE CustomerID=@customerID";


            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@firstName", firstName),
                DataHelper.MakeParameter("@lastName", lastName),
                DataHelper.MakeParameter("@address", address),
                DataHelper.MakeParameter("@city", city),
                DataHelper.MakeParameter("@region", region),
                DataHelper.MakeParameter("@country", country),
                DataHelper.MakeParameter("@postal", postal),
                DataHelper.MakeParameter("@phone", phone),
                DataHelper.MakeParameter("@email", email),
                DataHelper.MakeParameter("@privacy", privacy),
                DataHelper.MakeParameter("@customerID", customerID)
			};

            // Add to Table
            DataHelper.RunNonQuery(sql, parameters);
        }

        /// <summary>
        /// Removes a customer to the table using the Review ID
        /// </summary>
        public void deleteCustomer(int customerID)
        {

            // set up parameterized query statement
            string sql = "DELETE FROM CustomerLogon WHERE CustomerID=@customerID; ";
            sql += "DELETE FROM Customers WHERE CustomerID=@customerID;";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			    DataHelper.MakeParameter("@customerID", customerID)
			};

            // Add to Table
            DataHelper.RunNonQuery(sql, parameters);
        }

        /// <summary>
        /// Finds a unique ID in the database
        /// </summary>
        public int getUniqueCustomerID()
        {
            // Finds the max review ID
            string sql = "SELECT MAX(CustomerID) AS id FROM CustomerLogon";

            DataTable dt = DataHelper.GetDataTable(sql, null);

            // Returns the max ID plus 1
            return Convert.ToInt32(dt.Rows[0]["id"]) + 1;

        }
    }
}
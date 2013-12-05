using System;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Web.Configuration;

namespace Content.DataAccess
{
   /// <summary>
   /// Encapsulates common ADO.NET functionality
   /// </summary>
   public static class DataHelper
   {
       /// <summary>
       /// Create a provider-independent DbParameter object
       /// </summary>
       public static DbParameter MakeParameter(string name, object value)
       {
           DbParameter p = Factory.CreateParameter();
           p.ParameterName = name;
           p.Value = value;
           return p;
       }
      /// <summary>
      /// Create a provider-independent DbParameter object
      /// </summary>
      public static DbParameter MakeParameter(string name, object value, DbType paramType)
      {
         return MakeParameter(name,value,paramType,ParameterDirection.Input) ;
      }
      /// <summary>
      /// Create a provider-independent DbParameter object
      /// </summary>
      public static DbParameter MakeParameter(string name, object value, DbType paramType, ParameterDirection direction)
      {
         DbParameter param = Factory.CreateParameter();
         param.ParameterName = name;
         param.Value = value;
         param.DbType = paramType;
         param.Direction = direction;
         return param;
      }

      /// <summary>
      /// Returns a DataTable filled with data specified by sql and parameters
      /// </summary>
      public static DataTable GetDataTable(string sql, DbParameter[] parameters)
      {
         return GetDataTable(sql, CommandType.Text, parameters);
      }

      /// <summary>
      /// Returns a DataTable filled with data specified by name and parameters
      /// </summary>
      public static DataTable GetDataTable(string name, CommandType cmdType, DbParameter[] parameters)
      {
         DataTable dt = null;
         try
         {
            // create provider-independent connection
            DbConnection conn = Factory.CreateConnection();
            conn.ConnectionString = ConnectionSetting.ConnectionString;

            // create provider-independent data adapter
            DbDataAdapter adapter = Factory.CreateDataAdapter();

            DbCommand cmd = Factory.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = name;
            cmd.CommandType = cmdType;
            adapter.SelectCommand = cmd;

            // add parameters
            if (parameters != null)
            {
               foreach (DbParameter p in parameters)
                  adapter.SelectCommand.Parameters.Add(p);
            }

            // create data table
            dt = new DataTable();

            // fill a new data table with data from adapter
            adapter.Fill(dt);

         }
         catch (Exception ex)
         {
            // any errors will be handled by our custom exception handler
            DataAccessExceptionHandler.HandleException("DataHelper", "GetDataTable", ex.Message);
         }

         // Return the DataTable 
         return dt;
      }

      /// <summary>
      /// Runs a non-data returning SQL query
      /// </summary>
      public static void RunNonQuery(string sql, DbParameter[] parameters, CommandType cmdType)
      {
          RunNonQuery(sql, parameters, cmdType, false);
      }

      /// <summary>
      /// Runs a non-data returning SQL query
      /// </summary>
      public static int RunNonQuery(string sql, DbParameter[] parameters, CommandType cmdType, bool needNewlyGeneratedKey)
      {
          int result = 0;

         // create provider-independent connection
         using (DbConnection conn = Factory.CreateConnection())
         {
            conn.ConnectionString = ConnectionSetting.ConnectionString;

            // create provider-independent command
            DbCommand cmd = Factory.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = cmdType;

            // add parameters
            if (parameters != null)
            {
               foreach (DbParameter p in parameters)
                  cmd.Parameters.Add(p);
            }

            try
            {
               conn.Open();

               result = cmd.ExecuteNonQuery();

               if (needNewlyGeneratedKey)
               {
                   DbCommand cmd2 = Factory.CreateCommand();
                   cmd2.Connection = conn;
                   cmd2.CommandText = "SELECT @@IDENTITY";

                   result = Convert.ToInt32(cmd2.ExecuteScalar());
               }
            }
            catch (Exception ex)
            {
               // any errors will be handled by our custom exception handler
               DataAccessExceptionHandler.HandleException("DataHelper", "RunNonQuery", ex.Message);
            }
            finally
            {
               if (conn != null)
                  conn.Close();
            }
          return result;
         }
      }

      /// <summary>
      /// Runs a non-data returning SQL query
      /// </summary>
      public static void RunNonQuery(string sql, DbParameter[] parameters)
      {
         RunNonQuery(sql, parameters, CommandType.Text);
      }


      /// <summary>
      /// Runs a scalar returning SQL query
      /// </summary>
      public static object RunScalar(string sql, DbParameter[] parameters)
      {
         object scalar = null;

         // create provider-independent connection
         using (DbConnection conn = Factory.CreateConnection())
         {
            conn.ConnectionString = ConnectionSetting.ConnectionString;

            // create provider-independent command
            DbCommand cmd = Factory.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            // add parameters
            if (parameters != null)
            {
               foreach (DbParameter p in parameters)
                  cmd.Parameters.Add(p);
            }

            try
            {
               conn.Open();
               scalar = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
               // any errors will be handled by our custom exception handler
               DataAccessExceptionHandler.HandleException("DataHelper", "RunScalar", ex.Message);
            }
            finally
            {
               if (conn != null)
                  conn.Close();
            }
            return scalar;
         }
      }

      /// <summary>
      /// Private property that returns connection string setting from web.config
      /// </summary>
      private static ConnectionStringSettings ConnectionSetting
      {
         get
         {
             return WebConfigurationManager.ConnectionStrings["Art"];

         }
      }

      /// <summary>
      /// Private property to return appropriate DbProviderFactory
      /// </summary>
      private static DbProviderFactory Factory
      {
         get
         {
            string connString = ConnectionSetting.ConnectionString;
            string invariantName = ConnectionSetting.ProviderName;

            // verify that this provider name is supported
            DataTable providers = DbProviderFactories.GetFactoryClasses();
            DataRow[] foundArray = providers.Select("InvariantName='" + invariantName + "'");
            if (foundArray.Length == 0)
            {
               // any errors will be handled by our custom exception handler
               string msg = "Data Provider " + invariantName + " not found";
               DataAccessExceptionHandler.HandleException("DataHelper", "Factory", msg);
            }

            // get appropriate provider factory
            return DbProviderFactories.GetFactory(invariantName);
         }
      }
   }
}
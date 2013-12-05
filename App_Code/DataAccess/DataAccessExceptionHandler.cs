using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Content.DataAccess
{
   /// <summary>
   /// Summary description for DataAccessExceptionHandler
   /// </summary>
   public static class DataAccessExceptionHandler
   {
      public static void HandleException(string className, string methodName, string msg)
      {
         string message = className + ":" + methodName + " -- " + msg;
         throw new ApplicationException(message);
      }
   }
}

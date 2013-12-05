using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Content.Business
{
   /// <summary>
   /// Represents a single business rule
   /// </summary>
   public class SingleRule
   {
      private string _description;
      private string _name;

      public SingleRule(string name, string description)
      {
         _name = name;
         _description = description;
      }
      public string Description
      {
         get { return _description; }
         set { _description = value; }
      }
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

   }
}
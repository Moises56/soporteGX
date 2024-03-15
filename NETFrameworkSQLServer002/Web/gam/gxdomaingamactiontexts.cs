using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.gam {
   public class gxdomaingamactiontexts
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaingamactiontexts ()
      {
         domain["Edit"] = "Update";
         domain["Delete"] = "Delete";
         domain["Add"] = "Add";
         domain["Back"] = "Back";
         domain["Show filters"] = "Show Filters";
         domain["Hide filters"] = "Hide Filters";
         domain["Children"] = "Children";
         domain["Permission"] = "Permission";
         domain["Roles"] = "Roles";
         domain["Login"] = "Login";
         domain["Register"] = "Register";
         domain["Logout"] = "Logout";
         domain["Keys"] = "Keys";
         domain["File"] = "File";
         domain["Test"] = "Test";
         domain["Up"] = "Up";
         domain["Down"] = "Down";
         domain["Remove"] = "Remove";
         domain["Set as main"] = "Set As Main";
         domain["Main"] = "Main";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return context.GetMessage( value, "") ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Update"] = "Edit";
            domainMap["Delete"] = "Delete";
            domainMap["Add"] = "Add";
            domainMap["Back"] = "Back";
            domainMap["ShowFilters"] = "Show filters";
            domainMap["HideFilters"] = "Hide filters";
            domainMap["Children"] = "Children";
            domainMap["Permission"] = "Permission";
            domainMap["Roles"] = "Roles";
            domainMap["Login"] = "Login";
            domainMap["Register"] = "Register";
            domainMap["Logout"] = "Logout";
            domainMap["Keys"] = "Keys";
            domainMap["File"] = "File";
            domainMap["Test"] = "Test";
            domainMap["Up"] = "Up";
            domainMap["Down"] = "Down";
            domainMap["Remove"] = "Remove";
            domainMap["SetAsMain"] = "Set as main";
            domainMap["Main"] = "Main";
         }
         return (string)domainMap[key] ;
      }

   }

}

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
namespace GeneXus.Programs {
   public class gxdomaink2bsesitem
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bsesitem ()
      {
         domain["Context"] = "Context";
         domain["Stack"] = "Stack";
         domain["StackCaption"] = "StackCaption";
         domain["TrnContext"] = "TrnContext";
         domain["Messages"] = "Messages";
         domain["WorkFlowContext"] = "WorkFlowContext";
         domain["ComponentContext"] = "ComponentContext";
         domain["GXPortalMessage"] = "GXPortalMessage";
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
            domainMap["Context"] = "Context";
            domainMap["Stack"] = "Stack";
            domainMap["StackCaption"] = "StackCaption";
            domainMap["TrnContext"] = "TrnContext";
            domainMap["Messages"] = "Messages";
            domainMap["WorkFlowContext"] = "WorkFlowContext";
            domainMap["ComponentContext"] = "ComponentContext";
            domainMap["GXPortalMessage"] = "GXPortalMessage";
         }
         return (string)domainMap[key] ;
      }

   }

}

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
   public class gxdomaink2bpage
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bpage ()
      {
         domain[(short)20] = "Rows";
         domain[(short)1] = "FirstPage";
         domain[(short)0] = "NoPage";
         domain[(short)-1] = "NoMaxPage";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return ((context!=null) ? context.GetMessage( value, "") : value) ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Rows"] = (short)20;
            domainMap["FirstPage"] = (short)1;
            domainMap["NoPage"] = (short)0;
            domainMap["NoMaxPage"] = (short)-1;
         }
         return (short)domainMap[key] ;
      }

   }

}

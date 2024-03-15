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
   public class gxdomaink2baftertrnnavigation
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2baftertrnnavigation ()
      {
         domain[(short)1] = "Return To Caller";
         domain[(short)2] = "Entity Manager";
         domain[(short)3] = "Dynamic Link";
         domain[(short)4] = "Deprecated";
         domain[(short)5] = "None";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         string value;
         value = (string)(domain[key]==null?"":domain[key]);
         return value ;
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
            domainMap["ReturnToCaller"] = (short)1;
            domainMap["EntityManager"] = (short)2;
            domainMap["DynamicLink"] = (short)3;
            domainMap["EntityManger"] = (short)4;
            domainMap["None"] = (short)5;
         }
         return (short)domainMap[key] ;
      }

   }

}

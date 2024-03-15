using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtDolarAPI : GxUserType, IGxExternalObject
   {
      public SdtDolarAPI( )
      {
         /* Constructor for serialization */
      }

      public SdtDolarAPI( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public string getdollarrate( string gxTp_key )
      {
         string returngetdollarrate;
         returngetdollarrate = "";
         returngetdollarrate = (string)(libreria2Dolar.DolarAPI.GetDollarRate(gxTp_key));
         return returngetdollarrate ;
      }

      public Object ExternalInstance
      {
         get {
            if ( DolarAPI_externalReference == null )
            {
               DolarAPI_externalReference = new libreria2Dolar.DolarAPI();
            }
            return DolarAPI_externalReference ;
         }

         set {
            DolarAPI_externalReference = (libreria2Dolar.DolarAPI)(value);
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected libreria2Dolar.DolarAPI DolarAPI_externalReference=null ;
   }

}

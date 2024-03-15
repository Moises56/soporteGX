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
   public class SdtApiConsumer : GxUserType, IGxExternalObject
   {
      public SdtApiConsumer( )
      {
         /* Constructor for serialization */
      }

      public SdtApiConsumer( IGxContext context )
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
         returngetdollarrate = (string)(ApiConsumerLibrary.ApiConsumer.GetDollarRate(gxTp_key));
         return returngetdollarrate ;
      }

      public Object ExternalInstance
      {
         get {
            if ( ApiConsumer_externalReference == null )
            {
               ApiConsumer_externalReference = new ApiConsumerLibrary.ApiConsumer();
            }
            return ApiConsumer_externalReference ;
         }

         set {
            ApiConsumer_externalReference = (ApiConsumerLibrary.ApiConsumer)(value);
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected ApiConsumerLibrary.ApiConsumer ApiConsumer_externalReference=null ;
   }

}

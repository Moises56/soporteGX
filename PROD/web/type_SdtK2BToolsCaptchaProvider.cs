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
   public class SdtK2BToolsCaptchaProvider : GxUserType, IGxExternalObject
   {
      public SdtK2BToolsCaptchaProvider( )
      {
         /* Constructor for serialization */
      }

      public SdtK2BToolsCaptchaProvider( IGxContext context )
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

      public string generatestringtoken( int gxTp_amountOfCharacters )
      {
         string returngeneratestringtoken;
         if ( K2BToolsCaptchaProvider_externalReference == null )
         {
            K2BToolsCaptchaProvider_externalReference = new K2BTools.Captcha.K2BToolsCaptchaProvider();
         }
         returngeneratestringtoken = "";
         returngeneratestringtoken = (string)(K2BToolsCaptchaProvider_externalReference.GenerateStringToken(gxTp_amountOfCharacters));
         return returngeneratestringtoken ;
      }

      public string generateimage( int gxTp_width ,
                                   int gxTp_height ,
                                   string gxTp_captchaStr )
      {
         string returngenerateimage;
         if ( K2BToolsCaptchaProvider_externalReference == null )
         {
            K2BToolsCaptchaProvider_externalReference = new K2BTools.Captcha.K2BToolsCaptchaProvider();
         }
         returngenerateimage = "";
         returngenerateimage = (string)(K2BToolsCaptchaProvider_externalReference.GenerateImage(gxTp_width, gxTp_height, gxTp_captchaStr));
         return returngenerateimage ;
      }

      public Object ExternalInstance
      {
         get {
            if ( K2BToolsCaptchaProvider_externalReference == null )
            {
               K2BToolsCaptchaProvider_externalReference = new K2BTools.Captcha.K2BToolsCaptchaProvider();
            }
            return K2BToolsCaptchaProvider_externalReference ;
         }

         set {
            K2BToolsCaptchaProvider_externalReference = (K2BTools.Captcha.K2BToolsCaptchaProvider)(value);
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected K2BTools.Captcha.K2BToolsCaptchaProvider K2BToolsCaptchaProvider_externalReference=null ;
   }

}

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
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "GAMSDNotAuthorized_Level_DetailSdt" )]
   [XmlType(TypeName =  "GAMSDNotAuthorized_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtGAMSDNotAuthorized_Level_DetailSdt : GxUserType
   {
      public SdtGAMSDNotAuthorized_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Username = "";
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password = "";
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtGAMSDNotAuthorized_Level_DetailSdt( IGxContext context )
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

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("Username", gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Username, false, false);
         AddObjectProperty("Password", gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Username" )]
      [  XmlElement( ElementName = "Username"   )]
      public string gxTpr_Username
      {
         get {
            return gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Username ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Username = value;
            SetDirty("Username");
         }

      }

      [  SoapElement( ElementName = "Password" )]
      [  XmlElement( ElementName = "Password"   )]
      public string gxTpr_Password
      {
         get {
            return gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password = value;
            SetDirty("Password");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

      }

      public void initialize( )
      {
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Username = "";
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password = "";
         gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Password ;
      protected string gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Gxdynprop ;
      protected string gxTv_SdtGAMSDNotAuthorized_Level_DetailSdt_Username ;
   }

   [DataContract(Name = @"GAMSDNotAuthorized_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtGAMSDNotAuthorized_Level_DetailSdt>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtGAMSDNotAuthorized_Level_DetailSdt_RESTInterface( SdtGAMSDNotAuthorized_Level_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Username" , Order = 0 )]
      public string gxTpr_Username
      {
         get {
            return sdt.gxTpr_Username ;
         }

         set {
            sdt.gxTpr_Username = value;
         }

      }

      [DataMember( Name = "Password" , Order = 1 )]
      public string gxTpr_Password
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Password) ;
         }

         set {
            sdt.gxTpr_Password = value;
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 2 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtGAMSDNotAuthorized_Level_DetailSdt sdt
      {
         get {
            return (SdtGAMSDNotAuthorized_Level_DetailSdt)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtGAMSDNotAuthorized_Level_DetailSdt() ;
         }
      }

   }

}

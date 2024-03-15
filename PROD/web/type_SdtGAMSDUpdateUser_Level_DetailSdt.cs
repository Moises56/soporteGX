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
   [XmlRoot(ElementName = "GAMSDUpdateUser_Level_DetailSdt" )]
   [XmlType(TypeName =  "GAMSDUpdateUser_Level_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtGAMSDUpdateUser_Level_DetailSdt : GxUserType
   {
      public SdtGAMSDUpdateUser_Level_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Username = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Email = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Firstname = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Lastname = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Userguid = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Gxdynprop = "";
      }

      public SdtGAMSDUpdateUser_Level_DetailSdt( IGxContext context )
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
         AddObjectProperty("Username", gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Username, false, false);
         AddObjectProperty("Email", gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Email, false, false);
         AddObjectProperty("Firstname", gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Firstname, false, false);
         AddObjectProperty("Lastname", gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Lastname, false, false);
         AddObjectProperty("Userguid", gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Userguid, false, false);
         AddObjectProperty("Gxdynprop", gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Username" )]
      [  XmlElement( ElementName = "Username"   )]
      public string gxTpr_Username
      {
         get {
            return gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Username ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Username = value;
            SetDirty("Username");
         }

      }

      [  SoapElement( ElementName = "Email" )]
      [  XmlElement( ElementName = "Email"   )]
      public string gxTpr_Email
      {
         get {
            return gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Email ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Email = value;
            SetDirty("Email");
         }

      }

      [  SoapElement( ElementName = "Firstname" )]
      [  XmlElement( ElementName = "Firstname"   )]
      public string gxTpr_Firstname
      {
         get {
            return gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Firstname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Firstname = value;
            SetDirty("Firstname");
         }

      }

      [  SoapElement( ElementName = "Lastname" )]
      [  XmlElement( ElementName = "Lastname"   )]
      public string gxTpr_Lastname
      {
         get {
            return gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Lastname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Lastname = value;
            SetDirty("Lastname");
         }

      }

      [  SoapElement( ElementName = "Userguid" )]
      [  XmlElement( ElementName = "Userguid"   )]
      public string gxTpr_Userguid
      {
         get {
            return gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Userguid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Userguid = value;
            SetDirty("Userguid");
         }

      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

      }

      public void initialize( )
      {
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Username = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Email = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Firstname = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Lastname = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Userguid = "";
         gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Firstname ;
      protected string gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Lastname ;
      protected string gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Userguid ;
      protected string gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Gxdynprop ;
      protected string gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Username ;
      protected string gxTv_SdtGAMSDUpdateUser_Level_DetailSdt_Email ;
   }

   [DataContract(Name = @"GAMSDUpdateUser_Level_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtGAMSDUpdateUser_Level_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtGAMSDUpdateUser_Level_DetailSdt>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtGAMSDUpdateUser_Level_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtGAMSDUpdateUser_Level_DetailSdt_RESTInterface( SdtGAMSDUpdateUser_Level_DetailSdt psdt ) : base(psdt)
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

      [DataMember( Name = "Email" , Order = 1 )]
      public string gxTpr_Email
      {
         get {
            return sdt.gxTpr_Email ;
         }

         set {
            sdt.gxTpr_Email = value;
         }

      }

      [DataMember( Name = "Firstname" , Order = 2 )]
      public string gxTpr_Firstname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Firstname) ;
         }

         set {
            sdt.gxTpr_Firstname = value;
         }

      }

      [DataMember( Name = "Lastname" , Order = 3 )]
      public string gxTpr_Lastname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Lastname) ;
         }

         set {
            sdt.gxTpr_Lastname = value;
         }

      }

      [DataMember( Name = "Userguid" , Order = 4 )]
      public string gxTpr_Userguid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Userguid) ;
         }

         set {
            sdt.gxTpr_Userguid = value;
         }

      }

      [DataMember( Name = "Gxdynprop" , Order = 5 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtGAMSDUpdateUser_Level_DetailSdt sdt
      {
         get {
            return (SdtGAMSDUpdateUser_Level_DetailSdt)Sdt ;
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
            sdt = new SdtGAMSDUpdateUser_Level_DetailSdt() ;
         }
      }

   }

}

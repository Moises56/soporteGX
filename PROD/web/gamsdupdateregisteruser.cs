using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gamsdupdateregisteruser : GXProcedure
   {
      public gamsdupdateregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gamsdupdateregisteruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserGUID ,
                           string aP1_UserName ,
                           string aP2_Email ,
                           string aP3_FirstName ,
                           string aP4_LastName ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV19UserGUID = aP0_UserGUID;
         this.AV18UserName = aP1_UserName;
         this.AV10Email = aP2_Email;
         this.AV12FirstName = aP3_FirstName;
         this.AV14LastName = aP4_LastName;
         this.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP5_Messages=this.AV8Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( string aP0_UserGUID ,
                                                                             string aP1_UserName ,
                                                                             string aP2_Email ,
                                                                             string aP3_FirstName ,
                                                                             string aP4_LastName )
      {
         execute(aP0_UserGUID, aP1_UserName, aP2_Email, aP3_FirstName, aP4_LastName, out aP5_Messages);
         return AV8Messages ;
      }

      public void executeSubmit( string aP0_UserGUID ,
                                 string aP1_UserName ,
                                 string aP2_Email ,
                                 string aP3_FirstName ,
                                 string aP4_LastName ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         gamsdupdateregisteruser objgamsdupdateregisteruser;
         objgamsdupdateregisteruser = new gamsdupdateregisteruser();
         objgamsdupdateregisteruser.AV19UserGUID = aP0_UserGUID;
         objgamsdupdateregisteruser.AV18UserName = aP1_UserName;
         objgamsdupdateregisteruser.AV10Email = aP2_Email;
         objgamsdupdateregisteruser.AV12FirstName = aP3_FirstName;
         objgamsdupdateregisteruser.AV14LastName = aP4_LastName;
         objgamsdupdateregisteruser.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objgamsdupdateregisteruser.context.SetSubmitInitialConfig(context);
         objgamsdupdateregisteruser.initialize();
         Submit( executePrivateCatch,objgamsdupdateregisteruser);
         aP5_Messages=this.AV8Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gamsdupdateregisteruser)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         AV11Errors = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV11Errors.Count == 0 )
         {
            AV17User.gxTpr_Name = AV18UserName;
            AV17User.gxTpr_Email = AV10Email;
            AV17User.gxTpr_Firstname = AV12FirstName;
            AV17User.gxTpr_Lastname = AV14LastName;
            AV13isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).updateuserbykeytocompleteuserdata(AV17User, out  AV11Errors);
            if ( ! AV13isOK )
            {
               GXt_objcol_SdtMessages_Message1 = AV8Messages;
               new gamconverterrorstomessages(context ).execute(  AV11Errors, out  GXt_objcol_SdtMessages_Message1) ;
               AV8Messages = GXt_objcol_SdtMessages_Message1;
            }
         }
         else
         {
            GXt_objcol_SdtMessages_Message1 = AV8Messages;
            new gamconverterrorstomessages(context ).execute(  AV11Errors, out  GXt_objcol_SdtMessages_Message1) ;
            AV8Messages = GXt_objcol_SdtMessages_Message1;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV11Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         /* GeneXus formulas. */
      }

      private string AV19UserGUID ;
      private string AV12FirstName ;
      private string AV14LastName ;
      private bool AV13isOK ;
      private string AV18UserName ;
      private string AV10Email ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV11Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV17User ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.gamsdupdateregisteruser_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gamsdupdateregisteruser_services : GxRestService
   {
      [OperationContract(Name = "GAMSDUpdateRegisterUser" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( string UserGUID ,
                           string UserName ,
                           string Email ,
                           string FirstName ,
                           string LastName ,
                           out GxGenericCollection<GeneXus.Utils.SdtMessages_Message_RESTInterface> Messages )
      {
         Messages = new GxGenericCollection<GeneXus.Utils.SdtMessages_Message_RESTInterface>() ;
         try
         {
            if ( ! ProcessHeaders("gamsdupdateregisteruser") )
            {
               return  ;
            }
            gamsdupdateregisteruser worker = new gamsdupdateregisteruser(context);
            worker.IsMain = RunAsMain ;
            GXBaseCollection<GeneXus.Utils.SdtMessages_Message> gxrMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>();
            worker.execute(UserGUID,UserName,Email,FirstName,LastName,out gxrMessages );
            worker.cleanup( );
            Messages = new GxGenericCollection<GeneXus.Utils.SdtMessages_Message_RESTInterface>(gxrMessages) ;
         }
         catch ( Exception e )
         {
            WebException(e);
         }
         finally
         {
            Cleanup();
         }
      }

   }

}

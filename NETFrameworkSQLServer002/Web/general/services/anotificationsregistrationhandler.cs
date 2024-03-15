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
namespace GeneXus.Programs.general.services {
   public class anotificationsregistrationhandler : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "notificationsregistrationhandler_Services_Execute" ;
         }

      }

      public anotificationsregistrationhandler( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public anotificationsregistrationhandler( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_DeviceType ,
                           string aP1_DeviceId ,
                           string aP2_DeviceToken ,
                           string aP3_DeviceName )
      {
         this.AV11DeviceType = aP0_DeviceType;
         this.AV8DeviceId = aP1_DeviceId;
         this.AV10DeviceToken = aP2_DeviceToken;
         this.AV9DeviceName = aP3_DeviceName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_DeviceType ,
                                 string aP1_DeviceId ,
                                 string aP2_DeviceToken ,
                                 string aP3_DeviceName )
      {
         anotificationsregistrationhandler objanotificationsregistrationhandler;
         objanotificationsregistrationhandler = new anotificationsregistrationhandler();
         objanotificationsregistrationhandler.AV11DeviceType = aP0_DeviceType;
         objanotificationsregistrationhandler.AV8DeviceId = aP1_DeviceId;
         objanotificationsregistrationhandler.AV10DeviceToken = aP2_DeviceToken;
         objanotificationsregistrationhandler.AV9DeviceName = aP3_DeviceName;
         objanotificationsregistrationhandler.context.SetSubmitInitialConfig(context);
         objanotificationsregistrationhandler.initialize();
         Submit( executePrivateCatch,objanotificationsregistrationhandler);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((anotificationsregistrationhandler)stateInfo).executePrivate();
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
         context.StatusMessage( StringUtil.Trim( AV10DeviceToken) );
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
         /* GeneXus formulas. */
      }

      private short AV11DeviceType ;
      private string AV8DeviceId ;
      private string AV10DeviceToken ;
      private string AV9DeviceName ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.general.services.notificationsregistrationhandler_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class notificationsregistrationhandler_services : GxRestService
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      [OperationContract(Name = "NotificationsRegistrationHandler" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( short DeviceType ,
                           string DeviceId ,
                           string DeviceToken ,
                           string DeviceName )
      {
         try
         {
            permissionPrefix = "notificationsregistrationhandler_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("notificationsregistrationhandler") )
            {
               return  ;
            }
            anotificationsregistrationhandler worker = new anotificationsregistrationhandler(context);
            worker.IsMain = RunAsMain ;
            worker.execute(DeviceType,DeviceId,DeviceToken,DeviceName );
            worker.cleanup( );
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

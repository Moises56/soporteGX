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
   public class k2btoolsgetuseencryption : GXProcedure
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
            return "k2btoolsgetuseencryption_Services_Execute" ;
         }

      }

      public k2btoolsgetuseencryption( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2btoolsgetuseencryption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_encrypt )
      {
         this.AV9encrypt = "" ;
         initialize();
         executePrivate();
         aP0_encrypt=this.AV9encrypt;
      }

      public string executeUdp( )
      {
         execute(out aP0_encrypt);
         return AV9encrypt ;
      }

      public void executeSubmit( out string aP0_encrypt )
      {
         k2btoolsgetuseencryption objk2btoolsgetuseencryption;
         objk2btoolsgetuseencryption = new k2btoolsgetuseencryption();
         objk2btoolsgetuseencryption.AV9encrypt = "" ;
         objk2btoolsgetuseencryption.context.SetSubmitInitialConfig(context);
         objk2btoolsgetuseencryption.initialize();
         Submit( executePrivateCatch,objk2btoolsgetuseencryption);
         aP0_encrypt=this.AV9encrypt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2btoolsgetuseencryption)stateInfo).executePrivate();
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
         AV9encrypt = AV8ConfigurationManager.getvalue("USE_ENCRYPTION");
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
         AV9encrypt = "";
         AV8ConfigurationManager = new GeneXus.Core.genexus.common.configuration.SdtConfigurationManager(context);
         /* GeneXus formulas. */
      }

      private string AV9encrypt ;
      private GeneXus.Core.genexus.common.configuration.SdtConfigurationManager AV8ConfigurationManager ;
      private string aP0_encrypt ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.k2btoolsgetuseencryption_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class k2btoolsgetuseencryption_services : GxRestService
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

      [OperationContract(Name = "K2BToolsGetUseEncryption" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( out string encrypt )
      {
         encrypt = "" ;
         try
         {
            permissionPrefix = "k2btoolsgetuseencryption_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("k2btoolsgetuseencryption") )
            {
               return  ;
            }
            k2btoolsgetuseencryption worker = new k2btoolsgetuseencryption(context);
            worker.IsMain = RunAsMain ;
            worker.execute(out encrypt );
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

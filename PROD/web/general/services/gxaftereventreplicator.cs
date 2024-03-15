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
   public class gxaftereventreplicator : GXProcedure
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
            return "gxaftereventreplicator_Services_Execute" ;
         }

      }

      public gxaftereventreplicator( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gxaftereventreplicator( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> aP0_EventResults ,
                           GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo aP1_GxSynchroInfo )
      {
         this.AV8EventResults = aP0_EventResults;
         this.GxSynchroInfo = aP1_GxSynchroInfo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> aP0_EventResults ,
                                 GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo aP1_GxSynchroInfo )
      {
         gxaftereventreplicator objgxaftereventreplicator;
         objgxaftereventreplicator = new gxaftereventreplicator();
         objgxaftereventreplicator.AV8EventResults = aP0_EventResults;
         objgxaftereventreplicator.GxSynchroInfo = aP1_GxSynchroInfo;
         objgxaftereventreplicator.context.SetSubmitInitialConfig(context);
         objgxaftereventreplicator.initialize();
         Submit( executePrivateCatch,objgxaftereventreplicator);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gxaftereventreplicator)stateInfo).executePrivate();
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

      private GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> AV8EventResults ;
      private GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo GxSynchroInfo ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.general.services.gxaftereventreplicator_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gxaftereventreplicator_services : GxRestService
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

      [OperationContract(Name = "GxAfterEventReplicator" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( GxGenericCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem_RESTInterface> EventResults ,
                           GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo_RESTInterface GxSynchroInfo )
      {
         try
         {
            permissionPrefix = "gxaftereventreplicator_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("gxaftereventreplicator") )
            {
               return  ;
            }
            gxaftereventreplicator worker = new gxaftereventreplicator(context);
            worker.IsMain = RunAsMain ;
            GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> gxrEventResults = new GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem>();
            EventResults.LoadCollection(gxrEventResults);
            GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo gxrGxSynchroInfo = GxSynchroInfo.sdt;
            worker.execute(gxrEventResults,gxrGxSynchroInfo );
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

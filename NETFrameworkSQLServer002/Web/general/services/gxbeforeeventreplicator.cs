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
   public class gxbeforeeventreplicator : GXProcedure
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
            return "gxbeforeeventreplicator_Services_Execute" ;
         }

      }

      public gxbeforeeventreplicator( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public gxbeforeeventreplicator( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem> aP0_GxPendingEvents ,
                           GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo aP1_GxSyncroInfo ,
                           ref GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> aP2_EventResults )
      {
         this.GxPendingEvents = aP0_GxPendingEvents;
         this.GxSyncroInfo = aP1_GxSyncroInfo;
         this.AV8EventResults = aP2_EventResults;
         initialize();
         executePrivate();
         aP0_GxPendingEvents=this.GxPendingEvents;
         aP2_EventResults=this.AV8EventResults;
      }

      public GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> executeUdp( ref GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem> aP0_GxPendingEvents ,
                                                                                                                                                        GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo aP1_GxSyncroInfo )
      {
         execute(ref aP0_GxPendingEvents, aP1_GxSyncroInfo, ref aP2_EventResults);
         return AV8EventResults ;
      }

      public void executeSubmit( ref GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem> aP0_GxPendingEvents ,
                                 GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo aP1_GxSyncroInfo ,
                                 ref GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> aP2_EventResults )
      {
         gxbeforeeventreplicator objgxbeforeeventreplicator;
         objgxbeforeeventreplicator = new gxbeforeeventreplicator();
         objgxbeforeeventreplicator.GxPendingEvents = aP0_GxPendingEvents;
         objgxbeforeeventreplicator.GxSyncroInfo = aP1_GxSyncroInfo;
         objgxbeforeeventreplicator.AV8EventResults = aP2_EventResults;
         objgxbeforeeventreplicator.context.SetSubmitInitialConfig(context);
         objgxbeforeeventreplicator.initialize();
         Submit( executePrivateCatch,objgxbeforeeventreplicator);
         aP0_GxPendingEvents=this.GxPendingEvents;
         aP2_EventResults=this.AV8EventResults;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gxbeforeeventreplicator)stateInfo).executePrivate();
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

      private GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem> aP0_GxPendingEvents ;
      private GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> aP2_EventResults ;
      private GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> AV8EventResults ;
      private GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem> GxPendingEvents ;
      private GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo GxSyncroInfo ;
   }

   [ServiceContract(Namespace = "GeneXus.Programs.general.services.gxbeforeeventreplicator_services")]
   [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class gxbeforeeventreplicator_services : GxRestService
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

      [OperationContract(Name = "GxBeforeEventReplicator" )]
      [WebInvoke(Method =  "POST" ,
      	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
      	ResponseFormat = WebMessageFormat.Json,
      	UriTemplate = "/")]
      public void execute( ref GxGenericCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem_RESTInterface> GxPendingEvents ,
                           GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo_RESTInterface GxSyncroInfo ,
                           ref GxGenericCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem_RESTInterface> EventResults )
      {
         try
         {
            permissionPrefix = "gxbeforeeventreplicator_Services_Execute";
            if ( ! IsAuthenticated() )
            {
               return  ;
            }
            if ( ! ProcessHeaders("gxbeforeeventreplicator") )
            {
               return  ;
            }
            gxbeforeeventreplicator worker = new gxbeforeeventreplicator(context);
            worker.IsMain = RunAsMain ;
            GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem> gxrGxPendingEvents = new GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem>();
            GxPendingEvents.LoadCollection(gxrGxPendingEvents);
            GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationInfo gxrGxSyncroInfo = GxSyncroInfo.sdt;
            GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem> gxrEventResults = new GXBaseCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem>();
            EventResults.LoadCollection(gxrEventResults);
            worker.execute(ref gxrGxPendingEvents,gxrGxSyncroInfo,ref gxrEventResults );
            worker.cleanup( );
            GxPendingEvents = new GxGenericCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventList_SynchronizationEventListItem_RESTInterface>(gxrGxPendingEvents) ;
            EventResults = new GxGenericCollection<GeneXus.Core.genexus.sd.synchronization.SdtSynchronizationEventResultList_SynchronizationEventResultListItem_RESTInterface>(gxrEventResults) ;
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

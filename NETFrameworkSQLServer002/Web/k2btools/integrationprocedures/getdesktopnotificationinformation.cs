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
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2btools.integrationprocedures {
   public class getdesktopnotificationinformation : GXProcedure
   {
      public getdesktopnotificationinformation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public getdesktopnotificationinformation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_K2BT_NotificationId ,
                           out SdtDesktopNotificationInfoSDT aP1_DesktopNotificationInfoSDT ,
                           out bool aP2_Loaded )
      {
         this.AV9K2BT_NotificationId = aP0_K2BT_NotificationId;
         this.AV8DesktopNotificationInfoSDT = new SdtDesktopNotificationInfoSDT(context) ;
         this.AV10Loaded = false ;
         initialize();
         executePrivate();
         aP1_DesktopNotificationInfoSDT=this.AV8DesktopNotificationInfoSDT;
         aP2_Loaded=this.AV10Loaded;
      }

      public bool executeUdp( short aP0_K2BT_NotificationId ,
                              out SdtDesktopNotificationInfoSDT aP1_DesktopNotificationInfoSDT )
      {
         execute(aP0_K2BT_NotificationId, out aP1_DesktopNotificationInfoSDT, out aP2_Loaded);
         return AV10Loaded ;
      }

      public void executeSubmit( short aP0_K2BT_NotificationId ,
                                 out SdtDesktopNotificationInfoSDT aP1_DesktopNotificationInfoSDT ,
                                 out bool aP2_Loaded )
      {
         getdesktopnotificationinformation objgetdesktopnotificationinformation;
         objgetdesktopnotificationinformation = new getdesktopnotificationinformation();
         objgetdesktopnotificationinformation.AV9K2BT_NotificationId = aP0_K2BT_NotificationId;
         objgetdesktopnotificationinformation.AV8DesktopNotificationInfoSDT = new SdtDesktopNotificationInfoSDT(context) ;
         objgetdesktopnotificationinformation.AV10Loaded = false ;
         objgetdesktopnotificationinformation.context.SetSubmitInitialConfig(context);
         objgetdesktopnotificationinformation.initialize();
         Submit( executePrivateCatch,objgetdesktopnotificationinformation);
         aP1_DesktopNotificationInfoSDT=this.AV8DesktopNotificationInfoSDT;
         aP2_Loaded=this.AV10Loaded;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getdesktopnotificationinformation)stateInfo).executePrivate();
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
         AV8DesktopNotificationInfoSDT = new SdtDesktopNotificationInfoSDT(context);
         /* GeneXus formulas. */
      }

      private short AV9K2BT_NotificationId ;
      private bool AV10Loaded ;
      private SdtDesktopNotificationInfoSDT aP1_DesktopNotificationInfoSDT ;
      private bool aP2_Loaded ;
      private SdtDesktopNotificationInfoSDT AV8DesktopNotificationInfoSDT ;
   }

}

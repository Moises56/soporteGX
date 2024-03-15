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
   public class markwebnotificationasread : GXProcedure
   {
      public markwebnotificationasread( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public markwebnotificationasread( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_NotificationId ,
                           out bool aP1_Success ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         this.AV9NotificationId = aP0_NotificationId;
         this.AV10Success = false ;
         this.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP1_Success=this.AV10Success;
         aP2_Messages=this.AV8Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( short aP0_NotificationId ,
                                                                             out bool aP1_Success )
      {
         execute(aP0_NotificationId, out aP1_Success, out aP2_Messages);
         return AV8Messages ;
      }

      public void executeSubmit( short aP0_NotificationId ,
                                 out bool aP1_Success ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         markwebnotificationasread objmarkwebnotificationasread;
         objmarkwebnotificationasread = new markwebnotificationasread();
         objmarkwebnotificationasread.AV9NotificationId = aP0_NotificationId;
         objmarkwebnotificationasread.AV10Success = false ;
         objmarkwebnotificationasread.AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objmarkwebnotificationasread.context.SetSubmitInitialConfig(context);
         objmarkwebnotificationasread.initialize();
         Submit( executePrivateCatch,objmarkwebnotificationasread);
         aP1_Success=this.AV10Success;
         aP2_Messages=this.AV8Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((markwebnotificationasread)stateInfo).executePrivate();
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
         AV8Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         /* GeneXus formulas. */
      }

      private short AV9NotificationId ;
      private bool AV10Success ;
      private bool aP1_Success ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8Messages ;
   }

}

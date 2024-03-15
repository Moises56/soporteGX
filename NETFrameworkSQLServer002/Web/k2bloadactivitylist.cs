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
namespace GeneXus.Programs {
   public class k2bloadactivitylist : GXProcedure
   {
      public k2bloadactivitylist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bloadactivitylist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_ActivityList )
      {
         this.AV8ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test") ;
         initialize();
         executePrivate();
         aP0_ActivityList=this.AV8ActivityList;
      }

      public GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> executeUdp( )
      {
         execute(out aP0_ActivityList);
         return AV8ActivityList ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_ActivityList )
      {
         k2bloadactivitylist objk2bloadactivitylist;
         objk2bloadactivitylist = new k2bloadactivitylist();
         objk2bloadactivitylist.AV8ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test") ;
         objk2bloadactivitylist.context.SetSubmitInitialConfig(context);
         objk2bloadactivitylist.initialize();
         Submit( executePrivateCatch,objk2bloadactivitylist);
         aP0_ActivityList=this.AV8ActivityList;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bloadactivitylist)stateInfo).executePrivate();
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
         AV8ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "test");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_ActivityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV8ActivityList ;
   }

}

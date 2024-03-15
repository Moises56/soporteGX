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
   public class k2blistallstaticmenus : GXProcedure
   {
      public k2blistallstaticmenus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2blistallstaticmenus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem> aP0_MultiLevelMenuCollection )
      {
         this.AV9MultiLevelMenuCollection = new GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem>( context, "K2BMultiLevelMenuCollectionItem", "test") ;
         initialize();
         executePrivate();
         aP0_MultiLevelMenuCollection=this.AV9MultiLevelMenuCollection;
      }

      public GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem> executeUdp( )
      {
         execute(out aP0_MultiLevelMenuCollection);
         return AV9MultiLevelMenuCollection ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem> aP0_MultiLevelMenuCollection )
      {
         k2blistallstaticmenus objk2blistallstaticmenus;
         objk2blistallstaticmenus = new k2blistallstaticmenus();
         objk2blistallstaticmenus.AV9MultiLevelMenuCollection = new GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem>( context, "K2BMultiLevelMenuCollectionItem", "test") ;
         objk2blistallstaticmenus.context.SetSubmitInitialConfig(context);
         objk2blistallstaticmenus.initialize();
         Submit( executePrivateCatch,objk2blistallstaticmenus);
         aP0_MultiLevelMenuCollection=this.AV9MultiLevelMenuCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2blistallstaticmenus)stateInfo).executePrivate();
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
         AV9MultiLevelMenuCollection = new GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem>( context, "K2BMultiLevelMenuCollectionItem", "test");
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
         AV9MultiLevelMenuCollection = new GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem>( context, "K2BMultiLevelMenuCollectionItem", "test");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem> aP0_MultiLevelMenuCollection ;
      private GXBaseCollection<SdtK2BMultiLevelMenuCollection_K2BMultiLevelMenuCollectionItem> AV9MultiLevelMenuCollection ;
   }

}

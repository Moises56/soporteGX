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
   public class k2blistallmenusinitializations : GXProcedure
   {
      public k2blistallmenusinitializations( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2blistallmenusinitializations( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BPersistedMenuOutput> aP0_PersistedMenuOutputCollection )
      {
         this.AV9PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "test") ;
         initialize();
         executePrivate();
         aP0_PersistedMenuOutputCollection=this.AV9PersistedMenuOutputCollection;
      }

      public GXBaseCollection<SdtK2BPersistedMenuOutput> executeUdp( )
      {
         execute(out aP0_PersistedMenuOutputCollection);
         return AV9PersistedMenuOutputCollection ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BPersistedMenuOutput> aP0_PersistedMenuOutputCollection )
      {
         k2blistallmenusinitializations objk2blistallmenusinitializations;
         objk2blistallmenusinitializations = new k2blistallmenusinitializations();
         objk2blistallmenusinitializations.AV9PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "test") ;
         objk2blistallmenusinitializations.context.SetSubmitInitialConfig(context);
         objk2blistallmenusinitializations.initialize();
         Submit( executePrivateCatch,objk2blistallmenusinitializations);
         aP0_PersistedMenuOutputCollection=this.AV9PersistedMenuOutputCollection;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2blistallmenusinitializations)stateInfo).executePrivate();
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
         AV9PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "test");
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
         AV9PersistedMenuOutputCollection = new GXBaseCollection<SdtK2BPersistedMenuOutput>( context, "K2BPersistedMenuOutput", "test");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtK2BPersistedMenuOutput> aP0_PersistedMenuOutputCollection ;
      private GXBaseCollection<SdtK2BPersistedMenuOutput> AV9PersistedMenuOutputCollection ;
   }

}

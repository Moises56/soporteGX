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
   public class k2bremovetrncontextbyname : GXProcedure
   {
      public k2bremovetrncontextbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bremovetrncontextbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_TransactionName )
      {
         this.AV10TransactionName = aP0_TransactionName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_TransactionName )
      {
         k2bremovetrncontextbyname objk2bremovetrncontextbyname;
         objk2bremovetrncontextbyname = new k2bremovetrncontextbyname();
         objk2bremovetrncontextbyname.AV10TransactionName = aP0_TransactionName;
         objk2bremovetrncontextbyname.context.SetSubmitInitialConfig(context);
         objk2bremovetrncontextbyname.initialize();
         Submit( executePrivateCatch,objk2bremovetrncontextbyname);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bremovetrncontextbyname)stateInfo).executePrivate();
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
         new k2bsessionremove(context ).execute(  "TrnContext"+":"+AV10TransactionName) ;
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

      private string AV10TransactionName ;
   }

}

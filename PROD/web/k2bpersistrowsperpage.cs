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
   public class k2bpersistrowsperpage : GXProcedure
   {
      public k2bpersistrowsperpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bpersistrowsperpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           short aP2_RowsPerPage )
      {
         this.AV9ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV10RowsPerPage = aP2_RowsPerPage;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 short aP2_RowsPerPage )
      {
         k2bpersistrowsperpage objk2bpersistrowsperpage;
         objk2bpersistrowsperpage = new k2bpersistrowsperpage();
         objk2bpersistrowsperpage.AV9ProgramName = aP0_ProgramName;
         objk2bpersistrowsperpage.AV8GridName = aP1_GridName;
         objk2bpersistrowsperpage.AV10RowsPerPage = aP2_RowsPerPage;
         objk2bpersistrowsperpage.context.SetSubmitInitialConfig(context);
         objk2bpersistrowsperpage.initialize();
         Submit( executePrivateCatch,objk2bpersistrowsperpage);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bpersistrowsperpage)stateInfo).executePrivate();
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

      private short AV10RowsPerPage ;
      private string AV9ProgramName ;
      private string AV8GridName ;
   }

}

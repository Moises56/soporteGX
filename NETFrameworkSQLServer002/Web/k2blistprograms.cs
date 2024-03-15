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
   public class k2blistprograms : GXProcedure
   {
      public k2blistprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2blistprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "test") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV8ProgramNames;
      }

      public GXBaseCollection<SdtK2BProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV8ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames )
      {
         k2blistprograms objk2blistprograms;
         objk2blistprograms = new k2blistprograms();
         objk2blistprograms.AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "test") ;
         objk2blistprograms.context.SetSubmitInitialConfig(context);
         objk2blistprograms.initialize();
         Submit( executePrivateCatch,objk2blistprograms);
         aP0_ProgramNames=this.AV8ProgramNames;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2blistprograms)stateInfo).executePrivate();
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
         AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "test");
         /* GeneXus formulas. */
      }

      private GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> AV8ProgramNames ;
   }

}

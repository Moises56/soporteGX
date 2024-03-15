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
   public class k2bpersistgridconfiguration : GXProcedure
   {
      public k2bpersistgridconfiguration( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bpersistgridconfiguration( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ProgramName ,
                           string aP1_GridName ,
                           SdtK2BGridConfiguration aP2_GridConfiguration )
      {
         this.AV9ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV12GridConfiguration = aP2_GridConfiguration;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_ProgramName ,
                                 string aP1_GridName ,
                                 SdtK2BGridConfiguration aP2_GridConfiguration )
      {
         k2bpersistgridconfiguration objk2bpersistgridconfiguration;
         objk2bpersistgridconfiguration = new k2bpersistgridconfiguration();
         objk2bpersistgridconfiguration.AV9ProgramName = aP0_ProgramName;
         objk2bpersistgridconfiguration.AV8GridName = aP1_GridName;
         objk2bpersistgridconfiguration.AV12GridConfiguration = aP2_GridConfiguration;
         objk2bpersistgridconfiguration.context.SetSubmitInitialConfig(context);
         objk2bpersistgridconfiguration.initialize();
         Submit( executePrivateCatch,objk2bpersistgridconfiguration);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bpersistgridconfiguration)stateInfo).executePrivate();
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

      private string AV9ProgramName ;
      private string AV8GridName ;
      private SdtK2BGridConfiguration AV12GridConfiguration ;
   }

}

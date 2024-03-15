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
   public class k2bsetobjectcontainername : GXProcedure
   {
      public k2bsetobjectcontainername( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsetobjectcontainername( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_objectContainerName )
      {
         this.AV8objectContainerName = aP0_objectContainerName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_objectContainerName )
      {
         k2bsetobjectcontainername objk2bsetobjectcontainername;
         objk2bsetobjectcontainername = new k2bsetobjectcontainername();
         objk2bsetobjectcontainername.AV8objectContainerName = aP0_objectContainerName;
         objk2bsetobjectcontainername.context.SetSubmitInitialConfig(context);
         objk2bsetobjectcontainername.initialize();
         Submit( executePrivateCatch,objk2bsetobjectcontainername);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsetobjectcontainername)stateInfo).executePrivate();
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
         new k2bgetcomponentcontext(context ).execute( out  AV9ComponentContext) ;
         AV9ComponentContext.gxTpr_Objectcontainername = AV8objectContainerName;
         new k2bsetcomponentcontext(context ).execute(  AV9ComponentContext) ;
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
         AV9ComponentContext = new SdtK2BComponentContext(context);
         /* GeneXus formulas. */
      }

      private string AV8objectContainerName ;
      private SdtK2BComponentContext AV9ComponentContext ;
   }

}

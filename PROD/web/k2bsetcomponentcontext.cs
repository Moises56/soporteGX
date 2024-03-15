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
   public class k2bsetcomponentcontext : GXProcedure
   {
      public k2bsetcomponentcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsetcomponentcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtK2BComponentContext aP0_ComponentContext )
      {
         this.AV8ComponentContext = aP0_ComponentContext;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtK2BComponentContext aP0_ComponentContext )
      {
         k2bsetcomponentcontext objk2bsetcomponentcontext;
         objk2bsetcomponentcontext = new k2bsetcomponentcontext();
         objk2bsetcomponentcontext.AV8ComponentContext = aP0_ComponentContext;
         objk2bsetcomponentcontext.context.SetSubmitInitialConfig(context);
         objk2bsetcomponentcontext.initialize();
         Submit( executePrivateCatch,objk2bsetcomponentcontext);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsetcomponentcontext)stateInfo).executePrivate();
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
         AV9xml = AV8ComponentContext.ToXml(false, true, "", "");
         new k2bsessionset(context ).execute(  "ComponentContext",  AV9xml) ;
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
         AV9xml = "";
         /* GeneXus formulas. */
      }

      private string AV9xml ;
      private SdtK2BComponentContext AV8ComponentContext ;
   }

}

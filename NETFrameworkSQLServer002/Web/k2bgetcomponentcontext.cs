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
   public class k2bgetcomponentcontext : GXProcedure
   {
      public k2bgetcomponentcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetcomponentcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out SdtK2BComponentContext aP0_ComponentContext )
      {
         this.AV9ComponentContext = new SdtK2BComponentContext(context) ;
         initialize();
         executePrivate();
         aP0_ComponentContext=this.AV9ComponentContext;
      }

      public SdtK2BComponentContext executeUdp( )
      {
         execute(out aP0_ComponentContext);
         return AV9ComponentContext ;
      }

      public void executeSubmit( out SdtK2BComponentContext aP0_ComponentContext )
      {
         k2bgetcomponentcontext objk2bgetcomponentcontext;
         objk2bgetcomponentcontext = new k2bgetcomponentcontext();
         objk2bgetcomponentcontext.AV9ComponentContext = new SdtK2BComponentContext(context) ;
         objk2bgetcomponentcontext.context.SetSubmitInitialConfig(context);
         objk2bgetcomponentcontext.initialize();
         Submit( executePrivateCatch,objk2bgetcomponentcontext);
         aP0_ComponentContext=this.AV9ComponentContext;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetcomponentcontext)stateInfo).executePrivate();
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
         GXt_char1 = AV8xml;
         new k2bsessionget(context ).execute(  "ComponentContext", out  GXt_char1) ;
         AV8xml = GXt_char1;
         AV9ComponentContext.FromXml(AV8xml, null, "", "");
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
         AV8xml = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private string AV8xml ;
      private SdtK2BComponentContext aP0_ComponentContext ;
      private SdtK2BComponentContext AV9ComponentContext ;
   }

}

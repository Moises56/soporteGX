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
   public class k2bsetcontext : GXProcedure
   {
      public k2bsetcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bsetcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( SdtK2BContext aP0_Context )
      {
         this.AV8Context = aP0_Context;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtK2BContext aP0_Context )
      {
         k2bsetcontext objk2bsetcontext;
         objk2bsetcontext = new k2bsetcontext();
         objk2bsetcontext.AV8Context = aP0_Context;
         objk2bsetcontext.context.SetSubmitInitialConfig(context);
         objk2bsetcontext.initialize();
         Submit( executePrivateCatch,objk2bsetcontext);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsetcontext)stateInfo).executePrivate();
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
         AV10Data = AV8Context.ToXml(false, true, "", "");
         new k2bsessionset(context ).execute(  "Context",  AV10Data) ;
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
         AV10Data = "";
         /* GeneXus formulas. */
      }

      private string AV10Data ;
      private SdtK2BContext AV8Context ;
   }

}

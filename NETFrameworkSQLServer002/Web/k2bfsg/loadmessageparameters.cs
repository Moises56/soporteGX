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
namespace GeneXus.Programs.k2bfsg {
   public class loadmessageparameters : GXProcedure
   {
      public loadmessageparameters( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public loadmessageparameters( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref bool aP0_ShowDetailedMessages )
      {
         this.AV8ShowDetailedMessages = aP0_ShowDetailedMessages;
         initialize();
         executePrivate();
         aP0_ShowDetailedMessages=this.AV8ShowDetailedMessages;
      }

      public bool executeUdp( )
      {
         execute(ref aP0_ShowDetailedMessages);
         return AV8ShowDetailedMessages ;
      }

      public void executeSubmit( ref bool aP0_ShowDetailedMessages )
      {
         loadmessageparameters objloadmessageparameters;
         objloadmessageparameters = new loadmessageparameters();
         objloadmessageparameters.AV8ShowDetailedMessages = aP0_ShowDetailedMessages;
         objloadmessageparameters.context.SetSubmitInitialConfig(context);
         objloadmessageparameters.initialize();
         Submit( executePrivateCatch,objloadmessageparameters);
         aP0_ShowDetailedMessages=this.AV8ShowDetailedMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadmessageparameters)stateInfo).executePrivate();
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
         AV8ShowDetailedMessages = false;
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

      private bool AV8ShowDetailedMessages ;
      private bool aP0_ShowDetailedMessages ;
   }

}

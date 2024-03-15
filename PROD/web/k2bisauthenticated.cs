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
   public class k2bisauthenticated : GXProcedure
   {
      public k2bisauthenticated( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bisauthenticated( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out bool aP0_IsAuthenticated )
      {
         this.AV8IsAuthenticated = false ;
         initialize();
         executePrivate();
         aP0_IsAuthenticated=this.AV8IsAuthenticated;
      }

      public bool executeUdp( )
      {
         execute(out aP0_IsAuthenticated);
         return AV8IsAuthenticated ;
      }

      public void executeSubmit( out bool aP0_IsAuthenticated )
      {
         k2bisauthenticated objk2bisauthenticated;
         objk2bisauthenticated = new k2bisauthenticated();
         objk2bisauthenticated.AV8IsAuthenticated = false ;
         objk2bisauthenticated.context.SetSubmitInitialConfig(context);
         objk2bisauthenticated.initialize();
         Submit( executePrivateCatch,objk2bisauthenticated);
         aP0_IsAuthenticated=this.AV8IsAuthenticated;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bisauthenticated)stateInfo).executePrivate();
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
         if ( new GeneXus.Programs.genexussecurity.SdtGAMUser(context).isanonymous() )
         {
            AV8IsAuthenticated = false;
         }
         else
         {
            AV8IsAuthenticated = true;
         }
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

      private bool AV8IsAuthenticated ;
      private bool aP0_IsAuthenticated ;
   }

}

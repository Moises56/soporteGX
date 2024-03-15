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
namespace GeneXus.Programs.k2btools.integrationprocedures {
   public class registerclient : GXProcedure
   {
      public registerclient( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public registerclient( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref string aP0_UserCode )
      {
         this.AV8UserCode = aP0_UserCode;
         initialize();
         executePrivate();
         aP0_UserCode=this.AV8UserCode;
      }

      public string executeUdp( )
      {
         execute(ref aP0_UserCode);
         return AV8UserCode ;
      }

      public void executeSubmit( ref string aP0_UserCode )
      {
         registerclient objregisterclient;
         objregisterclient = new registerclient();
         objregisterclient.AV8UserCode = aP0_UserCode;
         objregisterclient.context.SetSubmitInitialConfig(context);
         objregisterclient.initialize();
         Submit( executePrivateCatch,objregisterclient);
         aP0_UserCode=this.AV8UserCode;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((registerclient)stateInfo).executePrivate();
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

      private string AV8UserCode ;
      private string aP0_UserCode ;
   }

}

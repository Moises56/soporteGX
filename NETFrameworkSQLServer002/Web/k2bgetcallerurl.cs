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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2bgetcallerurl : GXProcedure
   {
      public k2bgetcallerurl( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public k2bgetcallerurl( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out string aP0_Result )
      {
         this.AV8Result = "" ;
         initialize();
         executePrivate();
         aP0_Result=this.AV8Result;
      }

      public string executeUdp( )
      {
         execute(out aP0_Result);
         return AV8Result ;
      }

      public void executeSubmit( out string aP0_Result )
      {
         k2bgetcallerurl objk2bgetcallerurl;
         objk2bgetcallerurl = new k2bgetcallerurl();
         objk2bgetcallerurl.AV8Result = "" ;
         objk2bgetcallerurl.context.SetSubmitInitialConfig(context);
         objk2bgetcallerurl.initialize();
         Submit( executePrivateCatch,objk2bgetcallerurl);
         aP0_Result=this.AV8Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetcallerurl)stateInfo).executePrivate();
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
         AV8Result = AV9HttpRequest.ScriptName + "?" + AV9HttpRequest.QueryString;
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
         AV8Result = "";
         AV9HttpRequest = new GxHttpRequest( context);
         /* GeneXus formulas. */
      }

      private string AV8Result ;
      private string aP0_Result ;
      private GxHttpRequest AV9HttpRequest ;
   }

}
